using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using LabCenter.Authority;

namespace LabCenter.LabUtility.PublicUtility
{
    public class Account
    {
        public static bool IsManager(string id)
        {
            AuthorityManage m = new AuthorityManage();
            return m.IsManager(id);
        }

        public static bool ExistStudent(string id)
        {
            return GetStudentName(id) != "";
        }

        public static string Name(string id)
        {
            string name=GetStudentName(id);
            if (name!="")
            {
                return name;
            }
            else
            {
                return GetTeacherName(id); 
            }
        }

        /// <summary>
        /// 获取学生名字
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>如果没有则返回空字符</returns>
        public static string GetStudentName(string id)
        {
            OpQuery op = new OpQuery("Account", new SqlGetStudentName(id));
            
            op.Do();
            //string s = op.GetLastError();
            DataSet ds = op.Ds;
            if (ds.Tables[0].Rows.Count == 0)
            {
                return "";
            }
            return ds.Tables[0].Rows[0]["Name"].ToString();
        }

        /// <summary>
        /// 获取教师名字
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>如果没有则返回空字符</returns>
        public static string GetTeacherName(string id)
        {
            OpQuery op = new OpQuery("Account", new SqlGetTeacherName(id));
            op.Do();
            DataSet ds = op.Ds;
            if (ds.Tables[0].Rows.Count == 0)
            {
                return "";
            }
            return ds.Tables[0].Rows[0]["Name"].ToString();
        }

    }
}
