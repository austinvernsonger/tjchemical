using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlDelTeaChooseTime : ISql
    {
        private string _grade;
        private int _teaSchoolID;

        public SqlDelTeaChooseTime(string grade, int teaSchoolID)
        {
            _grade = grade;
            _teaSchoolID = teaSchoolID;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "Delete from TeachingManageInfo where TeaMagType=2 and Grade = '"+ _grade +"' and TeaSchoolID = '"+ _teaSchoolID +"'";
        }        
        
        #endregion
    }
}
