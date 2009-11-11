using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlGetTutorsList : ISql
    {
        public SqlGetTutorsList()
        { }

        #region ISql 成员

        public string GetSql()
        {
            return "select t.TeacherID, Name from Teacher as t inner join TeacherOrdinary as tod on t.TeacherID = tod.TeacherID where TutorType!=0";

        }

        #endregion
    }
}
