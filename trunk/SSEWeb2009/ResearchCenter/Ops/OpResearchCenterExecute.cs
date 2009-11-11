using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Operation;
using SMBL.Interface.Database;

namespace ResearchCenter.Ops
{
    class OpResearchCenterExecute : DBOperation
    {
        protected ISql m_ISql;
        public ISql SetISql
        {
            set { m_ISql = value; }
        }
        //Excute操作影响数据库的行数
        protected int m_ExecuteNumber = 0;
        public int ExecuteNumber
        {
            get { return m_ExecuteNumber; }
        }
        //Excute操作是否成功
        protected Boolean m_ExecuteResult = false;
        public Boolean ExecuteResult
        {
            get { return m_ExecuteResult; }
        }

        public OpResearchCenterExecute(String DBName, ISql TheISql)
        {
            SetISql = TheISql;
            BindDBName = DBName;
        }

        public override void processDelegate()
        {
            m_ExecuteNumber = myProcessor.Execute(m_ISql);
            m_ExecuteResult = (m_ExecuteNumber > 0 ? true : false);
        }
    }
}
