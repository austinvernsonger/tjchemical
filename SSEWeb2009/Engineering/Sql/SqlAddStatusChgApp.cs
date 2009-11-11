using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    /// <summary>
    /// Funtion:Add StudStatusChangeApply
    /// parameter:studentID,applyCategory,applyReason,applyTime
    /// Author:Ansin
    /// </summary>
    public class SqlAddStatusChgApp : ISql
    {     
            private string studentID;
            private string applyCategory;
            private string applyReason;

            public SqlAddStatusChgApp(string studID, string appCategory, string appReason)
            {
                studentID = studID;
                applyCategory = appCategory;
                applyReason = appReason;
            }

            #region ISql 成员

            public string GetSql()
            {
                return "insert into StuStatusChangeInfo(StuID,ApplyCategory,ApplyTime,ApplyReason) " +
                                "values('" + studentID + "','" + applyCategory + "','" + System.DateTime.Now + "','" + applyReason + "')";
            }

            #endregion
       
    }
}
