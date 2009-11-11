using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlUpdateFinalPaperAttachment:ISql
    {
        private string _studentID;
        private string _url;

        public SqlUpdateFinalPaperAttachment(string studentID, string url)
        {
            _studentID = studentID;
            _url = url;
        }
        #region ISql 成员

        public string GetSql()
        {
            return "update AttachmentInfo set LastModifyTime='" + System.DateTime.Now + "' , AttachNameUrl='" + _url + "' where CreateByUser='" + _studentID + "' and Category=5";
        }

        #endregion

    }
}
