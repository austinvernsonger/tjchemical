using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace SysCom.Sql
{
    class sqlDeleteNewsAuthority:ISql
    {
        public sqlDeleteNewsAuthority(String id)
        {
            this._id = id;
        }

        private String _id;

        #region ISql 成员

        public string GetSql()
        {
            return "DELETE FROM NewsAuthority WHERE id='"+_id+"'";
        }

        #endregion
    }
}
