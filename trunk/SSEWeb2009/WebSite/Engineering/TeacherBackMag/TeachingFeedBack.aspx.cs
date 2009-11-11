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

public partial class Engineering_TeacherBackMag_TeachingFeedBack : System.Web.UI.Page
{
    private int courseID;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["IdentifyNumber"] == null)
        {
            SysCom.Login.LoginRedirect(Request.Url.ToString());
        }
        if (Request["item"] != "" && Request["item"] != null &&
            Request["courseid"]!=""&& Request["courseid"] !=null)
        {
            courseID = Convert.ToInt32(Request["courseid"]);
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
        //返回评教人数
        CourseManage cMag = new CourseManage();
        DataSet dsSum = cMag.GetTeachingFeedBackStuNum(courseID);
        lblSum.Text = dsSum.Tables[0].Rows.Count.ToString();
        //显示评教结果
        int item = Convert.ToInt32(Request["item"]);
        DataSet dsXml = new DataSet();
        dsXml.ReadXml(Server.MapPath(@"../Resources/Xml/xmlEvaluationRes.xml"));
        string xmlRes = dsXml.Tables[0].Rows[item]["Result"].ToString();
        System.IO.StringReader sr = new System.IO.StringReader(xmlRes);
        DataSet ds = new DataSet();
        ds.ReadXml(sr);
        gvResult.DataSource = ds.Tables[0];
        gvResult.DataBind();
        //获取用户建议
        string xmlSuggestion = dsXml.Tables[0].Rows[item]["Suggestion"].ToString();
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
