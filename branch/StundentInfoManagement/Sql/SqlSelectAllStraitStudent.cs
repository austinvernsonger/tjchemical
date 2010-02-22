using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMBL.Interface.Database;

namespace StundentInfoManagement.Sql
{
    class SqlSelectAllStraitStudent : OldtoNewSql
    {
        public override string GetSql()
        {
            return "Select S.StudentID,S.Name,P.StraitDegree from [Student] as S,[StraitStudentInfo] as P where S.StudentID = P.StudentID";
        }
    }
}
