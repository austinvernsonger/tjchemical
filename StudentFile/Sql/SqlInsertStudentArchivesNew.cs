using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMBL.Interface.Database;
namespace StudentFile.Sql
{
    class SqlInsertStudentArchivesNew : OldtoNewSql
    {
        public void GetContent(String strAddTime,String strContent,String strAddPeople,String strRemark,String strStudentID)
        {
            this.key = new object[] { "@AddTime", "@Content", "@AddPeople", "@Remark", "@StudentID" };
            this.value = new object[] { strAddTime.Trim(), strContent.Trim(), strAddPeople.Trim(), strRemark.Trim(), strStudentID.Trim() };
        }
        public override string GetSql()
        {
            return "Insert into [ArchivesNew] (AddTime,Content,AddPeople,Remark,StudentID) values (@AddTime,@Content,@AddPeople,@Remark,@StudentID)";
        }
    }
}
