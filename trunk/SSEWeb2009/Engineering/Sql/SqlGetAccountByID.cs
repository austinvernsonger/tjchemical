using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetAccountByID : ISql
    {
        private string _accountID;

        public SqlGetAccountByID(string accountID)
        {
            _accountID = accountID;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "select * from Account where AccountID ='"+_accountID+"' ";
        }

        #endregion
    }
}
