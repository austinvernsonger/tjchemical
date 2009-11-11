using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetTuitionInfobyTermStu:ISql
    {
        private string _term;
        private string _stuID;

        public SqlGetTuitionInfobyTermStu(string term, string stuID)
        {
            _term = term.Trim();
            _stuID = stuID.Trim();
        }

        #region ISql 成员

        public string GetSql()
        {
            return "select * from TuitionInfo where StuID='" + _stuID + "' and PaymentTerm='"+_term+"'";
        }

        #endregion 
    }
}
