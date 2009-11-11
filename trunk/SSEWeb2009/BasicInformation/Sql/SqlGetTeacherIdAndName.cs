using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;
namespace SysCom.Sql
{
    class SqlGetTeacherIdAndName:ISql
    {

        #region ISql 成员

        public string GetSql()
        {
           return "SELECT TeacherID,Name FROM Teacher";
        }

        #endregion


    }


}
