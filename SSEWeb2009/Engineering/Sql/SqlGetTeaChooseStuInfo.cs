using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetTeaChooseStuInfo:ISql
    {
        private int _tMagId;
        private string _teacherID;

        public SqlGetTeaChooseStuInfo(int tMagId, string teacherID)
        {
            _tMagId = tMagId;
            _teacherID = teacherID;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "select * from TeachingManageInfo as tm inner join Student as s on tm.Grade=s.Grade inner join TeachingSchoolInfo as ts on ts.TeaSchoolID = tm.TeaSchoolID inner join TutorChooseInfo as tc on tc.StuID = s.StudentID "+
                    "where TeaMagID = '"+_tMagId+"' and TeacherID='"+_teacherID+"'";
        }

        #endregion
    }
}
