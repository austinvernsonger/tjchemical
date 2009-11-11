using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlDeleteStudentExamInfo:ISql
    {
        private string _studentID;

        public SqlDeleteStudentExamInfo(string studentID)
        {
            _studentID = studentID;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "delete from ExamResultInfo where StuID ='" + _studentID+ "'";
        }

        #endregion
    }
}
