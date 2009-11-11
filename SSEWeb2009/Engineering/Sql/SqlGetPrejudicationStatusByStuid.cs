using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetPrejudicationStatusByStuid:ISql
    {
        private string _stuid;

        public SqlGetPrejudicationStatusByStuid(string stuid)
        {
            _stuid = stuid;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "select s.Name as sName,t.Name as tName, * from DefenceApplicationStatus as da inner join "+
                        "AttachmentInfo as ai on da.StudentID=ai.CreateByUser inner join Student as s on s.StudentID=da.StudentID "+
                        "inner join StudentMSE as sm on sm.StudentID=s.StudentID inner join TeachingSchoolInfo as ts on ts.TeaSchoolID=sm.TeaSchoolID "+
                        "inner join Teacher as t on sm.TeacherID = t.TeacherID where IsAnswered=1 and IsQualified=0 and Category=5 and s.StudentID='"+_stuid+"'";
        }

        #endregion
    }
}
