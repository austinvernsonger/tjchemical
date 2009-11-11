using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace LabCenter.Equipment.Sql
{
    class SqlGetOpenDevice : ISql
    {
        #region ISql ≥…‘±

        public string GetSql()
        {
            return "select * from OpenDeviceList";
        }

        #endregion
    }
}
