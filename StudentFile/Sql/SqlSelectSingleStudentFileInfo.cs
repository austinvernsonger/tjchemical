using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMBL.Interface.Database;
namespace StudentFile.Sql
{
    class SqlSelectSingleStudentFileInfo : OldtoNewSql
    {
        public void GetID(String ID)
        {
            this.key = new object[] { "@ID" };
            this.value = new object[] { ID.Trim() };
        }
        public override string GetSql()
        {
            return "Select S.Name, S.NativeProvince, S.StudentSource, S.Party, P.CYLdata, P.CCPdata, P.BuildingDate, P.ArchivesSource, P.ArchivesGetMethod, P.GraduationTime, P.ArchivesSendDate,P.UnitName, P.UnitAddress, P.UnitCode, P.UnitLinkman, P.UnitTele, P.HowToSend, P.IfKeepArchives, P.KeepStartDate from [Student] as S,[Archives] as P where S.StudentID = P.StudentID and P.StudentID = @ID";
        }
    }
}
