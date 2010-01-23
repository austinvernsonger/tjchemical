using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;
namespace SysCom.Sql
{
    public class sqlAdminInfo : OldtoNewSql
    {
        #region ISql 成员

        public override string GetSql()
        {
            return "SELECT * FROM Admin WHERE Admin=@Admin";
        }

        #endregion


        public sqlAdminInfo(string Student_ID)
        {
            this.key = new Object[] { "@Admin" };
            this.value = new Object[] { Student_ID.Trim() };
        }
    }
}
