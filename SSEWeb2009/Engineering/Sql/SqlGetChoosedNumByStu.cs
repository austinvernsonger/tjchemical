using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetChoosedNumByStu:ISql
    {
        private string _teacherID;

        public SqlGetChoosedNumByStu(string teacherID)
        {
            _teacherID = teacherID;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "select * from TeachingManageInfo as tm inner join TeachingSchoolInfo as ts on tm.TeaSchoolID=ts.TeaSchoolID "+
                    "inner join Student as s on s.Grade=tm.Grade inner join TutorChooseInfo as tc on tc.StuID=s.StudentID where TeaMagType=2 and tc.TeacherID='" + _teacherID + "' and getdate() < (EndTime + 30) and getdate() > EndTime";
        }

        #endregion

    }
}
