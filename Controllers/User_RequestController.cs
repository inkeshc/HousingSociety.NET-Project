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
    public class User_RequestController : Controller
    {
        private User_RequestEntities db = new User_RequestEntities();

        // GET: User_Request
        public ActionResult Index()
        {
            return View(db.User_Request.ToList());
        }

        // GET: User_Request/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_Request user_Request = db.User_Request.Find(id);
            if (user_Request == null)
            {
                return HttpNotFound();
            }
            return View(user_Request);
        }

        // GET: User_Request/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User_Request/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "REGID,Fname,Lname,Wing,Flat_No,Request_Priority,Request_Detail")] User_Request user_Request)
        {
            if (ModelState.IsValid)
            {
                db.User_Request.Add(user_Request);
                db.SaveChanges();
                //return RedirectToAction("Index");              
                return RedirectToAction("User_Home", "Login_User");
            }

            return View(user_Request);
        }

        // GET: User_Request/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_Request user_Request = db.User_Request.Find(id);
            if (user_Request == null)
            {
                return HttpNotFound();
            }
            return View(user_Request);
        }

        // POST: User_Request/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "REGID,Fname,Lname,Wing,Flat_No,Request_Priority,Request_Detail")] User_Request user_Request)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user_Request).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user_Request);
        }

        // GET: User_Request/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_Request user_Request = db.User_Request.Find(id);
            if (user_Request == null)
            {
                return HttpNotFound();
            }
            return View(user_Request);
        }

        // POST: User_Request/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User_Request user_Request = db.User_Request.Find(id);
            db.User_Request.Remove(user_Request);
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
