using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using kho2222.Models;
namespace kho2222.Controllers
{
    public class ChonHangController : Controller
    {
        private kho2Entities db = new kho2Entities();
        // GET: ChonHang
        public ActionResult Index()
        {
            if (Session["giohang"] == null)
            {
                ViewBag.giohangcout = 0;
            }
            else
            {
                List<giohang> gh = (List<giohang>)Session["giohang"];
                ViewBag.giohangcount = gh.Count;


            }
            return View(db.hangs.ToList());
        }

        // GET: ChonHang/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        public ActionResult muahang(string id)
        {
            ViewBag.tong = 0;
            if (Session["giohang"] == null)
            {
                giohang a = new giohang();
                var sp = db.hangs.Where(s => s.maHG == id).Single();
                a.id = sp.maHG;
                a.name = sp.tenHG;
                a.sl = 1;
                a.price = (int)sp.gia;
                a.image = sp.anh;
                a.tongtien = a.sl * a.price;
                ViewBag.tong += a.tongtien;
                List<giohang> gh = new List<giohang>();
                gh.Add(a);

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
                    a.sl = 1;
                    a.price = (int)sp.gia;
                    a.image = sp.anh;
                    a.tongtien = a.sl * a.price;
                    ViewBag.tong += a.tongtien;
                    gh.Add(a);

                }
                else
                {
                    test.sl = test.sl + 1;
                }
                Session["giohang"] = gh;

            }
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

            }

            return RedirectToAction("Index");

        }
        public ActionResult them(string id)
        {

            List<giohang> gh = (List<giohang>)Session["giohang"];
            var test = gh.Find(s => s.id == id);

            if (test.sl >= 1)
            {
                test.sl = test.sl + 1;
                test.tongtien = test.sl * test.price;

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


        // GET: ChonHang/Details/5
       

        // GET: ChonHang/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ChonHang/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ChonHang/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ChonHang/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ChonHang/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ChonHang/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
