using System;
using System.Collections.Generic;
using System.Text;

namespace SysCom
{
    public class SavingTeacherInfo
    {
        //private static System.Data.DataSet mResult;
        private String m_TeacherID;
        private String m_TeacherPassWord;
        private int m_AccountState;
        private int m_EmailValidation;
        private String m_TeacherName;
        private String m_Gender;
        private bool isTeacherOrdinary;


        public void SetTeacherID(String TeacherID)
        {
            m_TeacherID = TeacherID;
        }
        public String GetTeacherID()
        {
            return m_TeacherID;
        }

        public void SetTeacherPassWord(String TeacherPassWord)
        {
            m_TeacherPassWord = TeacherPassWord;
        }
        public String GetTeacherPassWord()
        {
            return m_TeacherPassWord;
        }

        public void SetAccountState(int AccountState)
        {
            m_AccountState = AccountState;
        }
        public int GetAccountState()
        {
            return m_AccountState;
        }

        public void SetEmailValidation(int EmailValidation)
        {
            m_EmailValidation = EmailValidation;
        }
        public int GetEmailValidation()
        {
            return m_EmailValidation;
        }

        public void SetTeacherName(String TeacherName)
        {
            m_TeacherName = TeacherName;
        }
        public String GetTeacherName()
        {
            return m_TeacherName;
        }

        public void SetGender(String Gender)
        {
            m_Gender = Gender;
        }
        public String GetGender()
        {
            return m_Gender;
        }
        public void SetIsTeacherOrdinary(bool TeacherOrdinary)
        {
            isTeacherOrdinary = TeacherOrdinary;
        }
        public bool GetIsTeacherOrdinary()
        {
            return isTeacherOrdinary;
        }
    }
}
