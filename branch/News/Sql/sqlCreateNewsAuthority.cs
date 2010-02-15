using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace SysCom.Sql
{
    public class sqlCreateNewsAuthority: OldtoNewSql
    {
        public sqlCreateNewsAuthority(String id,String name)
        {
            this._id = id;
            this._name = name;
        }

        private String _id;
        private String _name;

        #region ISql 成员

        public override string GetSql()
        {
            return "INSERT INTO NewsAuthority (id,name)VALUES('" + _id + "','" + _name + "')";
        }

        #endregion
    }
}
