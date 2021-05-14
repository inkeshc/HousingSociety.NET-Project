using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using HousingSociety.Models;

namespace HousingSociety.Controllers
{
    public class Society_AddController : Controller
    {
        private Society_AddEnitites db = new Society_AddEnitites();

        // GET: Society_Add
        public ActionResult Index()
        {
            return View(db.Society_Add.ToList());
        }

        // GET: Society_Add/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Society_Add society_Add = db.Society_Add.Find(id);
            if (society_Add == null)
            {
                return HttpNotFound();
            }
            return View(society_Add);
        }

        // GET: Society_Add/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Society_Add/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "REGID,POST,Fname,Lname,Wing,Flat_No,Time_From,Time_To,Email,Password")] Society_Add society_Add)
        {
            if (ModelState.IsValid)
            {
                db.Society_Add.Add(society_Add);
                db.SaveChanges();
                //return RedirectToAction("Index");
                // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Society Register Successfully')", true);
                
                return RedirectToAction("Admin_Home", "Login_Admin");
            }

            return View(society_Add);
        }

        // GET: Society_Add/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Society_Add society_Add = db.Society_Add.Find(id);
            if (society_Add == null)
            {
                return HttpNotFound();
            }
            return View(society_Add);
        }

        // POST: Society_Add/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "REGID,POST,Fname,Lname,Wing,Flat_No,Time_From,Time_To,Email,Password")] Society_Add society_Add)
        {
            if (ModelState.IsValid)
            {
                db.Entry(society_Add).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(society_Add);
        }

        // GET: Society_Add/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Society_Add society_Add = db.Society_Add.Find(id);
            if (society_Add == null)
            {
                return HttpNotFound();
            }
            return View(society_Add);
        }

        // POST: Society_Add/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Society_Add society_Add = db.Society_Add.Find(id);
            db.Society_Add.Remove(society_Add);
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

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
