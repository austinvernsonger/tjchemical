using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMBL.Interface.Database;
namespace StudentFile.Sql
{
    class SqlDeleteStudentFile : OldtoNewSql
    {
        public void GetID(String ID)
        {
            this.key = new object[] { "@Id" };
            this.value = new object[] { ID.Trim() };
        }
        public override string GetSql()
        {
            return "delete from [Archives] where StudentID = @Id";
        }
    }
}
