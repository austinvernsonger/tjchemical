using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMBL.Interface.Database;
namespace StudentFile.Sql
{
    class SqlInsertStudentArchivesContent : OldtoNewSql
    {
        public void GetInsertContent(String strTitle, String strContent, String Remark, String ID)
        {
            this.key = new object[] { "@Title", "@Content", "@Remark", "@ID" };
            this.value = new object[] { strTitle.Trim(), strContent.Trim(), Remark.Trim(), ID.Trim() };
        }
        public override string GetSql()
        {
            return "Insert into [ArchivesContent] (ContentTitle,Content,Remark,StudentID) values (@Title,@Content,@Remark,@ID)";
        }
    }
}
