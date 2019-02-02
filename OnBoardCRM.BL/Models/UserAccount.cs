using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoardCRM.BL.Models
{
    public class UserAccount : Common.ModelHelper
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        internal override void ManageEntity()
        {
            this.sqlParams = new List<SqlParameter>();
            this.sqlParams.Add(new SqlParameter("@Mode", (int)this.mode));
            this.sqlParams.Add(new SqlParameter("@UserID", this.UserID));
            this.sqlParams.Add(new SqlParameter("@UserName", this.UserName));
            this.sqlParams.Add(new SqlParameter("@Password", this.Password));
            this.sqlParams.Add(new SqlParameter("@Email", this.Email));

            this.spName = "ManageUserAccount";
            base.ManageEntity();
            this.UserID = this.ID;
        }

        internal override void FillEntity(DataRow dr)
        {
            this.UserID = Convert.ToInt32(dr["UserID"]);
            this.UserName = Convert.ToString(dr["UserName"]);
            this.Password = Convert.ToString(dr["Password"]);
            this.Email = Convert.ToString(dr["Email"]);
        }
    }

    public class UserAccountManager
    {
        public static bool AuthenticateUser(string username, string password, out UserAccount loggedInUser)
        {
            loggedInUser = null;
            NameValueCollection coll = new NameValueCollection();
            coll.Add("username", username);
            coll.Add("password", password);
            UserAccount[] users = SearchUsers(coll);
            if (users?.Length > 0)
            {
                loggedInUser = users.FirstOrDefault();
                return true;
            }

            return false;
        }

        public static UserAccount[] SearchUsers(NameValueCollection coll)
        {
            List<UserAccount> retVal = new List<UserAccount>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            if (coll?.Count > 0)
            {
                if (!string.IsNullOrWhiteSpace(coll["username"]))
                {
                    sqlParams.Add(new SqlParameter("@username", coll["username"]));
                }

                if (!string.IsNullOrWhiteSpace(coll["password"]))
                {
                    sqlParams.Add(new SqlParameter("@password", coll["password"]));
                }
            }

            DataTable result = DL.Manager.DBManager.CallRetrievalSP("GetUserAccounts", sqlParams.ToArray());
            if (result?.Rows?.Count > 0)
            {
                foreach (DataRow dr in result.Rows)
                {
                    UserAccount item = new UserAccount();
                    item.FillEntity(dr);
                    retVal.Add(item);
                }
            }

            return retVal.ToArray();
        }
    }
}
