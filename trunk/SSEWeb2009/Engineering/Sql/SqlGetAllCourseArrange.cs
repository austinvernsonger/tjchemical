using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetAllCourseArrange:ISql
    {
        public SqlGetAllCourseArrange()
        { }

        #region ISql 成员

        public string GetSql()
        {
            DateTime dtNow = System.DateTime.Now.Date;
            string sql = "select (EndTime+1) as eTime,* from TeachingManageInfo as tm inner join TeachingSchoolInfo as ts on ts.TeaSchoolID=tm.TeaSchoolID where TeaMagType=1 and '" + dtNow + "' > EndTime and confirmation=0";
            return sql;
        }

        #endregion
    }
}
