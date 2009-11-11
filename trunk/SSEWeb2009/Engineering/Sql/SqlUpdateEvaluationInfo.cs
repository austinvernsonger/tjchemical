using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    //更新学生是否评教
    class SqlUpdateEvaluationInfo:ISql
    {
        private int _courseID;
        private string _stuID;

        public SqlUpdateEvaluationInfo(int courseID, string stuID)
        {
            _courseID = courseID;
            _stuID = stuID;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "update ExamResultInfo set Status=Status+1 where CourID='" + _courseID + "' and StuID='" + _stuID + "'"; 
        }

        #endregion
    }
}
