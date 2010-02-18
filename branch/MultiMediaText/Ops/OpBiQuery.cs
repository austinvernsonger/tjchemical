using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Operation;
using SMBL.Interface.Database;
using System.Data;
namespace SysCom.Ops
{
    class OpBiQuery:DBOperation
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

        public OpBiQuery(String DBName, ISql TheISql)
        {
            SetISql = TheISql;
            BindDBName = "TjMedical";
        }

        public override void processDelegate()
        {
            m_Ds = myProcessor.Query(m_ISql);
        }
    }
}
