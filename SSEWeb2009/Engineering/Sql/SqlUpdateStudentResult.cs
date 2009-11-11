using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlUpdateStudentResult:ISql
    {
        private string _stuid;
        private int _courseid;
        private string _result;

        public SqlUpdateStudentResult(string stuid, int courseid, string result)
        {
            _stuid = stuid;
            _courseid = courseid;
            _result = result;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "update ExamResultInfo set CourResult = '" + _result + "' where StuID='" + _stuid + "' and CourID='" + _courseid + "'";
        }

        #endregion

    }
}
