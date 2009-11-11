using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;
using SMBL.Operation;
using System.Data;
namespace SysCom.Ops
{
    class OpLoginQuery: DBOperation
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

        public OpLoginQuery(String DBName, ISql TheISql)
        {
            SetISql = TheISql;
            BindDBName = DBName;
        }

        public override void processDelegate()
        {
            ds = myProcessor.Query(iSql);
        }
    }
}
