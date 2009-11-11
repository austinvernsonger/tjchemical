using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace LabCenter.LabUtility.PublicUtility
{
    class SqlGetStudentName:ISql
    {
        public SqlGetStudentName(string sid)
        {
            id = sid;
        }
        
        string id;

        public string GetSql()
        {
            return "select * from Student where StudentID = '" + id + "'";
        }
    }
}
