using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMBL.Interface.Database;
namespace StundentInfoManagement.Sql
{
    class SqlSelectAllAwardPunishmentStudent : OldtoNewSql
    {
        public override string GetSql()
        {
            return "Select S.StudentID,S.Name,S.Class,R.ID from [Student] as S,[RewardsPenalties] as R where S.StudentID = R.StudentID";
        }
    }
}
