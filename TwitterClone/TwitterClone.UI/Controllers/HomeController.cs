using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TwitterClone.BusinessLayer;
using TwitterClone.UI.Models;
using TwitterClone.DataLayer.Models;

namespace TwitterClone.UI.Controllers
{
    public class HomeController : Controller
    {
        UserBL objUser = new UserBL();
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
                {
                    // TODO:: Get the list of tweets from the logged in user and his followings
                    //List<Tweet> listTweet = objUser.;
                    return View();
                }
                else
                    return RedirectToAction("Login", "User");
            }
            else
            {
                //TODO:: Send the username with userid to Modal dialog where user can do FOLLOW and UNFOLLOW
                Person objPerson = objUser.SearchUser(queryString);
                if (objPerson != null)
                    searchResult.showDialog = true;
                return PartialView("_PartialSearchDialog", objPerson);
                //return RedirectToAction("Index", "Home", searchResult);
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