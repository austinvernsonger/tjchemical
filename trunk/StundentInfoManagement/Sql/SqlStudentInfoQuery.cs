using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMBL.Interface.Database;
namespace StundentInfoManagement.Sql
{
    class SqlStudentInfoQuery : OldtoNewSql
    {
        private String returnString;
        public void GetCondition(String strStudentID, String strName, String strNation, String strDepartment,
        String strField, String strEntranceYear,String strStudentType, String strGraduationType, String strWorkUnit)
        {
            this.key = new object[] {"@StudentID","@Name","@Nation","@Department","@Field","@EntranceYear","@StudentType","@GraduationType","@WorkUnit"};
            this.value = new object[] {strStudentID.Trim(),strName.Trim(),strNation.Trim(),strDepartment.Trim(),strField.Trim(),strEntranceYear.Trim(),strStudentType.Trim(),strGraduationType.Trim(),strWorkUnit.Trim() };
        }
        public override string GetSql()
        {
            return "select StudentID, Name, Nation, DepartmentID,WorkUnitID,Major,EntryYear,TypeofStudent,GraduationType from Student where StudentID like @StudentID and Name like @Nmae and Nation like @Nation and DepartmentID like @Department and Major like @Field and EntryYear like @EntranceYear and TypeofStudent like @StudentType and GraduationType like @Graduation and WorkUnitID like @WorkUnitID";
        }
    }
}
