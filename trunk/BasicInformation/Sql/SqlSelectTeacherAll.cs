using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;
namespace SysCom.Sql
{
    class SqlSelectTeacherAll:ISql
    {
        #region ISql 成员

        public string GetSql()
        {
            return "select TeacherID,Name,Gender from Teacher";
        }

        #endregion
    }
}
