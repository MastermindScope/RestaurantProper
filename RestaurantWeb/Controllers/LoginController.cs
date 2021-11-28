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
    public class LoginController : BaseController
    {

        // GET: Login
        public ActionResult Index()
        {
            return View(db.Kunden.ToList());
        }

        // GET: Login/Details/5
        public ActionResult Select(int? id)
        {
            if (id == null)
            {
                return new
                         HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kunde user = db.Kunden.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            setUserId(id.Value);
            return RedirectToAction("Index", "Home");
        }

    }
}
