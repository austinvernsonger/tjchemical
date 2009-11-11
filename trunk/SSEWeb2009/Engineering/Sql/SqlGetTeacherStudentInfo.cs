using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetTeacherStudentInfo:ISql
    {
        private string _stuID;

        public SqlGetTeacherStudentInfo(string stuID)
        {
            _stuID = stuID;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "select * from TutorChooseInfo as tc inner join Teacher as t on tc.TeacherID = t.TeacherID where StuID='" + _stuID + "'";
        }

        #endregion
    }
}
