using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetTuitionInfoByStudentID:ISql
    {

        private string _studentID;

        public SqlGetTuitionInfoByStudentID(string studentID)
        {
            _studentID = studentID;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "select PaymentTerm,MustMoney,ActualMoney,PaymentTime,Remark from TuitionInfo where StuID='" + _studentID + "' order by PaymentTime desc";
        }

        #endregion 
    }
}
