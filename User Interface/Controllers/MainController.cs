using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace User_Interface.Controllers
{
    public class MainController : Controller
    {
        // GET: Main
        public ActionResult Index()
        {
            ViewBag.ShowError = false;
            return View();
        }

        public ActionResult LoginCheck(FormCollection collection)
        {
            string userName = collection["username"];
            string password = collection["password"];


            OnBoardCRM.BL.Models.UserAccount loggedInUser;
            //bool retVal = OnBoardCRM.BL.Models.UserAccountManager.AuthenticateUser(userName, password, out loggedInUser);
            bool retVal = false;

            if (retVal)
            {
               // Session[userName] = loggedInUser;
                return View("Dashboard");
            }
            else
            {
                ViewBag.ShowError = true;
                return View("Index");
            }


           // return View("Index");
        }
    }
}