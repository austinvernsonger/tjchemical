using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlAddTutorChoosingByStu:ISql
    {
        private Willing _will;

        public SqlAddTutorChoosingByStu(Willing will)
        {
            _will = will;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "insert into TutorChooseInfo(StuID, TeacherID, Will, TeaWill) values('" + _will.StuID + "', '" + _will.TeacherID+ "', '1',1)";
        }

        #endregion
    }
}
