using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlAddUsers : ISql
    {
        private StudentInfo stuInfo;

        public SqlAddUsers(StudentInfo stu)
        {
            stuInfo = stu;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "Insert into Users(UserID, UserName) values('"+stuInfo.StuID+"', '"+stuInfo.StuName+"')";
        }

        #endregion
    }
}
