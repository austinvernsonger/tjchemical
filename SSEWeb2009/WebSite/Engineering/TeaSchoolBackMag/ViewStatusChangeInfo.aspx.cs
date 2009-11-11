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

public partial class Engineering_TeaSchoolBackMag_ViewStatusChangeInfo : System.Web.UI.Page
{
    //测试教学点编号
    int teaSchoolID = 34;

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btn_Query_Click(object sender, EventArgs e)
    {
        if (dplGrade.SelectedIndex == 0)
        {
            Response.Write("<script language='javascript'>alert('请选择你要查询的年级！')</script>");
        }
        else
        {
            string grade = dplGrade.SelectedValue;
            StatusChgAppMgr scm = new StatusChgAppMgr();
            DataSet ds = scm.GetTSchoolStatusList(teaSchoolID,grade);
            if (ds.Tables[0].Rows.Count == 0)
            {
                lblResult1.Text = "对不起，本教学点该年级没有同学！";
            }
            gvClassStatus.DataSource = ds.Tables[0];
            gvClassStatus.DataBind();
        }

        
    }
    protected void btn_SearchByType_Click(object sender, EventArgs e)
    {
        if (dplApplyChgType.SelectedIndex == 0)
        {
            Response.Write("<script language='javascript'>alert('请选择你要查询的年级！')</script>");
        }
        else
        {
            string applyCategory = dplApplyChgType.SelectedValue;
            StatusChgAppMgr scm = new StatusChgAppMgr();
            DataSet ds = scm.GetStatusChangeInTSchool(teaSchoolID, applyCategory);
            if (ds.Tables[0].Rows.Count == 0)
            {
                lblResult2.Text = "对不起，本教学点没有同学" + dplApplyChgType.SelectedValue.ToString() +"!";
            }
            gvChangeInfo.DataSource = ds.Tables[0];
            gvChangeInfo.DataBind();
        }

    }
}
