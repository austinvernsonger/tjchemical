using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlAddMidForm:ISql
    {
        private string _fileName ;
        private string _createdByUser;
        private string _url;

        public SqlAddMidForm(string createdByUser, string url,string subject)
        {
            _createdByUser = createdByUser;
            _url = url;
            _fileName = subject;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "insert into AttachmentInfo(AttachName, CreateTime, CreateByUser, LastModifyTime, AttachNameUrl, Category) " +
                "values('" + _fileName + "', '" + System.DateTime.Now + "', '" + _createdByUser + "','" + System.DateTime.Now + "','" + _url + "',2) select SCOPE_IDENTITY() as id";
        }

        #endregion
    }
}
