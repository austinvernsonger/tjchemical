using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    public class SqlGetAllCoursePair : ISql
    {
        #region ISql 成员

        public string GetSql()
        {
            return "select CourseName, CourseID from Course";
        }

        #endregion
    }
}
