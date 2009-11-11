using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlUpdateTeaChooseStu:ISql
    {
        private string _studentID;
        private string _teacherID;
        private int _status;

        public SqlUpdateTeaChooseStu(int status, string studentID, string teacherID)
        {
            _studentID = studentID;
            _teacherID = teacherID;
            _status = status;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "update TutorChooseInfo set TeaWill = '"+_status+"' where StuID='"+_studentID+"' and TeacherID='"+_teacherID+"'";
        }

        #endregion
    }
}
