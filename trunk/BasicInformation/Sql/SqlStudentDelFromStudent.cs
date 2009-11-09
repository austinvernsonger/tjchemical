using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace SysCom.Sql
{
    class SqlStudentDelFromStudent : ISql
    {
        private String StudentID;
        public SqlStudentDelFromStudent(String ID)
        {
            StudentID = ID;
        }

        public string GetSql()
        {
            return ("delete from Student where StudentID='" + StudentID + "'");
        }
    }
}
