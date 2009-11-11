using System;
using System.Collections.Generic;
using System.Text;
using Department.Engineering;
using System.Data;

namespace Department.Engineering
{
    public class TeaSchoolLogin
    {
        public string CheckInfo = "";

        public bool TeaLogin(string Username, string Password)
        {
            CheckInfo = "";
            OpEngineerQuery op = new OpEngineerQuery("Engineering", new SqlGetTSchoolPwd(Username));
            op.Do();
            DataSet ds = op.Ds;
            if (ds.Tables[0].Rows.Count == 0)
            {
                CheckInfo = "对不起，登录的教学点名称不存在！";
                return false;
            }
            if (ds.Tables[0].Rows[0]["Password"].ToString() != Password)
            {
                CheckInfo = "对不起，密码不正确！";
                return false;
            }
            return true;

        }


        public bool ChangeTSchoolPwd(string TeaSchoolID, string Password)
        {
            OpEngineerExecute op = new OpEngineerExecute("Engineering", new SqlUpdateTSchoolPwd(TeaSchoolID,Password));
            op.Do();
            if (op.ExecuteResult == true)
            {
                return true;
            }
            return false;
        }
    }    
}
