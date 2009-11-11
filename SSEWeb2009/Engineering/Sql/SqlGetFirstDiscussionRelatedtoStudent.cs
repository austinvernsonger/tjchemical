using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetFirstDiscussionRelatedtoStudent:ISql
    {
        private string _studentID;
        private int _category;

        public SqlGetFirstDiscussionRelatedtoStudent(string studentID, int category)
        {
            _studentID = studentID;
            _category = category;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "select *,left(DisplayOrder,23)as parentOrder from Discussion where (left(Communicators,10)='"+_studentID+"' or right(Communicators,10)='"+_studentID+"') and Category='"+_category+"' and len(DisplayOrder)/23=1";
        }

        #endregion
    }
}
