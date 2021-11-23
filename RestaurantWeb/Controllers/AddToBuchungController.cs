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
    public class AddToBuchungController : BaseController
    {
        private Buchung buchung;
        // GET: AddToBuchung
        public ActionResult Index(int id)
        {
            ViewBag.BuchungsId = id;
            buchung = db.Bestellungen.Find(id);
            if (buchung == null) { return HttpNotFound("could not find buchung with that id " + id); }
            return View(db.Gerichte.ToList());
        }


        public ActionResult AddToBuchung(int? id)
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

        public ActionResult Add(int id, int buchungsId)
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

            Buchung buchung = db.Bestellungen.Find(buchungsId);
            

            //buchung.AddGericht(gericht);
            db.Bestellungen.Find(buchung.Id).AddGericht(gericht);
            db.Bestellungen.Find(buchung.Id).EnthaeltGerichte.Add(gericht);
            db.SaveChanges();

            return RedirectToAction("Index", "Buchungs");
        }
    }
}
