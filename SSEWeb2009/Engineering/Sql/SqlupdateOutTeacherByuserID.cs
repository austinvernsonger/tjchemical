using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlupdateOutTeacherByuserID:ISql
    {
        private string _userID;
        private string _url;
        private string _fileName;

        public SqlupdateOutTeacherByuserID(string userID, string url, string fileName)
        {
            _userID = userID;
            _url = url;
            _fileName = fileName;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "update AttachmentInfo set AttachName='"+_fileName+"' ,LastModifyTime='" + System.DateTime.Now + "' , AttachNameUrl='" + _url + "' where Category=4 and CreateByUser='" + _userID + "'";
        }

        #endregion
    }
}
