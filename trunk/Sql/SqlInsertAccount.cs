using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;
namespace SysCom.Sql
{
    class SqlInsertAccount:ISql
    {
        #region ISql 成员
        private SavingTeacherInfo m_TeacherInfo;
        public void SetTeacherInfo(SavingTeacherInfo sTeacherInfo)
        {
            m_TeacherInfo = sTeacherInfo;
        }
        public string GetSql()
        {
            return "insert into Account(AccountID,Password,AccountState,EmailValidation)values('" + m_TeacherInfo.GetTeacherID() + "','"
                + m_TeacherInfo.GetTeacherPassWord() + "','" + m_TeacherInfo.GetAccountState().ToString() + "','" + m_TeacherInfo.GetEmailValidation().ToString() + "')";
        }

        #endregion
    }
}
