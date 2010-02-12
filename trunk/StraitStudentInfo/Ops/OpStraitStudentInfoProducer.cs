﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMBL.Interface.Database;
using SMBL.Operation;

namespace StraitStudentInfo.Ops
{
    class OpStraitStudentInfoProducer : DBOperation
    {
        private object[] parms;
        private String PName;

        protected object executeresult = null;
        public object ExecuteResult
        {
            get { return executeresult; }
        }

        public OpStraitStudentInfoProducer(String ProducerName, params object[] Parameters)
        {
            parms = Parameters;
            PName = ProducerName;
            BindDBName = "TjMedical";
        }

        public override void processDelegate()
        {
            String test = "";
            foreach (object a in parms)
            {
                test += a.ToString() + ",";
            }
            object mRtnValue = new object();
            myProcessor.Producer(PName, out mRtnValue, parms);
            executeresult = mRtnValue;
        }
    }
}
