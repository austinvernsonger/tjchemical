using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetCourseNum:ISql
    {
        private int _term;
        private string _grade;

        public SqlGetCourseNum(QueryInfo qInfo)
        {
            _term = Convert.ToInt32(qInfo.Time);
            _grade = qInfo.Grade;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "select distinct CourseTime,c.Grade,ts.TeaSchoolID,ts.TeaSchoolName,StartTime,EndTime,num=(select count(*) from Course as c1 where CourseID in (select CourID from ExamResultInfo where IsOpened=1) and c1.Grade='"+_grade+"' and c1.CourseTime='"+_term+"'and c1.TeaSchoolID=c.TeaSchoolID) from Course as c inner join TeachingSchoolInfo as ts on ts.TeaSchoolID=c.TeaSchoolID left join TeachingManageInfo as tm on (c.Grade=tm.Grade and c.TeaSchoolID=tm.TeaSchoolID and tm.TeaMagType=3) where c.Grade='"+_grade+"' and c.CourseTime='"+_term+"'";
        }

        #endregion
    }
}
