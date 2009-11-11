using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Operation;
using System.Data;
using SMBL.Interface.Database;

namespace LabCenter.LabUtility.PublicUtility
{
    public class OpQuery : DBOperation
    {

        ISql m_ISql;

        DataSet m_Ds=null;
        public DataSet Ds
        {
            get { return m_Ds; }
        }

        public OpQuery(String DBName, ISql theISql)
        {
            m_ISql = theISql;
            BindDBName = DBName;
        }

        public override void processDelegate()
        {
            m_Ds = myProcessor.Query(m_ISql);
        }
    }
}
