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
    public class AddToBuchungController : Controller
    {
        private RestaurantModelContainer db = new RestaurantModelContainer();

        // GET: AddToBuchung
        public ActionResult Index()
        {
            return View(db.Gerichte.ToList());
        }

        // GET: AddToBuchung/Details/5
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
