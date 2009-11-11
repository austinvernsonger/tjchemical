using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SMBL.Interface.Database;
using SMBL.Operation;

namespace LabCenter.Repair.Ops
{
    class OpRepairQuery:DBOperation
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

        public OpRepairQuery(String DBName, ISql TheISql)
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
