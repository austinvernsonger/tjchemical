using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlDeleteStudentChooseTutorInfo:ISql
    {
        private string _studentID;

        public SqlDeleteStudentChooseTutorInfo(string studentID)
        {
            _studentID = studentID;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "delete from TutorChooseInfo where StuID ='"+_studentID+"'";
        }

        #endregion
    }
}
