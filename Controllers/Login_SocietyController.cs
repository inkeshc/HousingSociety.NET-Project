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
    public class Login_SocietyController : Controller
    {
        private Login_SocietyEntities db = new Login_SocietyEntities();

        // GET: Login_Society
        public ActionResult Index()
        {
            return View(db.Login_Society.ToList());
        }

        // GET: Login_Society/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Login_Society login_Society = db.Login_Society.Find(id);
            if (login_Society == null)
            {
                return HttpNotFound();
            }
            return View(login_Society);
        }

        // GET: Login_Society/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Login_Society/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "REGID,Society_Name,Email,Password")] Login_Society login_Society)
        {
            if (ModelState.IsValid)
            {
                db.Login_Society.Add(login_Society);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(login_Society);
        }

        // GET: Login_Society/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Login_Society login_Society = db.Login_Society.Find(id);
            if (login_Society == null)
            {
                return HttpNotFound();
            }
            return View(login_Society);
        }

        // POST: Login_Society/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "REGID,Society_Name,Email,Password")] Login_Society login_Society)
        {
            if (ModelState.IsValid)
            {
                db.Entry(login_Society).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(login_Society);
        }

        // GET: Login_Society/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Login_Society login_Society = db.Login_Society.Find(id);
            if (login_Society == null)
            {
                return HttpNotFound();
            }
            return View(login_Society);
        }

        // POST: Login_Society/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Login_Society login_Society = db.Login_Society.Find(id);
            db.Login_Society.Remove(login_Society);
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
    
    
        [HttpGet]
    public ActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Login(HousingSociety.Models.Login_Society login_Society_Model)
    {
        //credential check
        using (Login_SocietyEntities LSE = new Login_SocietyEntities())
        {
                try
                {
                    var Admin_Details = LSE.Login_Society.Where(u => u.Society_Name == login_Society_Model.Society_Name
                    && u.Email == login_Society_Model.Email
                    && u.Password == login_Society_Model.Password).FirstOrDefault();

                    var addr = new System.Net.Mail.MailAddress(Admin_Details.Email);
                    {
                        if (Admin_Details == null)
                        {
                            return View("Login");
                        }
                        else
                        {
                            Session["Email"] = Admin_Details.Email;
                            return View("Society_Home");
                        }
                    }
                }
                catch
                {
                    ViewBag.Message = string.Format("Please enter valid email id - abc@test.com");
                    return View("Login");
                }
            }
    }

    [HttpGet]
    public ActionResult Society_Home()
    {
        return View();
    }

        public ActionResult Contact()
        {
            return View();
        }
    }
}
