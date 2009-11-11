using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetStudentsByTeaID:ISql
    {
        private string _teacherID;
        private QueryInfo _qInfo;
        private string sql = "";

        public SqlGetStudentsByTeaID(string teacherID, QueryInfo qInfo)
        {
            _teacherID = teacherID;
            _qInfo = qInfo;
        }

        #region ISql 成员

        public string GetSql()
        {
            sql = "select distinct s.StudentID, s.Name, s.Gender, s.Grade, t.TeaSchoolName, s.Degree from StudentMSE as sm "+
                    "inner join Student as s on s.StudentID = sm.StudentID inner join TeachingSchoolInfo as t on t.TeaSchoolID=sm.TeaSchoolID "+
                    "where TeacherID = '"+_teacherID+"'";
            if (_qInfo.AccountID != null)
            {
                sql = sql + " and s.StudentID='"+_qInfo.AccountID+"'";
            }
            if (_qInfo.Name != null)
            {
                sql = sql + " and s.Name='" + _qInfo.Name + "'";
            }
            if (_qInfo.Grade != null )
            {
                sql = sql + " and s.Grade='"+_qInfo.Grade+"'";
            }
            if ( _qInfo.TSchoolID != null)
            {
                sql = sql + " and t.TeaSchoolID='"+_qInfo.TSchoolID+"'"; 
            }

            return sql;
            
        }

        #endregion
    }
}
