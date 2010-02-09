using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMBL.Interface.Database;
namespace StudentFile.Sql
{
    class SqlDeleteArchivesNew : OldtoNewSql
    {
        public void GetID(Int64 ID,String StudentID)
        {
            this.key = new object[] { "@ID", "@StudentID" };
            this.value = new object[] { ID, StudentID.Trim() };
        }
        public override string GetSql()
        {
            return "Delete from ArchivesNew where ID = @ID and StudentID = @StudentID";
        }
    }
}
