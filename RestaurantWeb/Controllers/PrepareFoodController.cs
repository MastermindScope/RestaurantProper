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
            if(hasUser() && LoggedInUser.RoleKoch) {
                DateTime now = DateTime.Now;


                var liste = db.Bestellungen
                            .Where(b => b.Essenszeit.Year == now.Year &&
                            b.Essenszeit.Month == now.Month &&
                            b.Essenszeit.Day == now.Day &&
                            -b.Essenszeit.Hour * 60 - b.Essenszeit.Minute + now.Hour * 60 + now.Minute + 33 >= 0 &&
                            b.InFiliale.Id == LoggedInUser.KochtIn.Id)
                            .SelectMany(b => b.EnthaeltGerichte).ToList();





                return View(liste);
            }


            
            return RedirectToAction("Index", "Home");

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
