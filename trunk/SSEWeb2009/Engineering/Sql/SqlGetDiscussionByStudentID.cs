using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetDiscussionByStudentID:ISql
    {
        private string _studentID;

        public SqlGetDiscussionByStudentID(string studentID)
        {
            _studentID = studentID;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "select d.*,Name,(select count(*)-1 from Discussion as d2 where left(d2.DisplayOrder,len(rtrim(d.DisplayOrder)))=d.DisplayOrder) "+
                    "as ChildCount from Discussion as d inner join Teacher as t on t.TeacherID=right(Communicators,len(Communicators)-11) where (len(DisplayOrder)/23)=1 " +
                    "and left(Communicators,10)='"+_studentID+"' and Category=1 order by CreatedDate desc";
        }

        #endregion
    }
}
