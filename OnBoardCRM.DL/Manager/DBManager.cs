using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoardCRM.DL.Manager
{
    public class DBManager
    {
        private static string connectionString
        {
            //get { return System.Configuration.ConfigurationManager.ConnectionStrings["DBConnString"].ConnectionString; }
            get { return "Data Source=Db-Server;Initial Catalog=OnBoardCRM;User id=developer; Password=developer123; MultipleActiveResultSets=true"; }
        }

        public static bool CallActionSP(string spName, SqlParameter[] parameters)
        {
            bool retVal = false;
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(spName, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddRange(parameters);

                        con.Open();
                        cmd.ExecuteNonQuery();
                        retVal = true;
                    }
                }
            }
            catch (Exception ex)
            {
                // log error
            }

            return retVal;
        }

        public static DataTable CallRetrievalSP(string spName, SqlParameter[] parameters)
        {
            DataTable retObj = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(spName, con))
                    {
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            da.Fill(retObj);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // log error
            }

            return retObj;
        }
    }
}
