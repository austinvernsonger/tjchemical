using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMBL.Interface.Database;
using SMBL.Operation;

namespace IdentifyLibrary.Ops
{
    class OpIdentifyExec : DBOperation
    {
        //通过mISql获取执行的sql语句
        protected ISql iSql;
        public ISql SetISql
        {
            set { iSql = value; }
        }
        //Excute操作影响数据库的行数
        protected int executenumber = 0;
        public int ExecuteNumber
        {
            get { return executenumber; }
        }
        //Excute操作是否成功
        protected Boolean executeresult = false;
        public Boolean ExecuteResult
        {
            get { return executeresult; }
        }

        public OpIdentifyExec(ISql TheISql)
        {
            SetISql = TheISql;
            BindDBName = "TjMedical";
        }

        public override void processDelegate()
        {
            executenumber = myProcessor.Execute(iSql);
            executeresult = (ExecuteNumber > 0 ? true : false);
        }
    }
}
