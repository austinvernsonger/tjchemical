using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlUpdateCourseStudentNumWithNum:ISql
    {
        private int _courseID;
        private int _num;

        public SqlUpdateCourseStudentNumWithNum(int courseID, int num)
        {
            _courseID = courseID;
            _num = num;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "update Course Set StudentNumber='"+_num+"' where CourseID='" + _courseID + "'";
        }

        #endregion
    }
}
