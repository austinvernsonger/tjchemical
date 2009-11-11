using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlUpdateStudentMSE:ISql
    {
        private StudentInfo _stuInfo;

        public SqlUpdateStudentMSE(StudentInfo stuInfo)
        {
            _stuInfo = stuInfo;
        }

        #region ISql 成员

        public string GetSql()
        {
            string sql = "update StudentMSE set StudentID='"+_stuInfo.StuID+"'";
            if (_stuInfo.TeaSchoolID != null)
            {
                sql = sql + ", TeaSchoolID='" + _stuInfo.TeaSchoolID + "'";
            }
            if (_stuInfo.WorkPlace != null)
            {
                sql = sql + ",Company='"+_stuInfo.WorkPlace+"'";
            }
            if (_stuInfo.WorkPlaceAdd != null)
            {
                sql = sql + ", CompanyAddress='"+_stuInfo.WorkPlaceAdd+"'";
            }
            sql = sql + " where StudentID='" + _stuInfo.StuID + "'";
            return sql;
        }

        #endregion
    }
}
