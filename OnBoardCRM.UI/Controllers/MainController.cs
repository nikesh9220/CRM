using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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
            NameValueCollection nm = new NameValueCollection();
            OnBoardCRM.BL.Models.Client[] cm = OnBoardCRM.BL.Models.ClientManager.SearchClient(nm);
            ViewBag.ShowError = false;
            return View();
        }

        public ActionResult LoginCheck(FormCollection collection)
        {
            string userName = collection["username"];
            string password = collection["password"];


            OnBoardCRM.BL.Models.UserAccount loggedInUser;
            bool retVal = OnBoardCRM.BL.Models.UserAccountManager.AuthenticateUser(userName, password, out loggedInUser);
          //  bool retVal = false;

            if (retVal)
            {
                Session["UserID"] = loggedInUser;
                Session["UserName"] = loggedInUser.UserName.ToString();
                return RedirectToAction("UserDashBoard");
            }
            else
            {
                ViewBag.ShowError = true;
                //return RedirectToAction("Index");
                return View("Index");
            }


           // return View("Index");
        }
        public ActionResult UserDashBoard()
        {
            if (Session["UserID"] != null)
            {

                return View();
            } else
            {
                return RedirectToAction("Index");
            }
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index");

        }
    }
}