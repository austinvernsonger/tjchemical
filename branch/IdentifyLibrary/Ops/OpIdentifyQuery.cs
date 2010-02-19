using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMBL.Interface.Database;
using SMBL.Operation;
using System.Data;
namespace IdentifyLibrary.Ops
{
    class OpIdentifyQuery : DBOperation
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

        public OpIdentifyQuery(ISql TheISql)
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
