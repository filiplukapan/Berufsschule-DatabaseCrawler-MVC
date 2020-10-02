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
    public class peopleController : Controller
    {
        private moviesEntities db = new moviesEntities();

        // GET: people
        public ActionResult Index()
        {
            return View(db.people.ToList());
        }

        // GET: people/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            people people = db.people.Find(id);
            if (people == null)
            {
                return HttpNotFound();
            }
            return View(people);
        }

        // GET: people/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: people/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "person_id,first_name,last_name,account_type,dob,compress_pass,hash_pass,enc_pass")] people people)
        {
            if (ModelState.IsValid)
            {
                db.people.Add(people);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(people);
        }

        // GET: people/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            people people = db.people.Find(id);
            if (people == null)
            {
                return HttpNotFound();
            }
            return View(people);
        }

        // POST: people/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "person_id,first_name,last_name,account_type,dob,compress_pass,hash_pass,enc_pass")] people people)
        {
            if (ModelState.IsValid)
            {
                db.Entry(people).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(people);
        }

        // GET: people/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            people people = db.people.Find(id);
            if (people == null)
            {
                return HttpNotFound();
            }
            return View(people);
        }

        // POST: people/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            people people = db.people.Find(id);
            db.people.Remove(people);
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
