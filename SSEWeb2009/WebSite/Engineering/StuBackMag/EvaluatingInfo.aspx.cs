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
using System.IO;
using System.Xml;
using System.Xml.XPath;

public partial class Engineering_StuBackMag_EvaluatingInfo : System.Web.UI.Page
{
    private int _courseId = -1;
    private bool isSugNull = true; // 判断是否有建议，初始化为true 表示默认情况下有建议
    private string stuID;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["IdentifyNumber"] == null)
        {
            SysCom.Login.LoginRedirect(Request.Url.ToString());
        }
        stuID = Session["IdentifyNumber"].ToString();
        if (Request["id"] != null)
        {
            _courseId = Convert.ToInt32(Request["id"]);
        }
        if (!IsPostBack)
        {
            DataSet ds = new DataSet("MyDs");
            ds.ReadXml(Server.MapPath(@"../Resources/Xml/xmlEvaluatingInfo.xml"));
            Session["evaluatingInfo"] = ds;
            gvEvaluatingInfo.DataSource = ds.Tables[0];
            gvEvaluatingInfo.DataBind();

            CourseManage cMag = new CourseManage();
            DataSet dsCourse = new DataSet();
            dsCourse = cMag.GetCourseTeacherInfo(_courseId);
            int count = dsCourse.Tables[0].Rows.Count;
            if (count > 0)
            {
                lblCourseName.Text = "课程名称：" + dsCourse.Tables[0].Rows[0]["CourseName"].ToString();
                if (count == 2)
                {
                    lblTeacher.Text = "任课教师：" + dsCourse.Tables[0].Rows[0]["Name"].ToString() + "," + dsCourse.Tables[0].Rows[1]["Name"].ToString();
                }
                if (count == 1)
                {
                    lblTeacher.Text = "任课教师：" + dsCourse.Tables[0].Rows[0]["Name"].ToString();
                }
            }
        }
    }
    protected void gvEvaluatingInfo_PreRender(object sender, EventArgs e)
    {
        for (int rowIndex = gvEvaluatingInfo.Rows.Count - 2; rowIndex >= 0; rowIndex--)
        {
            GridViewRow row = gvEvaluatingInfo.Rows[rowIndex];
            GridViewRow previousRow = gvEvaluatingInfo.Rows[rowIndex + 1];
            if (row.Cells[0].Text == previousRow.Cells[0].Text)
            {
                row.Cells[0].RowSpan = previousRow.Cells[0].RowSpan < 2 ? 2 : previousRow.Cells[0].RowSpan + 1;
                previousRow.Cells[0].Visible = false;
            }

        }
    }
    protected void btSubmit_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet("res");
        DataSet tmpDs = (DataSet)Session["evaluatingInfo"];
        StudentManage sMag = new StudentManage();
        if (!File.Exists(Server.MapPath(@"../Resources/Xml/xmlEvaluationRes.xml")))
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("CourseID", typeof(int));
            dt.Columns.Add("Result", typeof(string));
            dt.Columns.Add("Suggestion", typeof(string));
            ds.Tables.Add(dt);

            SaveEvaluatingInfo(ds, tmpDs);
            if (true == sMag.UpdateStuEvaluation(_courseId, stuID))
            {
                // Response.Redirect("test.aspx?id=" + _courseId);
                Response.Write("<script language='javascript'>alert('提交成功！')</script>");
                btSubmit.Enabled = false;
            }
            else
            {
                Response.Write("<script language='javascript'>alert('提交失败！')</script>");
            }
        }
        else
        {
            ds.ReadXml(Server.MapPath(@"../Resources/Xml/xmlEvaluationRes.xml"));
            string res = "";
            string sug = "";
            int num = ds.Tables[0].Rows.Count;
            int i;
            for (i = 0; i < num; i++)
            {
                int courId = Convert.ToInt32(ds.Tables[0].Rows[i]["CourseID"]);
                if (courId == _courseId)
                {
                    // Response.Write("该门课程存在");
                    res = ds.Tables[0].Rows[i]["Result"].ToString();
                    sug = ds.Tables[0].Rows[i]["Suggestion"].ToString();
                    break;
                }
            }
            if (i == num)
            {
                //该课程不存在，添加课程
                SaveEvaluatingInfo(ds, tmpDs);
                if (true == sMag.UpdateStuEvaluation(_courseId, stuID))
                {
                    Response.Write("<script language='javascript'>alert('提交成功！')</script>");
                    btSubmit.Enabled = false;
                }
                else
                {
                    Response.Write("<script language='javascript'>alert('提交失败！')</script>");
                }
                return;
            }

            System.IO.StringReader sr = new System.IO.StringReader(res);
            DataSet ds1 = new DataSet();
            ds1.ReadXml(sr);
            for (int k = 0; k < gvEvaluatingInfo.Rows.Count; k++)
            {
                for (int j = 3; j <= 6; j++)
                {
                    RadioButton rd = (RadioButton)gvEvaluatingInfo.Rows[k].FindControl("RadioButton" + (j - 2).ToString());
                    if (rd.Checked == true)
                    {
                        ds1.Tables[0].Rows[k][j] = Convert.ToInt32(ds1.Tables[0].Rows[k][j]) + 1;
                        break;
                    }
                }
            }
            string newSuggestion = "";
            if(tbSuggestion.Text.Trim() != "")
            {
                isSugNull = true;
                if (sug == "")
                {
                    DataSet ds2 = new DataSet();
                    DataTable dt2 = new DataTable();
                    ds2.Tables.Add(dt2);
                    dt2.Columns.Add("ID", typeof(int));
                    dt2.Columns.Add("Item", typeof(string));
                    DataRow dr2 = dt2.NewRow();
                    dr2["ID"] = 1;
                    dr2["Item"] = tbSuggestion.Text.Trim();
                    dt2.Rows.Add(dr2);
                    newSuggestion = ds2.GetXml();
                }
                else
                {

                    System.IO.StringReader srSug = new System.IO.StringReader(sug);
                    DataSet ds2 = new DataSet();
                    ds2.ReadXml(srSug);
                    int id = Convert.ToInt32(ds2.Tables[0].Rows[ds2.Tables[0].Rows.Count - 1]["ID"]);
                    DataRow drNew = ds2.Tables[0].NewRow();
                    drNew["ID"] = id + 1;
                    drNew["Item"] = tbSuggestion.Text.Trim();
                    ds2.Tables[0].Rows.Add(drNew);
                    newSuggestion = ds2.GetXml();

                }
            }
            else
            {
                isSugNull = false;
            }

            //更新评教结果
            string newRes = ds1.GetXml();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(Server.MapPath(@"../Resources/Xml/xmlEvaluationRes.xml"));
            XmlNodeList nodeList = xmlDoc.SelectSingleNode("res").ChildNodes;//获取dbGuest节点的所有子节点
            foreach (XmlNode xn in nodeList)//遍历所有子节点
            {
                XmlElement xe = (XmlElement)xn;//将子节点类型转换为XmlElement类型

                XmlNodeList node = xe.GetElementsByTagName("CourseID");
                if (node.Count > 0)
                {

                    if (node[0].InnerText == Convert.ToString(_courseId))
                    {
                        XmlNodeList nls = xe.ChildNodes;//继续获取xe子节点的所有子节点
                        foreach (XmlNode xn1 in nls)//遍历
                        {
                            XmlElement xe2 = (XmlElement)xn1;//转换类型
                            if (xe2.Name == "Result")//如果找到
                            {
                                xe2.InnerText = newRes;//则修改
                                break;//找到退出来就可以了
                            }
                        }
                        if (isSugNull == true)
                        {
                            foreach (XmlNode xn1 in nls)
                            {
                                XmlElement xe2 = (XmlElement)xn1;//转换类型
                                if (xe2.Name == "Suggestion")//如果找到
                                {
                                    xe2.InnerText = newSuggestion;//则修改
                                    break;//找到退出来就可以了
                                }
                            }
                        }
                        break;
                    }
                }

            }
            xmlDoc.Save(Server.MapPath(@"../Resources/Xml/xmlEvaluationRes.xml"));
            if (true == sMag.UpdateStuEvaluation(_courseId, stuID))
            {
                // Response.Redirect("test.aspx?id=" + _courseId);
                Response.Write("<script language='javascript'>alert('提交成功！')</script>");
                btSubmit.Enabled = false;
            }
            else
            {
                Response.Write("<script language='javascript'>alert('提交失败！')</script>");
            }
        }
    }
    protected void SaveEvaluatingInfo(DataSet ds, DataSet tmpDs)
    {
        //保存评教信息
        DataRow dr = ds.Tables[0].NewRow();
        dr["CourseID"] = _courseId;

        //以下保存用户的评教的结果
        for (int i = 0; i < gvEvaluatingInfo.Rows.Count; i++)
        {
            for (int j = 3; j <= 6; j++)
            {
                RadioButton rd = (RadioButton)gvEvaluatingInfo.Rows[i].FindControl("RadioButton" + (j - 2).ToString());
                if (rd.Checked == true)
                {
                    tmpDs.Tables[0].Rows[i][j] = Convert.ToInt32(tmpDs.Tables[0].Rows[i][j]) + 1;
                    break;
                }
            }
        }

        dr["Result"] = tmpDs.GetXml();
        //  ds.Tables[0].Rows.Add(dr);

        //以下是用户的建议
        if (tbSuggestion.Text.Trim() == "")
        {
            //没有建议
            dr["Suggestion"] = "";
        }
        else
        {
            //有建议的情况
            DataSet dsSug = new DataSet("Sug");
            DataTable dtSug = new DataTable("dtSug");
            dsSug.Tables.Add(dtSug);
            dtSug.Columns.Add("ID", typeof(int));
            dtSug.Columns.Add("Item", typeof(string));
            DataRow drSug = dtSug.NewRow();
            drSug["ID"] = 1;
            drSug["Item"] = tbSuggestion.Text.Trim();
            dtSug.Rows.Add(drSug);
            dr["Suggestion"] = dsSug.GetXml();
        }
        ds.Tables[0].Rows.Add(dr);
        ds.WriteXml(Server.MapPath(@"../Resources/Xml/xmlEvaluationRes.xml"));  
    }
}
