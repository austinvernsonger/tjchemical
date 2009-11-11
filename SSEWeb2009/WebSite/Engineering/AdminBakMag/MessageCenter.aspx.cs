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

public partial class Engineering_AdminBakMag_MessageCenter : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //绑定学籍变动信息
            BindApplyRecord();
            //绑定选课结果信息
            bindCourseResult();
            //绑定导师结果信息
            bindTutorResult();
            //绑定论文分配信息
            bindThesisInfo();
        }
    }

    protected void BindApplyRecord()
    {
        StatusChgAppMgr scm = new StatusChgAppMgr();
        DataSet ds = scm.GetUnhandleStatusApp();
        int num = ds.Tables[0].Rows.Count;
        if (num > 0)
        {
            lnbApply.Text =num + "条新";
            lnbApply.ForeColor = System.Drawing.Color.Red;
        }
        else
        {
            lnbApply.Text = "0条新";
        }
    }
    protected void bindCourseResult()
    {
        TeachingAgendaManage taMag = new TeachingAgendaManage();
        DataSet ds = taMag.GetUnhandleChoosingCourseArragement();
        int num = ds.Tables[0].Rows.Count;
        if (num == 0)
        {
            lnbCourse.Text = "0条新";
        }
        else
        {
            lnbCourse.Text = num + "条新";
            lnbCourse.ForeColor = System.Drawing.Color.Red;
        }
    }
    protected void bindTutorResult()
    {
        TeacherManage tMag = new TeacherManage();
        DataSet ds = tMag.GetCompleteTutorTime();
        int num = ds.Tables[0].Rows.Count;
        if (num > 0)
        {
            lnbTutor.Text = num + "条新";
            lnbTutor.ForeColor = System.Drawing.Color.Red;
        }
        else
        {
            lnbTutor.Text = "0条新";
        }
    }
    protected void bindThesisInfo()
    {
        DocumentManage dMag = new DocumentManage();
        DataSet ds = dMag.GetSqlPrejudicationStatus();
        int num = ds.Tables[0].Rows.Count;
        if (num > 0)
        {
            lnbThesis.Text = num + "条新";
            lnbThesis.ForeColor = System.Drawing.Color.Red;
        }
        else
        {
            lnbThesis.Text = "0条新";
        }
    }
}
