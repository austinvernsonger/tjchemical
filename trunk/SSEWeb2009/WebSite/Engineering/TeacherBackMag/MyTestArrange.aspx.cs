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

public partial class Engineering_TeacherBackMag_MyTestArrange : System.Web.UI.Page
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
            bindTestArrangement();
        }
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
    public string GetSupervisor(string teacherID)
    {
        TeacherManage tMag = new TeacherManage();
        DataSet ds = tMag.GetTeacherInfoByTeacherID(teacherID);
        string name = ds.Tables[0].Rows[0]["Name"].ToString();
        return name;
    }
    protected void bindTestArrangement()
    {
        TestManage tMag = new TestManage();
        DataSet ds = tMag.GetExamArrangementByTeacher(teacherID);
        if (ds.Tables[0].Rows.Count > 0)
        {
            Table1.Visible = true;
            lblMessage.Visible = false;
            int rowCount = ds.Tables[0].Rows.Count;
            for (int i = 0; i < rowCount; i++)
            {
                string name = "";
                TableRow row = new TableRow();
                row.HorizontalAlign = HorizontalAlign.Center;
                for (int j = 0; j < 5; j++)
                {
                    TableCell cell = new TableCell();
                    cell.Height = 31;
                    row.Cells.Add(cell);
                    cell.BorderColor = System.Drawing.Color.Black;
                    cell.BorderStyle = BorderStyle.Solid;
                    cell.BorderWidth = 1;
                }
                row.Cells[0].Text = GetCourseTime(ds.Tables[0].Rows[i][0].ToString());
                row.Cells[1].Text = ds.Tables[0].Rows[i][1].ToString();
                row.Cells[2].Text = ds.Tables[0].Rows[i][2].ToString();
                row.Cells[2].ForeColor = System.Drawing.Color.Red;
                row.Cells[3].Text = ds.Tables[0].Rows[i][3].ToString();
                if (ds.Tables[0].Rows[i][4] != System.DBNull.Value
                    && ds.Tables[0].Rows[i][4].ToString() != "")
                {
                    name = GetSupervisor(ds.Tables[0].Rows[i][4].ToString());
                }
                if (ds.Tables[0].Rows[i][5] != System.DBNull.Value
                   && ds.Tables[0].Rows[i][5].ToString() != "")
                {
                    name = name + " " + GetSupervisor(ds.Tables[0].Rows[i][5].ToString());
                }
                row.Cells[4].Text = name;
                Table1.Rows.Add(row);
            }
        }
        else
        {
            Table1.Visible = false;
            lblMessage.Visible = true;
        }
    }
}
