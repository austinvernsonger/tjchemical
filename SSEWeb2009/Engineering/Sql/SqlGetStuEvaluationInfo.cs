using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetStuEvaluationInfo:ISql
    {
        private int _courseID;
        private string _stuID;

        public SqlGetStuEvaluationInfo(int courseID, string stuID)
        {
            _courseID = courseID;
            _stuID = stuID;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "select Status from ExamResultInfo where CourID='" + _courseID + "' and StuID='" + _stuID + "'";
        }

        #endregion
    }
}
