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

public partial class Engineering_AdminBakMag_ViewTeachingEvaluationRes : System.Web.UI.Page
{
    private int courseID;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["id"] != "" && Request["id"] != null)
        {
            courseID = Convert.ToInt32(Request["id"]);
            bindData();
        }
    }
    protected void gvResult_PreRender(object sender, EventArgs e)
    {
        for (int rowIndex = gvResult.Rows.Count - 2; rowIndex >= 0; rowIndex--)
        {
            GridViewRow row = gvResult.Rows[rowIndex];
            GridViewRow previousRow = gvResult.Rows[rowIndex + 1];
            if (row.Cells[0].Text == previousRow.Cells[0].Text)
            {
                row.Cells[0].RowSpan = previousRow.Cells[0].RowSpan < 2 ? 2 : previousRow.Cells[0].RowSpan + 1;
                previousRow.Cells[0].Visible = false;
            }

        }
    }
    protected void gvSuggestion_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvSuggestion.PageIndex = e.NewPageIndex;
        bindData();
    }
    protected void bindData()
    {
        CourseManage cMag = new CourseManage();
        DataSet dsNum = cMag.GetTeachingFeedBackStuNum(courseID);
        lblSum.Text = dsNum.Tables[0].Rows.Count.ToString();
        DataSet dsXml = new DataSet();
        dsXml.ReadXml(Server.MapPath(@"../Resources/Xml/xmlEvaluationRes.xml"));
        int num = dsXml.Tables[0].Rows.Count;
        int i;
        for (i = 0; i < num; i++)
        {
            int courID = Convert.ToInt32(dsXml.Tables[0].Rows[i]["CourseID"]);
            if (courID == courseID)
            {
                //已经有人对该门课程进行了评教;
                break;
            }
        }
        if (i == num)
        {
            //还没有人对该门课程进行评教
            //Panel1.Visible= false;
            //lblText.Visible = true;
            return;
        }
        string xmlRes = dsXml.Tables[0].Rows[i]["Result"].ToString();
        System.IO.StringReader sr = new System.IO.StringReader(xmlRes);
        DataSet ds = new DataSet();
        ds.ReadXml(sr);
        gvResult.DataSource = ds.Tables[0];
        gvResult.DataBind();
        ds = cMag.GetCourseTeacherInfo(courseID);
        if (ds.Tables[0].Rows.Count > 0)
        {
            lblCourseName.Text = "课程名称：" + ds.Tables[0].Rows[0]["CourseName"].ToString();
            if (ds.Tables[0].Rows.Count == 1)
            {
                lblTeacher.Text = "任课教师：" + ds.Tables[0].Rows[0]["Name"].ToString();
            }
            if (ds.Tables[0].Rows.Count == 2)
            {
                lblTeacher.Text = "任课教师：" + ds.Tables[0].Rows[0]["Name"].ToString() + "," + ds.Tables[0].Rows[1]["Name"].ToString();
            }
        }
        //获取用户建议
        string xmlSuggestion = dsXml.Tables[0].Rows[i]["Suggestion"].ToString();
        if (xmlSuggestion != "")
        {
            System.IO.StringReader srSug = new System.IO.StringReader(xmlSuggestion);
            DataSet ds1 = new DataSet();
            ds1.ReadXml(srSug);
            gvSuggestion.DataSource = ds1.Tables[0];
            gvSuggestion.DataBind();
        }  
    }
}
