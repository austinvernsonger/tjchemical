using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlDeleteStudentAttachment:ISql
    {
        private string _studentID;

        public SqlDeleteStudentAttachment(string studentID)
        {
            _studentID = studentID;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "delete from AttachmentInfo where CreateByUser ='" + _studentID + "'";
        }

        #endregion
    }
}
