using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlUpdateStuInfo:ISql
    {
        private StudentInfo _stuInfo;

        public SqlUpdateStuInfo(StudentInfo stuInfo)
        {
            _stuInfo = stuInfo;
        }

        #region ISql 成员

        public string GetSql()
        {
            string sql = "update Student set Name='" + _stuInfo.StuName + "'";
            if (_stuInfo.Grade != null)
            {
                sql = sql + ",Grade='"+_stuInfo.Grade+"'";
            }
            if (_stuInfo.Birthday != null)
            {
                sql = sql + ",Birthday='" + Convert.ToDateTime(_stuInfo.Birthday) + "'"; 
            }
            if (_stuInfo.Gender != -1)
            {
                sql = sql + ",Gender='" + _stuInfo.Gender + "'";
            }
            if (_stuInfo.StuIDNumber != null)
            {
                sql = sql + ",IDNumber='" + _stuInfo.StuIDNumber + "'";
            }
            if (_stuInfo.Nation != null)
            {
                sql = sql + ",Nation='" + _stuInfo.Nation + "'";
            }
            if (_stuInfo.NativePro != null)
            {
                sql = sql + ", NativeProvince='" + _stuInfo.NativePro + "'";
            }
            if (_stuInfo.PolStatus != null)
            {
                sql = sql + ",PoliticalStatus='"+_stuInfo.PolStatus+"'";
            }
            if (_stuInfo.MarStatus != -1)
            {
                sql = sql + ",MaritalStatus='"+_stuInfo.MarStatus+"'";
            }
            if (_stuInfo.EmailAddress != null)
            {
                sql = sql + ",EmailAddress='"+_stuInfo.EmailAddress+"'";
            }
            if (_stuInfo.OrigDegree != null)
            {
                sql = sql + ",OrigDegree='" + _stuInfo.OrigDegree + "'";
            }
            if (_stuInfo.MobPhone != null)
            {
                sql = sql + ", MobilePhone='"+_stuInfo.MobPhone+"'";
            }
            if (_stuInfo.FixedPhone != null)
            {
                sql = sql + ",FixedPhone='"+_stuInfo.FixedPhone+"'";
            }
            if (_stuInfo.Address != null)
            {
                sql = sql + ",Address='"+_stuInfo.Address+"'";
            }
            if (_stuInfo.HomeAddress != null)
            {
                sql = sql + ", HomeAddress='"+_stuInfo.HomeAddress+"'";
            }
            if (_stuInfo.PostalCode != null)
            {
                sql = sql + ",PostalCode='"+_stuInfo.PostalCode+"'";
            }
            if (_stuInfo.Schooling != null)
            {
                sql = sql + ",LengthOfSchooling='"+_stuInfo.Schooling+"'";
            }
            if (_stuInfo.Degree != null)
            {
                sql = sql + ",Degree='"+_stuInfo.Degree+"'";
            }
            sql = sql + " where StudentID='" + _stuInfo.StuID + "'";
            return sql;
        }

        #endregion
    }
}
