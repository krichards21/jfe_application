using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace jfe_application.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Jackson Family Enterprises";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "For administrative help contact your manager.";

            return View();
        }
    }
}