using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetStudentPic:ISql
    {
        private string _studentID;

        public SqlGetStudentPic(string studentID)
        {
            _studentID = studentID;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "select StudentPic from StudentMSE where StudentID='" + _studentID + "'";
        }

        #endregion
    }
}
