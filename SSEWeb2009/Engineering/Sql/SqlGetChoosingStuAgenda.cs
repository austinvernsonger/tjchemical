using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetChoosingStuAgenda:ISql
    {
        public SqlGetChoosingStuAgenda()
        { 
        }

        #region ISql 成员

        public string GetSql()
        {
            return "select * from TeachingManageInfo as tm inner join TeachingSchoolInfo as ts on tm.TeaSchoolID=ts.TeaSchoolID " +
                    "where TeaMagType=2 and convert(varchar(10),getdate(),120) between (EndTime+1) and (EndTime + 15)";
        }

        #endregion
    }
}
