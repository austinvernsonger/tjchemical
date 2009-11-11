using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetDiscussionByItemID:ISql
    {
        private int _itemID;

        public SqlGetDiscussionByItemID(int itemID)
        {
            _itemID = itemID;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "select * from Discussion where ItemID='"+_itemID+"'";
        }

        #endregion
    }
}
