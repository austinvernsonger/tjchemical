using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlUpdateTeaChooseTime : ISql
    {
        private QueryInfo _qInfo;

        public SqlUpdateTeaChooseTime(QueryInfo qInfo)
        {
            _qInfo = qInfo;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "update TeachingManageInfo Set StartTime = '" + Convert.ToDateTime(_qInfo.StartTime) + "',EndTime = '" + Convert.ToDateTime(_qInfo.EndTime) + "' where TeaMagType=2 and Grade = '"+ _qInfo.Grade +"' and TeaSchoolID = '"+ _qInfo.TSchoolID +"'";
        }        

        #endregion

    }
}

    