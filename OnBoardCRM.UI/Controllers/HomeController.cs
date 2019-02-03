using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace User_Interface.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            OnBoardCRM.BL.Models.Client client = new OnBoardCRM.BL.Models.Client()
            {
                ClientName = "Gujarat Technologocal University",
                CreatedBy = 1,
                CreatedOn = DateTime.Now,
                SubscribedProducts = new[]
                {
                    new OnBoardCRM.BL.Models.Product()
                    {
                        ProductName = "Plans",
                        RefTemplate = "Plans_Template",
                        Domains = new[]
                        {
                            new OnBoardCRM.BL.Models.Domain()
                            {
                                DomainName = "PT",
                                StubName = "GTU_Plans_PT"
                            },
                            new OnBoardCRM.BL.Models.Domain()
                            {
                                DomainName = "OT",
                                StubName = "GTU_Plans_OT"
                            }
                        }
                    },
                    new OnBoardCRM.BL.Models.Product()
                    {
                        ProductName = "Steps",
                        RefTemplate = "Steps_Template",
                        Domains = new[]
                        {
                            new OnBoardCRM.BL.Models.Domain()
                            {
                                DomainName = "PT",
                                StubName = "GTU_Steps_PT"
                            },
                            new OnBoardCRM.BL.Models.Domain()
                            {
                                DomainName = "OT",
                                StubName = "GTU_Steps_OT"
                            }
                        }
                    }
                }
            };

            client.Create();
            return View("Login");
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