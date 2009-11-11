using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlAddDocumentInfoDatabase:ISql
    {
        private string _stuid;
        private int _length;
        private string _contentType;
        private byte[] _content;
        private string _fileName;
     

        public SqlAddDocumentInfoDatabase(string stuid, int length, string contentType, byte [] content, string filename)
        {
            _stuid = stuid;
            _length = length;
            _contentType = contentType;
            _content = content;
            _fileName = filename;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "insert into AttachmentInfo(AttachName, ContentType, ContentSize, CreateTime, CreateByUser,LastModifyTime,Content,Category) " +
                    "values('" + _fileName + "','" + _contentType + "','" + _length + "','" + System.DateTime.Now + "','" + _stuid + "','" + System.DateTime.Now + "','" + _content + "', 5)";
        }

        #endregion
    }
}
