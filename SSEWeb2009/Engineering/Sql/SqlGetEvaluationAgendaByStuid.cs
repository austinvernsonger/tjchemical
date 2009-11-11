using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetEvaluationAgendaByStuid:ISql
    {
        private string _stuid;

        public SqlGetEvaluationAgendaByStuid(string stuid)
        {
            _stuid = stuid;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "select distinct * from TeachingManageInfo as tm inner join Student as s on s.Grade=tm.Grade inner join StudentMSE as sm on s.StudentID=sm.StudentID and sm.TeaSchoolID=tm.TeaSchoolID where s.StudentID='" + _stuid + "'  and TeaMagType=3 and convert(varchar(10),getdate(),120) between StartTime and EndTime and tm.Term = (select max(Term) from TeachingManageInfo where TeaMagType=3)";
        }

        #endregion
    }
}
