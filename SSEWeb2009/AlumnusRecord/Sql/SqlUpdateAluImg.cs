using System;
using System.Collections.Generic;
using System.Text;
using SMBL.Interface.Database;

namespace AlumnusRecord.Sql
{
    class SqlUpdateAluImg : ISql
    {
        private string m_ID;
        private byte[] m_ImgLoc;

        public SqlUpdateAluImg(string id, byte[] imgLoc)
        {
            m_ID = id;
            m_ImgLoc = imgLoc; 
        }

        #region ISql 成员

        public string GetSql()
        {
            StringBuilder binaryData = new StringBuilder();
            binaryData.Append("0x");

            for (int i = 0; i < m_ImgLoc.Length; i++)
            {
                string s = Convert.ToString(m_ImgLoc[i], 16);
                if (s != null && s.Length < 2)
                    binaryData.Append("0").Append(s);
                else
                    binaryData.Append(s);
                
            }
            return "Update Graduate Set HeadPicture = " + binaryData.ToString() + " where StudentID = '" + m_ID + "'";
        }

        #endregion
    }
}
