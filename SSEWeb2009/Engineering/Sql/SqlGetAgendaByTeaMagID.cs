using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetAgendaByTeaMagID:ISql
    {
        private int _teaMagID;

        public SqlGetAgendaByTeaMagID(int teaMagID)
        {
            _teaMagID = teaMagID;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "select * from TeachingManageInfo where TeaMagID='"+_teaMagID+"'";
        }

        #endregion
    }
}
