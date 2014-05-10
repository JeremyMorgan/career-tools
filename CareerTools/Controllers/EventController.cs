using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CareerTools.Models;

namespace CareerTools.Controllers
{
    public class EventController : Controller
    {
        private careertoolsEntities db = new careertoolsEntities();

        // GET: /Event/
        [Authorize]
        public ActionResult Index()
        {
            var events = db.Events.Include(e => e.Contact).Include(e => e.ContactType).Include(e => e.Job).Include(e => e.Stage);
            return View(events.ToList());
        }

        // GET: /Event/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // GET: /Event/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.ContactFK = new SelectList(db.Contacts, "ContactID", "UserID");
            ViewBag.ContactFK = new SelectList(db.ContactTypes, "ContactTypeID", "ContactTypeName");
            ViewBag.JobFK = new SelectList(db.Jobs, "JobID", "UserID");
            ViewBag.StageFK = new SelectList(db.Stages, "StageID", "StageName");
            return View();
        }

        // POST: /Event/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include="EventID,UserID,ContactFK,JobFK,TypeFK,Date,StageFK,Notes")] Event @event)
        {
            if (ModelState.IsValid)
            {
                db.Events.Add(@event);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ContactFK = new SelectList(db.Contacts, "ContactID", "UserID", @event.ContactFK);
            ViewBag.ContactFK = new SelectList(db.ContactTypes, "ContactTypeID", "ContactTypeName", @event.ContactFK);
            ViewBag.JobFK = new SelectList(db.Jobs, "JobID", "UserID", @event.JobFK);
            ViewBag.StageFK = new SelectList(db.Stages, "StageID", "StageName", @event.StageFK);
            return View(@event);
        }

        // GET: /Event/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            ViewBag.ContactFK = new SelectList(db.Contacts, "ContactID", "UserID", @event.ContactFK);
            ViewBag.ContactFK = new SelectList(db.ContactTypes, "ContactTypeID", "ContactTypeName", @event.ContactFK);
            ViewBag.JobFK = new SelectList(db.Jobs, "JobID", "UserID", @event.JobFK);
            ViewBag.StageFK = new SelectList(db.Stages, "StageID", "StageName", @event.StageFK);
            return View(@event);
        }

        // POST: /Event/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit([Bind(Include="EventID,UserID,ContactFK,JobFK,TypeFK,Date,StageFK,Notes")] Event @event)
        {
            if (ModelState.IsValid)
            {
                db.Entry(@event).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ContactFK = new SelectList(db.Contacts, "ContactID", "UserID", @event.ContactFK);
            ViewBag.ContactFK = new SelectList(db.ContactTypes, "ContactTypeID", "ContactTypeName", @event.ContactFK);
            ViewBag.JobFK = new SelectList(db.Jobs, "JobID", "UserID", @event.JobFK);
            ViewBag.StageFK = new SelectList(db.Stages, "StageID", "StageName", @event.StageFK);
            return View(@event);
        }

        // GET: /Event/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // POST: /Event/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            Event @event = db.Events.Find(id);
            db.Events.Remove(@event);
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
