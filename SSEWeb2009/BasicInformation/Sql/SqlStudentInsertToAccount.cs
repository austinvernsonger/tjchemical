using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace SysCom.Sql
{
    class SqlStudentInsertToAccount : ISql
    {
        BasicStudentInfo m_BSI;

        public SqlStudentInsertToAccount(BasicStudentInfo BSI)
        {
            m_BSI = BSI;
        }

        public string GetSql()
        {
            return ("insert into Account(AccountID,Password,AccountState,EmailValidation) values('" + m_BSI.m_StudentID + "','" + m_BSI.m_StudentPassWord + "',0,0)");
        }
    }
}
