using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlUpdateOpenSpeechByAttachID:ISql
    {
        private int _attachID;
        private string _url;
        private string _fileName;

        public SqlUpdateOpenSpeechByAttachID(int attachID, string url, string fileName)
        {
            _attachID = attachID;
            _url = url;
            _fileName = fileName;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "update AttachmentInfo set AttachName='" + _fileName + "' " +
                ", LastModifyTime='" + System.DateTime.Now + "' , AttachNameUrl='" + _url + "' where  AttachID='"+_attachID+"'";
        }

        #endregion
    }
}
