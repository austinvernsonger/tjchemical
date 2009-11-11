using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetOutTeacherByUserID:ISql
    {
         private string _userID;

         public SqlGetOutTeacherByUserID(string userID)
        {
            _userID = userID;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "Select * from AttachmentInfo where CreateByUser='" + _userID + "' and Category=4";
        }

        #endregion
    }
}
