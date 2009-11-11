using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlAddDefenceApplication:ISql
    {
        private string _stuid;

        public SqlAddDefenceApplication(string stuid)
        {
            _stuid = stuid;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "insert into DefenceApplicationStatus(StudentID, CreatedTime) values('" + _stuid + "',getdate())";
        }

        #endregion
    }
}
