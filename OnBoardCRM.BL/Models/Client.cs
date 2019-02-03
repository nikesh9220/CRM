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
    public class Client : Common.ModelHelper
    {
        public int ClientID { get; set; }
        public string ClientName { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public Product[] SubscribedProducts { get; set; }
                
        internal override void ManageEntity()
        {
            this.sqlParams = new List<SqlParameter>();
            this.sqlParams.Add(new SqlParameter("@Mode", (int)this.mode));
            this.sqlParams.Add(new SqlParameter("@ClientID", this.ClientID));
            this.sqlParams.Add(new SqlParameter("@ClientName", this.ClientName));
            this.sqlParams.Add(new SqlParameter("@CreatedBy", this.CreatedBy));
            this.sqlParams.Add(new SqlParameter("@CreatedOn", this.CreatedOn));
            this.sqlParams.Add(new SqlParameter("@SubscribedProducts", string.Join(",", this.SubscribedProducts?.Select(p => p.ProductID))));

            this.spName = "ManageClient";
            base.ManageEntity();
            this.ClientID = this.ID;
        }

        internal override void FillEntity(DataRow dr)
        {
            this.ClientID = Convert.ToInt32(dr["ClientID"]);
            this.ClientName = Convert.ToString(dr["ClientName"]);
            this.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
            this.CreatedOn = Convert.ToDateTime(dr["CreatedOn"]);
            string products = Convert.ToString(dr["SubscribedProducts"]);
            if (!string.IsNullOrWhiteSpace(products))
            {
                string[] temp = products.Split(',');
                this.SubscribedProducts = temp.Select(t => new Product() { ProductID = int.Parse(t) }).ToArray();
            }
        }
    }

    public class ClientManager
    {
        public static Client[] SearchClients(NameValueCollection coll)
        {
            List<Client> retVal = new List<Client>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            //if (coll?.Count > 0)
            //{
            //    if (!string.IsNullOrWhiteSpace(coll["username"]))
            //    {
            //        sqlParams.Add(new SqlParameter("@username", coll["username"]));
            //    }

            //    if (!string.IsNullOrWhiteSpace(coll["password"]))
            //    {
            //        sqlParams.Add(new SqlParameter("@password", coll["password"]));
            //    }
            //}

            DataTable result = DL.Manager.DBManager.CallRetrievalSP("GetClients", sqlParams.ToArray());
            if (result?.Rows?.Count > 0)
            {
                foreach (DataRow dr in result.Rows)
                {
                    Client item = new Client();
                    item.FillEntity(dr);
                    retVal.Add(item);
                }
            }

            return retVal.ToArray();
        }
    }

}
