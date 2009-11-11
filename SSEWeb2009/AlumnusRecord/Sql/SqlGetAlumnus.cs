using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace AlumnusRecord.Sql
{
    class SqlGetAlumnus : ISql
    {
        private string m_StudentID;

        public SqlGetAlumnus(string ID)
        {
            m_StudentID = ID; 
        }





        #region ISql 成员

        public string GetSql()
        {
            return "SELECT Name, StudentID, Origin,TeachingPoint,GraduateYear,WorkPlace,WorkAddress,Phone,Email,Summary,Publicity,Degree from Graduate where StudentID = '" + m_StudentID + "'";
        }

        #endregion
    }
}
