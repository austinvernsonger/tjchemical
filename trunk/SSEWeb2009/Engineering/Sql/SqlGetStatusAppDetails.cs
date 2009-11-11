using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
   public class SqlGetStatusAppDetails : ISql
    {
       private string _studentId;
       public SqlGetStatusAppDetails(string studID)
       {
           _studentId = studID;
       }

       #region ISql 成员

       public string GetSql()
       {
           return "select * from StuStatusChangeInfo where StuID ='"+_studentId+"'";
       }

       #endregion
    }
}
