using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace Department.Engineering
{
    /// <summary>
    /// 添加选课日程安排
    /// </summary>
    class SqlAddCourTimeAnge:ISql
    {
        private QueryInfo qInfo;

        public SqlAddCourTimeAnge(QueryInfo queryInfo)
        {
            qInfo = queryInfo;
        }

        #region ISql 成员

        public string GetSql()
        {
            if (qInfo.Time != null)
            {
                return "insert into TeachingManageInfo(TeaSchoolID, TeaMagType, Grade, StartTime, EndTime, Term) " +
                    "values('" + qInfo.TSchoolID + "', 1, '" + qInfo.Grade + "', '" + Convert.ToDateTime(qInfo.StartTime) + "','" + Convert.ToDateTime(qInfo.EndTime) + "','"+Convert.ToInt32(qInfo.Time)+"')";
            }
            else
            {
                return "insert into TeachingManageInfo(TeaSchoolID, TeaMagType, Grade, StartTime, EndTime) " +
                    "values('" + qInfo.TSchoolID + "', 1, '" + qInfo.Grade + "', '" + Convert.ToDateTime(qInfo.StartTime) + "','" + Convert.ToDateTime(qInfo.EndTime) + "')";
            }
        }

        #endregion
    }
}
