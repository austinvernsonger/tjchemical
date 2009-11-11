using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetChildMessage:ISql
    {
        private string _parentDisplayOrder;
        private string _studentID;

        public SqlGetChildMessage(string parentDisplayOrder,string studentID)
        {
            _parentDisplayOrder = parentDisplayOrder;
            _studentID = studentID;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "select * from Discussion where left(DisplayOrder,23)='" + _parentDisplayOrder + "' and (len(DisplayOrder)/23)>1 and (left(Communicators,10)='" + _studentID + "' or right(Communicators,10)='" + _studentID + "') order by CreatedDate desc";
        }

        #endregion
    }
}
