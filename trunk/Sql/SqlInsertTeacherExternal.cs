using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;
namespace SysCom.Sql
{
    class SqlInsertTeacherExternal:ISql
    {
        #region ISql 成员
        private SavingTeacherInfo m_TeacherInfo;
        public void SetTeacherInfo(SavingTeacherInfo sTeacherInfo)
        {
            m_TeacherInfo = sTeacherInfo;
        }
        public string GetSql()
        {
            return "insert into TeacherExternal(TeacherID)values('" + m_TeacherInfo.GetTeacherID() + "')";
        }

        #endregion
    }
}
