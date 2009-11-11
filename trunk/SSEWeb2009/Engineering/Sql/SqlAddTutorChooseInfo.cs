using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlAddTutorChooseInfo:ISql
    {
        private string _studentID;
        private string _teacherID;
        private string _will;

        public SqlAddTutorChooseInfo(string stuID, string teacherID, string will)
        {
            _studentID = stuID;
            _teacherID = teacherID;
            _will = will;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "insert into TutorChooseInfo(StuID, TeacherID, Will) values('"+_studentID+"', '"+_teacherID+"','"+_will+"')";
        }

        #endregion
    }
}
