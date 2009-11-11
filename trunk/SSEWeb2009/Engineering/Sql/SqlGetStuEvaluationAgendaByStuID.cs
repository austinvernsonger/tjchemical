using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetStuEvaluationAgendaByStuID:ISql
    {
        private string _studentID;

        public SqlGetStuEvaluationAgendaByStuID(string studentID)
        {
            _studentID = studentID;
        }

        #region ISql 成员

        public string GetSql()
        {
              //return "select distinct * from TeachingManageInfo as tm inner join Student as s on s.Grade=tm.Grade inner join StudentMSE as sm on s.StudentID=sm.StudentID and sm.TeaSchoolID=tm.TeaSchoolID inner join ExamResultInfo as e on e.StuID=s.StudentID inner join Course as c on c.CourseID=e.CourID where s.StudentID='"+_studentID+"' and tm.Term = ((select max(Term) from TeachingManageInfo)) and TeaMagType=3 and convert(varchar(10),getdate(),120) between StartTime and EndTime ";
            return "select distinct * from TeachingManageInfo as tm inner join Student as s on s.Grade=tm.Grade inner join StudentMSE as sm on s.StudentID=sm.StudentID and sm.TeaSchoolID=tm.TeaSchoolID where s.StudentID='" + _studentID + "'  and TeaMagType=3 and convert(varchar(10),getdate(),120) between StartTime and EndTime and tm.Term = (select max(Term) from TeachingManageInfo where TeaMagType=3)";
        }

        #endregion
    }
}
