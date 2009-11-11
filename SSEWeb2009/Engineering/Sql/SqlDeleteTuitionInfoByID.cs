using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlDeleteTuitionInfoByID:ISql
    {
        private int _tuitionID;

        public SqlDeleteTuitionInfoByID(int ID)
        {
            _tuitionID = ID;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "Delete from TuitionInfo where TuitionID='" + _tuitionID + "'";
        }

        #endregion
    }
}
