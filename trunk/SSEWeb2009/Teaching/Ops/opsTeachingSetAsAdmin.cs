using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Operation;

namespace Teaching.Ops
{
    /// <summary>
    /// 教学模块通用SQL执行语句操作器
    /// </summary>
    public class opsTeachingSetAsAdmin : DBOperation
    {
        /// <summary>
        /// My attributes
        /// </summary>

        protected String TeacherID;
        protected bool bSucc;
        public bool isSucc
        {
            get
            {
                return bSucc;
            }
        }

        public opsTeachingSetAsAdmin(String ID)
        {
            TeacherID = ID;
            myBindDBName = "Teaching";
        }
        public override void processDelegate()
        {
            object mRtnValue = new object();
            myProcessor.Producer("P_TEACHING_SET_ADMIN", out mRtnValue, TeacherID);
            bSucc = Convert.ToBoolean(mRtnValue);
        }
    }
}