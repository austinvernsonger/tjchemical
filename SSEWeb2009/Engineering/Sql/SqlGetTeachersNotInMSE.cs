using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetTeachersNotInMSE:ISql
    {
        public SqlGetTeachersNotInMSE()
        { }

        #region ISql 成员

        public string GetSql()
        {
            return "select TeacherID,Name from Teacher where TeacherID not in (select UserID from Users)";
        }

        #endregion
    }
}
