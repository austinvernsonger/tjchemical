using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlAddCourse : ISql
    {
        private CourseInfo cInfo;

        public SqlAddCourse(CourseInfo Info)
        {
            cInfo = Info;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "insert into Course(CourseName, Target, CourseTime, ExamMode, InstruMode, Property, Category, Credit, CreditHour, Grade, TeaSchoolID, ClassPeriod,Place) " +
                   "values('" + cInfo.CourseName + "', '" + cInfo.Target + "','" + Convert.ToInt32(cInfo.CourseTime) + "','" + cInfo.ExamMode + "','" + cInfo.InstruMode + "','" + cInfo.Property + "','" + cInfo.Category + "','" + cInfo.Credit + "'" +
                   ",'" + cInfo.CreditHour + "','" + cInfo.Grade + "','" + cInfo.TeaSchoolID + "','"+cInfo.ClassPeriod+"','"+cInfo.Place+"')";
        }

        #endregion
    }
}
