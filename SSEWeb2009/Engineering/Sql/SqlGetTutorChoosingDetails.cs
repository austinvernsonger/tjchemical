using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetTutorChoosingDetails:ISql
    {
        private string _stuID;

        public SqlGetTutorChoosingDetails(string stuid)
        {
            _stuID = stuid;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "select s.Name as sName, t.Name as tName,* from TutorChooseInfo as tc inner join Teacher as t on tc.TeacherID=t.TeacherID "+
                    "inner join Student as s on tc.StuID=s.StudentID inner join StudentMSE as sm on sm.StudentID = s.StudentID "+
                    "inner join TeachingSchoolInfo as ts on ts.TeaSchoolID=sm.TeaSchoolID where StuID ='"+_stuID+"'";
        }

        #endregion
    }
}
