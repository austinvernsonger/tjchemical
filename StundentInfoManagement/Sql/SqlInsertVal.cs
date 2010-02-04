using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMBL.Interface.Database;
namespace StundentInfoManagement.Sql
{
    class SqlInsertVal : OldtoNewSql
    {
        public void GetContent(String ID,String strContent,Int16 val)
        {
            this.key = new object[] { "@Id", "@Content", "@Val" };
            this.value = new object[] { ID.Trim(), strContent.Trim(), val };
        }
        public override string GetSql()
        {
            return "Update Student Set Remark=@Content, Validity=@Val Where StudentID=@Id";
        }
    }
}
