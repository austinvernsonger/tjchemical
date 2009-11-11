using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetFromExamResult:ISql
    {
        private string _stuID;
        private int _courseID;

        public SqlGetFromExamResult(string stuID,int courseID)
        {
            _stuID = stuID;
            _courseID = courseID;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "select * from ExamResultInfo where CourID='" + _courseID + "' and StuID = '" + _stuID + "'";
        }

        #endregion
    }
}
