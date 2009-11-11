using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using StudentManages.Sql;
using System.Data;
using System.Collections;

public partial class StudentManage_LoginCheck : System.Web.UI.Page
{
    BaseOperate sqlBaseOp;
    protected void Page_Load(object sender, EventArgs e)
    {
        string ID = Convert.ToString(Session["IdentifyNumber"]);
        StringBuilder sb = new StringBuilder("select Grade,Class,Type from Privilege where ID='");
        sb.Append(ID);
        sb.Append("'");
        sqlBaseOp = new BaseOperate();
        DataSet ds= sqlBaseOp.Select(sb.ToString());
        DataTable dt=ds.Tables[0];
        string toURL="";

        if (dt.Rows.Count == 0)
        {
            //学生
            toURL = "StudentInfo.aspx";
        }
        else 
        { 
            
            if (Convert.ToInt32( dt.Rows[0][2]) == 0)
            {
                //打开班主任页面

                //班主任
                List<string[]> GradeClassArr = new List<string[]>();
                foreach (DataRow row in dt.Rows)
                {
                    string[] GradeClassEle = new string[2];
                    GradeClassEle[0] = row[0].ToString();
                    GradeClassEle[1] = row[1].ToString();
                    GradeClassArr.Add(GradeClassEle);
                }
                Session["HeadTeacher_GradeClass"] = GradeClassArr;
                toURL = "HeadTeacherSA.aspx";

            }
            else if (Convert.ToInt32(dt.Rows[0][2]) == 1)
            {
                Response.Write("管理员");
                toURL = "AdministratorContestVerify.aspx";
                //打开管理员页面

                //管理员
            }
        }
    //判断身份，管理员？班主任？学生？
        this.Response.Redirect(toURL);
    }
}
