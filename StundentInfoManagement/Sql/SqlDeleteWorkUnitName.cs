using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMBL.Interface.Database;
namespace StundentInfoManagement.Sql
{
    class SqlDeleteWorkUnitName : OldtoNewSql
    {
        public void GetSelectedID(string Id)
        {
            this.key = new object[] { "@WorkUnitID" };
            this.value = new object[] { Id.Trim() };
        }
        public override string GetSql()
        {
            return "Delete from [WorkUnit] where WorkUnitID = @WorkUnitID";
        }
    }
}
