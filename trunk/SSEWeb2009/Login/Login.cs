using System;
using System.Web;
using System.Collections.Generic;
using System.Data;
using System.Text;
using SysCom.Sql;
namespace SysCom
{
    ///<summary>
    /// 功能类：Login - 完成登陆模块的基本功能
    /// 作者：Sunwell
    /// 最近一次修改时间：2009-7-9
    ///</summary>
    public class Login
    {
        /// <summary>
        /// 验证登陆信息
        /// </summary>
        /// <param name="ToCheck">需要验证的信息</param>
        /// <param name="SaveCookie">是否保存在cookies中</param>
        /// <returns>验证结果</returns>
        public static LoginType CheckInfo(LoginInfo ToCheck,bool SaveCookie)
        {
            SysCom.Ops.OpCheckInfo op = new SysCom.Ops.OpCheckInfo("Account", new sqlCheckInfo(ToCheck));
            op.Do();
            DataSet ds = op.LoginInfoDs;
            if(ds.Tables[0].Rows.Count==0)
            {
                return LoginType.Nouser;
            }
            if (ds.Tables[0].Rows[0]["Password"].ToString()!=ToCheck.Password)
            {
                return LoginType.PsError;
            }
            if (ds.Tables[0].Rows[0]["AccountState"].ToString() =="1")
            {
                return LoginType.Frozen;
            }
            if (ds.Tables[0].Rows[0]["EmailValidation"].ToString() == "False")
            {
                return LoginType.NotSure;
            }
            return LoginType.Succeed;
        }
        /// <summary>
        /// 根据ID找到密码
        /// </summary>
        /// <param name="AccountId"></param>
        /// <returns></returns>
        public static LoginInfo FindPassWord(String AccountId)
        {
            SysCom.Ops.OpCheckInfo op = new SysCom.Ops.OpCheckInfo("Account", new sqlFindByAccountId(AccountId));
            op.Do();
            DataSet ds = op.LoginInfoDs;
            if (ds.Tables[0].Rows.Count == 0)
            {
                return null;
            }
            LoginInfo info = new LoginInfo();
            info.Password = ds.Tables[0].Rows[0]["Password"].ToString();
            info.Emailaddress = ds.Tables[0].Rows[0]["SafetyEmail"].ToString();
            return info;
        }

        /// <summary>
        /// 页面跳转
        /// </summary>
        /// <param name="toURL">需要跳转的页面</param>
        public static void LoginRedirect(string toURL)
        {
            #region
            //HttpContext.Current.Response.Redirect(HttpContext.Current.Request.ApplicationPath + "/Login/Login.aspx?toURL="+toURL);
            //这里写错了，我帮你改了(../可能返回的层次不正确)  by MengChao
            //HttpContext.Current.Response.Redirect(HttpContext.Current.Request.ServerVariables["HTTP_HOST"]);
            HttpContext.Current.Response.Redirect("http://" + 
            HttpContext.Current.Request.Url.Authority + HttpContext.Current.Request.ApplicationPath + "/Login/Login.aspx?toURL=" + toURL);
           
            #endregion
        }

        /// <summary>
        /// 获取Login页面的地址
        /// </summary>
        /// <returns></returns>
        public static string LoginUrl()
        {
            return HttpContext.Current.Request.ApplicationPath + "/Login/Login.aspx";

        }

        /// <summary>
        /// 返回登陆表信息 
        /// </summary>
        /// <returns></returns>
        public static DataSet GetList()
        {
            Ops.OpLoginQuery i = new Ops.OpLoginQuery("Account", new sqlLoginList());
            i.Do();
            return i.Ds;
        }

        /// <summary>
        /// 后台删除用户
        /// </summary>
        /// <param name="ToCheck"></param>
        /// <returns></returns>
        public static bool Delete(LoginInfo ToCheck)
        {
            Ops.OpLoginExecute op = new Ops.OpLoginExecute("Account", new sqlLoginDelete(ToCheck));
            op.Do();
            return op.ExecuteResult;
        }
        /// <summary>
        /// 后台新增用户
        /// </summary>
        /// <param name="ToCheck"></param>
        /// <returns></returns>
        public static bool Insert(LoginInfo ToCheck)
        {
            Ops.OpLoginExecute op = new Ops.OpLoginExecute("Account", new sqlLoginInsert(ToCheck));
            op.Do();
            return op.ExecuteResult;
        }
        /// <summary>
        /// 后台修改用户信息
        /// </summary>
        /// <param name="ToCheck"></param>
        /// <returns></returns>
        public static bool Update(LoginInfo ToCheck)
        {
            Ops.OpLoginExecute op = new Ops.OpLoginExecute("Account", new sqlLoginUpdate(ToCheck));
            op.Do();
            return op.ExecuteResult;
        }
        
        /// <summary>
        /// 用户修改自己的密码
        /// </summary>
        /// <param name="ToCheck">新密码</param>
        /// <returns></returns>
        #region 修改密码
        public static bool ChangePassword(LoginInfo ToCheck)
        {
            Ops.OpLoginExecute op = new Ops.OpLoginExecute("Account", new sqlChangePassword(ToCheck));
            op.Do();
            return op.ExecuteResult;
        } 
        #endregion
    }
}
