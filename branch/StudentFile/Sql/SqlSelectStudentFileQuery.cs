using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMBL.Interface.Database;
namespace StudentFile.Sql
{
    class SqlSelectStudentFileQuery : OldtoNewSql
    {
        private string returnstring;
        public void GetConditon(String ID,String strName)
        {
            this.key = new object[] { "@ID", "@Name" };
            this.value = new object[] { "%" + ID.Trim() + "%", "%" + strName.Trim() + "%" };
            returnstring = "select S.StudentID,S.Name from [Student] as S,[Archives] as T where S.StudentID = T.StudentID";
            if (ID!=String.Empty)
            {
                returnstring += " and T.StudentID like @ID";
            }
            if (strName!=String.Empty)
            {
                returnstring += " and S.Name like @Name";
            }
        }
        public override string GetSql()
        {
            return returnstring;
        }
    }
}
