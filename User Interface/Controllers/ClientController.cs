using OnBoardCRM.BL.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace User_Interface.Controllers
{
    public class ClientController : Controller
    {
        // GET: Client
        public ActionResult Index()
        {

            NameValueCollection coll = new NameValueCollection();
            Client[] clients =  ClientManager.SearchClients(coll);
            if (clients?.Length > 0)
            {
                
            }
            
            return View();
        }


        public ActionResult AddNewClient()
        {


            return View();
        }
    }
}