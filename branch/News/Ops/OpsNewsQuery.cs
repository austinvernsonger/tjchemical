using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Operation;
using System.Data;
using SMBL.Interface.Database;
namespace SysCom.Ops
{
    public class OpsNewsQuery:DBOperation
    {
        protected ISql iSql;
        public ISql SetISql
        {
            set { iSql = value; }
        }
        //保存查询数据库后返回的DataSet

        protected DataSet ds = null;
        public DataSet Ds
        {
            get { return ds; }
        }

        public OpsNewsQuery(String DBName, ISql TheISql)
        {
            SetISql = TheISql;
            BindDBName = "TjMedical";
        }

        public override void processDelegate()
        {
            ds = myProcessor.Query(iSql);
        }
    }
}
