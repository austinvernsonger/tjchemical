using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMBL.Interface.Database;
namespace StundentInfoManagement.Sql
{
    class SqlSelectStraitStudentBasicInfo : OldtoNewSql
    {
        public void GetID(String ID)
        {
            this.key = new object[] { "@ID" };
            this.value = new object[] { ID.Trim() };
        }
        public override string GetSql()
        {
            return "Select S.Name,P.RegisteredResidenceBeforeSchool,P.FamilyMemberNum,P.FamilySalary,P.DiBao,P.GuCan,P.SingleParent,P.MartyrChild,P.Apply,P.ExplainThings,P.StraitDegree from [Student] as S,[StraitStudentInfo] as P where P.StudentID = @ID and S.StudentID = P.StudentID";
        }
    }
}
