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
    public class RecrutingCompanyController : Controller
    {
        private careertoolsEntities db = new careertoolsEntities();

        // GET: /RecrutingCompany/
        [Authorize]
        public ActionResult Index()
        {
            return View(db.RecruitingCompanies.ToList());
        }

        // GET: /RecrutingCompany/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecruitingCompany recruitingcompany = db.RecruitingCompanies.Find(id);
            if (recruitingcompany == null)
            {
                return HttpNotFound();
            }
            return View(recruitingcompany);
        }

        // GET: /RecrutingCompany/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: /RecrutingCompany/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include="RecruitingCompanyID,UserID,CompanyName")] RecruitingCompany recruitingcompany)
        {
            if (ModelState.IsValid)
            {
                db.RecruitingCompanies.Add(recruitingcompany);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(recruitingcompany);
        }

        // GET: /RecrutingCompany/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecruitingCompany recruitingcompany = db.RecruitingCompanies.Find(id);
            if (recruitingcompany == null)
            {
                return HttpNotFound();
            }
            return View(recruitingcompany);
        }

        // POST: /RecrutingCompany/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit([Bind(Include="RecruitingCompanyID,UserID,CompanyName")] RecruitingCompany recruitingcompany)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recruitingcompany).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(recruitingcompany);
        }

        // GET: /RecrutingCompany/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecruitingCompany recruitingcompany = db.RecruitingCompanies.Find(id);
            if (recruitingcompany == null)
            {
                return HttpNotFound();
            }
            return View(recruitingcompany);
        }

        // POST: /RecrutingCompany/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            RecruitingCompany recruitingcompany = db.RecruitingCompanies.Find(id);
            db.RecruitingCompanies.Remove(recruitingcompany);
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
