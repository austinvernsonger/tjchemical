using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetMidFormByStuID:ISql
    {
        private string _userID;

        public SqlGetMidFormByStuID(string userID)
        {
            _userID = userID;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "Select * from AttachmentInfo where CreateByUser='" + _userID + "' and Category=2";
        }

        #endregion
    }
}
