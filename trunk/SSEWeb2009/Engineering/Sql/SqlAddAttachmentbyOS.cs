using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlAddAttachmentbyOS:ISql
    {
        private string _createdByUser;
        private string _url;
        private string _fileName;

        public SqlAddAttachmentbyOS(string userId, string url, string fileName)
        {
            _createdByUser = userId;
            _url = url;
            _fileName = fileName;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "insert into AttachmentInfo(AttachName,CreateTime, CreateByUser, LastModifyTime, AttachNameUrl, Category) " +
                "values('"+_fileName+"','" + System.DateTime.Now + "', '" + _createdByUser + "','" + System.DateTime.Now + "','" + _url + "',1)  select SCOPE_IDENTITY() as id";
        }

        #endregion
    }
}
