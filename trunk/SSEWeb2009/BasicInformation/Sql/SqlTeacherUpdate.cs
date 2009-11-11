using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;
namespace SysCom.Sql
{
    class SqlTeacherUpdate:ISql
    {
        #region ISql 成员
        private SavingTeacherInfo m_TeacherInfo;
        public void SetTeacherInfo(SavingTeacherInfo sTeacherInfo)
        {
            m_TeacherInfo = sTeacherInfo;
        }
        public string GetSql()
        {
            return "update Teacher set Name = '" + m_TeacherInfo.GetTeacherName() + "',Gender='" + 
                m_TeacherInfo.GetGender() + "'where TeacherID = '" + m_TeacherInfo.GetTeacherID() + "'";
        }

        #endregion
    }
}
