using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlUpdateTestArrangement:ISql
    {
        private TestInfo _tInfo;

        public SqlUpdateTestArrangement(TestInfo tInfo)
        {
            _tInfo = tInfo;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "update ExamArrangeInfo set ExamTime='" + _tInfo.TestTime + "',ExamPlace='" + _tInfo.TestPlace + "',Supervisor1='" + _tInfo.Supervisor1 + "',Supervisor2='" + _tInfo.Supervisor2 + "' where ExamArrID='"+_tInfo.ExamID+"'";
            
        }

        #endregion
    }
}
