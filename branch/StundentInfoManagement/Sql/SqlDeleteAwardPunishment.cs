using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMBL.Interface.Database;
namespace StundentInfoManagement.Sql
{
    class SqlDeleteAwardPunishment : OldtoNewSql
    {
        public void GetID(String ID)
        {
            this.key = new object[] { "@ID" };
            this.value = new object[] { ID.Trim() };
        }
        public override string GetSql()
        {
            return "Delete from [RewardsPenalties] where ID = @ID";
        }
    }
}
