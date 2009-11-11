using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetStatusAppInfo:ISql
    {
        private string _stuID;

        public SqlGetStatusAppInfo(string stuID)
        {
            _stuID = stuID;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "select max(StuStatusID) from StuStatusChangeInfo where StuID='"+_stuID+"'";
        }

        #endregion
    }
}
