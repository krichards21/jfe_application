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
    public class BrandTypesController : Controller
    {
        private JFEEntities db = new JFEEntities();

        // GET: BrandTypes
        public ActionResult Index()
        {
            return View(db.BrandTypes.ToList());
        }

        // GET: BrandTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BrandType brandType = db.BrandTypes.Find(id);
            if (brandType == null)
            {
                return HttpNotFound();
            }
            return View(brandType);
        }

        // GET: BrandTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BrandTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,type")] BrandType brandType)
        {
            if (ModelState.IsValid)
            {
                db.BrandTypes.Add(brandType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(brandType);
        }

        // GET: BrandTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BrandType brandType = db.BrandTypes.Find(id);
            if (brandType == null)
            {
                return HttpNotFound();
            }
            return View(brandType);
        }

        // POST: BrandTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,type")] BrandType brandType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(brandType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(brandType);
        }

        // GET: BrandTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BrandType brandType = db.BrandTypes.Find(id);
            if (brandType == null)
            {
                return HttpNotFound();
            }
            return View(brandType);
        }

        // POST: BrandTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BrandType brandType = db.BrandTypes.Find(id);
            db.BrandTypes.Remove(brandType);
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
