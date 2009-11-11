using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace LabCenter.LabUtility.PublicUtility
{
    class SqlGetTeacherName : ISql
    {
        public SqlGetTeacherName(string tid)
        {
            id = tid;
        }
        
        string id;

        public string GetSql()
        {
            return "select * from Teacher where TeacherID = '" + id + "'";
        }
    }
}
