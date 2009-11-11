using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    public class SqlGetUnhandleStaApp : ISql
    {
        public SqlGetUnhandleStaApp()
        { }
        
        #region ISql 成员

        public string GetSql()
        {
            return "select * from StuStatusChangeInfo as ssc inner join Student as s on ssc.StuID = s.StudentID "+
                    "inner join StudentMSE as sm on s.StudentID=sm.StudentID inner join TeachingSchoolInfo as ts on ts.TeaSchoolID=sm.TeaSchoolID "+
                     "where ApplyResult=0 order by ApplyTime asc";
        }

        #endregion
        
    }
}
