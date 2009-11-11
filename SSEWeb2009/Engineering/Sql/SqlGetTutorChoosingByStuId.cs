using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetTutorChoosingByStuId:ISql
    {
        private string _stuid;

        public SqlGetTutorChoosingByStuId(string stuid)
        {
            _stuid = stuid;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "select * from TutorChooseInfo as tc inner join Teacher as t on tc.TeacherID=t.TeacherID where StuID ='"+_stuid+"'";
        }

        #endregion
    }
}
