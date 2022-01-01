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
    public class CTphieunhapsController : Controller
    {
        private kho2Entities db = new kho2Entities();

        // GET: CTphieunhaps
        public ActionResult Index(string mak)
        {
            var cTphieunhaps = db.CTphieunhaps.Include(c => c.hang).Include(c => c.kho).Include(c => c.phieunhap).Where(m=>m.mak.Equals(mak));
            return View(cTphieunhaps.ToList());
        }

        // GET: CTphieunhaps/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CTphieunhap cTphieunhap = db.CTphieunhaps.Find(id);
            if (cTphieunhap == null)
            {
                return HttpNotFound();
            }
            return View(cTphieunhap);
        }

        // GET: CTphieunhaps/Create
        public ActionResult Create()
        {
            ViewBag.maHG = new SelectList(db.hangs, "maHG", "tenHG");
            ViewBag.mak = new SelectList(db.khoes, "mak", "tenkho");
            ViewBag.maPN = new SelectList(db.phieunhaps, "maPN", "maPN");
            return View();
        }

        // POST: CTphieunhaps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,maPN,maHG,mak,namSX,soluong,gianhap,thanhtien")] CTphieunhap cTphieunhap)
        {
            if (ModelState.IsValid)
            {
                db.CTphieunhaps.Add(cTphieunhap);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.maHG = new SelectList(db.hangs, "maHG", "tenHG", cTphieunhap.maHG);
            ViewBag.mak = new SelectList(db.khoes, "mak", "tenkho", cTphieunhap.mak);
            ViewBag.maPN = new SelectList(db.phieunhaps, "maPN", "maPN", cTphieunhap.maPN);
            return View(cTphieunhap);
        }

        // GET: CTphieunhaps/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CTphieunhap cTphieunhap = db.CTphieunhaps.Find(id);
            if (cTphieunhap == null)
            {
                return HttpNotFound();
            }
            ViewBag.maHG = new SelectList(db.hangs, "maHG", "tenHG", cTphieunhap.maHG);
            ViewBag.mak = new SelectList(db.khoes, "mak", "tenkho", cTphieunhap.mak);
            ViewBag.maPN = new SelectList(db.phieunhaps, "maPN", "maPN", cTphieunhap.maPN);
            return View(cTphieunhap);
        }

        // POST: CTphieunhaps/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,maPN,maHG,mak,namSX,soluong,gianhap,thanhtien")] CTphieunhap cTphieunhap)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cTphieunhap).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.maHG = new SelectList(db.hangs, "maHG", "tenHG", cTphieunhap.maHG);
            ViewBag.mak = new SelectList(db.khoes, "mak", "tenkho", cTphieunhap.mak);
            ViewBag.maPN = new SelectList(db.phieunhaps, "maPN", "maPN", cTphieunhap.maPN);
            return View(cTphieunhap);
        }

        // GET: CTphieunhaps/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CTphieunhap cTphieunhap = db.CTphieunhaps.Find(id);
            if (cTphieunhap == null)
            {
                return HttpNotFound();
            }
            return View(cTphieunhap);
        }

        // POST: CTphieunhaps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CTphieunhap cTphieunhap = db.CTphieunhaps.Find(id);
            db.CTphieunhaps.Remove(cTphieunhap);
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
