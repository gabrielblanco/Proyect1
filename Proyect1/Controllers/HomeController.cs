using Microsoft.Owin.Security;
using Proyect1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyect1.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Enjoy changing products with";
            return View();
        }

        public ActionResult MyProducts()
        {
            if (@Session["LogedIdUser"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }


        public ActionResult Login() {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User u) {

            if (ModelState.IsValid)
            {
                using (DBProyect1Entities db = new DBProyect1Entities())
                {
                    var v = db.Users.Where(a => a.Email.Equals(u.Email) && a.Password.Equals(u.Password)).FirstOrDefault();
                    if (v != null) {
                        Session["LogedIdUser"] = v.Id.ToString();
                        Session["LogedUsername"] = v.Username.ToString();
                        return RedirectToAction("MyProducts");
                    }
                }
            }
            return View(u);
        
        }
        public ActionResult Register() {
            return View();
        }

        [HttpPost]
        
        [ValidateAntiForgeryToken]
        public ActionResult Register(User u) {
            if (ModelState.IsValid)
            {
                using (DBProyect1Entities db = new DBProyect1Entities())
                {
                    UserController user = new UserController();
                    user.Create(u);
                    return RedirectToAction("Login",u);
                }
            }
            return View(u);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {

            Session.RemoveAll();
            return RedirectToAction("Index", "Home");
        }
        
    }
}