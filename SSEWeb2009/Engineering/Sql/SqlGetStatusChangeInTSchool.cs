using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetStatusChangeInTSchool : ISql
    {
        private int _teaSchoolID;
        private string _applyCategory;

        public SqlGetStatusChangeInTSchool(int teaSchoolID, string applyCategory)
        {
            _teaSchoolID = teaSchoolID;
            _applyCategory = applyCategory;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "select StuID,Name,Grade,ApplyCategory,ApplyTime,BackTime from StuStatusChangeInfo as ss "+
                   "inner join Student as s on ss.StuID = s.StudentID inner join StudentMSE as sm "+
                   "on s.StudentID = sm.StudentID where ApplyResult = 1 and "+
                   "TeaSchoolID = '"+ _teaSchoolID +"' and ApplyCategory = '"+ _applyCategory +"'";
        }


        #endregion
     }
}
