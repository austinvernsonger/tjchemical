using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Operation;

namespace Teaching.Ops
{
    /// <summary>
    /// 教学模块通用SQL执行语句操作器
    /// </summary>
    public class opsTeachingExec : DBOperation
    {
        /// <summary>
        /// My attributes
        /// </summary>

        protected String mSQL;
        protected bool bSucc;
        public bool isSucc
        {
            get
            {
                return bSucc;
            }
        }

        public opsTeachingExec(String SQL)
        {
            mSQL = SQL;
            myBindDBName = "Teaching";
        }
        public override void processDelegate()
        {
            if (myProcessor.Execute(new Sql.sqlTeaching(mSQL)) != 0)
            {
                bSucc = true;
            }
            else
            {
                bSucc = false;
            }
        }
    }
}