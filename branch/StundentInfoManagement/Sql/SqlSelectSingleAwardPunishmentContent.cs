using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMBL.Interface.Database;
namespace StundentInfoManagement.Sql
{
    class SqlSelectSingleAwardPunishmentContent : OldtoNewSql
    {
        public void GetID(String ID)
        {
            this.key = new object[] { "@ID" };
            this.value = new object[] { ID.Trim() };
        }
        public override string GetSql()
        {
            return "Select R.StudentID,S.Name,R.Type,R.ApplyTime,R.Context from [Student] as S,[RewardsPenalties] as R where S.StudentID = R.StudentID and R.ID = @ID";
        }
    }
}
