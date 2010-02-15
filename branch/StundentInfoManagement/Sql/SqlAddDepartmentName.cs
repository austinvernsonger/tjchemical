using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMBL.Interface.Database;
namespace StundentInfoManagement.Sql
{
    class SqlAddDepartmentName : OldtoNewSql
    {
        public void GetDepartmentName(string DpName)
        {
            this.key = new object[] { "@Departname" };
            this.value = new object[] { DpName.Trim() };
        }
        public override string GetSql()
        {
            return "Insert into [Department] (DepartmentName) values (@Departname)";
        }
    }
}
