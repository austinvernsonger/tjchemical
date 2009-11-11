using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlDeleteCourse:ISql
    {
        private int courseID;

        public SqlDeleteCourse(int cID) 
        {
            courseID = cID;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "Delete from Course where CourseID = '" + courseID + "'";
        }

        #endregion
    }
}
