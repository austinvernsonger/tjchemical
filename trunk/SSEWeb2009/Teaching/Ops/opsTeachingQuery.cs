using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Operation;

namespace Teaching.Ops
{
    /// <summary>
    /// 教学模块通用SQL查询语句操作器
    /// </summary>
    public class opsTeachingQuery : DBOperation
    {
        /// <summary>
        /// My attributes
        /// </summary>
        public System.Data.DataSet mResult;

        protected String mSQL;

        public opsTeachingQuery(String SQL)
        {
            mSQL = SQL;
            myBindDBName = "Teaching";
        }
        public override void processDelegate()
        {
            mResult = myProcessor.Query(new Sql.sqlTeaching(mSQL));
        }
    }
}