using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    /// <summary>
    /// 获得选课的时间安排
    /// </summary>
    class SqlGetCourTimeForChosing:ISql
    {
        private string studentID;

        public SqlGetCourTimeForChosing(string stuID)
        {
            studentID = stuID;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "select distinct t.* from TeachingManageInfo as t inner join StudentMSE as se on se.TeaSchoolID = t.TeaSchoolID "+
                    "inner join Student as s on t.Grade=s.Grade where s.StudentID='" + studentID + "' and t.TeaMagType = 1 and convert(varchar(10),getdate(),120) between StartTime and EndTime";
        }

        #endregion
    }
}
