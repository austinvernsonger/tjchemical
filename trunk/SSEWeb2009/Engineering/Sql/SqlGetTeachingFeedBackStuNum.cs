using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetTeachingFeedBackStuNum:ISql
    {
        private int _courseID;

        public SqlGetTeachingFeedBackStuNum(int courseid)
        {
            _courseID = courseid;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "select * from ExamResultInfo where Status=1 and CourID='"+_courseID+"'";
        }

        #endregion
    }
}
