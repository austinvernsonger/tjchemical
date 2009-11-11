using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlAddStudentPic:ISql
    {
        private string _studentID;
        private byte[] _fileStream;

        public SqlAddStudentPic(string studentID, byte[] fileStream)
        {
            _studentID = studentID;
            _fileStream = fileStream;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "update StudentMSE Set StudentMSE = '"+_fileStream+"'";
        }

        #endregion
    }
}
