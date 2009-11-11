using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlUpdateTutorChoosingInfoByAdm:ISql
    {
        private string _stuID;
        private string _teacherID;
        private string _will;
        private int _teaWill;

        public SqlUpdateTutorChoosingInfoByAdm(string stuID, string teacherID, string will, int teaWill)
        {
            _stuID = stuID;
            _teacherID = teacherID;
            _will = will;
            _teaWill = teaWill;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "update TutorChooseInfo Set Will = '" + _will + "',TeaWill = '" + _teaWill + "' where StuID='" + _stuID + "' and TeacherID='"+_teacherID+"'";
        }

        #endregion

    }
}
