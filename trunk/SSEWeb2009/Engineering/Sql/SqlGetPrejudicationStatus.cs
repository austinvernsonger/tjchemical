using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetPrejudicationStatus:ISql
    {
        public SqlGetPrejudicationStatus()
        { }

        #region ISql 成员

        public string GetSql()
        {
            return "select * from DefenceApplicationStatus as da inner join AttachmentInfo as ai on da.StudentID=ai.CreateByUser inner join Student as s on s.StudentID=da.StudentID where IsAnswered=1 and IsQualified=0 and Category=5";
        }

        #endregion
    }
}
