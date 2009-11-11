using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetTeaChooseTimeByStu:ISql
    {
        private string _studentID;

        public SqlGetTeaChooseTimeByStu(string studentID)
        {
            _studentID = studentID;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "select  * from TeachingManageInfo as tm inner join Student as s on s.Grade=tm.Grade inner join StudentMSE as sm on s.StudentID=sm.StudentID and sm.TeaSchoolID=tm.TeaSchoolID where s.StudentID='" + _studentID + "'  and TeaMagType=2 and convert(varchar(10),getdate(),120) between StartTime and EndTime ";
        }

        #endregion
    }
}
