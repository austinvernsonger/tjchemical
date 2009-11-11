using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using LabCenter.Reservation;
using LabCenter.LabUtility.LoginUtility;

public partial class 实验预约_LabOrder : System.Web.UI.Page
{
    FrontManager ftm = new FrontManager();
    DataSet ds = new DataSet();
    DataTable dt = new DataTable();
    //string basicConfigpath = AppDomain.CurrentDomain.BaseDirectory +
    //                       @"LabCenter\XmlConfig\basicConfig.xml";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LoginCtrl.CheckLoginRedirect(this);
        }
    }
    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        int selval = Convert.ToInt32(DropDownList1.SelectedValue);
        ds = ftm.GetValidExperiment(selval);
        if (ds == null || ds.Tables.Count == 0 || ds.Tables.Count == 1 && ds.Tables[0].Rows.Count == 0)
        {
            Label3.Text = "该时间段无实验可预约!";
            RadioButtonList1.Visible = false;
            Label6.Text = "";
        }
        else
        {
            RadioButtonList1.DataTextField = "ExperimentName";
            RadioButtonList1.DataValueField = "ExperimentID";
            RadioButtonList1.DataSource = ds.Tables[0];
            RadioButtonList1.DataBind();
            ds.Reset();
            ds = ftm.GetRemainDevice(selval);
            if(ds.Tables.Count != 0)
            {
                Label6.Text = ds.Tables[0].Rows[0]["RemainCount"].ToString();
            }
            Label3.Text = "";
            if(!RadioButtonList1.Visible)
            {
                RadioButtonList1.Visible = true;
            }
            if(!RadioButtonList1.Enabled)
            {
                RadioButtonList1.Enabled = true;
            }
        }
        ds.Reset();
    }

    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        if (!DropDownList1.Enabled)
        {DropDownList1.Enabled = true;}
        if (!LinkButton3.Enabled)
        {LinkButton3.Enabled = true;}
        if (RadioButtonList1.Enabled)
        {RadioButtonList1.Enabled = false;}
        //根据选择的日期返回时间段...
        int idayofweek = Convert.ToInt32(Calendar1.SelectedDate.DayOfWeek);
        string[] thisweekday = new string[] { "本周日", "本周一", "本周二", "本周三", "本周四", "本周五", "本周六" };
        string[] nextweekday = new string[] { "下周日", "下周一", "下周二", "下周三", "下周四", "下周五", "下周六" };
        ds = ftm.GetValidTimeSpan(idayofweek);
        dt.Columns.Add("timespan", typeof(string));
        dt.Columns.Add("spannumber", typeof(int));
        dt.Rows.Add(dt.NewRow());
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            DataRow tempdr = dt.NewRow();
            string str = dr["EndDayOfWeek"].ToString();
            if (str == "")
            {
                DateTime date = Convert.ToDateTime(DateTime.Now.ToLongDateString()+" "+dr["EndTime"].ToString());
                if (Calendar1.SelectedDate.CompareTo(DateTime.Today) == 0 && DateTime.Now.CompareTo(date) >= 0)
                { continue; }
                tempdr["timespan"] = dr["BeginTime"].ToString() + "-" + dr["EndTime"].ToString();                    
            }
            else
            {
                if (Convert.ToInt32(dr["EndDayOfWeek"]) >= idayofweek)
                {
                    tempdr["timespan"] = dr["BeginTime"].ToString() + "-" + thisweekday[Convert.ToInt32(dr["EndDayOfWeek"])] + dr["EndTime"].ToString();
                }
                else
                {
                    tempdr["timespan"] = dr["BeginTime"].ToString() + "-" + nextweekday[Convert.ToInt32(dr["EndDayOfWeek"])] + dr["EndTime"].ToString();
                }
            }
            tempdr["spannumber"] = Convert.ToInt32(dr["spannumber"].ToString());
            dt.Rows.Add(tempdr);
        }
        DropDownList1.DataValueField = "spannumber";
        DropDownList1.DataTextField = "timespan";
        DropDownList1.DataSource = dt;
        DropDownList1.DataBind();
        dt.Reset();
        ds.Reset();
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        if(RadioButtonList1.SelectedValue == "" || !RadioButtonList1.Enabled)
        {
            Label3.Text = "请先选择实验!";
            return;
        }
        if(Convert.ToInt32(Label6.Text.ToString()) <= 0)
        {
            Label3.Text = "当前时间段预约已满,无剩余设备;请考虑其他时间段!";
            return;
        }
        else
        {
            String stuid = LoginCtrl.CheckLoginRedirect(this);
            if (ftm.NewReservation(stuid, Convert.ToInt32(RadioButtonList1.SelectedValue), Convert.ToInt32(DropDownList1.SelectedValue))
            && ftm.UpdateRemainDevice(Convert.ToInt32(DropDownList1.SelectedValue), -1))
            {
                Label3.Text = "预约成功!";
                ds = ftm.GetRemainDevice(Convert.ToInt32(DropDownList1.SelectedValue));
                if (ds.Tables.Count != 0)
                {
                    Label6.Text = ds.Tables[0].Rows[0]["RemainCount"].ToString();
                }
            }
            else
            {
                Label3.Text = ftm.ErrorMsg;
                return;
            }
        }
        
        //Calendar1.Enabled = false;//...
        //DropDownList1.Enabled = false;
        //RadioButtonList1.Enabled = false;
        //LinkButton1.Enabled = false;
        //LinkButton3.Enabled = false;
    }

    
    protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
    {
        List<DateTime> dateList = new List<DateTime>();

        ds = ftm.GetValidDayofWeek(BasicConfig.CurrentTerm,
            BasicConfig.CurrentWeek);
        if (ds == null || ds.Tables.Count == 0 || ds.Tables.Count == 1 && ds.Tables[0].Rows.Count == 0)
        {
            Label3.Text = "当前不可预约!";
            return;
        }
        else
        {
            dt = ds.Tables[0];
        }
        int count=0;
        foreach(DataRow dr in dt.Rows)
        {
            int i = -1;
            switch (dr["BeginDayOfWeek"].ToString())
            {
                case "1":
                    i = DayOfWeek.Monday - DateTime.Today.DayOfWeek;
                    break;
                case "2":
                    i = DayOfWeek.Tuesday - DateTime.Today.DayOfWeek;
                    break;
                case "3":
                    i = DayOfWeek.Wednesday - DateTime.Today.DayOfWeek;
                    break;
                case "4":
                    i = DayOfWeek.Thursday - DateTime.Today.DayOfWeek;
                    break;
                case "5":
                    i = DayOfWeek.Friday - DateTime.Today.DayOfWeek;
                    break;
                case "6":
                    i = DayOfWeek.Saturday - DateTime.Today.DayOfWeek;
                    break;
                default:
                    break;
            }
            if (i >= 0)
            {
                if(i == 0)
                {
                    DateTime dt1 = Convert.ToDateTime(DateTime.Now.ToLongDateString()+" "+dr["EndTime"].ToString());
                    if(DateTime.Now.CompareTo(dt1) >= 0)
                    {continue;}
                }
                if (!dateList.Contains(DateTime.Today.AddDays(i)))
                {dateList.Add(DateTime.Today.AddDays(i)); count++;}
            }
        }
        for (int j = 0; j < count; j++)
        {
            if (e.Day.Date == dateList[j])
            {
                e.Cell.BackColor = System.Drawing.Color.LightGreen;
                e.Day.IsSelectable = true;
            }
        }
        dateList.Clear();
        dt.Reset();
        ds.Reset();
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Label3.Text = "";
        RadioButtonList1.Enabled = false;
    }
}
