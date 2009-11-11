using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace SysCom.Sql
{
    class SqlStudentInsertToStudent : ISql
    {
        BasicStudentInfo m_BSI;

        public SqlStudentInsertToStudent(BasicStudentInfo BSI)
        {
            m_BSI = BSI;
        }

        public string GetSql()
        {
            return ("insert into Student(Name,StudentID,Gender,Major,LengthOfSchooling,Degree) values('" + m_BSI.m_StudentName + "','" + m_BSI.m_StudentID + "'," + m_BSI.m_Gender + ",'" + m_BSI.m_Major + "','" + m_BSI.m_LengthOfSchooling + "','" + m_BSI.m_Degree + "')");
        }
    }
}