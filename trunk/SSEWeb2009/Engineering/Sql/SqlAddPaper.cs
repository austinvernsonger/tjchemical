using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlAddPaper:ISql
    {
        private string _fileName;
        private string _createdByUser;
        private string _url;


        public SqlAddPaper(string fileName, string userID, string url)
        {
            _fileName = fileName;
            _createdByUser = userID;
            _url = url;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "insert into AttachmentInfo(AttachName, CreateTime, CreateByUser, LastModifyTime, AttachNameUrl, Category) " +
                "values('" + _fileName + "', '" + System.DateTime.Now + "', '" + _createdByUser + "','" + System.DateTime.Now + "','" + _url + "',3) select SCOPE_IDENTITY() as id";
        }

        #endregion
    }
}
