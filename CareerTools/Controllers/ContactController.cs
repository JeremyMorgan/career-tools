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
    public class ContactController : Controller
    {
        private careertoolsEntities db = new careertoolsEntities();

        // GET: /Contact/
        [Authorize]
        public ActionResult Index()
        {
            var contacts = db.Contacts.Include(c => c.RecruitingCompany);
            return View(contacts.ToList());
        }

        // GET: /Contact/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = db.Contacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // GET: /Contact/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.RecruitingCompanyFK = new SelectList(db.RecruitingCompanies, "RecruitingCompanyID", "CompanyName");
            return View();
        }

        // POST: /Contact/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include="ContactID,UserID,FirstName,LastName,RecruitingCompanyFK,Email,Phone")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                db.Contacts.Add(contact);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RecruitingCompanyFK = new SelectList(db.RecruitingCompanies, "RecruitingCompanyID", "CompanyName", contact.RecruitingCompanyFK);
            return View(contact);
        }

        // GET: /Contact/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = db.Contacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            ViewBag.RecruitingCompanyFK = new SelectList(db.RecruitingCompanies, "RecruitingCompanyID", "CompanyName", contact.RecruitingCompanyFK);
            return View(contact);
        }

        // POST: /Contact/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit([Bind(Include="ContactID,UserID,FirstName,LastName,RecruitingCompanyFK,Email,Phone")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contact).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RecruitingCompanyFK = new SelectList(db.RecruitingCompanies, "RecruitingCompanyID", "CompanyName", contact.RecruitingCompanyFK);
            return View(contact);
        }

        // GET: /Contact/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = db.Contacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // POST: /Contact/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            Contact contact = db.Contacts.Find(id);
            db.Contacts.Remove(contact);
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
