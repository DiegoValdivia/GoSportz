using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MoarSportz.Models;
using Microsoft.AspNet.Identity;

namespace MoarSportz.Controllers
{
    public class LoadEntriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: LoadEntries
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();

            var loadEntries = db.LoadEntries.Include(l => l.AspNetUser).Where(l => l.AspNetUserId == userId);
            return View(loadEntries?.ToList());
        }

        // GET: LoadEntries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoadEntry loadEntry = db.LoadEntries.Find(id);
            if (loadEntry == null)
            {
                return HttpNotFound();
            }
            return View(loadEntry);
        }

        // GET: LoadEntries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoadEntries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AspNetUserId,CreatedDate,Duration,Load,PerceivedExertionRating")] LoadEntry loadEntry)
        {
            loadEntry.AspNetUserId = User.Identity.GetUserId();

            if (ModelState.IsValid)
            {
                db.LoadEntries.Add(loadEntry);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AspNetUserId = new SelectList(db.Users, "Id", "Email", loadEntry.AspNetUserId);
            return View(loadEntry);
        }

        // GET: LoadEntries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoadEntry loadEntry = db.LoadEntries.Find(id);
            if (loadEntry == null)
            {
                return HttpNotFound();
            }
            ViewBag.AspNetUserId = new SelectList(db.Users, "Id", "Email", loadEntry.AspNetUserId);
            return View(loadEntry);
        }

        // POST: LoadEntries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AspNetUserId,CreatedDate,Duration,Load,PerceivedExertionRating")] LoadEntry loadEntry)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loadEntry).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AspNetUserId = new SelectList(db.Users, "Id", "Email", loadEntry.AspNetUserId);
            return View(loadEntry);
        }

        // GET: LoadEntries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoadEntry loadEntry = db.LoadEntries.Find(id);
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
            LoadEntry loadEntry = db.LoadEntries.Find(id);
            db.LoadEntries.Remove(loadEntry);
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
