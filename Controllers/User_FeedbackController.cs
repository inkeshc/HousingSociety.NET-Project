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
    public class User_FeedbackController : Controller
    {
        private User_FeedbackEntities db = new User_FeedbackEntities();

        // GET: User_Feedback
        public ActionResult Index()
        {
            return View(db.User_Feedback.ToList());
        }

        // GET: User_Feedback/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_Feedback user_Feedback = db.User_Feedback.Find(id);
            if (user_Feedback == null)
            {
                return HttpNotFound();
            }
            return View(user_Feedback);
        }

        // GET: User_Feedback/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User_Feedback/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "REGID,Fname,Lname,Wing,Flat_No,Feedback_Detail")] User_Feedback user_Feedback)
        {
            if (ModelState.IsValid)
            {
                db.User_Feedback.Add(user_Feedback);
                db.SaveChanges();
                return RedirectToAction("User_Home", "Login_User");
            }

            return View(user_Feedback);
        }

        // GET: User_Feedback/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_Feedback user_Feedback = db.User_Feedback.Find(id);
            if (user_Feedback == null)
            {
                return HttpNotFound();
            }
            return View(user_Feedback);
        }

        // POST: User_Feedback/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "REGID,Fname,Lname,Wing,Flat_No,Feedback_Detail")] User_Feedback user_Feedback)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user_Feedback).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user_Feedback);
        }

        // GET: User_Feedback/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_Feedback user_Feedback = db.User_Feedback.Find(id);
            if (user_Feedback == null)
            {
                return HttpNotFound();
            }
            return View(user_Feedback);
        }

        // POST: User_Feedback/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User_Feedback user_Feedback = db.User_Feedback.Find(id);
            db.User_Feedback.Remove(user_Feedback);
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
