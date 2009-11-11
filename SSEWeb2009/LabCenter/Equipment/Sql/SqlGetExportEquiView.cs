using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace LabCenter.Equipment.Sql
{
    class SqlGetExportEquiView : ISql
    {
        public SqlGetExportEquiView()
        {
        }
        #region ISql ≥…‘±

        public string GetSql()
        {
            return "select * from DeviceInfo";
        }

        #endregion
    }
}
