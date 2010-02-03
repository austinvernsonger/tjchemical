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
        public void GetCondition(String strStudentID, String strName, String strNation, Int16 strDepartment,
        String strField, Int32 strEntranceYear,Int16 strStudentType, Int16 strGraduationType, Int16 strWorkUnit)
        {
            this.key = new object[] {"@StudentID","@Name","@Nation","@Department","@Field","@EntranceYear","@StudentType","@GraduationType","@WorkUnit"};
            this.value = new object[] {strStudentID.Trim(),strName.Trim(),strNation.Trim(),strDepartment,strField.Trim(),strEntranceYear,strStudentType,strGraduationType,strWorkUnit };
            returnString = "select StudentID, Name, Nation, DepartmentID,WorkUnitID,Major,EntryYear,TypeofStudent,GraduationType from Student where 1=1";
            if (strStudentID.Trim() != String.Empty)
            {
                returnString += " and StudentID like @StudentID";
            }
            if (strName.Trim() != String.Empty)
            {
                returnString += " and Name like @Name";
            }
            if (strNation.Trim() != String.Empty)
            {
                returnString += " and Nation like @Nation";
            }
            if (strDepartment != -1)
            {
                returnString += " and DepartmentID = @Department";
            }
            if (strField != String.Empty)
            {
                returnString += " and Major like @Field";
            }
            if (strEntranceYear != 0)
            {
                returnString += " and EntryYear = @EntranceYear";
            }
            if (strStudentType != -1)
            {
                returnString += " and TypeofStudent = @StudentType";
            }
            if (strGraduationType != -1)
            {
                returnString += " and GraduationType = @GraduationType";
            }
            if (strWorkUnit != -1)
            {
                returnString += " and WorkUnitID = @WorkUnit";
            }
        }
        public override string GetSql()
        {
            
            return returnString;
        }
    }
}
