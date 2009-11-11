using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetDiscussionInfoByTeacherID:ISql
    {
        private string _teacherID;

        public SqlGetDiscussionInfoByTeacherID(string teacherID)
        {
            _teacherID = teacherID;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "select d.*,Name,StudentID,(select count(*)-1 from Discussion as d2 where left(d2.DisplayOrder,len(rtrim(d.DisplayOrder)))=d.DisplayOrder) " +
                    "as ChildCount from Discussion as d inner join Student as s on s.StudentID=left(Communicators,10) where (len(DisplayOrder)/23)=1 " +
                    "and right(Communicators,len(Communicators)-11)='" + _teacherID + "' order by CreatedDate desc";
        }

        #endregion
    }
}
