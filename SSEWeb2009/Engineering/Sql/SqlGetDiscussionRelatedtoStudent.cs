using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetDiscussionRelatedtoStudent:ISql
    {
        private string _studentID;
        private int _category;

        public SqlGetDiscussionRelatedtoStudent(string studentID, int category)
        {
            _studentID = studentID;
            _category = category;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "select * from Discussion where (left(Communicators,10)='" + _studentID + "' or right(Communicators,10)='" + _studentID + "') and Category='" + _category + "' order by CreatedDate desc";
        }

        #endregion
    }
}
