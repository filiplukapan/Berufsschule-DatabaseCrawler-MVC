using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using databaseCrawlerFinal.Models;

namespace databaseCrawlerFinal.Controllers
{
    public class tvsController : Controller
    {
        private moviesEntities db = new moviesEntities();

        // GET: tvs
        public ActionResult Index()
        {
            return View(db.tv.ToList());
        }

        // GET: tvs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tv tv = db.tv.Find(id);
            if (tv == null)
            {
                return HttpNotFound();
            }
            return View(tv);
        }

        // GET: tvs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tvs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "tv_id,tv_title,num_seasons")] tv tv)
        {
            if (ModelState.IsValid)
            {
                db.tv.Add(tv);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tv);
        }

        // GET: tvs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tv tv = db.tv.Find(id);
            if (tv == null)
            {
                return HttpNotFound();
            }
            return View(tv);
        }

        // POST: tvs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "tv_id,tv_title,num_seasons")] tv tv)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tv).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tv);
        }

        // GET: tvs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tv tv = db.tv.Find(id);
            if (tv == null)
            {
                return HttpNotFound();
            }
            return View(tv);
        }

        // POST: tvs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tv tv = db.tv.Find(id);
            db.tv.Remove(tv);
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
