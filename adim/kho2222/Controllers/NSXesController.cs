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
    public class NSXesController : Controller
    {
        private kho2Entities db = new kho2Entities();

        // GET: NSXes
        public ActionResult Index()
        {
            return View(db.NSXes.ToList());
        }

        // GET: NSXes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NSX nSX = db.NSXes.Find(id);
            if (nSX == null)
            {
                return HttpNotFound();
            }
            return View(nSX);
        }

        // GET: NSXes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NSXes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "maNSX,tenNSX,dienthoai,diachi")] NSX nSX)
        {
            if (ModelState.IsValid)
            {
                db.NSXes.Add(nSX);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nSX);
        }

        // GET: NSXes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NSX nSX = db.NSXes.Find(id);
            if (nSX == null)
            {
                return HttpNotFound();
            }
            return View(nSX);
        }

        // POST: NSXes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "maNSX,tenNSX,dienthoai,diachi")] NSX nSX)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nSX).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nSX);
        }

        // GET: NSXes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NSX nSX = db.NSXes.Find(id);
            if (nSX == null)
            {
                return HttpNotFound();
            }
            return View(nSX);
        }

        // POST: NSXes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            NSX nSX = db.NSXes.Find(id);
            db.NSXes.Remove(nSX);
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
