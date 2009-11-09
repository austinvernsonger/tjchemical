using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace SysCom.Sql
{
    class SqlGetStudentTable : ISql
    {

        public string GetSql()
        {
            return "SELECT Name,StudentID,Gender,Major,LengthOfSchooling FROM Student";
        }

    }
}
