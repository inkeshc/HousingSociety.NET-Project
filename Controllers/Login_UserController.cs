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
    public class Login_UserController : Controller
    {
        private Login_UserEntities db = new Login_UserEntities();

        // GET: Login_User       
        public ActionResult Index()
        {
            Login_UserEntities LSA = new Login_UserEntities();

            List<Login_User> list = LSA.Login_User.ToList();
            ViewBag.Login_Userlist = new SelectList(list, "Society_Name");


            //return View(db.Login_User.ToList());

            return View();
        }

        // GET: Login_User/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Login_User login_User = db.Login_User.Find(id);
            if (login_User == null)
            {
                return HttpNotFound();
            }
            return View(login_User);
        }

        // GET: Login_User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Login_User/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "REGID,Society_Name,Email,Password")] Login_User login_User)
        {
            if (ModelState.IsValid)
            {
                db.Login_User.Add(login_User);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(login_User);
        }

        // GET: Login_User/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Login_User login_User = db.Login_User.Find(id);
            if (login_User == null)
            {
                return HttpNotFound();
            }
            return View(login_User);
        }

        // POST: Login_User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "REGID,Society_Name,Email,Password")] Login_User login_User)
        {
            if (ModelState.IsValid)
            {
                db.Entry(login_User).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(login_User);
        }

        // GET: Login_User/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Login_User login_User = db.Login_User.Find(id);
            if (login_User == null)
            {
                return HttpNotFound();
            }
            return View(login_User);
        }

        // POST: Login_User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Login_User login_User = db.Login_User.Find(id);
            db.Login_User.Remove(login_User);
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
        public ActionResult Login(HousingSociety.Models.Login_User login_User_Model)
        {

            //credential check
            using (Login_UserEntities LUE = new Login_UserEntities())
            {
                try
                {
                    var User_Details = LUE.Login_User.Where(u => u.Society_Name == login_User_Model.Society_Name
                                    && u.Email == login_User_Model.Email
                                    && u.Password == login_User_Model.Password).FirstOrDefault();
                    var addr = new System.Net.Mail.MailAddress(User_Details.Email);
                    {
                        if (User_Details == null)
                        {
                            return View("Login");
                        }
                        else
                        {
                            Session["Email"] = User_Details.Email;
                            return View("User_Home");
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
        public ActionResult User_Home()
        {
            return View();
        }
        
        public ActionResult Contact()
        {
            return View();
        }
    }
}
