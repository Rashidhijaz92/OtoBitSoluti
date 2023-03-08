using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using loginsigupMj.Models;
using Newtonsoft.Json;

namespace loginsigupMj.Controllers
{
    public class AdminController : Controller
    {
        BAL bl = new BAL();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Login(Login login)
        {
            string response = bl.Login(login);
            return Json(response, JsonRequestBehavior.AllowGet);


        }
        public ActionResult Register()
        {
            return View();

        }
        [HttpPost]
        public ActionResult Register(Register register)
        {
            string response = bl.Register(register);
            return Json(response, JsonRequestBehavior.AllowGet);
        }
    }
}