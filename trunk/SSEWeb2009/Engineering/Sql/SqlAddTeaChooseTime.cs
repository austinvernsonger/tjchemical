using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    class SqlAddTeaChooseTime:ISql
    {
        private QueryInfo _qInfo;

        public SqlAddTeaChooseTime(QueryInfo qInfo)
        {
            _qInfo = qInfo;
        }

        #region ISql 成员

        public string GetSql()
        {
            return "Insert into TeachingManageInfo(TeaSchoolID, TeaMagType, Grade, StartTime, EndTime) "+
            "values('"+_qInfo.TSchoolID+"', 2, '"+_qInfo.Grade+"','"+Convert.ToDateTime(_qInfo.StartTime)+"','"+Convert.ToDateTime(_qInfo.EndTime)+"')";
        }

        #endregion
    }
}
