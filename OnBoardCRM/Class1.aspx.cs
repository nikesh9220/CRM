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
            BL.Models.UserAccount loggedInUser;
            bool retVal = BL.Models.UserAccountManager.AuthenticateUser("MasterAdmin", "admin@123", out loggedInUser);

        }
    }
}