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
    public class khoesController : Controller
    {
        private kho2Entities db = new kho2Entities();

        // GET: khoes
        public ActionResult Index()
        {
            return View(db.khoes.ToList());
        }

        // GET: khoes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            kho kho = db.khoes.Find(id);
            if (kho == null)
            {
                return HttpNotFound();
            }
            return View(kho);
        }

        // GET: khoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: khoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "mak,tenkho,diachi,thetich,anh,thetichDD")] kho kho)
        {
            if (ModelState.IsValid)
            {
                db.khoes.Add(kho);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kho);
        }

        // GET: khoes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            kho kho = db.khoes.Find(id);
            if (kho == null)
            {
                return HttpNotFound();
            }
            return View(kho);
        }

        // POST: khoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "mak,tenkho,diachi,thetich,anh,thetichDD")] kho kho)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kho).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kho);
        }

        // GET: khoes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            kho kho = db.khoes.Find(id);
            if (kho == null)
            {
                return HttpNotFound();
            }
            return View(kho);
        }

        // POST: khoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            kho kho = db.khoes.Find(id);
            db.khoes.Remove(kho);
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
