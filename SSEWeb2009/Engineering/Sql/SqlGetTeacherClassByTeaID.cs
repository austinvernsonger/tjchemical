using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetTeacherClassByTeaID:ISql
    {
        private string _teacherID;

        public SqlGetTeacherClassByTeaID(string teacherID)
        {
            _teacherID = teacherID;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "select * from Course as c inner join Teacher_Course as t on t.CourseID = c.CourseID inner join TeachingSchoolInfo as ts "+
                        "on ts.TeaSchoolID = c.TeaSchoolID where t.TeacherID='" + _teacherID + "' and c.Target=1 and c.CourseTime =(select max(CourseTime) "+
                        "from Course) and c.CourseID in (select CourID from ExamResultInfo where IsOpened=1)";
        }

        #endregion
    }
}
