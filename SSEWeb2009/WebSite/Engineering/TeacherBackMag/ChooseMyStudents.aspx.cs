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

public partial class Engineering_TeacherBackMag_ChooseMyStudents : System.Web.UI.Page
{
    private string teacherID;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["IdentifyNumber"] == null)
        {
            SysCom.Login.LoginRedirect(Request.Url.ToString());
        }
        teacherID = Session["IdentifyNumber"].ToString();
        if (!IsPostBack)
        {
            bindGvChoosingStu();
        }
    }
    protected void bindGvChoosingStu()
    {
        TeachingAgendaManage taMag = new TeachingAgendaManage();
        DataSet ds = taMag.GetChoosingStuAgenda();
        gvChoosingStu.DataSource = ds.Tables[0];
        gvChoosingStu.DataBind();
        if (ds.Tables[0].Rows.Count > 0)
        {
            lblRes.Visible = false;
            div_choseStu.Visible = true;
        }
        else
        {
            lblRes.Visible = true;
            div_choseStu.Visible = false;
        }
        
    }
    protected void gvChoosingStu_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HyperLink hl = (HyperLink)e.Row.FindControl("hlStartChoosing");
            Label lb = (Label)e.Row.FindControl("lblNul");
            int tMagID = Convert.ToInt32(gvChoosingStu.DataKeys[e.Row.RowIndex].Value);
            StudentManage sMag = new StudentManage();
            DataSet ds = sMag.GetTeaChooseStuInfo(tMagID, teacherID);
            int num = ds.Tables[0].Rows.Count;
            if (num == 0)
            {
                //没有学生选该教师
                lb.Visible = true;
                hl.Visible = false;
                e.Row.Cells[4].Text = "请等待教务员分配";
                e.Row.Cells[3].Text = "未选择";
            }
            else
            { 
                //有学生选择该教师
                hl.Visible = true;
                lb.Visible = false;
                int i;
                for (i = 0; i < num; i++)
                {
                    if (Convert.ToInt32(ds.Tables[0].Rows[i]["TeaWill"]) == 1)
                    {
                        break;
                    }
                }
                if (i == num)
                {
                    //未选择
                    e.Row.Cells[3].Text = "未选择";                    
                }
                else
                {
                    //选择
                    e.Row.Cells[3].Text = "已选择";                    
                }
            }
            if (ddlSelect.SelectedValue != "全部" && ddlSelect.SelectedValue != e.Row.Cells[3].Text)
            {
                e.Row.Visible = false;
            }
        }
    }
    public string GetSpanTime(string time)
    {
        string choosingTime = "";
        DateTime nowTime = DateTime.Now;
        DateTime endTime = Convert.ToDateTime(time);
        TimeSpan ts = nowTime - endTime;
        int span = 15 - ts.Days+1;
        choosingTime = "距离选学生结束还剩下 <span style='color:Red'>" + span + "</span> 天";
        return choosingTime;
    }
    protected void ddlSelect_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindGvChoosingStu();
    }
}
