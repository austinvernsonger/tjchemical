using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace LabCenter.Repair.Sql
{
    class SqlComputerConfirm:ISql
    {
        string m_cp_num;
        public SqlComputerConfirm(string cp_number)
        {
            m_cp_num = cp_number.Trim();
        }
        #region ISql ��Ա

        public string GetSql()
        {
            //ȷ��Ҫȷ�ϵĵ��Ե�ǰ״̬Ϊ��ȷ��
            return "update ComputerRepair set " +
                "State=1,ConfirmTime=getdate() where ComputerNumber='" +
                m_cp_num + "' and State=0";
        }

        #endregion
    }
}
