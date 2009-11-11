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

public partial class Engineering_StuBackMag_TuitionInfo : System.Web.UI.Page
{
    private string studentID;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["IdentifyNumber"] == null)
        {
            SysCom.Login.LoginRedirect(Request.Url.ToString());
        }
        studentID = Session["IdentifyNumber"].ToString();
        bindTuitionInfo();
    }
    public string GetCourseTime(string cTime)
    {
        string courseTime = "";
        courseTime = cTime.Substring(0, 4);
        int term = Convert.ToInt32(cTime.Substring(4, 1));
        if (term == 0)
        {
            courseTime = courseTime + "秋";
        }
        else
        {
            courseTime = courseTime + "春";
        }
        return courseTime;
    }
    protected void bindTuitionInfo()
    {
        TuitionManage tMag = new TuitionManage();
        DataSet ds = tMag.GetTuitionInfo(studentID);
        if (ds.Tables[0].Rows.Count == 0)
        {
            lblMessage.Visible = true;
            Table1.Visible = false;
        }
        else
        {
            lblMessage.Visible = false;
            int rowCount = ds.Tables[0].Rows.Count;
            for (int i = 0; i < rowCount; i++)
            {
                TableRow row = new TableRow();
                row.HorizontalAlign = HorizontalAlign.Center;
                for (int j = 0; j < 5; j++)
                {
                    TableCell cell = new TableCell();
                    if (j == 0)
                    {
                        cell.Text = GetCourseTime(ds.Tables[0].Rows[i][j].ToString());
                    }
                    else if (j == 3)
                    {
                        cell.Text = Convert.ToDateTime(ds.Tables[0].Rows[i][j]).ToString("yyyy-MM-dd");
                    }
                    else
                    {
                        cell.Text = ds.Tables[0].Rows[i][j].ToString();
                    }
                    cell.Height = 31;
                    row.Cells.Add(cell);
                }
                Table1.Rows.Add(row);
            }
        }
    }
}
