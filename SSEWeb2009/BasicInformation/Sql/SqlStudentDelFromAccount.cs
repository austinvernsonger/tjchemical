using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace SysCom.Sql
{
    class SqlStudentDelFromoAccount : ISql
    {
        private String StudentID;
        public SqlStudentDelFromoAccount(String ID)
        {
            StudentID = ID;
        }

        public string GetSql()
        {
            return ("delete from Account where AccountID='" + StudentID + "'");
        }
    }
}
