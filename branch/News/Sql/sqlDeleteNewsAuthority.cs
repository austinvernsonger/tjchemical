using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace SysCom.Sql
{
    class sqlDeleteNewsAuthority: OldtoNewSql
    {
        public sqlDeleteNewsAuthority(String id)
        {
            this._id = id;
        }

        private String _id;

        #region ISql 成员

        public override string GetSql()
        {
            return "DELETE FROM NewsAuthority WHERE id='"+_id+"'";
        }

        #endregion
    }
}
