using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlDeleteStudentDisscussion:ISql
    {
        private string _studentID;

        public SqlDeleteStudentDisscussion(string studentID)
        {
            _studentID = studentID;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "delete from Discussion where left(Communicators,10) ='" + _studentID + "' or right(Communicators,10)='" + _studentID + "'";
        }

        #endregion
    }
}
