using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlAddAccount : ISql
    {
        private string stuID;
        private string password;

        public SqlAddAccount(StudentInfo stu)
        {
            stuID = stu.StuID;
            password = stu.Password;
        }

        #region ISql 成员

        //该SQL语句中的AccountStatus,EmailValidation字段可能会更改
        public string GetSql()
        {
            return "insert into Account(AccountID,Password,AccountState,EmailValidation) values('" + stuID + "','" + password + "',0,1)";
        }

        #endregion
    }
}
