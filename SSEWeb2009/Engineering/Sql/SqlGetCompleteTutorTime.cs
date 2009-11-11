using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetCompleteTutorTime:ISql
    {
        public SqlGetCompleteTutorTime()
        { }

        #region ISql 成员

        public string GetSql()
        {
            return "select *, (EndTime+15) as completeTime  from TeachingManageInfo as tm inner join TeachingSchoolInfo as ts on tm.TeaSchoolID=ts.TeaSchoolID where TeaMagType=2 and convert(varchar(10),getdate(),120) > (EndTime+15) and confirmation=0";
        }

        #endregion
    }
}
