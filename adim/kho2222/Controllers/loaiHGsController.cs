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
    public class loaiHGsController : Controller
    {
        private kho2Entities db = new kho2Entities();

        // GET: loaiHGs
        public ActionResult Index()
        {
            return View(db.loaiHGs.ToList());
        }

        // GET: loaiHGs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            loaiHG loaiHG = db.loaiHGs.Find(id);
            if (loaiHG == null)
            {
                return HttpNotFound();
            }
            return View(loaiHG);
        }

        // GET: loaiHGs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: loaiHGs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "maLH,tenLH")] loaiHG loaiHG)
        {
            if (ModelState.IsValid)
            {
                db.loaiHGs.Add(loaiHG);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(loaiHG);
        }

        // GET: loaiHGs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            loaiHG loaiHG = db.loaiHGs.Find(id);
            if (loaiHG == null)
            {
                return HttpNotFound();
            }
            return View(loaiHG);
        }

        // POST: loaiHGs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "maLH,tenLH")] loaiHG loaiHG)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loaiHG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loaiHG);
        }

        // GET: loaiHGs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            loaiHG loaiHG = db.loaiHGs.Find(id);
            if (loaiHG == null)
            {
                return HttpNotFound();
            }
            return View(loaiHG);
        }

        // POST: loaiHGs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            loaiHG loaiHG = db.loaiHGs.Find(id);
            db.loaiHGs.Remove(loaiHG);
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
