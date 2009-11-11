using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlUpdateAgendaConfirmStatus:ISql
    {
        private int _agendaID;

        public SqlUpdateAgendaConfirmStatus(int agendaID)
        {
            _agendaID = agendaID;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "update TeachingManageInfo Set confirmation=1 where TeaMagID='" + _agendaID + "'";
        }

        #endregion
    }
}
