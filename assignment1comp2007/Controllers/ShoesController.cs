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
    public class ShoesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Shoes
        public ActionResult Index()
        {
            return View(db.Shoes.ToList());
        }

        // GET: Shoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shoe shoe = db.Shoes.Find(id);
            if (shoe == null)
            {
                return HttpNotFound();
            }
            return View(shoe);
        }

        // GET: Shoes/Create
        public ActionResult Create()
        {
            ViewBag.BrandId = new SelectList(db.Companies.OrderBy(b => b.CompanyName), "BrandId", "CompanyName");
            return View();
        }

        // POST: Shoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId,BrandId,ShoeName,Price,SizeUS,Quantity,ImageUrl")] Shoe shoe)
        {
            if (ModelState.IsValid)
            {

                // check for a new shoe image upload
                if (Request.Files.Count > 0)
                {
                    var file = Request.Files[0];

                    if (file.FileName != null && file.ContentLength > 0)
                    {
                        string path = Server.MapPath("~/Content/Images/") + file.FileName;
                        file.SaveAs(path);

                        // add path to image name before saving
                        shoe.ImageUrl = "/Content/Images/" + file.FileName;
                    }
                }

                db.Shoes.Add(shoe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(shoe);
        }

        // GET: Shoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shoe shoe = db.Shoes.Find(id);
            if (shoe == null)
            {
                return HttpNotFound();
            }
            ViewBag.BrandId = new SelectList(db.Companies.OrderBy(b => b.CompanyName), "BrandId", "CompanyName", shoe.BrandId);
            return View(shoe);
        }

        // POST: Shoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId,BrandId,ShoeName,Price,SizeUS,Quantity,ImageUrl")] Shoe shoe)
        {
            if (ModelState.IsValid)
            {
                // check for a new shoe image upload
                if (Request.Files.Count > 0)
                {
                    var file = Request.Files[0];

                    if (file.FileName != null && file.ContentLength > 0)
                    {
                        string path = Server.MapPath("~/Content/Images/") + file.FileName;
                        file.SaveAs(path);

                        // add path to image name before saving
                        shoe.ImageUrl = "/Content/Images/" + file.FileName;
                    }
                }
                db.Entry(shoe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(shoe);
        }

        // GET: Shoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shoe shoe = db.Shoes.Find(id);
            if (shoe == null)
            {
                return HttpNotFound();
            }
            return View(shoe);
        }

        // POST: Shoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Shoe shoe = db.Shoes.Find(id);
            db.Shoes.Remove(shoe);
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
