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
    public class ReferController : Controller
    {
        private careertoolsEntities db = new careertoolsEntities();

        // GET: /Refer/
        public ActionResult Index()
        {
            return View(db.Refers.ToList());
        }

        // GET: /Refer/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Refer refer = db.Refers.Find(id);
            if (refer == null)
            {
                return HttpNotFound();
            }
            return View(refer);
        }

        // GET: /Refer/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Refer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include="ReferID,UserID,Name")] Refer refer)
        {
            if (ModelState.IsValid)
            {
                db.Refers.Add(refer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(refer);
        }

        // GET: /Refer/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Refer refer = db.Refers.Find(id);
            if (refer == null)
            {
                return HttpNotFound();
            }
            return View(refer);
        }

        // POST: /Refer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit([Bind(Include="ReferID,UserID,Name")] Refer refer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(refer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(refer);
        }

        // GET: /Refer/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Refer refer = db.Refers.Find(id);
            if (refer == null)
            {
                return HttpNotFound();
            }
            return View(refer);
        }

        // POST: /Refer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            Refer refer = db.Refers.Find(id);
            db.Refers.Remove(refer);
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
