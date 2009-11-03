using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace SysCom
{
    ///<summary>
    /// 用户类：LoginInfo - 记录登录表信息 
    /// 作者：Sunwell
    /// 最近一次修改时间：2009-7-9
    ///</summary>
    public class LoginInfo
    {
        //用户名 
        private String username;
        public String Username
        {
            get { return username; }
            set { username = value; }
        }
        //密码
        private String password;

        public String Password
        {
            get { return password; }
            set { password = value; }
        }
        //认证邮箱 
        private String emailaddress;

        public String Emailaddress
        {
            get { return emailaddress; }
            set { emailaddress = value; }
        }

        //用户状态
        private String accoutstate;

        public String Accoutstate
        {
            get { return accoutstate; }
            set { accoutstate = value; }
        }

        //邮箱认证结果
        private Int32 emailvalidation;

        public Int32 Emailvalidation
        {
            get { return emailvalidation; }
            set { emailvalidation = value; }
        }
    }
}
