using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMBL.Interface.Database;
namespace StundentInfoManagement.Sql
{
    class SqlSelectStraitStudentByQuery : OldtoNewSql
    {
        private string returnstring;
        public void GetCondition(String ID,String strName,Int16 iClass,Int16 Degree)
        {
            this.key = new object[] { "@ID", "@Name", "@Class","@Degree" };
            this.value = new object[] { "%" + ID.Trim() + "%", "%" + strName.Trim() + "%",iClass, Degree };
            returnstring = "Select S.StudentID,S.Name,S.Class,P.StraitDegree from [Student] as S,[StraitStudentInfo] as P where S.StudentID = P.StudentID";
            if (ID != String.Empty)
            {
                returnstring += " and P.StudentID like @ID";
            }
            if (strName != String.Empty)
            {
                returnstring += " and S.Name like @Name";
            }
            if (iClass !=-1)
            {
                returnstring += " and S.Class = @Class";
            }
            if (Degree != -1)
            {
                returnstring += " and P.StraitDegree = @Degree";
            }
        }
        public override string GetSql()
        {
            return returnstring;
        }
    }
}
