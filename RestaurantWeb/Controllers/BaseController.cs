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
    public class BaseController : Controller
    {
        protected RestaurantModelContainer db = new RestaurantModelContainer();

        private static String UserIdKey = "UserId";

        protected int idStorage;

        public BaseController()
        {
            ViewBag.User = setUser();
            ViewBag.UserName = setUser()?.Name;
            ViewBag.RoleKoch = setUser()?.RoleKoch;
            ViewBag.RoleUser = setUser()?.RoleUser;
        }

        public Kunde setUser()
        {
            if (Session == null) { return null; }
            int? userId = Session[UserIdKey] as int?;
            if (userId == null) return null;
            Kunde res = db.Kunden.Find(userId);
            if (res == null) return null;
            ViewBag.User = res;
            ViewBag.UserName = res.Name;
            ViewBag.RoleKoch = res.RoleKoch;
            ViewBag.RoleUser = res.RoleUser;
            _LoggedInUser = res;

            return res;
        }


        private Kunde _LoggedInUser = null;
        protected Kunde LoggedInUser => _LoggedInUser ?? setUser();

        protected bool hasUser()
        {
            return LoggedInUser != null;
        }

        protected void setUserId(int userId)
        {
            Session[UserIdKey] = userId;
        }
    }

}