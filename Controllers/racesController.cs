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
    public class racesController : Controller
    {
        private moviesEntities db = new moviesEntities();

        // GET: races
        public ActionResult Index()
        {
            return View(db.races.ToList());
        }

        // GET: races/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            races races = db.races.Find(id);
            if (races == null)
            {
                return HttpNotFound();
            }
            return View(races);
        }

        // GET: races/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: races/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "race_id,race_name")] races races)
        {
            if (ModelState.IsValid)
            {
                db.races.Add(races);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(races);
        }

        // GET: races/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            races races = db.races.Find(id);
            if (races == null)
            {
                return HttpNotFound();
            }
            return View(races);
        }

        // POST: races/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "race_id,race_name")] races races)
        {
            if (ModelState.IsValid)
            {
                db.Entry(races).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(races);
        }

        // GET: races/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            races races = db.races.Find(id);
            if (races == null)
            {
                return HttpNotFound();
            }
            return View(races);
        }

        // POST: races/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            races races = db.races.Find(id);
            db.races.Remove(races);
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
