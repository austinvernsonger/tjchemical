using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetTeaChooseTimeByQInfoWithNull:ISql
    {
        public SqlGetTeaChooseTimeByQInfoWithNull()
        { }

        #region ISql 成员

        public string GetSql()
        {
            return "select distinct * from TeachingManageInfo as tm inner join TeachingSchoolInfo as ts on tm.TeaSchoolID = ts.TeaSchoolID where TeaMagType=2 order by StartTime desc";
        }

        #endregion
    }
}
