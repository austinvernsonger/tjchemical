using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;
namespace SysCom.Sql
{
    public class SqlGetActivityInformation : ISql
    {

        #region ISql 成员

        public string GetSql()
        {
            return "SELECT top 7 a.Title Title,b.StartTime StartTime,b.EndTime EndTime,b.Location Location,a.ID ID FROM Information a,InformationExtends b WHERE a.Mode='Activity' AND a.HasExtends='1' AND a.ID=b.InformationID AND a.State='0' ORDER BY a.LastModifyTime DESC";
        }

        #endregion


    }
}
