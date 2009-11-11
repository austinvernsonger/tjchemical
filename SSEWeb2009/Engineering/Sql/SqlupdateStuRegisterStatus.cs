using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlupdateStuRegisterStatus:ISql
    {
        private string _studentID;

        public SqlupdateStuRegisterStatus(string studentID)
        {
            _studentID = studentID;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "update StudentMSE set IsRegistered = 1 where StudentID='" + _studentID + "'";
        }

        #endregion
    }
}
