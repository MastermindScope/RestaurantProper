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
    public class SetupController : BaseController
    {
        // GET: Setup
        public ActionResult Import()
        {
            DemoData Dummy = new DemoData();

            foreach (var k in Dummy.Kunden)
            {
                db.Kunden.Add(k);
            }
            db.SaveChanges();
            foreach (var g in Dummy.Gerichte)
            {
                db.Gerichte.Add(g);
            }
            foreach (var f in Dummy.Filialen)
            {
                db.Filialen.Add(f);
            }
            foreach (var b in Dummy.Buchungen)
            {
                db.Bestellungen.Add(b);
            }
            db.SaveChanges();


            return RedirectToAction("Index", "Home");
        }

        public ActionResult ClearAll()
        {
            foreach (var bestellung in db.Bestellungen)
            {
                bestellung.EnthaeltGerichte.Clear();
            }

            db.SaveChanges();
            

            db.Bestellungen.RemoveRange(db.Bestellungen);
            db.SaveChanges();

            db.Kunden.RemoveRange(db.Kunden);
            db.SaveChanges();

            db.Filialen.RemoveRange(db.Filialen);
            db.SaveChanges();

            db.Gerichte.RemoveRange(db.Gerichte);
            db.SaveChanges();


            return RedirectToAction("Index", "Home");
        }

    }
}