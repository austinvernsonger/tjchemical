using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMBL.Interface.Database;
namespace StudentFile.Sql
{
    class SqlSelectStudentArchivesContent : OldtoNewSql
    {
        public void GetID(String ID)
        {
            this.key = new object[] { "@ID" };
            this.value = new object[] { ID.Trim() };
        }
        public override string GetSql()
        {
            return "Select * from [ArchivesContent] where StudentID = @ID";
        }
    }
}
