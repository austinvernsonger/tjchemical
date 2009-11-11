using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlDeleteTeachingAgendaByTeaMagID:ISql
    {
        private int _teaMagID;

        public SqlDeleteTeachingAgendaByTeaMagID(int teaMagID)
        {
            _teaMagID = teaMagID;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "Delete from TeachingManageInfo where TeaMagID='" + _teaMagID + "'";
        }

        #endregion
    }
}
