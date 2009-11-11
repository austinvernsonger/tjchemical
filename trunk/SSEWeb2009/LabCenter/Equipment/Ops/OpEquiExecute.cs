using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;
using SMBL.Operation;

namespace LabCenter.Equipment.Ops
{
    class OpEquiExecute:DBOperation
    {
        //ͨ��mISql��ȡִ�е�sql���
        protected ISql m_ISql;
        public ISql SetISql
        {
            set { m_ISql = value; }
        }
        //Excute����Ӱ�����ݿ������
        protected int m_ExecuteNumber=0;
        public int ExecuteNumber
        {
            get { return m_ExecuteNumber; }
        }
        //Excute�����Ƿ�ɹ�
        protected Boolean m_ExecuteResult=false;
        public Boolean ExecuteResult
        {
            get { return m_ExecuteResult; }
        }

        public OpEquiExecute(String DBName, ISql TheISql)
        {
            SetISql = TheISql;
            BindDBName = DBName;
        }

        public override void processDelegate()
        {
            m_ExecuteNumber = myProcessor.Execute(m_ISql);
            m_ExecuteResult = (m_ExecuteNumber>0 ? true : false);
        }
    }
}
