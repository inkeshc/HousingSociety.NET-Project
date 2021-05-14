using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HousingSociety.Models
{
    public class Login_AdminController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(HousingSociety.Models.Login_Admin login_Admin_Model)
        {
            //credential check
            using (LoginEntities LAE = new LoginEntities())
            {
                     try
                    {
                    var Admin_Details = LAE.Login_Admin.Where(u => u.Email == login_Admin_Model.Email
                    && u.Password == login_Admin_Model.Password).FirstOrDefault();

                    var addr = new System.Net.Mail.MailAddress(Admin_Details.Email);
                    {
                        if (Admin_Details == null)
                        {
                            return View("Login");
                        }
                        else
                        {
                            Session["Email"] = Admin_Details.Email;
                            return View("Admin_Home");
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
        public ActionResult Admin_Home()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login1()
        {
            return View();
        }
    }
}