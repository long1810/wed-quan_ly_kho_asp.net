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
    public class tksController : Controller
    {
        private kho2Entities db = new kho2Entities();

        // GET: tks
        public ActionResult Index()
        {
            var tks = db.tks.Include(t => t.kho);
            return View(tks.ToList());
        }

        // GET: tks/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tk tk = db.tks.Find(id);
            if (tk == null)
            {
                return HttpNotFound();
            }
            return View(tk);
        }

        // GET: tks/Create
        public ActionResult Create()
        {
            ViewBag.mak = new SelectList(db.khoes, "mak", "tenkho");
            return View();
        }

        // POST: tks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "tk1,mk,mak")] tk tk)
        {
            if (ModelState.IsValid)
            {
                db.tks.Add(tk);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.mak = new SelectList(db.khoes, "mak", "tenkho", tk.mak);
            return View(tk);
        }

        // GET: tks/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tk tk = db.tks.Find(id);
            if (tk == null)
            {
                return HttpNotFound();
            }
            ViewBag.mak = new SelectList(db.khoes, "mak", "tenkho", tk.mak);
            return View(tk);
        }

        // POST: tks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "tk1,mk,mak")] tk tk)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tk).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.mak = new SelectList(db.khoes, "mak", "tenkho", tk.mak);
            return View(tk);
        }

        // GET: tks/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tk tk = db.tks.Find(id);
            if (tk == null)
            {
                return HttpNotFound();
            }
            return View(tk);
        }

        // POST: tks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            tk tk = db.tks.Find(id);
            db.tks.Remove(tk);
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
