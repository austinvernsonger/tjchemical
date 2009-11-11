using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace LabCenter.Equipment.Sql
{
    class SqlGetDeviceApplyTableView : ISql
    {
        public SqlGetDeviceApplyTableView()
        {
        }
        #region ISql ≥…‘±

        public string GetSql()
        {
            return "select * from DeviceApplyTable";
        }

        #endregion
    }
}
