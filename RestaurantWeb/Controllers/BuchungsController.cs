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
    public class BuchungsController : BaseController
    {

        // GET: Buchungs
        public ActionResult Index()
        {
            if (hasUser() == true)
            {
                if (LoggedInUser.RoleUser == true)
                {
                    var bestellungen = db.Bestellungen.Where(b => b.GebuchtVon.Id == LoggedInUser.Id).Include(b => b.GebuchtVon).Include(b => b.InFiliale).Include(b => b.Essenszeit);
                    return View(bestellungen.ToList());
                }
                else if (LoggedInUser.RoleKoch == true)
                {
                    var bestellungen = db.Bestellungen.Include(b => b.GebuchtVon).Include(b => b.InFiliale).Include(b => b.Essenszeit);
                    return View(bestellungen.ToList());
                }
            }
            return RedirectToAction("Index", "Home");

        }

        // GET: Buchungs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Buchung buchung = db.Bestellungen.Find(id);
            if (buchung == null)
            {
                return HttpNotFound();
            }
            return View(buchung);
        }

        // GET: Buchungs/Create
        public ActionResult Create()
        {
            ViewBag.KundeId = new SelectList(db.Kunden, "Id", "Name");
            ViewBag.FilialeId = new SelectList(db.Filialen, "Id", "Name");
            ViewBag.GerichteId = new SelectList(db.Gerichte, "Id", "Name");


            return View();
        }

        // POST: Buchungs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Buchungsnummmer,Personen,KundeId,Essenszeit,FilialeId")] Buchung buchung)
        {
            if (ModelState.IsValid)
            {
                db.Bestellungen.Add(buchung);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KundeId = new SelectList(db.Kunden, "Id", "Name", buchung.KundeId);
            ViewBag.FilialeId = new SelectList(db.Filialen, "Id", "Name", buchung.FilialeId);
            ViewBag.GerichteId = new SelectList(db.Gerichte, "Id", "Name");
            return View(buchung);
        }

        // GET: Buchungs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Buchung buchung = db.Bestellungen.Find(id);
            if (buchung == null)
            {
                return HttpNotFound();
            }
            ViewBag.KundeId = new SelectList(db.Kunden, "Id", "Name", buchung.KundeId);
            ViewBag.FilialeId = new SelectList(db.Filialen, "Id", "Name", buchung.FilialeId);
            ViewBag.Gerichte = new SelectList(db.Gerichte, "Id", "Name", buchung.EnthaeltGerichte);
            return View(buchung);
        }

        // POST: Buchungs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Buchungsnummmer,Personen,KundeId,Essenszeit,FilialeId")] Buchung buchung)
        {
            if (ModelState.IsValid)
            {
                db.Entry(buchung).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KundeId = new SelectList(db.Kunden, "Id", "Name", buchung.KundeId);
            ViewBag.FilialeId = new SelectList(db.Filialen, "Id", "Name", buchung.FilialeId);
            ViewBag.GerichteId = new SelectList(db.Gerichte, "Id", "Name", buchung.EnthaeltGerichte);
            return View(buchung);
        }

        // GET: Buchungs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Buchung buchung = db.Bestellungen.Find(id);
            if (buchung == null)
            {
                return HttpNotFound();
            }
            return View(buchung);
        }

        // POST: Buchungs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Buchung buchung = db.Bestellungen.Find(id);
            db.Bestellungen.Remove(buchung);
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
