using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;
namespace SysCom.Sql
{
    class SqlSelectTeacherExternal:ISql
    {
        #region ISql 成员
        private string SelectId;
        public void SetSelectId(string id)
        {
            SelectId = id;
        }
        public string GetSql()
        {
            return "select * from TeacherExternal where TeacherID = '" + SelectId + "'";
        }

        #endregion
    }
}
