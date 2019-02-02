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
    public class Product : Common.ModelHelper
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public Domain[] Domains { get; set; }
        public string RefTemplate { get; set; }



        internal override void ManageEntity()
        {
            this.sqlParams = new List<SqlParameter>();
            this.sqlParams.Add(new SqlParameter("@Mode", (int)this.mode));
            this.sqlParams.Add(new SqlParameter("@ProductID", this.ProductID));
            this.sqlParams.Add(new SqlParameter("@ProductName", this.ProductName));
            this.sqlParams.Add(new SqlParameter("@Domains", Common.Utilities.XMLSerialize(this.Domains,typeof(Domain[]))));
            this.sqlParams.Add(new SqlParameter("@RefTemplate", this.RefTemplate));

            this.spName = "ManageProduct";
            base.ManageEntity();
            this.ProductID = this.ID;
        }

        internal override void FillEntity(DataRow dr)
        {
            this.ProductID = Convert.ToInt32(dr["ProductID"]);
            this.ProductName = Convert.ToString(dr["ProductName"]);
            this.Domains = (Domain[])Common.Utilities.XMLDeserialize(Convert.ToString(dr["Domains"]),typeof(Domain[]));
            this.RefTemplate = Convert.ToString(dr["RefTemplate"]);
        }
    }

    public class ProductManager
    {
        public static Product[] SearchProduct(NameValueCollection coll)
        {
            List<Product> retVal = new List<Product>();
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

            DataTable result = DL.Manager.DBManager.CallRetrievalSP("GetProducts", sqlParams.ToArray());
            if (result?.Rows?.Count > 0)
            {
                foreach (DataRow dr in result.Rows)
                {
                    Product item = new Product();
                    item.FillEntity(dr);
                    retVal.Add(item);
                }
            }

            return retVal.ToArray();
        }
    }
}
