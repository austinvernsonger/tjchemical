using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlAddTeachingEvaluationAgenda:ISql
    {
        private QueryInfo _qInfo;

        public SqlAddTeachingEvaluationAgenda(QueryInfo qInfo)
        {
            _qInfo = qInfo;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "Insert into TeachingManageInfo(TeaSchoolID, TeaMagType,Grade,StartTime,EndTime,Term) values('" + _qInfo.TSchoolID + "', 3, '"+_qInfo.Grade+"','"+Convert.ToDateTime(_qInfo.StartTime)+"','"+Convert.ToDateTime(_qInfo.EndTime)+"','"+Convert.ToInt32(_qInfo.Time)+"')";
        }

        #endregion
    }
}
