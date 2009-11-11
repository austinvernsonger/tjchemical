using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace LabCenter.Equipment.Sql
{
    class SqlGetEquipView : ISql
    {
        public SqlGetEquipView()
        {
        }
        #region ISql ≥…‘±

        public string GetSql()
        {
            return "select DeviceId, DeviceName, Status, Location,[User],Account from DeviceInfo";
        }

        #endregion
    }
}
