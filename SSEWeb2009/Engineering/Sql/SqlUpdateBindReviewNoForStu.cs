using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlUpdateBindReviewNoForStu:ISql
    {
        private string _studentID;
        private string _num;

        public SqlUpdateBindReviewNoForStu(string studentID, string num)
        {
            _studentID = studentID;
            _num = num;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "update StudentMSE Set BlindReviewNo='" + _num + "'  where StudentID = '" + _studentID + "'";
        }

        #endregion
    }
}
