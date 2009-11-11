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

public partial class Engineering_AdminBakMag_StuChoosingChangeDetails : System.Web.UI.Page
{
    private string stuid;

    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["IdentifyNumber"] == null)
        //{
        //    SysCom.Login.LoginRedirect(Request.Url.ToString());
        //}
        if (Request["id"] != null && Request["id"] != "")
        {
            stuid = Request["id"].ToString();
            if (!IsPostBack)
            {
                bindDvStuChangeInfo();                
            }
        }
    }
    protected void bindDvStuChangeInfo()
    {
        QueryInfo qInfo = new QueryInfo();
        qInfo.AccountID = stuid;
        StudentManage sMag = new StudentManage();
        DataSet ds = sMag.GetStusInfo(qInfo);
        dvStuChangeInfo.DataSource = ds.Tables[0];
        dvStuChangeInfo.DataBind();
    }
    protected void dvStuChangeInfo_DataBound(object sender, EventArgs e)
    {
        if (dvStuChangeInfo.CurrentMode == DetailsViewMode.Edit)
        {
            dvStuChangeInfo.Rows[7].Cells[0].Text = "为他分配导师：";
            TeacherManage tMag = new TeacherManage();
            DataSet ds = tMag.GetAllTutorInfoList();
            DropDownList dl = (DropDownList)dvStuChangeInfo.Rows[7].FindControl("ddlTeacher");
            dl.DataTextField = "UserName";
            dl.DataValueField = "UserID";
            dl.DataSource = ds.Tables[0];
            dl.DataBind();
        }
        else
        {
            StudentManage sMag = new StudentManage();
            string stuid = dvStuChangeInfo.DataKey.Value.ToString();
            DataSet ds = sMag.GetChoosingTutorByStuID(stuid);
            Label lb = (Label)dvStuChangeInfo.Rows[7].FindControl("lblTeacher");
            int count = ds.Tables[0].Rows.Count;
            if (count == 0)
            {
                //该生么有选导师
                lb.Text = "没有导师选他";
                lb.ForeColor = System.Drawing.Color.Red;
            }
            else if (count == 1)
            {
                if (Convert.ToInt32(ds.Tables[0].Rows[0]["TeaWill"]) == 1)
                {
                    lb.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                }
            }
            else if (count == 2)
            {
                int iTeaWill1 = Convert.ToInt32(ds.Tables[0].Rows[0]["TeaWill"]);
                int iTeaWill2 = Convert.ToInt32(ds.Tables[0].Rows[1]["TeaWill"]);
                if (iTeaWill1 == 0 && iTeaWill2 == 0)
                {
                    //2个老师都没选他
                    lb.Text = "没有导师选他";
                    lb.ForeColor = System.Drawing.Color.Red;
                }
                else if (iTeaWill1 == 1 && iTeaWill2 == 1)
                {
                    //2个老师都选他
                    string sWill1 = ds.Tables[0].Rows[0]["Will"].ToString();
                    string sWill2 = ds.Tables[0].Rows[1]["Will"].ToString();
                    if (sWill1.Contains("1") == true)
                    {
                        lb.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                    }
                    else
                    {
                        lb.Text = ds.Tables[0].Rows[1]["Name"].ToString();
                    }
                }
                else if (iTeaWill1 == 1 && iTeaWill2 == 0)
                {
                    //1个老师选他
                    lb.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                }
                else
                {
                    lb.Text = ds.Tables[0].Rows[1]["Name"].ToString();
                }
            }
            else
            {
                int iTeaWill1 = Convert.ToInt32(ds.Tables[0].Rows[0]["TeaWill"]);
                int iTeaWill2 = Convert.ToInt32(ds.Tables[0].Rows[1]["TeaWill"]);
                int iTeaWill3 = Convert.ToInt32(ds.Tables[0].Rows[2]["TeaWill"]);
                if (iTeaWill1 == 0 && iTeaWill2 == 0 && iTeaWill3 == 0)
                {
                    // 没有老师选他
                    lb.Text = "没有导师选他";
                    lb.ForeColor = System.Drawing.Color.Red;
                }
                else if (iTeaWill1 == 1 && iTeaWill2 == 1 && iTeaWill3 == 0)
                {
                    if (Convert.ToInt32(ds.Tables[0].Rows[0]["Will"]) < Convert.ToInt32(ds.Tables[0].Rows[1]["Will"]))
                    {
                        lb.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                    }
                    else
                    {
                        lb.Text = ds.Tables[0].Rows[1]["Name"].ToString();
                    }
                }
                else if (iTeaWill1 == 1 && iTeaWill2 == 0 && iTeaWill3 == 1)
                {
                    if (Convert.ToInt32(ds.Tables[0].Rows[0]["Will"]) < Convert.ToInt32(ds.Tables[0].Rows[2]["Will"]))
                    {
                        lb.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                    }
                    else
                    {
                        lb.Text = ds.Tables[0].Rows[2]["Name"].ToString();
                    }
                }
                else if (iTeaWill1 == 0 && iTeaWill2 == 1 && iTeaWill3 == 1)
                {
                    if (Convert.ToInt32(ds.Tables[0].Rows[1]["Will"]) < Convert.ToInt32(ds.Tables[0].Rows[2]["Will"]))
                    {
                        lb.Text = ds.Tables[0].Rows[1]["Name"].ToString();
                    }
                    else
                    {
                        lb.Text = ds.Tables[0].Rows[2]["Name"].ToString();
                    }
                }
                else if (iTeaWill1 == 1 && iTeaWill2 == 1 && iTeaWill3 == 1)
                {
                    if (Convert.ToInt32(ds.Tables[0].Rows[0]["Will"]) == 1)
                    {
                        lb.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                    }
                    else if (Convert.ToInt32(ds.Tables[0].Rows[1]["Will"]) == 1)
                    {
                        lb.Text = ds.Tables[0].Rows[1]["Name"].ToString();
                    }
                    else
                    {
                        lb.Text = ds.Tables[0].Rows[2]["Name"].ToString();
                    }
                }
                else
                {
                    if (iTeaWill1 == 1)
                    {
                        lb.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                    }
                    if (iTeaWill2 == 1)
                    {
                        lb.Text = ds.Tables[0].Rows[1]["Name"].ToString();
                    }
                    if (iTeaWill3 == 1)
                    {
                        lb.Text = ds.Tables[0].Rows[2]["Name"].ToString();
                    }
                }
            }
        }
    }
    protected void dvStuChangeInfo_ModeChanging(object sender, DetailsViewModeEventArgs e)
    {
        if (e.NewMode == DetailsViewMode.Edit)
        {
            dvStuChangeInfo.ChangeMode(DetailsViewMode.Edit);
            bindDvStuChangeInfo();
        }
        else if (e.CancelingEdit == true)
        {
            if (dvStuChangeInfo.CurrentMode == DetailsViewMode.Edit)
            {
                dvStuChangeInfo.ChangeMode(DetailsViewMode.ReadOnly);
                bindDvStuChangeInfo();
            }
        }
    
    }
    protected void dvStuChangeInfo_ItemCreated(object sender, EventArgs e)
    {        
        Label lb1 = (Label)dvStuChangeInfo.Rows[4].FindControl("lblFirstWill");
        Label lb2 = (Label)dvStuChangeInfo.Rows[5].FindControl("lblSecondWill");
        Label lb3 = (Label)dvStuChangeInfo.Rows[6].FindControl("lblThirdWill");
        StudentManage sMag = new StudentManage();
        DataSet ds = sMag.GetStuChooseTeacherInfo(stuid);
        int WillCount = ds.Tables[0].Rows.Count;
        lb1.Text = "无";
        lb2.Text = "无";
        lb3.Text = "无";        
        if( WillCount != 0 )
        {
            for (int i = 0; i < WillCount; i++)
            {
                if (ds.Tables[0].Rows[i]["Will"].ToString() == "1")
                {
                    lb1.Text = ds.Tables[0].Rows[i]["Name"].ToString();
                }
                if (ds.Tables[0].Rows[i]["Will"].ToString() == "2")
                {
                    lb2.Text = ds.Tables[0].Rows[i]["Name"].ToString();
                }
                if (ds.Tables[0].Rows[i]["Will"].ToString() == "3")
                {
                    lb3.Text = ds.Tables[0].Rows[i]["Name"].ToString();
                }
            }
        }

    }
    protected void dvStuChangeInfo_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
    {
        string stuid = dvStuChangeInfo.DataKey.Value.ToString();
        DropDownList dl = (DropDownList)dvStuChangeInfo.Rows[4].FindControl("ddlTeacher");
        StudentManage sMag = new StudentManage();
        DataSet ds = sMag.GetChoosingTutorByStuID(stuid);
        int count = ds.Tables[0].Rows.Count;
        if (dl.SelectedIndex == 0)
        {
            lblRes.Text = "请选择要为该生分配的导师！";
            lblRes.Visible = true;
        }
        else
        {
            string teacherID = dl.SelectedValue;
            if (count == 0)
            {
                //该生没有选导师
                Willing will = new Willing();
                will.StuID = stuid;
                will.TeacherID = teacherID;
                if (sMag.AddTutorChoosingInfoByAdm(will) == true)
                {
                    lblRes.Text = "调剂成功！";
                    lblRes.Visible = true;
                    dvStuChangeInfo.ChangeMode(DetailsViewMode.ReadOnly);
                    bindDvStuChangeInfo();
                }
                else
                {
                    lblRes.Text = "调剂失败，请重试！";
                    lblRes.Visible = true;
                    dvStuChangeInfo.ChangeMode(DetailsViewMode.ReadOnly);
                    bindDvStuChangeInfo();
                }
            }
            else
            {
                //更换志愿
                Willing will = new Willing();
                will.TeacherID = teacherID;
                will.StuID = stuid;
                if (true == sMag.UpdateTutorChoosingTran(will))
                {
                    //更新成功
                    lblRes.Text = "调剂成功！";
                    lblRes.Visible = true;
                    dvStuChangeInfo.ChangeMode(DetailsViewMode.ReadOnly);
                    bindDvStuChangeInfo();
                }
                else
                {
                    //更新失败
                    lblRes.Text = "调剂失败，请重试！";
                    lblRes.Visible = true;
                    dvStuChangeInfo.ChangeMode(DetailsViewMode.ReadOnly);
                    bindDvStuChangeInfo();
                }
            }
        }
    }
}
