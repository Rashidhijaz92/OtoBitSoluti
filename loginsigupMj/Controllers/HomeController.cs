using loginsigupMj.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace loginsigupMj.Controllers
{
    public class HomeController : Controller
    {
        BAL bl = new BAL();

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult Login()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
        public ActionResult RegisterApi()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
        public ActionResult GetUser(int Id)
        {
            DataTable dt = new DataTable();
            dt = bl.GetUserApi(Id);
          
            return View(dt);

        }

    }
}

