using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;
using SMBL.Operation;

namespace Department.Engineering
{
    class OpEngineerTransaction : DBOperation
    {
        protected delDoTransaction doTransaction;

        protected bool result = false;

        public bool Result
        {
            get { return result; }
        }

        public OpEngineerTransaction(String DBName, delDoTransaction doTrans)
        {
            BindDBName = DBName;
            doTransaction = doTrans;
        }

        public override void processDelegate()
        {   
            result = myProcessor.Transaction(doTransaction);
        }
    }
}
