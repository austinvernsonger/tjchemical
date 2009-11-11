using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlUpdateChoosingCourseAgenda:ISql
    {
        private string _startTime;
        private string _endTime;
        private int _teaMagID;

        public SqlUpdateChoosingCourseAgenda(string startTime, string endTime, int teaMagID)
        {
            _startTime = startTime;
            _endTime = endTime;
            _teaMagID = teaMagID;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "update TeachingManageInfo Set StartTime ='" + Convert.ToDateTime(_startTime) + "', EndTime='" + Convert.ToDateTime(_endTime) + "' where TeaMagID='"+_teaMagID+"'";
        }

        #endregion
    }
}
