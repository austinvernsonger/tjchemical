using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetPaperDiscussionLatestTime:ISql
    {
        private int _itemID;

        public SqlGetPaperDiscussionLatestTime(int itemID)
        {
            _itemID = itemID;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "select (select max(CreatedDate) from Discussion as d2 where left(d2.DisplayOrder,len(rtrim(d.DisplayOrder)))=d.DisplayOrder) " +
                    "as MaxTime from Discussion as d where ItemID='"+_itemID+"'";
        }

        #endregion
    }
}
