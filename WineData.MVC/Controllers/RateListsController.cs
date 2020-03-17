using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WineData.MVC.Models;

namespace WineData.MVC.Controllers
{
    public class RateListsController : Controller
    {
        private WineDataEntities db = new WineDataEntities();

        // GET: RateLists
        public ActionResult Index()
        {
            return View(db.RateLists.ToList());
        }

        // GET: RateLists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RateList rateList = db.RateLists.Find(id);
            if (rateList == null)
            {
                return HttpNotFound();
            }
            return View(rateList);
        }

        // GET: RateLists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RateLists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Rate")] RateList rateList)
        {
            if (ModelState.IsValid)
            {
                db.RateLists.Add(rateList);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rateList);
        }

        // GET: RateLists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RateList rateList = db.RateLists.Find(id);
            if (rateList == null)
            {
                return HttpNotFound();
            }
            return View(rateList);
        }

        // POST: RateLists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Rate")] RateList rateList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rateList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rateList);
        }

        // GET: RateLists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RateList rateList = db.RateLists.Find(id);
            if (rateList == null)
            {
                return HttpNotFound();
            }
            return View(rateList);
        }

        // POST: RateLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RateList rateList = db.RateLists.Find(id);
            db.RateLists.Remove(rateList);
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
