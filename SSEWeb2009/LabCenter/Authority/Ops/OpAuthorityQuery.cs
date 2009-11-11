using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Operation;
using SMBL.Interface.Database;
using System.Data;

namespace LabCenter.Authority.Ops
{
    class OpAuthorityQuery:DBOperation
    {
        protected ISql m_ISql;
        public ISql SetISql
        {
            set{m_ISql=value;}
        }
        //保存查询数据库后返回的DataSet

        protected DataSet m_Ds=null;
        public DataSet Ds
        {
            get { return m_Ds; }
        }

        public OpAuthorityQuery(String DBName, ISql TheISql)
        {
            SetISql = TheISql;
            BindDBName = DBName;
        }

        public override void processDelegate()
        {
            m_Ds = myProcessor.Query(m_ISql);
        }
    }
}
