using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlAddFinalPaperByStu:ISql
    {
        private string _studentID;
        private string _path;
        private string _title;

        public SqlAddFinalPaperByStu(string studentID, string path, string title)
        {
            _studentID = studentID;
            _path = path;
            _title = title;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "insert into AttachmentInfo(AttachName, CreateTime, CreateByUser, LastModifyTime, AttachNameUrl, Category) " +
                "values('" + _title + "', '" + System.DateTime.Now + "', '" + _studentID + "','" + System.DateTime.Now + "','" + _path + "',5)";
        }

        #endregion
    }
}
