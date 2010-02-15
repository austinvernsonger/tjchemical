using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMBL.Interface.Database;
namespace StundentInfoManagement.Sql
{
    class SqlSelectStudentAccount : OldtoNewSql
    {
        public override string GetSql()
        {
            return "select S.AccountID, T.Name from [Account] as S, [Student] as T Where S.AccountID = T.StudentID";
        }
    }
}
