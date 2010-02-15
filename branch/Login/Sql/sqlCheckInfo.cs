using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;
namespace SysCom.Sql
{
    public class sqlCheckInfo : OldtoNewSql
    {
        #region ISql 成员

        public override string GetSql()
        {
            return "SELECT * FROM Account WHERE AccountID=@AccountID";
        }

        #endregion


        public sqlCheckInfo(string Student_ID)
        {
            this.key = new Object[] { "@AccountID" };
            this.value = new Object[] {Student_ID.Trim()};
        }
    }
}
