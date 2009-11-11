using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    public class SqlGetTutorOfStds : ISql
    {
        private ChosenTutor _ct;
        private string sql = "";

        public SqlGetTutorOfStds(ChosenTutor ct)
        {
            _ct = ct;

        }

        #region ISql 成员

        /// <summary>
        /// 这边如何修改成用outer join!!!
        /// </summary>
        /// <returns></returns>
        public string GetSql()
        {
            sql = "select s.StudentID, s.Name as sName, s.Gender, Grade, TeaSchoolName, Degree, t.Name as tName " +
                  "from Student as s inner join StudentMSE as se on s.StudentID = se.StudentID " +
                  "inner join Teacher as t on t.TeacherID = se.TeacherID inner join " +
                  "TeachingSchoolInfo as ts on ts.TeaSchoolID = se.TeaSchoolID where 1=1"; 
            if (_ct.StudentID != null )
            {
                sql = sql + " and s.StudentID='" + _ct.StudentID + "'";
            }
            if (_ct.TeaSchoolID != -1)
            {
                sql = sql + " and ts.TeaSchoolID='" + _ct.TeaSchoolID + "'";
            }
            if (_ct.Grade != null)
            {
                sql = sql + " and Grade='" + _ct.Grade + "'";
            }
           
            return sql;
        }
        #endregion

    }
}
