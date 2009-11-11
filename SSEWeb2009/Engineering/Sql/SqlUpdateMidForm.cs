using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlUpdateMidForm:ISql
    {
        private int _attachID;
        private string _url;
        private string _subject;

        public SqlUpdateMidForm(int attachID, string url, string subject)
        {
            _attachID = attachID;
            _url = url;
            _subject = subject;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "update AttachmentInfo set AttachName='"+_subject+"',LastModifyTime='" + System.DateTime.Now + "' , AttachNameUrl='" + _url + "' where AttachID='" + _attachID + "'";
        }

        #endregion
    }
}
