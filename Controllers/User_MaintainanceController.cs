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
    public class User_MaintainanceController : Controller
    {
        private User_MaintainanceEntities db = new User_MaintainanceEntities();

        // GET: User_Maintainance
        public ActionResult Index()
        {
            return View(db.User_Maintainance.ToList());
        }

        // GET: User_Maintainance/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_Maintainance user_Maintainance = db.User_Maintainance.Find(id);
            if (user_Maintainance == null)
            {
                return HttpNotFound();
            }
            return View(user_Maintainance);
        }

        // GET: User_Maintainance/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User_Maintainance/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "REGID,Fname,Lname,Wing,Flat_No,Maintainance_Bill,Month,Year")] User_Maintainance user_Maintainance)
        {
            if (ModelState.IsValid)
            {
                db.User_Maintainance.Add(user_Maintainance);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user_Maintainance);
        }

        // GET: User_Maintainance/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_Maintainance user_Maintainance = db.User_Maintainance.Find(id);
            if (user_Maintainance == null)
            {
                return HttpNotFound();
            }
            return View(user_Maintainance);
        }

        // POST: User_Maintainance/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "REGID,Fname,Lname,Wing,Flat_No,Maintainance_Bill,Month,Year")] User_Maintainance user_Maintainance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user_Maintainance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user_Maintainance);
        }

        // GET: User_Maintainance/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_Maintainance user_Maintainance = db.User_Maintainance.Find(id);
            if (user_Maintainance == null)
            {
                return HttpNotFound();
            }
            return View(user_Maintainance);
        }

        // POST: User_Maintainance/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User_Maintainance user_Maintainance = db.User_Maintainance.Find(id);
            db.User_Maintainance.Remove(user_Maintainance);
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
