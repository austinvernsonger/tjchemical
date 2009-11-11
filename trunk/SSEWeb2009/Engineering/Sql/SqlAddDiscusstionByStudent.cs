using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlAddDiscusstionByStudent:ISql
    {
        private string _communicator;
        private string _title;
        private int _category;
        private int _attachID;
        private string _body;

        public SqlAddDiscusstionByStudent(string communicator, string title, int category, int attachID,string body)
        {
            _communicator = communicator;
            _title = title;
            _category = category;
            _attachID = attachID;
            _body = body;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "insert into Discussion(CreatedDate, Title, DisplayOrder, Communicators, Category, Status,body, AttachID) values(GetDate(),'" + _title + "',Convert(nvarchar(24),GetDate(),21),'" + _communicator + "','" + _category + "',10, '"+_body+"','"+_attachID+"')";
        }

        #endregion
    }
}
