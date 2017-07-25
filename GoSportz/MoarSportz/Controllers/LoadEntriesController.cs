using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MoarSportz.Models;

namespace MoarSportz.Controllers
{
    public class LoadEntriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: LoadEntries
        public ActionResult Index()
        {
            var loadEntry = db.LoadEntry.Include(l => l.Athlete);
            return View(loadEntry.ToList());
        }

        // GET: LoadEntries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoadEntry loadEntry = db.LoadEntry.Find(id);
            if (loadEntry == null)
            {
                return HttpNotFound();
            }
            return View(loadEntry);
        }

        // GET: LoadEntries/Create
        public ActionResult Create()
        {
            ViewBag.AthleteId = new SelectList(db.Athletes, "AthleteId", "AspNetUser");
            return View();
        }

        // POST: LoadEntries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CreatedDate,Duration,Load,PerceivedExertionRating,AthleteId")] LoadEntry loadEntry)
        {
            if (ModelState.IsValid)
            {
                db.LoadEntry.Add(loadEntry);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AthleteId = new SelectList(db.Athletes, "AthleteId", "AspNetUser", loadEntry.AthleteId);
            return View(loadEntry);
        }

        // GET: LoadEntries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoadEntry loadEntry = db.LoadEntry.Find(id);
            if (loadEntry == null)
            {
                return HttpNotFound();
            }
            ViewBag.AthleteId = new SelectList(db.Athletes, "AthleteId", "AspNetUser", loadEntry.AthleteId);
            return View(loadEntry);
        }

        // POST: LoadEntries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CreatedDate,Duration,Load,PerceivedExertionRating,AthleteId")] LoadEntry loadEntry)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loadEntry).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AthleteId = new SelectList(db.Athletes, "AthleteId", "AspNetUser", loadEntry.AthleteId);
            return View(loadEntry);
        }

        // GET: LoadEntries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoadEntry loadEntry = db.LoadEntry.Find(id);
            if (loadEntry == null)
            {
                return HttpNotFound();
            }
            return View(loadEntry);
        }

        // POST: LoadEntries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LoadEntry loadEntry = db.LoadEntry.Find(id);
            db.LoadEntry.Remove(loadEntry);
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
