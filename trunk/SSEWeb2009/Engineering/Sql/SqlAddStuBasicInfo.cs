using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlAddStuBasicInfo : ISql
    {
        private StudentInfo stuInfo;
        public SqlAddStuBasicInfo(StudentInfo stu)
        {
            stuInfo = stu;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "Insert into Student(StudentID, Name, Gender, LengthOfSchooling, Degree, Major, Grade) values('" + stuInfo.StuID + "', '"+stuInfo.StuName+"', '"+stuInfo.Gender+"','"+stuInfo.Schooling+"','"+stuInfo.Degree+"','"+stuInfo.Major+"','"+stuInfo.Grade+"')";
        }

        #endregion
    }
}
