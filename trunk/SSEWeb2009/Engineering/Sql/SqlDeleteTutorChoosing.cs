using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlDeleteTutorChoosing:ISql
    {
        private string _stuid;

        public SqlDeleteTutorChoosing(string stuid)
        {
            _stuid = stuid;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "Delete from TutorChooseInfo where StuID = '" + _stuid + "'";
        }

        #endregion
    }
}
