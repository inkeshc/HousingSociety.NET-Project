using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HousingSociety.Models;

namespace HousingSociety.Controllers
{
    public class Society__Add_UserController : Controller
    {
        private Society__Add_UserEntities db = new Society__Add_UserEntities();

        // GET: Society__Add_User
        public ActionResult Index()
        {
            return View(db.Society__Add_User.ToList());
        }

        // GET: Society__Add_User/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Society__Add_User society__Add_User = db.Society__Add_User.Find(id);
            if (society__Add_User == null)
            {
                return HttpNotFound();
            }
            return View(society__Add_User);
        }

        // GET: Society__Add_User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Society__Add_User/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "REGID,Aadhar_Card,Fname,Lname,Wing,Flat_No,Email,Contact,Password,Type")] Society__Add_User society__Add_User)
        {
            if (ModelState.IsValid)
            {
                db.Society__Add_User.Add(society__Add_User);
                db.SaveChanges();
                return RedirectToAction("Society_Home", "Login_Society");
            }

            return View(society__Add_User);
        }

        // GET: Society__Add_User/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Society__Add_User society__Add_User = db.Society__Add_User.Find(id);
            if (society__Add_User == null)
            {
                return HttpNotFound();
            }
            return View(society__Add_User);
        }

        // POST: Society__Add_User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "REGID,Aadhar_Card,Fname,Lname,Wing,Flat_No,Email,Contact,Password,Type")] Society__Add_User society__Add_User)
        {
            if (ModelState.IsValid)
            {
                db.Entry(society__Add_User).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(society__Add_User);
        }

        // GET: Society__Add_User/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Society__Add_User society__Add_User = db.Society__Add_User.Find(id);
            if (society__Add_User == null)
            {
                return HttpNotFound();
            }
            return View(society__Add_User);
        }

        // POST: Society__Add_User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Society__Add_User society__Add_User = db.Society__Add_User.Find(id);
            db.Society__Add_User.Remove(society__Add_User);
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
        public ActionResult Index_User()
        {
            return View();
        }
    }
}
