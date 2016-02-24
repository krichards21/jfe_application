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
    public class SiteCallsController : Controller
    {
        private JFEEntities db = new JFEEntities();

        // GET: SiteCalls
        public ActionResult Index()
        {
            var siteCalls = db.SiteCalls.Include(s => s.SalesReps).Include(s => s.Classification).Include(s => s.Stores).Include(s => s.Brand).Include(s => s.Brand1);
            return View(siteCalls.ToList());
        }

        // GET: SiteCalls/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SiteCall siteCall = db.SiteCalls.Find(id);
            if (siteCall == null)
            {
                return HttpNotFound();
            }
            return View(siteCall);
        }

        // GET: SiteCalls/Create
        public ActionResult Create()
        {
            ViewBag.salesRepID = new SelectList(db.SalesReps, "Id", "name");
            ViewBag.classificationID = new SelectList(db.Classifications, "Id", "name");
            ViewBag.storeID = new SelectList(db.Stores, "Id", "storeid");
            ViewBag.displayBrands = new SelectList(db.Brands, "Id", "brand1");
            ViewBag.coldBrands = new SelectList(db.Brands, "Id", "brand1");
            return View();
        }

        // POST: SiteCalls/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,datetimeCall,classificationID,salesRepID,storeID,displayBrands,coldBrands,largestCases,coverage,display,currentCases,total750mlCold,schematicFacings,coldBox,pod,cbf,notes")] SiteCall siteCall)
        {
            if (ModelState.IsValid)
            {
                db.SiteCalls.Add(siteCall);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.salesRepID = new SelectList(db.SalesReps, "Id", "name", siteCall.salesRepID);
            ViewBag.classificationID = new SelectList(db.Classifications, "Id", "name", siteCall.classificationID);
            ViewBag.storeID = new SelectList(db.Stores, "Id", "storeid", siteCall.storeID);
            ViewBag.displayBrands = new SelectList(db.Brands, "Id", "brand1", siteCall.displayBrands);
            ViewBag.coldBrands = new SelectList(db.Brands, "Id", "brand1", siteCall.coldBrands);
            return View(siteCall);
        }

        // GET: SiteCalls/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SiteCall siteCall = db.SiteCalls.Find(id);
            if (siteCall == null)
            {
                return HttpNotFound();
            }
            ViewBag.salesRepID = new SelectList(db.SalesReps, "Id", "name", siteCall.salesRepID);
            ViewBag.classificationID = new SelectList(db.Classifications, "Id", "name", siteCall.classificationID);
            ViewBag.storeID = new SelectList(db.Stores, "Id", "storeid", siteCall.storeID);
            ViewBag.displayBrands = new SelectList(db.Brands, "Id", "brand1", siteCall.displayBrands);
            ViewBag.coldBrands = new SelectList(db.Brands, "Id", "brand1", siteCall.coldBrands);
            return View(siteCall);
        }

        // POST: SiteCalls/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,datetimeCall,classificationID,salesRepID,storeID,displayBrands,coldBrands,largestCases,coverage,display,currentCases,total750mlCold,schematicFacings,coldBox,pod,cbf,notes")] SiteCall siteCall)
        {
            if (ModelState.IsValid)
            {
                db.Entry(siteCall).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.salesRepID = new SelectList(db.SalesReps, "Id", "name", siteCall.salesRepID);
            ViewBag.classificationID = new SelectList(db.Classifications, "Id", "name", siteCall.classificationID);
            ViewBag.storeID = new SelectList(db.Stores, "Id", "storeid", siteCall.storeID);
            ViewBag.displayBrands = new SelectList(db.Brands, "Id", "brand1", siteCall.displayBrands);
            ViewBag.coldBrands = new SelectList(db.Brands, "Id", "brand1", siteCall.coldBrands);
            return View(siteCall);
        }

        // GET: SiteCalls/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SiteCall siteCall = db.SiteCalls.Find(id);
            if (siteCall == null)
            {
                return HttpNotFound();
            }
            return View(siteCall);
        }

        // POST: SiteCalls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SiteCall siteCall = db.SiteCalls.Find(id);
            db.SiteCalls.Remove(siteCall);
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
