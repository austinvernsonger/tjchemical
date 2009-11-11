using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetStuChooseTeacherNum:ISql
    {
        private string _studentID;
        private string _teacherID;

        public SqlGetStuChooseTeacherNum(string studentID,string teacherID)
        {
            _teacherID = teacherID;
            _studentID = studentID;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "select count(*) as num from TutorChooseInfo as tc inner join Student as s on s.StudentID=tc.StuID "+
                        "inner join StudentMSE as sm on sm.StudentID=s.StudentID where s.Grade = (select Grade from Student "+
                        "where StudentID='"+_studentID+"') and sm.TeaSchoolID=(select TeaSchoolID from StudentMSE where StudentID='"+_studentID+"') and tc.TeacherID='"+_teacherID+"'";
        }

        #endregion
    }
}
