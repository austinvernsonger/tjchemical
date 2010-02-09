using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMBL.Interface.Database;
namespace StudentFile.Sql
{
    class SqlSelectAllStudentFile : OldtoNewSql
    {
        public override string GetSql()
        {
            return "select S.StudentID,S.Name from [Student] as S,[Archives] as T where S.StudentID = T.StudentID";
        }
    }
}
