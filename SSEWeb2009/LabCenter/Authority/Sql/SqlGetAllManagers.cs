using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace LabCenter.Authority.Sql
{
    class SqlGetAllManagers:ISql
    {
        public SqlGetAllManagers()
        {
        }
        #region ISql ≥…‘±

        public string GetSql()
        {
            return "select MemberID,Name from ManagerInfo where IsSuper='0'";
        }

        #endregion
    }
}
