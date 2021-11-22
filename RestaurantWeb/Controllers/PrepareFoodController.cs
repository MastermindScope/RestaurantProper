using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RestaurantLibDB;

namespace RestaurantWeb.Controllers
{
    public class PrepareFoodController : BaseController
    {

        // GET: PrepareFood
        public ActionResult Index()
        {
            DateTime now = DateTime.Now;

            TimeSpan viertelStunde = new TimeSpan(18000);//ticks in 15 minutes = 18000

            
            return View(db.Gerichte.Select(g => g.EnthaltenIn
                .Where(b => b.Essenszeit.Year == now.Year)
                .Where(b => b.Essenszeit.Day == now.Day)
                .Where(b => b.Essenszeit.Month == now.Month)
                .Where(b => (b.Essenszeit.Hour + b.Essenszeit.Minute / 60 - now.Hour - now.Minute / 60 - 0.25) < 0))
                .ToList()); //this had to be done this scuffed because linq does not want to process comparisons between datetimes
        }

        // GET: PrepareFood/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gericht gericht = db.Gerichte.Find(id);
            if (gericht == null)
            {
                return HttpNotFound();
            }
            return View(gericht);
        }

        // GET: PrepareFood/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PrepareFood/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Beschreibung,Preis")] Gericht gericht)
        {
            if (ModelState.IsValid)
            {
                db.Gerichte.Add(gericht);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gericht);
        }

        // GET: PrepareFood/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gericht gericht = db.Gerichte.Find(id);
            if (gericht == null)
            {
                return HttpNotFound();
            }
            return View(gericht);
        }

        // POST: PrepareFood/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Beschreibung,Preis")] Gericht gericht)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gericht).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gericht);
        }

        // GET: PrepareFood/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gericht gericht = db.Gerichte.Find(id);
            if (gericht == null)
            {
                return HttpNotFound();
            }
            return View(gericht);
        }

        // POST: PrepareFood/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Gericht gericht = db.Gerichte.Find(id);
            db.Gerichte.Remove(gericht);
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
