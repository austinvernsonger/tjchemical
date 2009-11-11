using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Department.Engineering;
using System.Collections.Generic;

public partial class Engineering_AdminBakMag_TutorChooseingDetails : System.Web.UI.Page
{
    private Dictionary<string, string> StuTea = new Dictionary<string, string>();
    private QueryInfo qInfo = new QueryInfo();

    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["IdentifyNumber"] == null)
        //{
        //    SysCom.Login.LoginRedirect(Request.Url.ToString());
        //}
        if (Request["grade"] != null && Request["grade"] != "" 
            && Request["schoolid"] != null && Request["schoolid"] != "")
        {
            string grade = Request["grade"].ToString();
           string schoolid = Request["schoolid"].ToString();            
            
            qInfo.Grade = grade;
            qInfo.TSchoolID = schoolid;
            lblResult.Text = "";
            StudentManage sMag = new StudentManage();
            DataSet ds = sMag.GetStusInfo(qInfo);
            gvTutorChoosing.DataSource = ds.Tables[0];
            gvTutorChoosing.DataBind();
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblGrade.Text = "年级："+ds.Tables[0].Rows[0]["Grade"].ToString();
                lblSchool.Text = "教学点："+ds.Tables[0].Rows[0]["TeaSchoolName"].ToString();
            }
            ViewState["Count"] = ds.Tables[0].Rows.Count;

            GetTutorsTempStd();
        }
    }
    protected void gvTutorChoosing_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            string stuid = gvTutorChoosing.DataKeys[e.Row.RowIndex].Value.ToString();
            LinkButton lbStu = (LinkButton)e.Row.FindControl("lbStuNo");
            lbStu.Attributes.Add("onclick", "javascript:OpenOvertimeDlog('" + stuid + "',550,500)"); 
            StudentManage sMag = new StudentManage();
            DataSet ds = sMag.GetChoosingTutorByStuID(stuid);
            int count = ds.Tables[0].Rows.Count;
            if (count == 0)
            {
                //该生没有选导师
                e.Row.Cells[3].Text = "未分配";
                e.Row.Cells[3].ForeColor = System.Drawing.Color.Red;
                StuTea.Add(stuid, "NULL");
            }

            //选导师的表中只有一个志愿，应该是对应着调剂过后的情况
            if (count == 1)
            {
                //只选择了一个老师
                if (Convert.ToInt32(ds.Tables[0].Rows[0]["TeaWill"]) == 1)
                {
                    //有导师选该生
                    string teaid = ds.Tables[0].Rows[0]["TeacherID"].ToString();
                    e.Row.Cells[3].Text = ds.Tables[0].Rows[0]["Name"].ToString();
                    StuTea.Add(stuid, teaid);
                }
                else
                {
                    //该导师没选他
                    e.Row.Cells[3].Text = "未分配";
                    e.Row.Cells[3].ForeColor = System.Drawing.Color.Red;
                    StuTea.Add(stuid, "NULL");
                }
            }
            ////////if (count == 2)
            ////////{
            ////////    //表示选择了两个导师
            ////////    int teaWill1 = Convert.ToInt32(ds.Tables[0].Rows[0]["TeaWill"]);
            ////////    int teaWill2 = Convert.ToInt32(ds.Tables[0].Rows[1]["TeaWill"]);
            ////////    if (teaWill1 == 0 && teaWill2 == 0)
            ////////    {
            ////////        // 两个导师都没选该生
            ////////        e.Row.Cells[3].Text = "未分配";
            ////////        e.Row.Cells[3].ForeColor = System.Drawing.Color.Red;
            ////////        StuTea.Add(stuid, "NULL");
            ////////    }
            ////////    else if (teaWill1 == 1 && teaWill2 == 1)
            ////////    {
            ////////        //两个导师都选了该生
            ////////        string stuWill1 = ds.Tables[0].Rows[0]["Will"].ToString();
            ////////        string stuWill2 = ds.Tables[0].Rows[1]["Will"].ToString();
            ////////        if (stuWill1.Contains(",") == true)
            ////////        {
            ////////            string[] will = stuWill1.Split(',');
            ////////            int iWill1 = Convert.ToInt32(will[0]);
            ////////            int iWill2 = Convert.ToInt32(will[1]);
            ////////            int iWill3 = Convert.ToInt32(stuWill2);
            ////////            if (iWill3 < iWill1 && iWill3 < iWill2)
            ////////            {
            ////////                string teaid = ds.Tables[0].Rows[1]["TeacherID"].ToString();
            ////////                e.Row.Cells[3].Text = ds.Tables[0].Rows[1]["Name"].ToString();
            ////////                StuTea.Add(stuid, teaid);
            ////////            }
            ////////            else
            ////////            {
            ////////                string teaid = ds.Tables[0].Rows[0]["TeacherID"].ToString();
            ////////                e.Row.Cells[3].Text = ds.Tables[0].Rows[0]["Name"].ToString();
            ////////                StuTea.Add(stuid, teaid);
            ////////            }
            ////////        }
            ////////        else
            ////////        {
            ////////            string[] will = stuWill2.Split(',');
            ////////            int iWill1 = Convert.ToInt32(stuWill1);
            ////////            int iWill2 = Convert.ToInt32(will[0]);
            ////////            int iWill3 = Convert.ToInt32(will[1]);
            ////////            if (iWill1 < iWill2 && iWill1 < iWill3)
            ////////            {
            ////////                string teaid = ds.Tables[0].Rows[0]["TeacherID"].ToString();
            ////////                e.Row.Cells[3].Text = ds.Tables[0].Rows[0]["Name"].ToString();
            ////////                StuTea.Add(stuid, teaid);
            ////////            }
            ////////            else
            ////////            {
            ////////                string teaid = ds.Tables[0].Rows[1]["TeacherID"].ToString();
            ////////                e.Row.Cells[3].Text = ds.Tables[0].Rows[1]["Name"].ToString();
            ////////                StuTea.Add(stuid, teaid);
            ////////            }
            ////////        }
            ////////    }
            ////////    else if (teaWill1 == 1 && teaWill2 == 0)
            ////////    {
            ////////        string teaid = ds.Tables[0].Rows[0]["TeacherID"].ToString();
            ////////        e.Row.Cells[3].Text = ds.Tables[0].Rows[0]["Name"].ToString();
            ////////        StuTea.Add(stuid, teaid);
            ////////    }
            ////////    else
            ////////    {
            ////////        string teaid = ds.Tables[0].Rows[1]["TeacherID"].ToString();
            ////////        e.Row.Cells[3].Text = ds.Tables[0].Rows[1]["Name"].ToString();
            ////////        StuTea.Add(stuid, teaid);
            ////////    }

            ////////}
            if (count == 3)
            {
                //选了3个导师
                int teaWill1 = Convert.ToInt32(ds.Tables[0].Rows[0]["TeaWill"]);
                int teaWill2 = Convert.ToInt32(ds.Tables[0].Rows[1]["TeaWill"]);
                int teaWill3 = Convert.ToInt32(ds.Tables[0].Rows[2]["TeaWill"]);
                if (teaWill1 == 0 && teaWill2 == 0 && teaWill3 == 0)
                {
                    //没有导师选该生
                    e.Row.Cells[3].Text = "未分配";
                    e.Row.Cells[3].ForeColor = System.Drawing.Color.Red;
                    StuTea.Add(stuid, "NULL");
                }
                else if (teaWill1 == 1 && teaWill2 == 1 && teaWill3 == 1)
                {
                    //3个导师都选了该生
                    int iWill1 = Convert.ToInt32(ds.Tables[0].Rows[0]["Will"]);
                    int iWill2 = Convert.ToInt32(ds.Tables[0].Rows[1]["Will"]);
                    int iWill3 = Convert.ToInt32(ds.Tables[0].Rows[2]["Will"]);
                    int minWill = Math.Min(Math.Min(iWill1, iWill2), iWill3);
                    if (iWill1 == minWill)
                    {
                        string teaid = ds.Tables[0].Rows[0]["TeacherID"].ToString();
                        e.Row.Cells[3].Text = ds.Tables[0].Rows[0]["Name"].ToString();
                        StuTea.Add(stuid, teaid);
                    }
                    if (iWill2 == minWill)
                    {
                        string teaid = ds.Tables[0].Rows[1]["TeacherID"].ToString();
                        e.Row.Cells[3].Text = ds.Tables[0].Rows[1]["Name"].ToString();
                        StuTea.Add(stuid, teaid);
                    }
                    if (iWill3 == minWill)
                    {
                        string teaid = ds.Tables[0].Rows[2]["TeacherID"].ToString();
                        e.Row.Cells[3].Text = ds.Tables[0].Rows[2]["Name"].ToString();
                        StuTea.Add(stuid, teaid);
                    }
                }
                else if (teaWill1 == 1 && teaWill2 == 1 && teaWill3 == 0)
                {
                    int iWill1 = Convert.ToInt32(ds.Tables[0].Rows[0]["Will"]);
                    int iWill2 = Convert.ToInt32(ds.Tables[0].Rows[1]["Will"]);
                    if (iWill1 < iWill2)
                    {
                        string teaid = ds.Tables[0].Rows[0]["TeacherID"].ToString();
                        e.Row.Cells[3].Text = ds.Tables[0].Rows[0]["Name"].ToString();
                        StuTea.Add(stuid, teaid);
                    }
                    else
                    {
                        string teaid = ds.Tables[0].Rows[1]["TeacherID"].ToString();
                        e.Row.Cells[3].Text = ds.Tables[0].Rows[1]["Name"].ToString();
                        StuTea.Add(stuid, teaid);
                    }
                }
                else if (teaWill1 == 0 && teaWill2 == 1 && teaWill3 == 1)
                {
                    int iWill2 = Convert.ToInt32(ds.Tables[0].Rows[1]["Will"]);
                    int iWill3 = Convert.ToInt32(ds.Tables[0].Rows[2]["Will"]);
                    if (iWill2 < iWill3)
                    {
                        string teaid = ds.Tables[0].Rows[1]["TeacherID"].ToString();
                        e.Row.Cells[3].Text = ds.Tables[0].Rows[1]["Name"].ToString();
                        StuTea.Add(stuid, teaid);
                    }
                    else
                    {
                        string teaid = ds.Tables[0].Rows[2]["TeacherID"].ToString();
                        e.Row.Cells[3].Text = ds.Tables[0].Rows[2]["Name"].ToString();
                        StuTea.Add(stuid, teaid);
                    }
                }
                else if (teaWill1 == 1 && teaWill2 == 0 && teaWill3 == 1)
                {
                    int iWill1 = Convert.ToInt32(ds.Tables[0].Rows[0]["Will"]);
                    int iWill3 = Convert.ToInt32(ds.Tables[0].Rows[2]["Will"]);
                    if (iWill1 < iWill3)
                    {
                        string teaid = ds.Tables[0].Rows[0]["TeacherID"].ToString();
                        e.Row.Cells[3].Text = ds.Tables[0].Rows[0]["Name"].ToString();
                        StuTea.Add(stuid, teaid);
                    }
                    else
                    {
                        string teaid = ds.Tables[0].Rows[2]["TeacherID"].ToString();
                        e.Row.Cells[3].Text = ds.Tables[0].Rows[2]["Name"].ToString();
                        StuTea.Add(stuid, teaid);
                    }
                }
                else
                {
                    if (teaWill1 == 1)
                    {
                        string teaid = ds.Tables[0].Rows[0]["TeacherID"].ToString();
                        e.Row.Cells[3].Text = ds.Tables[0].Rows[0]["Name"].ToString();
                        StuTea.Add(stuid, teaid);
                    }
                    if (teaWill2 == 1)
                    {
                        string teaid = ds.Tables[0].Rows[1]["TeacherID"].ToString();
                        e.Row.Cells[3].Text = ds.Tables[0].Rows[1]["Name"].ToString();
                        StuTea.Add(stuid, teaid);
                    }
                    if (teaWill3 == 1)
                    {
                        string teaid = ds.Tables[0].Rows[2]["TeacherID"].ToString();
                        e.Row.Cells[3].Text = ds.Tables[0].Rows[2]["Name"].ToString();
                        StuTea.Add(stuid, teaid);
                    }
                }
            }            
            
        }
    }

    protected void btSave_Click(object sender, EventArgs e)
    {
        StudentManage sMag = new StudentManage();
        if (true == sMag.UpdateStusTutorTrans(qInfo, StuTea))
        {
            //成功
            btSave.Enabled = false;
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('保存成功')</script>");
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('保存失败')</script>");
        }
    }

    protected void GetTutorsTempStd()
    {
        TeacherManage tm = new TeacherManage();
        DataSet ds = tm.GetTutorsInfoList();
        gvTutorsTempStdNum.DataSource = ds.Tables[0].DefaultView;
        gvTutorsTempStdNum.DataBind();
    }

    protected void gvTutorsTempStdNum_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.DataItem != null)
        {
            int stdNum = 0;
            int gv2Count = Convert.ToInt32(ViewState["Count"]);
            string TutorName = e.Row.Cells[0].Text.ToString().Trim();
            for (int j = 0; j < gv2Count; j++)
            {
                if (TutorName == gvTutorChoosing.Rows[j].Cells[3].Text.ToString().Trim())
                {
                    stdNum++;
                }
            }
            e.Row.Cells[3].Text = stdNum.ToString();
        }     
    }
}
