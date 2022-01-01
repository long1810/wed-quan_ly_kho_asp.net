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
    public class khsController : Controller
    {
        private kho2Entities db = new kho2Entities();

        // GET: khs
        public ActionResult Index()
        {
            return View(db.khs.ToList());
        }

        // GET: khs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            kh kh = db.khs.Find(id);
            if (kh == null)
            {
                return HttpNotFound();
            }
            return View(kh);
        }

        // GET: khs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: khs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "maKH,tenkh,dienthoai,diachi,anh")] kh kh)
        {
            if (ModelState.IsValid)
            {
                db.khs.Add(kh);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kh);
        }

        // GET: khs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            kh kh = db.khs.Find(id);
            if (kh == null)
            {
                return HttpNotFound();
            }
            return View(kh);
        }

        // POST: khs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "maKH,tenkh,dienthoai,diachi,anh")] kh kh)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kh).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kh);
        }

        // GET: khs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            kh kh = db.khs.Find(id);
            if (kh == null)
            {
                return HttpNotFound();
            }
            return View(kh);
        }

        // POST: khs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            kh kh = db.khs.Find(id);
            db.khs.Remove(kh);
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
