using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlUpdateStuTutorID:ISql
    {
        private string _stuid;
        private string _teacherid;

        public SqlUpdateStuTutorID(string stuid, string teacherid)
        {
            _stuid = stuid;
            _teacherid = teacherid;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "update StudentMSE set TeacherID = '" + _teacherid + "' where StudentID='"+_stuid+"'";
        }

        #endregion
    }
}
