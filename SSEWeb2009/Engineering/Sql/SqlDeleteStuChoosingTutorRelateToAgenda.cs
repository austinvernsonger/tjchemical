using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlDeleteStuChoosingTutorRelateToAgenda:ISql
    {

        private int _teaMagID;

        public SqlDeleteStuChoosingTutorRelateToAgenda(int teaMagID)
        {
            _teaMagID = teaMagID;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "delete from TutorChooseInfo where StuID in (select s.StudentID from Student as s inner join StudentMSE as sm on s.StudentID=sm.StudentID inner join TeachingManageInfo as tm on tm.Grade=s.Grade and tm.TeaSchoolID=sm.TeaSchoolID where TeaMagID='"+_teaMagID+"')";
        }

        #endregion
    }
}
