using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetGradeByStuId:ISql
    {
        private string _stuId;

        public SqlGetGradeByStuId(string stuid)
        {
            _stuId = stuid;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "select Grade from Student where StudentID='"+_stuId+"'";
        }

        #endregion
    }
}
