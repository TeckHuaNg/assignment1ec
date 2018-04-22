using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using assignment1comp2007.Models;

namespace assignment1comp2007.Controllers
{
    [Authorize]
    public class CompaniesController : Controller
    {
        //private ApplicationDbContext db = new ApplicationDbContext();
        private IMockCompaniesRepository db;

        //default
        public CompaniesController()
        {
            this.db = new EFCompaniesRepository();
        }
        //mock
        public CompaniesController(IMockCompaniesRepository mockRepo)
        {
            this.db = mockRepo;
        }


        [OverrideAuthorization]
        // GET: Companies
        public ActionResult Index()
        {
            return View(db.Companies.ToList());
        }

        [OverrideAuthorization]
        // GET: Companies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                return View("Error");
            }
            Company company = db.Companies.SingleOrDefault(c => c.BrandId == id);
            if (company == null)
            {
                return View("Error");
            }
            return View(company);
        }

        //// GET: Companies/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Companies/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "BrandId,CompanyName,Description")] Company company)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Companies.Add(company);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(company);
        //}

        // GET: Companies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                return View("Error");
            }
            Company company = db.Companies.SingleOrDefault(c => c.BrandId == id);
            if (company == null)
            {
                return View("Error");
            }
            return View(company);
        }

        // POST: Companies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BrandId,CompanyName,Description")] Company company)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(company).State = EntityState.Modified;
                //db.SaveChanges();
                db.Save(company);
                return RedirectToAction("Index");
            }
            return View("Edit", company);
        }

        // GET: Companies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                return View("Error");

            }
            Company company = db.Companies.SingleOrDefault(c => c.BrandId == id);
            if (company == null)
            {
                return View("Error");
            }
            return View(company);
        }

        // POST: Companies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Company company = db.Companies.SingleOrDefault(c => c.BrandId == id);
            //db.Companies.Remove(company);
            //db.SaveChanges();
            db.Delete(company);
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
