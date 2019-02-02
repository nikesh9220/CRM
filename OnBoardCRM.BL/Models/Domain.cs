using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace OnBoardCRM.BL.Models
{
    public class Domain : Common.ModelHelper
    {
        public int DomainID { get; set; }
        public string DomainName { get; set; }
        public string StubName { get; set; }

        internal override void ManageEntity()
        {
            this.sqlParams = new List<SqlParameter>();
            this.sqlParams.Add(new SqlParameter("@Mode", (int)this.mode));
            this.sqlParams.Add(new SqlParameter("@DomainID", this.DomainID));
            this.sqlParams.Add(new SqlParameter("@DomainName", this.DomainName));
            this.sqlParams.Add(new SqlParameter("@StubName", this.StubName));

            this.spName = "ManageDomain";
            base.ManageEntity();
            this.DomainID = this.ID;
        }

        internal override void FillEntity(DataRow dr)
        {
            this.DomainID = Convert.ToInt32(dr["DomainID"]);
            this.DomainName = Convert.ToString(dr["DomainName"]);
            this.StubName = Convert.ToString(dr["StubName"]);
        }
    }

    public class DomainManager
    {
        public static Domain[] SearchDomain(NameValueCollection coll)
        {
            List<Domain> retVal = new List<Domain>();
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

            DataTable result = DL.Manager.DBManager.CallRetrievalSP("GetDomains", sqlParams.ToArray());
            if (result?.Rows?.Count > 0)
            {
                foreach (DataRow dr in result.Rows)
                {
                    Domain item = new Domain();
                    item.FillEntity(dr);
                    retVal.Add(item);
                }
            }

            return retVal.ToArray();
        }
    }
}
