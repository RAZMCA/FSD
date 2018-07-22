using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TwitterClone.UI.Models;

namespace TwitterClone.UI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Session["UserName"] != null)
                return View();
            else
                return RedirectToAction("Login", "User");
        }

        [HttpGet]
        public ActionResult Index(string search)
        {
            string queryString = Request.QueryString["search"];
            Search searchResult = new Search(); 
            if (string.IsNullOrEmpty(queryString))
            {
                if (Session["UserName"] != null)
                    return View();
                else
                    return RedirectToAction("Login", "User");
            }
            else
            {
                searchResult.showDialog = true;
                return RedirectToAction("Index", "Home", searchResult);
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}