﻿using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetAllRoles:ISql
    {
        public SqlGetAllRoles()
        { }

        #region ISql 成员

        public string GetSql()
        {
            return "select * from Roles";
        }

        #endregion
    }
}