using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlUpdateStudentPicture:ISql
    {
        private string _studentID;
        private string _path;

        public SqlUpdateStudentPicture(string studentID, string path)
        {
            _studentID = studentID;
            _path = path;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "update AttachmentInfo set AttachNameUrl = '" + _path + "' where CreateByUser='" + _studentID + "' and Category=6";
        }

        #endregion
    }
}
