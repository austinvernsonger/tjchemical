using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Operation;
using SMBL.Interface.Database;
using Education.Sql;

namespace Education.Ops
{
    /// <summary>
    /// 教学模块通用SQL查询语句操作器
    /// </summary>
    class opsEducationQurey : DBOperation
    {
            public System.Data.DataSet mResult;

            private ISql mSQL;

            public opsEducationQurey(ISql SQL, String dbName)
            {
                mSQL = SQL;
                myBindDBName = dbName;
            }
            public override void processDelegate()
            {
                mResult = myProcessor.Query(mSQL);
            }
        }
}
