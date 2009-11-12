﻿using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlUpdateTeachingEvaluationAgenda:ISql
    {
        private QueryInfo _qInfo;

        public SqlUpdateTeachingEvaluationAgenda(QueryInfo qInfo)
        {
            _qInfo = qInfo;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "update TeachingManageInfo set StartTime = '" + Convert.ToDateTime(_qInfo.StartTime) + "', EndTime='" + Convert.ToDateTime(_qInfo.EndTime) + "' where TeaSchoolID='" + _qInfo.TSchoolID + "' and Grade='" + _qInfo.Grade + "' and Term='" + Convert.ToInt32(_qInfo.Time) + "' and TeaMagType=3";
        }

        #endregion
    }
}