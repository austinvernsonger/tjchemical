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
using System.Text;

public partial class Engineering_StuBackMag_MyScoreInfo : System.Web.UI.Page
{
    private string studentID;
    private string[] sProperty = new string[] { "学位课", "非学位课", "必修环节", "其他" };
    private string[] sCategory = new string[] { "必修", "选修", "其他" };
    private string resProperty = null;  //成绩性质
    private float result = 0;  //成绩
    private float degreeSum = 0; //学位学分
    private float ndegreeSum = 0; //非学位
    private float mclassSum = 0;  // 必修环节

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["IdentifyNumber"] == null)
        {
            SysCom.Login.LoginRedirect(Request.Url.ToString());
        }
        studentID = Session["IdentifyNumber"].ToString();
        bindMyScoreInfo();
    }
    protected void bindMyScoreInfo()
    {
        StudentManage sMag = new StudentManage();
        DataSet ds = sMag.GetExamResultByStuID(studentID);
        if (ds.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                TableRow row = new TableRow();
                row.HorizontalAlign = HorizontalAlign.Center;
                TableCell cell = new TableCell();
                if (dr["Property"] != System.DBNull.Value)
                {
                    cell.Text = sProperty[Convert.ToInt32(dr["Property"])];
                }
                else
                {
                    cell.Text = "";
                }
                cell.BorderColor = System.Drawing.Color.Black;
                cell.Height = 31;
                row.Cells.Add(cell);

                cell = new TableCell();
                if (dr["Category"] != System.DBNull.Value)
                {
                    cell.Text = sCategory[Convert.ToInt32(dr["Category"])];
                }
                else
                {
                    cell.Text = "";
                }
                cell.BorderColor = System.Drawing.Color.Black;
                row.Cells.Add(cell);
                cell = new TableCell();
                if (dr["ExamTime"] != System.DBNull.Value)
                {
                    cell.Text = dr["ExamTime"].ToString().Trim().Substring(0, 10);
                }
                else
                {
                    cell.Text = "";
                }
                cell.BorderColor = System.Drawing.Color.Black;
                row.Cells.Add(cell);

                cell = new TableCell();
                if (dr["CourseName"] != System.DBNull.Value)
                {
                    cell.Text = dr["CourseName"].ToString();
                }
                else
                {
                    cell.Text = "";
                }
                cell.BorderColor = System.Drawing.Color.Black;
                row.Cells.Add(cell);

                cell = new TableCell();
                if (dr["CreditHour"] != System.DBNull.Value)
                {
                    cell.Text = dr["CreditHour"].ToString();
                }
                else
                {
                    cell.Text = "";
                }
                cell.BorderColor = System.Drawing.Color.Black;
                row.Cells.Add(cell);

                cell = new TableCell();
                if (dr["Credit"] != System.DBNull.Value)
                {
                    cell.Text = dr["Credit"].ToString();
                }
                else
                {
                    cell.Text = "";
                }
                cell.BorderColor = System.Drawing.Color.Black;
                row.Cells.Add(cell);

                result = Convert.ToSingle(dr["CourResult"]);
                if (result >= 60)
                {
                    resProperty = "合格";
                }
                else
                {
                    resProperty = "不合格";
                }
                cell = new TableCell();
                cell.Text = result.ToString();
                cell.BorderColor = System.Drawing.Color.Black;
                row.Cells.Add(cell);

                cell = new TableCell();
                if (resProperty == "不合格")
                {
                    cell.BackColor = System.Drawing.Color.Red;
                }
                cell.Text = resProperty;
                cell.BorderColor = System.Drawing.Color.Black;
                row.Cells.Add(cell);

                Table1.Rows.Add(row);

                if (Convert.ToInt32(dr["Property"]) == 0 && string.Compare(resProperty, "合格") == 0)
                {
                    degreeSum += Convert.ToSingle(dr["Credit"]);
                }
                else if (Convert.ToInt32(dr["Property"]) == 1 && string.Compare(resProperty, "合格") == 0)
                {
                    ndegreeSum += Convert.ToSingle(dr["Credit"]);
                }
                else if (Convert.ToInt32(dr["Property"]) == 2 && string.Compare(resProperty, "合格") == 0)
                {
                    mclassSum += Convert.ToSingle(dr["Credit"]);
                }
            }
        }
        lblDegreeCredit.Text = "已完成学位课学分：" + degreeSum.ToString();
        lblNonDegreeCredit.Text = "非学位课学分：" + ndegreeSum.ToString();
        lblTotalCredit.Text = "总学分：" + (degreeSum + ndegreeSum + mclassSum).ToString();
    }
}
