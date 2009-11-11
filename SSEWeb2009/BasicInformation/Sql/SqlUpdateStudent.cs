using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace SysCom.Sql
{
    class SqlUpdateStudent : ISql
    {
        BasicStudentInfo m_BSI;

        public SqlUpdateStudent(BasicStudentInfo BSI)
        {
            m_BSI = BSI;
        }

        public string GetSql()
        {
            return ("update Student set Name='" + m_BSI.m_StudentName + "', Gender=" + m_BSI.m_Gender + ",Major='" + m_BSI.m_Major + "',LengthOfSchooling='" + m_BSI.m_LengthOfSchooling + "' where StudentID='" + m_BSI.m_StudentID + "'");
        }
    }
}