using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace LabCenter.Equipment.Sql
{
    class SqlTest:ISql
    {
        public string GetSql()
        {
            return "insert into test values('abc','abc')";
        }
    }
}
