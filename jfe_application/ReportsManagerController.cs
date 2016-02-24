using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace jfe_application
{
    public class ReportsManagerController : Controller
    {
        private JFEEntities db = new JFEEntities();

        // GET: SiteCalls
        public ActionResult Index()
        {
            //var siteCalls = db.SiteCalls.Include(s => s.SalesReps).Include(s => s.Classification).Include(s => s.Stores).Include(s => s.Brand).Include(s => s.Brand1);
            return View();
        }
    }
}