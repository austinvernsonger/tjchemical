using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetStuChooseTeacherNumByWill:ISql
    {
        private string _studentID;
        private string _teacherID;
        private string _will;

        public SqlGetStuChooseTeacherNumByWill(string studentID, string teacherID, string will)
        {
            _studentID = studentID;
            _teacherID = teacherID;
            _will = will;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "select count(*) as num from TutorChooseInfo as tc inner join Student as s on s.StudentID=tc.StuID " +
                        "inner join StudentMSE as sm on sm.StudentID=s.StudentID where s.Grade = (select Grade from Student " +
                        "where StudentID='" + _studentID + "') and sm.TeaSchoolID=(select TeaSchoolID from StudentMSE where StudentID='" + _studentID + "') and tc.TeacherID='" + _teacherID + "' and Will='"+_will+"'";
        }

        #endregion
    }
}
