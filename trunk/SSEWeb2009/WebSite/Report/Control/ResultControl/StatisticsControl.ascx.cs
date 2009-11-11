using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Report.Descriptor;
using Report.Serializer;
using System.Web.Hosting;
using System.Data;
using Report.Helper;

public partial class Report_Control_ResultControl_StatisticsControl : System.Web.UI.UserControl
{
    DataSet m_dataSet = null;
    const string ReportDescriptorSessionName = "Result_ReportDescriptorSessionName_Result";
    const string ReportResultSessionName = "Result_ReportResultSessionName_Result";
    ReportDescriptor report;
    public string tempFilePath = "";


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SaveSession();
        }

        LoadSession();

        ReportSerializer x = new ReportSerializer(Hidden_DescriptorFilePAth.Text);
        report = x.Deserialize();
        //Displayer1.SetReportDescriptorFilePath(Hidden_DescriptorFilePAth.Text);
        Displayer1.SetDisplayMode(DisplayMode.DisplayBack);
        Displayer1.SetReportResultFilePath(Hidden_ResultFilePAth.Text);

        ShowResult();
        SaveSession();
    }

    private void LoadSession()
    {
        report = Session[ReportDescriptorSessionName] as ReportDescriptor;
        m_dataSet = Session[ReportResultSessionName] as DataSet;
    }

    private void SaveSession()
    {
        Session[ReportDescriptorSessionName] = report;
        Session[ReportResultSessionName] = m_dataSet;
   }

    public ReportDescriptor Report
    {
        get { return report; }
        set { report = value; }
    }

    public void SetReportDescriptorFilePath(string path)
    {
        Hidden_DescriptorFilePAth.Text = path;
    }

    public void SetReportResultFilePath(string path)
    {
        Hidden_ResultFilePAth.Text = path;
    }

    public void SetReportKey(string key)
    {
        Hidden_Key.Text = key;
    }

    public void SetReportValueToKey(string value)
    {
        Hidden_Value.Text = value;
    }

    
    public bool ShowResult()
    {
        if (report == null || Hidden_DescriptorFilePAth.Text == "")
        {
            Label1.Text = "无法得到结果";
            return false;
        }

        ResultSerializer rs = new ResultSerializer(Hidden_ResultFilePAth.Text, Hidden_Value.Text);
        if (!rs.Deserialize())
        {
            Label1.Text = "无法得到结果";
            return false;
        }
        //if there are no keyvalue,then return all the records
        //else if there are primarykey and key value or there are only key,return the correspond records
        if (Hidden_Key.Text != "")
        {
            m_dataSet.Clear();
            if (!m_dataSet.Tables[0].Columns.Contains(Hidden_Key.Text))
            {
                Label1.Text = "无此记录";
                return false;
            }
            foreach (DataRow dr in rs.DataSet.Tables[0].Rows)
            {
                if (dr[Hidden_Key.Text].ToString().Equals(Hidden_Value.Text))
                {
                    m_dataSet.Tables[0].Rows.Add(dr);
                }
            }
        }
        else
        {
            m_dataSet = rs.DataSet;
        }

        GridView1.DataSource = m_dataSet;
        GridView1.DataBind();
        ChangeColumn();

        return true;
    }

    private void ChangeColumn()
    {
        DataColumnCollection dcc = m_dataSet.Tables[0].Columns;
        for(int i=0;i<dcc.Count;++i)
        {
            DataColumn dc=dcc[i];
            AbstractDescriptor rd=report.FindDescriptorByFullName(dc.ColumnName);
            if (rd.ResultDescriptor.ResultViewMode== ResultViewMode.Hide)
            {
                foreach (GridViewRow gridrow in GridView1.Rows)
                {
                    gridrow.Cells[i+2].Visible = false;

                }
                GridView1.HeaderRow.Cells[i+2 ].Visible = false;
              //GridView1.Columns[i].Visible = false;
                //dcc.RemoveAt(i);
               // --i;
            }
            else
            {
                GridView1.HeaderRow.Cells[i+2].Text = rd.Name;
                //dc.ColumnName = rd.Name;
            }
        }
    }


    public void CreateExcel(DataSet ds, string FileName)
    {
        string tempname = report.Name + ".csv";
        string tempFilePathPhy = HostingEnvironment.ApplicationPhysicalPath + "\\Report\\" + tempname;
        //tempFilePath = HostingEnvironment.ApplicationVirtualPath + tempname;
        Common.Export(ds.Tables[0], ExportFormat.CSV, tempFilePathPhy, System.Text.Encoding.GetEncoding("GB2312"));
        //Server.Transfer(HostingEnvironment.ApplicationVirtualPath + tempname);
        string downScript = "window.open('\\"+tempname+"')";
        System.Web.UI.ScriptManager.RegisterStartupScript(Button_Output, Button_Output.GetType(), "test", downScript, true);
//         HttpResponse resp;
//         resp = Page.Response;
//         resp.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
//         resp.AppendHeader("Content-Disposition", "attachment;filename=" + FileName);
//         string colHeaders = "", ls_item = "";
// 
//         //定义表对象与行对象，同时用DataSet对其值进行初始化
//         DataTable dt = ds.Tables[0];
//         DataRow[] myRow = dt.Select();//可以类似dt.Select("id>10")之形式达到数据筛选目的
//         int i = 0;
//         int cl = dt.Columns.Count;
// 
//         //取得数据表各列标题，各标题之间以t分割，最后一个列标题后加回车符
//         for (i = 0; i < cl; i++)
//         {
//             if (i == (cl - 1))//最后一列，加n
//             {
//                 colHeaders += dt.Columns[i].ColumnName.ToString() + "\n";
//             }
//             else
//             {
//                 colHeaders += dt.Columns[i].ColumnName.ToString() + "\t";
//             }
// 
//         }
//         resp.Write(colHeaders);
//         //向HTTP输出流中写入取得的数据信息
// 
//         //逐行处理数据  
//         foreach (DataRow row in myRow)
//         {
//             //当前行数据写入HTTP输出流，并且置空ls_item以便下行数据    
//             for (i = 0; i < cl; i++)
//             {
//                 if (i == (cl - 1))//最后一列，加n
//                 {
//                     ls_item += row[i].ToString() + "\n";
//                 }
//                 else
//                 {
//                     ls_item += row[i].ToString() + "\t";
//                 }
// 
//             }
//             resp.Write(ls_item);
//             ls_item = "";
// 
//         }
//         resp.End();
    }
    protected void Button_Output_Click(object sender, EventArgs e)
    {
        ResultSerializer rs = new ResultSerializer(Hidden_ResultFilePAth.Text, Hidden_Value.Text);
        if (!rs.Deserialize())
        {
            Label1.Text = "无法得到结果";
            return;
        }
        CreateExcel(rs.DataSet, report.Name + ".xls");
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        int index = GridView1.SelectedIndex;
        List<KeyValuePair<string, string>> arraylist = new List<KeyValuePair<string, string>>();
        for (int i = 0; i < m_dataSet.Tables[0].Columns.Count; i++)
        {
            arraylist.Add(new KeyValuePair<string, string>(m_dataSet.Tables[0].Columns[i].ColumnName, m_dataSet.Tables[0].Rows[index][i].ToString()));
        }

        report.SetLastResult(arraylist);
        report.SetDisplayMode(DisplayMode.DisplayBack);
        Displayer1.SetDescriptor(report);
        Timer_Refresh.Enabled = true;
        
    }
    protected void Button_Refresh_Click(object sender, EventArgs e)
    {
        Timer_Refresh.Enabled = true;
    }
}
