using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetAttachment:ISql
    {
        private string _userID;
        private int _category;

        public SqlGetAttachment(string userID, int category)
        {
            _userID = userID;
            _category = category;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "select * from AttachmentInfo where CreateByUser='" + _userID + "' and Category='"+_category+"'";
        }

        #endregion
    }
}
