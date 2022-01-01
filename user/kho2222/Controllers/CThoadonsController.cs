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
    public class CThoadonsController : Controller
    {
        private kho2Entities db = new kho2Entities();

        // GET: CThoadons
        public ActionResult Index()
        {
            var cThoadons = db.CThoadons.Include(c => c.hang).Include(c => c.hoadon).Include(c => c.kho);
            return View(cThoadons.ToList());
        }

        // GET: CThoadons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CThoadon cThoadon = db.CThoadons.Find(id);
            if (cThoadon == null)
            {
                return HttpNotFound();
            }
            return View(cThoadon);
        }

        // GET: CThoadons/Create
        public ActionResult Create()
        {
            ViewBag.maHG = new SelectList(db.hangs, "maHG", "tenHG");
            ViewBag.maHD = new SelectList(db.hoadons, "maHD", "maHD");
            ViewBag.mak = new SelectList(db.khoes, "mak", "tenkho");
            return View();
        }

        // POST: CThoadons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,maHD,maHG,mak,namSX,soluong,giaban,thanhtien")] CThoadon cThoadon)
        {
            if (ModelState.IsValid)
            {
                db.CThoadons.Add(cThoadon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.maHG = new SelectList(db.hangs, "maHG", "tenHG", cThoadon.maHG);
            ViewBag.maHD = new SelectList(db.hoadons, "maHD", "maHD", cThoadon.maHD);
            ViewBag.mak = new SelectList(db.khoes, "mak", "tenkho", cThoadon.mak);
            return View(cThoadon);
        }

        // GET: CThoadons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CThoadon cThoadon = db.CThoadons.Find(id);
            if (cThoadon == null)
            {
                return HttpNotFound();
            }
            ViewBag.maHG = new SelectList(db.hangs, "maHG", "tenHG", cThoadon.maHG);
            ViewBag.maHD = new SelectList(db.hoadons, "maHD", "maHD", cThoadon.maHD);
            ViewBag.mak = new SelectList(db.khoes, "mak", "tenkho", cThoadon.mak);
            return View(cThoadon);
        }

        // POST: CThoadons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,maHD,maHG,mak,namSX,soluong,giaban,thanhtien")] CThoadon cThoadon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cThoadon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.maHG = new SelectList(db.hangs, "maHG", "tenHG", cThoadon.maHG);
            ViewBag.maHD = new SelectList(db.hoadons, "maHD", "maHD", cThoadon.maHD);
            ViewBag.mak = new SelectList(db.khoes, "mak", "tenkho", cThoadon.mak);
            return View(cThoadon);
        }

        // GET: CThoadons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CThoadon cThoadon = db.CThoadons.Find(id);
            if (cThoadon == null)
            {
                return HttpNotFound();
            }
            return View(cThoadon);
        }

        // POST: CThoadons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CThoadon cThoadon = db.CThoadons.Find(id);
            db.CThoadons.Remove(cThoadon);
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
