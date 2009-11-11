using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlDeleteRolesAoutUserID:ISql
    {
        private string _userID;

        public SqlDeleteRolesAoutUserID(string userID)
        {
            _userID = userID;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "Delete from UserRoles where UseId='" + _userID + "'";
        }

        #endregion
    }
}
