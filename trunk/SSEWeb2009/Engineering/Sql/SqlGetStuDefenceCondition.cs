using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetStuDefenceCondition:ISql
    {
        private string _stuid;

        public SqlGetStuDefenceCondition(string stuid)
        {
            _stuid = stuid;
        }


        #region ISql 成员

        public string GetSql()
        {
            return "select * from AttachmentInfo where CreateByUser='"+_stuid+"'";
        }

        #endregion
    }
}
