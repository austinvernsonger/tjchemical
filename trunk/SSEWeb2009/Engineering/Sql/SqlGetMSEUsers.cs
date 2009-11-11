using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetMSEUsers:ISql
    {
        private string _accountid;

        public SqlGetMSEUsers(string accountid)
        {
            _accountid = accountid;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "Select * from Users where UserID ='"+_accountid+"'";
        }

        #endregion
    }
}
