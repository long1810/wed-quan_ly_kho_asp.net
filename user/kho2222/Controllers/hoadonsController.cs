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
    public class hoadonsController : Controller
    {
        private kho2Entities db = new kho2Entities();

        // GET: hoadons
        public ActionResult Index()
        {
            var hoadons = db.hoadons.Include(h => h.kh);
            return View(hoadons.ToList());
        }

        // GET: hoadons/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            hoadon hoadon = db.hoadons.Find(id);
            if (hoadon == null)
            {
                return HttpNotFound();
            }
            return View(hoadon);
        }

        // GET: hoadons/Create
        public ActionResult Create()
        {
            ViewBag.maKH = new SelectList(db.khs, "maKH", "tenkh");
            return View();
        }

        // POST: hoadons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "maHD,ngayban,tk,maKH,thanhtoan")] hoadon hoadon)
        {
            if (ModelState.IsValid)
            {
                db.hoadons.Add(hoadon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.maKH = new SelectList(db.khs, "maKH", "tenkh", hoadon.maKH);
            return View(hoadon);
        }

        // GET: hoadons/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            hoadon hoadon = db.hoadons.Find(id);
            if (hoadon == null)
            {
                return HttpNotFound();
            }
            ViewBag.maKH = new SelectList(db.khs, "maKH", "tenkh", hoadon.maKH);
            return View(hoadon);
        }

        // POST: hoadons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "maHD,ngayban,tk,maKH,thanhtoan")] hoadon hoadon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hoadon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.maKH = new SelectList(db.khs, "maKH", "tenkh", hoadon.maKH);
            return View(hoadon);
        }

        // GET: hoadons/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            hoadon hoadon = db.hoadons.Find(id);
            if (hoadon == null)
            {
                return HttpNotFound();
            }
            return View(hoadon);
        }

        // POST: hoadons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            hoadon hoadon = db.hoadons.Find(id);
            db.hoadons.Remove(hoadon);
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
