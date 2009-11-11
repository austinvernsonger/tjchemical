using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Operation;
using SMBL.Interface.Database;

namespace Education.Ops
{
    /// <summary>
    /// 教务模块通用SQL执行语句操作器
    /// </summary>
    class opsEducationExec:DBOperation
    {

        /// <summary>
        /// My attributes
        /// </summary>

        protected ISql mSQL;

        public opsEducationExec(ISql SQL,String DbName)
        {
            mSQL = SQL;
            myBindDBName = DbName;
        }
        public override void processDelegate()
        {
            myProcessor.Execute(mSQL);
        }
    }
}
