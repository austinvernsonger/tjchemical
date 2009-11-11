using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetCourseInfoByTermAndStuID:ISql
    {
        private string _term;
        private string _studentID;

        public SqlGetCourseInfoByTermAndStuID(string term, string studentID)
        {
            _term = term;
            _studentID = studentID;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "select distinct CourseID, * from Course where Grade=(select Grade from Student where StudentID='"+_studentID+"') "+
                        "and TeaSchoolID=(Select TeaSchoolID from StudentMSE where StudentID='"+_studentID+"') and CourseID in (select CourID from ExamResultInfo where IsOpened=1) and CourseTime='"+Convert.ToInt32(_term)+"'";
        }

        #endregion
    }
}
