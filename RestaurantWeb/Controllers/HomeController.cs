using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestaurantWeb.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Wilkommen auf der Webseite der Gaststätte Götz";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Kontaktdaten.";

            return View();
        }
    }
}