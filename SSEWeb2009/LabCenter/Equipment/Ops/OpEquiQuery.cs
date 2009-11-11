using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SMBL.Interface.Database;
using SMBL.Operation;


namespace LabCenter.Equipment.Ops
{
    class OpEquiQuery : DBOperation
    {
        protected ISql m_ISql;
        public ISql SetISql
        {
            set{m_ISql=value;}
        }
        //�����ѯ���ݿ�󷵻ص�DataSet

        protected DataSet m_Ds=null;
        public DataSet Ds
        {
            get { return m_Ds; }
        }

        public OpEquiQuery(String DBName, ISql TheISql)
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
