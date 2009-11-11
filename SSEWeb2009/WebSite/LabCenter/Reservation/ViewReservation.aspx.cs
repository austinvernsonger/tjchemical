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

public partial class 实验预约_ViewOrder : System.Web.UI.Page
{
    FrontManager ftm = new FrontManager();
    DataSet ds = new DataSet();
    DataTable dt = new DataTable();

    protected void Page_Load()
    {
        Label3.Text = "";
        if(!Page.IsPostBack)
        {
            LoginCtrl.CheckLoginRedirect(this);
            if (BindGrid())
            {
                LinkButton2.Enabled = true;
            }
        }
    }

    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        String stuid = LoginCtrl.CheckLoginRedirect(this);
        if(ReservationList.SelectedValue == null)
        {
            Label3.Text = "请先选择要解除的预约!";
            return;
        }
        if (ftm.CancelReservation(stuid,Convert.ToInt32(ReservationList.SelectedValue)))
        {
            Label3.Text = "解除预约成功!";
            ReservationList.SelectedIndex = -1;
            if (!BindGrid())
            {
                LinkButton2.Enabled = false;
            }
        }
        else
        {
            Label3.Text = ftm.ErrorMsg;
        }
    }

    protected bool BindGrid()
    {
        string stuid = LoginCtrl.CheckLoginRedirect(this);
        ds = ftm.GetReservationByStuid(stuid);
        string[] thisweekday = new string[] { "本周日", "本周一", "本周二", "本周三", "本周四", "本周五", "本周六" };
        string[] nextweekday = new string[] { "下周日", "下周一", "下周二", "下周三", "下周四", "下周五", "下周六" };
        dt.Columns.Add("DateIndex", typeof(int));
        dt.Columns.Add("Labname", typeof(string));
        dt.Columns.Add("Timespan", typeof(string));
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            DataRow tempdr = dt.NewRow();
            string str = dr["EndDayOfWeek"].ToString();
            if (str == "")
            {
                tempdr["Timespan"] = thisweekday[Convert.ToInt32(dr["BeginDayOfWeek"])] + dr["BeginTime"].ToString() + "-" + dr["EndTime"].ToString();
            }
            else
            {
                if (Convert.ToInt32(dr["EndDayOfWeek"]) >= Convert.ToInt32(dr["BeginDayOfWeek"]))//没跨周
                {
                    tempdr["Timespan"] = thisweekday[Convert.ToInt32(dr["BeginDayOfWeek"])] +
                        dr["BeginTime"].ToString() + "-" + thisweekday[Convert.ToInt32(dr["EndDayOfWeek"])] + dr["EndTime"].ToString();
                }
                else//跨周
                {
                    tempdr["Timespan"] = thisweekday[Convert.ToInt32(dr["BeginDayOfWeek"])] +
                        dr["BeginTime"].ToString() + "-" + nextweekday[Convert.ToInt32(dr["EndDayOfWeek"])] + dr["EndTime"].ToString();
                }
            }
            tempdr["DateIndex"] = Convert.ToInt32(dr["DateIndex"]);
            tempdr["Labname"] = dr["ExperimentName"].ToString();
            dt.Rows.Add(tempdr);
        }
        ReservationList.DataSource = dt;
        ReservationList.DataBind();
        if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
        {
            return false;
        }
        dt.Reset();
        ds.Reset();
        return true;
    }
}
