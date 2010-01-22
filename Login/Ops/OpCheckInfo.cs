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
        private String accountID;
        SMBL.Interface.Database.ISql sqlstring;

        public DataSet LoginInfoDs
        {
            get { return logininfods; }
            set { logininfods = value; }
        }
        public OpCheckInfo(String DBName, ISql theISql, String AccountID)
        {
            sqlstring = theISql;
            BindDBName = DBName;
            accountID = AccountID;
        }

        public override void processDelegate()
        {
           logininfods =myProcessor.Producer("P_Get_Account",accountID);
        }
    }
}
