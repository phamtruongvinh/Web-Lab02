using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Lab02.Models;

namespace Lab02.Controllers
{
    public class TheloaitinsController : Controller
    {
        private TintucEntities db = new TintucEntities();

        // GET: Theloaitins
        public ActionResult Index()
        {
            return View(db.Theloaitins.ToList());
        }

        // GET: Theloaitins/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Theloaitin theloaitin = db.Theloaitins.Find(id);
            if (theloaitin == null)
            {
                return HttpNotFound();
            }
            return View(theloaitin);
        }

        // GET: Theloaitins/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Theloaitins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDLoai,Tentheloai")] Theloaitin theloaitin)
        {
            if (ModelState.IsValid)
            {
                db.Theloaitins.Add(theloaitin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(theloaitin);
        }

        // GET: Theloaitins/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Theloaitin theloaitin = db.Theloaitins.Find(id);
            if (theloaitin == null)
            {
                return HttpNotFound();
            }
            return View(theloaitin);
        }

        // POST: Theloaitins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDLoai,Tentheloai")] Theloaitin theloaitin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(theloaitin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(theloaitin);
        }

        // GET: Theloaitins/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Theloaitin theloaitin = db.Theloaitins.Find(id);
            if (theloaitin == null)
            {
                return HttpNotFound();
            }
            return View(theloaitin);
        }

        // POST: Theloaitins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Theloaitin theloaitin = db.Theloaitins.Find(id);
            db.Theloaitins.Remove(theloaitin);
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
