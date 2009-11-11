using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlHasAuthority:ISql
    {
        private string _ID;
        private string _index;

        public SqlHasAuthority(string ID, string index)
        {
            _ID = ID;
            _index = index;
        }

         #region ISql 成员

        public string GetSql()
        {
            return "SELECT * FROM RoleFuncs as rf inner join Roles as r on rf.RoleID=r.RoleId inner join UserRoles as ur "+
                        "on ur.RoleID=r.RoleId inner join Users as u on u.UserID=ur.UseId inner join Funcs as f on  f.FuncID=rf.FuncID "+
                        "where u.UserID='" + _ID + "' and f.FuncID='"+_index+"'";
        }

        #endregion
    }
}
