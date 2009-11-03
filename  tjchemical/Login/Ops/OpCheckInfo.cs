using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using SMBL.Operation;
using SMBL.Interface.Database;
namespace SysCom.Ops
{
    public class OpCheckInfo:DBOperation
    {
        private DataSet logininfods;

        SMBL.Interface.Database.ISql sqlstring;

        public DataSet LoginInfoDs
        {
            get { return logininfods; }
            set { logininfods = value; }
        }
        public OpCheckInfo(String DBName,ISql theISql)
        {
            sqlstring = theISql;
            BindDBName = DBName;
        }

        public override void processDelegate()
        {
            LoginInfoDs = myProcessor.Query(sqlstring);
        }
    }
}
