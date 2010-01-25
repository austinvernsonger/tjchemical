using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMBL.Interface.Database;
namespace StundentInfoManagement.Sql
{
    class SqlAddWorkUnitName : OldtoNewSql
    {
        public void GetWorkUnitName(string WuN)
        {
            this.key = new object[] { "@WorkUnitName" };
            this.value = new object[] { WuN.Trim() };
        }
        public override string GetSql()
        {
            return "Insert into [WorkUnit] (WorkUnitName) values (@WorkUnitName)";
        }
    }
}
