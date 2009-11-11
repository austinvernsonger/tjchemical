using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlDeleteStuStatusChangInfo:ISql
    {
        private string _studentID;

        public SqlDeleteStuStatusChangInfo(string studentID)
        {
            _studentID = studentID;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "delete from StuStatusChangeInfo where StuID ='" + _studentID + "'";
        }

        #endregion
    }
}
