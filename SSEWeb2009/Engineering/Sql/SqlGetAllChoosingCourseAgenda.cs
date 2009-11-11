using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetAllChoosingCourseAgenda:ISql
    {
        public SqlGetAllChoosingCourseAgenda()
        { }

        #region ISql 成员

        public string GetSql()
        {
            return "select * from TeachingManageInfo as tm inner join TeachingSchoolInfo as ts on tm.TeaSchoolID = ts.TeaSchoolID where TeaMagType=1 order by StartTime desc";
        }

        #endregion
    }
}
