﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMBL.Interface.Database;
namespace StundentInfoManagement.Sql
{
    class SqlSelectAllWorkUnitName : OldtoNewSql
    {
        public override string GetSql()
        {
            return "select * from [WorkUnit]";
        }
    }
}
