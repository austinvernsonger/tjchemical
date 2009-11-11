using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetStudentPicture:ISql
    {
        private string _studentID;

        public SqlGetStudentPicture(string studentID)
        {
            _studentID = studentID;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "select * from AttachmentInfo where CreateByUser='" + _studentID + "' and Category=6";
        }

        #endregion
    }
}
