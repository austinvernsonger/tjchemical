﻿using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace SysCom.Sql
{
    public class sqlGetAuthority:ISql
    {

        public sqlGetAuthority(String id)
        {
            this._id = id;
        }

        private String _id;


        #region ISql 成员

        public string GetSql()
        {
            return "SELECT * FROM NewsAuthority WHERE Id='" + _id + "'";
        }

        #endregion
    }
}
