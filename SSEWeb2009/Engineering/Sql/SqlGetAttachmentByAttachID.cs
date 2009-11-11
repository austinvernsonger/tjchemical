using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetAttachmentByAttachID:ISql
    {
        private int _attachID;

        public SqlGetAttachmentByAttachID(int attachID)
        {
            _attachID = attachID;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "select * from AttachmentInfo where AttachID='"+_attachID+"'";
        }

        #endregion
    }
}
