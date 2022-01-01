using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using kho2222.Models;
namespace kho2222.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        private kho2Entities db = new kho2Entities();
        private const string CartSession = "CartSession";
        // GET: Cart
        public ActionResult Index()
        {
            

            if (Session["giohang"] == null)
            {
                ViewBag.giohangcout = 0;
            }
            else
            {
                List<giohang> gh = (List<giohang>)Session["giohang"];
                var sl = 0;
                var tien = 0;
                foreach (giohang a in gh)
                {
                    tien += a.tongtien;
                    sl += a.sl;
                }

                ViewBag.giohangcount = gh.Count;
                ViewBag.tongtien = tien;
                ViewBag.sl = sl;

            }
            return View(db.hangs.ToList());
        }
        public ActionResult giohang(string id)
        {

            if (Session["giohang"] == null)
            {
                ViewBag.tong = 0;
                giohang a = new giohang();
                var sp = db.hangs.Where(s => s.maHG == id).Single();
                a.id = sp.maHG;
                a.name = sp.tenHG;
                a.image = sp.anh;
                a.sl = 1;
                a.price = (int)sp.gia;
                a.tongtien = a.sl * a.price;

                //ViewBag.tong += a.tongtien;
                List<giohang> gh = new List<giohang>();
                gh.Add(a);
                //ViewBag.tong1 += a.sl * a.price;
                Session["giohang"] = gh;
            }
            else
            {
                List<giohang> gh = (List<giohang>)Session["giohang"];
                var test = gh.Find(s => s.id == id);
                if (test == null)
                {
                    giohang a = new giohang();
                    var sp = db.hangs.Where(s => s.maHG == id).Single();
                    a.id = sp.maHG;
                    a.name = sp.tenHG;
                    a.image = sp.anh;
                    a.sl = 1;
                    a.price = (int)sp.gia;
                    a.tongtien = a.sl * a.price;
                    int t = a.tongtien;
                    //ViewBag.tong =  t;
                    gh.Add(a);
                    //ViewBag.tong1 += a.sl * a.price;

                }
                else
                {
                    test.sl++;
                }
                Session["giohang"] = gh;
            }
            return RedirectToAction("Index");
        }
        public ActionResult them(string id)
        {
            List<giohang> gh = (List<giohang>)Session["giohang"];
            var test = gh.Find(s => s.id == id);
            test.sl = test.sl + 1;
            test.tongtien = test.sl * test.price;
            //ViewBag.tong += test.tongtien;

            return RedirectToAction("Index");

        }
        public ActionResult tru(string id)
        {

            List<giohang> gh = (List<giohang>)Session["giohang"];
            var test = gh.Find(s => s.id == id);
            if (test.sl >= 1)
            {


                test.sl = test.sl - 1;
                test.tongtien = test.sl * test.price;

                //ViewBag.tong -= test.tongtien;

            }

            return RedirectToAction("Index");

        }
        public ActionResult bo(string id)
        {
            List<giohang> gh = (List<giohang>)Session["giohang"];
            var test = gh.Find(s => s.id == id);
            gh.Remove(test);

            return RedirectToAction("Index");
        }

        public ActionResult remove_All_Money()
        {
            List<giohang> gh = (List<giohang>)Session["giohang"];
            if (gh != null)
            {
                gh.Clear();

            }
            return RedirectToAction("Index", "ChonHang");

        }

        public JsonResult upsl(string ma)
        {
            if (ma != null)
            {
                List<giohang> gh = (List<giohang>)Session["giohang"];
                var test = gh.Find(s => s.id == ma);
                //var obj = db.hangs.Where(m => m.maHang.Equals(ma)).ToList();
                if (test != null && test.sl > 0)
                {
                    return Json("1", JsonRequestBehavior.AllowGet);

                }
            }
            return Json("0", JsonRequestBehavior.AllowGet);
        }

        public ActionResult updatesl(FormCollection form)
        {
            List<giohang> gh = (List<giohang>)Session["giohang"];
            string ma = form["ma"].ToString();
            int sl = int.Parse(form["sl"]);
            //if(sl < db.hangs.Where(m=> m.maHang.Equals(ma)).)
            var test = gh.Find(s => s.id == ma);
            if (sl >= 1)
            {


                test.sl = sl;
                test.tongtien = test.sl * test.price;
            }
            return RedirectToAction("Index");

        }


        public ActionResult shop_success()
        {
            return View();
        }
        public ActionResult checkout(FormCollection form)
        {
            try
            {
                List<giohang> gh = (List<giohang>)Session["giohang"];
                phieunhap pn = new phieunhap();
                //ctpm ctpn = new ctpm();
                pn.maPN = form["mapn"];
                pn.maNCC = form["mancc"];
                pn.ngaynhap = DateTime.Now;
                //string mak = form["mak"];
                //string mak = Session["mak"].ToString();
                string mak = "k1";


                //DateTime namSX = form["namsx"];
                pn.tiennhap = 0;
                db.phieunhaps.Add(pn);
                foreach (giohang item in gh)
                {
                    CTphieunhap ctpn = new CTphieunhap();
                    ctpn.maPN = pn.maPN;
                    ctpn.maHG = item.id;
                    ctpn.mak  = mak;
                    ctpn.soluong = item.sl;

                    var sp = db.hangs.Where(s => s.maHG == item.id).Single();
                    DateTime sx = sp.namSX;
                    ctpn.namSX = sx;
                    
                    //ctpn.giaNhap = item.price;
                    //ctpn.thanhtien = item.tongtien;
                    db.CTphieunhaps.Add(ctpn);
                }
                db.SaveChanges();
                gh.Clear();
                return RedirectToAction("shop_success");

            }
            catch
            {
                return Content("error  check out sai .... ");

            }
        }

        public ActionResult checkin(FormCollection form)
        {
            try
            {
                List<giohang> gh = (List<giohang>)Session["giohang"];
                hoadon pn = new hoadon();
                //ctpm ctpn = new ctpm();
                pn.maHD = form["mahd"];
                pn.maKH = form["makh"];
                pn.ngayban = DateTime.Now;
                //string mak = form["mak"];
                string mak = Session["mak"].ToString();

                //DateTime namSX = form["namsx"];
                if (Session["tk"] == null)
                {
                    Session["URL"] = "~/Cart/Index";
                    return RedirectToAction("login", "Home");

                }
                
                else
                {
                    string tk = Session["tk"].ToString();
                    pn.tk = tk;
                }
                pn.thanhtoan = 0;


                db.hoadons.Add(pn);
                foreach (giohang item in gh)
                {
                    CThoadon ctpn = new CThoadon();
                    ctpn.maHD = pn.maHD;
                    ctpn.maHG = item.id;
                    ctpn.mak = mak;
                    ctpn.soluong = item.sl;

                    var sp = db.hangs.Where(s => s.maHG == item.id).Single();
                    DateTime sx = sp.namSX;
                    ctpn.namSX = sx;

                    //ctpn.giaNhap = item.price;
                    //ctpn.thanhtien = item.tongtien;
                    db.CThoadons.Add(ctpn);
                }
                db.SaveChanges();
                gh.Clear();
                return RedirectToAction("shop_success");

            }
            catch
            {
                return Content("error  check out sai .... ");

            }
        }


    }
}