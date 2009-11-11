using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using LabCenter.Reservation;
using LabCenter.LabUtility.LoginUtility;

public partial class 实验预约_CheckReport : System.Web.UI.Page
{
    FrontManager ftm = new FrontManager();
    DataSet ds = new DataSet();
    DataTable dt = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LoginCtrl.CheckLoginRedirect(this);
            BindGrid();
        }
    }

    protected void BindGrid()
    {
        string stuid = LoginCtrl.CheckLoginRedirect(this);
        ds = ftm.GetReportByStuid(stuid);
        dt.Columns.Add("Expname",typeof(string));
        dt.Columns.Add("ReportState",typeof(string));
        foreach(DataRow dr in ds.Tables[0].Rows)
        {
            DataRow tempdr = dt.NewRow();
            if(Convert.ToBoolean(dr["ReportState"].ToString()) == false)
            {
                tempdr["ReportState"] = "未交";
            }
            else
            {
                tempdr["ReportState"] = "已交";
            }
            tempdr["Expname"] = dr["ExperimentName"].ToString();
            dt.Rows.Add(tempdr);
        }
        ReportList.DataSource = dt;
        ReportList.DataBind();
        dt.Reset();
        ds.Reset();
    }
    //protected void ReportList_SelectedIndexChanged(object sender, EventArgs e)
    //{

    //}
}
