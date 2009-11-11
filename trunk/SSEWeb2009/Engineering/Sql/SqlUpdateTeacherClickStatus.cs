using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlUpdateTeacherClickStatus:ISql
    {
        private int _itemID;

        public SqlUpdateTeacherClickStatus(int itemID)
        { 
            _itemID = itemID;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "update Discussion set Status = Replace(Status,Right(Status,1),1) where ItemID='"+_itemID+"'";
        }

        #endregion
    }
}
