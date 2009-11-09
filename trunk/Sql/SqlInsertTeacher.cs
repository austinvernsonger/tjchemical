using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;
namespace SysCom.Sql
{
    class SqlInsertTeacher:ISql
    {
        #region ISql 成员
        private SavingTeacherInfo m_TeacherInfo;
        public void SetTeacherInfo(SavingTeacherInfo sTeacherInfo)
        {
            m_TeacherInfo = sTeacherInfo;
        }
        public string GetSql()
        {
            return "insert into Teacher(TeacherID,Name,Gender,Valid)values('" + m_TeacherInfo.GetTeacherID() + "','" + m_TeacherInfo.GetTeacherName() + "','"
                + m_TeacherInfo.GetGender() + "','1')";
        }

        #endregion
    }
}
