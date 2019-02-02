using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoardCRM.BL.Common
{
    public abstract class ModelHelper
    {
        internal int ID { get; set; }

        internal List<SqlParameter> sqlParams;
        internal string spName;
        internal Common.ObjectState mode;
        internal DataTable result;

        virtual internal void ManageEntity()
        {
            this.result = null;
            switch (this.mode)
            {
                case Common.ObjectState.Create:
                case Common.ObjectState.Read:
                    {
                        this.result = DL.Manager.DBManager.CallRetrievalSP(this.spName, this.sqlParams.ToArray());
                        break;
                    }
                case Common.ObjectState.Update:
                case Common.ObjectState.Delete:
                    {
                        DL.Manager.DBManager.CallActionSP(this.spName, this.sqlParams.ToArray());
                        break;
                    }
            }

            if (this.result?.Rows?.Count > 0)
            {
                if (this.mode == ObjectState.Create)
                {
                    this.ID = Convert.ToInt32(this.result.Rows[0][0]);
                }
                else
                {
                    this.FillEntity(this.result.Rows[0]);
                }
            }
        }

        virtual internal void FillEntity(DataRow dr) => throw new NotImplementedException();

        public void Create()
        {
            this.mode = ObjectState.Create;
            this.ManageEntity();
        }

        public void Read()
        {
            this.mode = ObjectState.Read;
            this.ManageEntity();
        }

        public void Update()
        {
            this.mode = ObjectState.Update;
            this.ManageEntity();
        }

        public void Delete()
        {
            this.mode = ObjectState.Delete;
            this.ManageEntity();
        }
    }

    public enum ObjectState
    {
        Create,
        Read,
        Update,
        Delete
    }
}
