using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetCourseAgendaByID:ISql
    {
        private int _agendaID;

        public SqlGetCourseAgendaByID(int agendaid)
        {
            _agendaID = agendaid;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "select *,ts.TeaSchoolName from Course as c inner join TeachingManageInfo "+
                        "as tm on tm.Grade=c.Grade and tm.TeaSchoolID=c.TeaSchoolID and tm.Term = c.CourseTime "+
                        "inner join TeachingSchoolInfo as ts on ts.TeaSchoolID=tm.TeaSchoolID  where TeaMagID='"+_agendaID+"'";
        }

        #endregion
    }
}
