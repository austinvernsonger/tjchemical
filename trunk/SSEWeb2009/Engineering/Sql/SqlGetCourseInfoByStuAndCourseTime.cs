using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetCourseInfoByStuAndCourseTime:ISql
    {
        private string _stuid;
        private string _term;

        public SqlGetCourseInfoByStuAndCourseTime(string stuid, string term)
        {
            _stuid = stuid;
            _term = term;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "select c.* from Course as c inner join ExamResultInfo as e on c.CourseID = e.CourID  where e.StuID = '" + _stuid + "' and c.CourseTime = '"+Convert.ToInt32(_term)+"'";
        }

        #endregion
    }
}
