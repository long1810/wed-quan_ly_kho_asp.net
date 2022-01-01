using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using kho2222.Models;

namespace kho2222.Controllers
{
    public class hangsController : Controller
    {
        private kho2Entities db = new kho2Entities();

        // GET: hangs
        public ActionResult Index(int? pape, string KeyWord, string filename = "", int asc = 1)
        {
            if (Session["tk"] == null)
            {
                Session["URL"] = "~/hangs/Index";
                return RedirectToAction("login", "Home");

            }
            //return View();
            List<hang> questions;
            // Tim kiem
            if (KeyWord != null && KeyWord != "")
            {
                //questions = db.hangs.Where(m => m.tenhg.Contains(KeyWord)).OrderBy(m => m.soluong).ToList();

                questions = db.hangs.Where(m => m.tenHG.Contains(KeyWord)).ToList();
            }
            else
            {
                questions = db.hangs.OrderBy(m => m.gia).ToList();

            }

            // Sap xep 
            if (filename == "sort")
            {
                if (asc == 1)
                {
                    questions = questions.OrderBy(m => m.gia).ToList();
                    ViewBag.filename = "sort";
                    ViewBag.asc = 1;
                }
                else
                {
                    questions = questions.OrderByDescending(m => m.gia).ToList();
                    ViewBag.filename = "sort";
                    ViewBag.asc = 0;
                }
            }
            // phan trang
            int pageSize = 3;
            int curpage = 1;
            if (pape != null) { curpage = pape.Value; }
            //int TotalRows = db.hangs.Include(q=>q.maNSX)Count();
            int TotalRows = db.hangs.Count();
            int numPapes = TotalRows / pageSize;
            if (TotalRows % pageSize != 0) { numPapes++; }
            ViewBag.NumPages = numPapes;
            ViewBag.CurrentPage = curpage;
            ViewBag.KeyWord = KeyWord;
            //questions = db.hangs.OrderBy(m => m.soluong).Skip((curpage - 1) * pageSize).Take(pageSize).ToList();

            return View(questions.Skip((curpage - 1) * pageSize).Take(pageSize).ToList());

        }

        // GET: hangs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            hang hang = db.hangs.Find(id);
            if (hang == null)
            {
                return HttpNotFound();
            }
            return View(hang);
        }

        // GET: hangs/Create
        public ActionResult Create()
        {
            ViewBag.maLH = new SelectList(db.loaiHGs, "maLH", "tenLH");
            ViewBag.maNSX = new SelectList(db.NSXes, "maNSX", "tenNSX");
            return View();
        }

        // POST: hangs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "maHG,tenHG,namSX,hanSD,maLH,maNSX,tinhtrang,mota,thetich,gia,anh,ngaynhapkho")] hang hang)
        {
            if (ModelState.IsValid)
            {
                db.hangs.Add(hang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.maLH = new SelectList(db.loaiHGs, "maLH", "tenLH", hang.maLH);
            ViewBag.maNSX = new SelectList(db.NSXes, "maNSX", "tenNSX", hang.maNSX);
            return View(hang);
        }

        // GET: hangs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            hang hang = db.hangs.Find(id);
            if (hang == null)
            {
                return HttpNotFound();
            }
            ViewBag.maLH = new SelectList(db.loaiHGs, "maLH", "tenLH", hang.maLH);
            ViewBag.maNSX = new SelectList(db.NSXes, "maNSX", "tenNSX", hang.maNSX);
            return View(hang);
        }

        // POST: hangs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "maHG,tenHG,namSX,hanSD,maLH,maNSX,tinhtrang,mota,thetich,gia,anh,ngaynhapkho")] hang hang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.maLH = new SelectList(db.loaiHGs, "maLH", "tenLH", hang.maLH);
            ViewBag.maNSX = new SelectList(db.NSXes, "maNSX", "tenNSX", hang.maNSX);
            return View(hang);
        }

        // GET: hangs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            hang hang = db.hangs.Find(id);
            if (hang == null)
            {
                return HttpNotFound();
            }
            return View(hang);
        }

        // POST: hangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            hang hang = db.hangs.Find(id);
            db.hangs.Remove(hang);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
