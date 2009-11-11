using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlAddStuMSEInfo : ISql
    {
        private string _stuID;
        private string _teaschoolID;

        public SqlAddStuMSEInfo(StudentInfo stu)
        {
            _stuID = stu.StuID;
            _teaschoolID = stu.TeaSchoolID;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "Insert into StudentMSE(StudentID, TeaSchoolID) values('" + _stuID + "', '" + _teaschoolID + "')";
        }

        #endregion
    }
}
