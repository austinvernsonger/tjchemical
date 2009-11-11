using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{

    class SqlAddDiscussion:ISql
    {
        private string _title;
        private string _body;
        private string _parentDisplayOrder;
        private string _communicators;
        private int _category;
        private string _status;
        private int _attachID;

        public SqlAddDiscussion(string title, string body, string parentDisplayOrder, string communicators, int category,int attachID, string status)
        {
            _title = title;
            _body = body;
            _parentDisplayOrder = parentDisplayOrder;
            _communicators = communicators;
            _category = category;
            _status = status;
            _attachID = attachID;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "insert into Discussion(CreatedDate, Title, Body, DisplayOrder, Communicators, Category,AttachID, Status) values(GetDate(),'" + _title + "','" + _body + "','" + _parentDisplayOrder + "'+Convert(nvarchar(24),GetDate(),21),'" + _communicators + "','" + _category + "','"+_attachID+"','" + _status + "')";

        }

        #endregion
    }
}
