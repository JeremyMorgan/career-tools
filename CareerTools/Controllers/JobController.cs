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
    public class JobController : Controller
    {
        private careertoolsEntities db = new careertoolsEntities();

        // GET: /Job/
        [Authorize]
        public ActionResult Index()
        {
            var jobs = db.Jobs.Include(j => j.Company1).Include(j => j.Refer).Include(j => j.Term);
            return View(jobs.ToList());
        }

        // GET: /Job/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = db.Jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        // GET: /Job/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.Company = new SelectList(db.Companies, "CompanyID", "UserID");
            ViewBag.ReferType = new SelectList(db.Refers, "ReferID", "UserID");
            ViewBag.TermFK = new SelectList(db.Terms, "TermId", "TermName");
            return View();
        }

        // POST: /Job/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include="JobID,UserID,JobTitle,Company,ReferType,Priority,TermFK")] Job job)
        {
            if (ModelState.IsValid)
            {
                db.Jobs.Add(job);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Company = new SelectList(db.Companies, "CompanyID", "UserID", job.Company);
            ViewBag.ReferType = new SelectList(db.Refers, "ReferID", "UserID", job.ReferType);
            ViewBag.TermFK = new SelectList(db.Terms, "TermId", "TermName", job.TermFK);
            return View(job);
        }

        // GET: /Job/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = db.Jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            ViewBag.Company = new SelectList(db.Companies, "CompanyID", "UserID", job.Company);
            ViewBag.ReferType = new SelectList(db.Refers, "ReferID", "UserID", job.ReferType);
            ViewBag.TermFK = new SelectList(db.Terms, "TermId", "TermName", job.TermFK);
            return View(job);
        }

        // POST: /Job/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit([Bind(Include="JobID,UserID,JobTitle,Company,ReferType,Priority,TermFK")] Job job)
        {
            if (ModelState.IsValid)
            {
                db.Entry(job).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Company = new SelectList(db.Companies, "CompanyID", "UserID", job.Company);
            ViewBag.ReferType = new SelectList(db.Refers, "ReferID", "UserID", job.ReferType);
            ViewBag.TermFK = new SelectList(db.Terms, "TermId", "TermName", job.TermFK);
            return View(job);
        }

        // GET: /Job/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = db.Jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        // POST: /Job/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            Job job = db.Jobs.Find(id);
            db.Jobs.Remove(job);
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
