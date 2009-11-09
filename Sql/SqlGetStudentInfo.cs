using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace SysCom.Sql
{
    class SqlGetStudentInfo : ISql
    {
        private String StudentID;
        public SqlGetStudentInfo(String ID)
        {
            StudentID = ID;
        }

        public string GetSql()
        {
            return "SELECT * FROM Student where StudentID='" + StudentID + "'";
        }

    }
}
