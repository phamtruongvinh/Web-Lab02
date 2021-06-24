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
    public class TintucsController : Controller
    {
        private TintucEntities db = new TintucEntities();

        // GET: Tintucs
        public ActionResult Index()
        {
            var tintucs = db.Tintucs.Include(t => t.Theloaitin);
            return View(tintucs.ToList());
        }

        // GET: Tintucs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tintuc tintuc = db.Tintucs.Find(id);
            if (tintuc == null)
            {
                return HttpNotFound();
            }
            return View(tintuc);
        }

        // GET: Tintucs/Create
        public ActionResult Create()
        {
            ViewBag.IDLoai = new SelectList(db.Theloaitins, "IDLoai", "Tentheloai");
            return View();
        }

        // POST: Tintucs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdTin,IDLoai,Tieudetin,Noidungtin")] Tintuc tintuc)
        {
            if (ModelState.IsValid)
            {
                db.Tintucs.Add(tintuc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDLoai = new SelectList(db.Theloaitins, "IDLoai", "Tentheloai", tintuc.IDLoai);
            return View(tintuc);
        }

        // GET: Tintucs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tintuc tintuc = db.Tintucs.Find(id);
            if (tintuc == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDLoai = new SelectList(db.Theloaitins, "IDLoai", "Tentheloai", tintuc.IDLoai);
            return View(tintuc);
        }

        // POST: Tintucs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdTin,IDLoai,Tieudetin,Noidungtin")] Tintuc tintuc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tintuc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDLoai = new SelectList(db.Theloaitins, "IDLoai", "Tentheloai", tintuc.IDLoai);
            return View(tintuc);
        }

        // GET: Tintucs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tintuc tintuc = db.Tintucs.Find(id);
            if (tintuc == null)
            {
                return HttpNotFound();
            }
            return View(tintuc);
        }

        // POST: Tintucs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tintuc tintuc = db.Tintucs.Find(id);
            db.Tintucs.Remove(tintuc);
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
