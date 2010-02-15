using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMBL.Interface.Database;
namespace StudentFile.Sql
{
    class SqlDeleteStudentArchivesContent : OldtoNewSql 
    {
        public void GetID(String Title,String ID)
        {
            this.key = new object[] { "@Title","@ID" };
            this.value = new object[] { Title.Trim(),ID.Trim() };
        }
        public override string GetSql()
        {
            return "Delete from [ArchivesContent] where ContentTitle = @Title and StudentID = @ID";
        }
    }
}
