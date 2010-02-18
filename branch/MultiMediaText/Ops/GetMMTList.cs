using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Operation;
using System.Data;

namespace SysCom.Ops
{
    class GetMMTList : DBOperation
    {
        private Sql.sqlMMTGetList mySql;
        private DataSet myResult = null;
        public DataSet Result
        {
            get { return myResult; }
        }

        public GetMMTList(Sql.sqlMMTGetList Sql)
        {
            mySql = Sql;
           BindDBName = "TjMedical";
        }

        public override void processDelegate()
        {
            String tmp = mySql.GetSql();
            myResult = myProcessor.Query(mySql);
        }
    }
}
