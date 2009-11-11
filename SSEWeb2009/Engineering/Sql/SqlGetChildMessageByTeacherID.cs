using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetChildMessageByTeacherID:ISql
    {
        private string _parentDisplayOrder;
        private string _teacherID;

        public SqlGetChildMessageByTeacherID(string parentDisplayOrder, string teacherID)
        {
            _parentDisplayOrder = parentDisplayOrder;
            _teacherID = teacherID;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "select * from Discussion where left(DisplayOrder,23)='" + _parentDisplayOrder + "' and (len(DisplayOrder)/23)>1 and (left(Communicators,len(Communicators)-11)='" + _teacherID + "' or right(Communicators,len(Communicators)-11)='" + _teacherID + "') order by CreatedDate desc";
        }

        #endregion
    }
}
