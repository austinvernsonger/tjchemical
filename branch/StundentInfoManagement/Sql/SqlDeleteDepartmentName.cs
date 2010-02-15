using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMBL.Interface.Database;
namespace StundentInfoManagement.Sql
{
    class SqlDeleteDepartmentName : OldtoNewSql
    {
        public void SetSelectedID(string id)
        {
            this.key = new object[] { "@Id" };
            this.value = new object[] { id.Trim() };
        }
        public override string GetSql()
        {
            return "delete from [Department] where DepartmentID = @Id";
        }
    }
}
