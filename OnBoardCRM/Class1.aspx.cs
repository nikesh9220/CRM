using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnBoardCRM
{
    public partial class Class1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BL.Models.Client client = new BL.Models.Client() {
                ClientName = "Gujarat Technologocal University",
                CreatedBy = 1,
                CreatedOn = DateTime.Now,
                SubscribedProducts = new[]
                {
                    new BL.Models.Product()
                    {
                        ProductName = "Plans",
                        RefTemplate = "Plans_Template",
                        Domains = new[]
                        {
                            new BL.Models.Domain()
                            {
                                DomainName = "PT",
                                StubName = "GTU_Plans_PT"
                            },
                            new BL.Models.Domain()
                            {
                                DomainName = "OT",
                                StubName = "GTU_Plans_OT"
                            }
                        }
                    },
                    new BL.Models.Product()
                    {
                        ProductName = "Steps",
                        RefTemplate = "Steps_Template",
                        Domains = new[]
                        {
                            new BL.Models.Domain()
                            {
                                DomainName = "PT",
                                StubName = "GTU_Steps_PT"
                            },
                            new BL.Models.Domain()
                            {
                                DomainName = "OT",
                                StubName = "GTU_Steps_OT"
                            }
                        }
                    }
                }
            };

            client.Create();
        }
    }
}