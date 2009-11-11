using System;
using System.Collections.Generic;
using System.Text;
using Admission.Ops;
using Admission.Sql;

namespace Admission
{
    public class TeacherAuthority
    {
        private string m_DbName = "Admission";
        private string m_TchID;
        public string TchID
        {
            get { return m_TchID; }
            set { m_TchID = value; }
        }
        public String ErrorMsg = "";


        public TeacherAuthority()
        {

        }

        public Boolean AddAdmin()
        {
            OpAdmissionExecute i = new OpAdmissionExecute(m_DbName, new SqlAddAdmin(m_TchID));
            if (!i.Do())
            {
                ErrorMsg = i.GetLastError();
                return false;
            }
            return true; 
        }
        public Boolean DelAdmin()
        {
            OpAdmissionExecute i = new OpAdmissionExecute(m_DbName, new SqlDelAdmin(m_TchID));
            if (!i.Do())
            {
                ErrorMsg = i.GetLastError();
                return false;
            }
            return true;
        }
        public void GetAuthority(ref bool HS,ref bool MS,ref bool ME,ref bool MTI,ref bool SUPER)
        {
            HS = IsHasAuthority(TchAuthority.HS_stu);
            MS = IsHasAuthority(TchAuthority.MS_stu);
            ME = IsHasAuthority(TchAuthority.ME_stu);
            MTI = IsHasAuthority(TchAuthority.MTI_stu);
            SUPER = IsHasAuthority(TchAuthority.SUPER);
        }

        public Boolean ClearAuthority()
        {
            OpAdmissionExecute i = new OpAdmissionExecute(m_DbName, new SqlSetAuthority(m_TchID));
            if (!i.Do())
            {
                ErrorMsg = i.GetLastError();
                return false;
            }
            return true;            
        }

        public Boolean SetTchAuthority(TchAuthority m_requestAuthority)
        {
            OpAdmissionExecute i = new OpAdmissionExecute(m_DbName, new SqlSetHSAuthority(m_TchID));
            switch (m_requestAuthority)
            {
                case TchAuthority.MS_stu:
                    i.SetISql = new SqlSetMSAuthority(m_TchID);
                    break;
                case TchAuthority.ME_stu:
                    i.SetISql = new SqlSetMEAuthority(m_TchID);
                    break;
                case TchAuthority.MTI_stu:
                    i.SetISql = new SqlSetMTIAuthority(m_TchID);
                    break;
                case TchAuthority.SUPER:
                    i.SetISql = new SqlSetSUPERAuthority(m_TchID);
                    break;
                default:
                    return false;
                    break;
            }
            if (!i.Do())
            {
                ErrorMsg = i.GetLastError();
                return false;
            }
            return true;
        }

        public Boolean IsHasAuthority(TchAuthority m_requestAuthority)
        {
            OpAdmissionQuery i = new OpAdmissionQuery(m_DbName, new SqlGetHSAuthority(m_TchID));
            switch(m_requestAuthority)
            {
                case TchAuthority.MS_stu:
                    i.SetISql = new SqlGetMSAuthority(m_TchID);
                    break;
                case TchAuthority.ME_stu:
                    i.SetISql = new SqlGetMEAuthority(m_TchID);
                    break;
                case TchAuthority.MTI_stu:
                    i.SetISql = new SqlGetMTIAuthority(m_TchID);
                    break;
                case TchAuthority.SUPER:
                    i.SetISql = new SqlGetSUPERAuthority(m_TchID);
                    break;
                default:
                    return false;
                    break;
            }
            i.Do();
            try
            {
                return Convert.ToBoolean(i.Ds.Tables[0].Rows[0][0]);
            }
            catch
            {
                return false;
            } 
            
        }
    }
}
