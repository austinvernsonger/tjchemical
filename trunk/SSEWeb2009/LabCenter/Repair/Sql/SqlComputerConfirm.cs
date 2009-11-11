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
        #region ISql 成员

        public string GetSql()
        {
            //确保要确认的电脑当前状态为待确定
            return "update ComputerRepair set " +
                "State=1,ConfirmTime=getdate() where ComputerNumber='" +
                m_cp_num + "' and State=0";
        }

        #endregion
    }
}
