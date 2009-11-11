using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetChoosingStuTime:ISql
    {
        private string _teacherID;

        public SqlGetChoosingStuTime(string teacherID)
        {
            _teacherID = teacherID;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "select * from TeachingManageInfo as tm inner join TeachingSchoolInfo as ts on tm.TeaSchoolID=ts.TeaSchoolID "+
                    "where TeaMagType=2 and convert(varchar(10),getdate(),120) < (EndTime + 30) and convert(varchar(10),getdate(),120) > EndTime and exists(select * from TutorChooseInfo as tc " +
                    "inner join Student as s on s.StudentID = tc.StuID inner join StudentMSE as sm on s.StudentID=sm.StudentID inner join TeachingManageInfo as tmi on tmi.Grade=s.Grade "+
                    "where tm.Grade = s.Grade and tm.TeaSchoolID = sm.TeaSchoolID and tc.TeacherID='"+_teacherID+"' and tm.TeaMagID = tmi.TeaMagID)";
        }

        #endregion
    }
}
