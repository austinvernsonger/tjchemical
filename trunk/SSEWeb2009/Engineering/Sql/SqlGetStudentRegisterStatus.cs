using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetStudentRegisterStatus:ISql
    {
        private string _studentID;

        public SqlGetStudentRegisterStatus(string studentID)
        {
            _studentID = studentID;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "select * from StudentMSE where StudentID ='" + _studentID + "' and IsRegistered=1";

        }
        #endregion
    }
}
