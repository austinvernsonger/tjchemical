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
using LabCenter.Reservation;
using LabCenter.LabUtility.LoginUtility;

public partial class LabCenter_Reservation_ReservationLogin_pre : System.Web.UI.Page
{
    //static string basicConfigpath = AppDomain.CurrentDomain.BaseDirectory +
    //                       @"LabCenter\XmlConfig\basicConfig.xml";

    string multiStudentLabpath = AppDomain.CurrentDomain.BaseDirectory +
                           @"LabCenter\XmlConfig\MultiStudentLab.xml";

    int term = (int)BasicConfig.CurrentTerm;
    int week = (int)BasicConfig.CurrentWeek;
    string stuid = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!LoginIPCheck.Check(Request.UserHostAddress))
        {
            Response.Redirect("~/LabCenter/Default.aspx");
        }
        if (!Page.IsPostBack)
        {
            stuid = LoginCtrl.CheckLoginRedirect(this);
            FrontManager fm = new FrontManager();
            fm.CheckForPenalty(stuid, term, week, multiStudentLabpath);//检查某学生在当天是否有"未应约"或"未登出"的不良记录
            DataSet ds1 = fm.GetIncompleteRegInfo(stuid, term, week);
            if (ds1 == null || ds1.Tables.Count == 0 || ds1.Tables[0].Rows.Count == 0)
            {
                DataSet ds2 = fm.GetCurrentReservation(stuid, term, week);
                if (ds2 == null || ds2.Tables.Count == 0 || ds2.Tables[0].Rows.Count == 0)
                {
                    lblmessage.Text = "您在当前时刻没有预约!";
                    btntemp.Visible = true;
                }
                else
                {
                    Response.Redirect("ReservationLogin.aspx?logtype=in&dateindex=" 
                        + ds2.Tables[0].Rows[0][0].ToString());
                }
            }
            else
            {
                Response.Redirect("ReservationLogin.aspx?logtype=out"
                        + "&DateIndex=" + ds1.Tables[0].Rows[0]["DateIndex"].ToString()
                        + "&ExperimentName=" + ds1.Tables[0].Rows[0]["ExperimentName"].ToString()
                        + "&BeginTime=" + ds1.Tables[0].Rows[0]["BeginTime"].ToString()
                        + "&EndTime=" + ds1.Tables[0].Rows[0]["EndTime"].ToString()
                        + "&LoginTime=" + ds1.Tables[0].Rows[0]["LoginTime"].ToString()
                        + "&DeviceID=" + ds1.Tables[0].Rows[0]["DeviceID"].ToString());
            }

        }
    }

    protected void btntemp_Click(object sender, EventArgs e)
    {
        ////
        stuid = LoginCtrl.CheckLoginRedirect(this);
        ////
        FrontManager fm = new FrontManager();
        DataSet ds = fm.GetCurrentInfo(term, week);
        if (ds == null || ds.Tables.Count == 0)
        {
            lblmessage.Text = "当前无法临时预约!";
            btntemp.Enabled = false;
            return;
        }
        ////
        if (ds.Tables[0].Rows.Count == 0)
        {
            lblmessage.Text = "当前无时间段可预约!";
            btntemp.Enabled = false;
            btnnext.Visible = true;
            return;
        }
        ////
        if (Convert.ToInt32(ds.Tables[0].Rows[0]["RemainCount"].ToString()) == 0)
        {
            lblmessage.Text = "当前时间段无剩余设备可预约!";
            btntemp.Enabled = false;
            btnnext.Visible = true;
            return;
        }
        
        ////
        DataSet dst = fm.GetReservationByStuid(stuid);
        if (dst != null && dst.Tables.Count != 0 && dst.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < dst.Tables[0].Rows.Count; i++ )
            {
                for (int j = 0; j < ds.Tables[0].Rows.Count; j++ )
                {
                    if ((dst.Tables[0].Rows[i]["DateIndex"].ToString()).Equals(ds.Tables[0].Rows[j]["DateIndex"].ToString()))
                    {
                        lblmessage.Text = "已预约该时间段！";
                        btntemp.Enabled = false;
                        return;
                    }
                }
            }
        }
        ////
        if (!fm.CompareTwoTime(ds.Tables[0].Rows[0]["beginTime"].ToString(),4))
        {
            lblmessage.Text = fm.ErrorMsg;
            btntemp.Enabled = false;
            btnnext.Visible = true;
            return;
        }
        else
        {
            rdbtnexplist.DataValueField = "DateIndex";
            rdbtnexplist.DataTextField = "ExperimentName";
            rdbtnexplist.DataSource = ds.Tables[0];
            rdbtnexplist.DataBind();
            btntemp.Enabled = false;
            divmore.Visible = true;
        }
    }

    protected void btnnext_Click(object sender, EventArgs e)
    {
        stuid = LoginCtrl.CheckLoginRedirect(this);
        FrontManager fm = new FrontManager();
        DataSet ds = fm.GetNextInfo(term, week);
        if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
        {
            lblmessage.Text = "无法预约下个时间段!";
            btnexp.Enabled = false;
            return;
        }
        if (Convert.ToInt32(ds.Tables[0].Rows[0]["RemainCount"].ToString()) == 0)
        {
            lblmessage.Text = "下个时间段无剩余设备可预约!";
            btnnext.Enabled = false;
            return;
        }
        ////
        DataSet dst = fm.GetReservationByStuid(stuid);
        if (dst != null && dst.Tables.Count != 0 && dst.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < dst.Tables[0].Rows.Count; i++)
            {
                for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                {
                    if ((dst.Tables[0].Rows[i]["DateIndex"].ToString()).Equals(ds.Tables[0].Rows[j]["DateIndex"].ToString()))
                    {
                        lblmessage.Text = "已预约该时间段！";
                        btnnext.Enabled = false;
                        return;
                    }
                }
            }
        }
        ////
        rdbtnexplist.DataValueField = "DateIndex";
        rdbtnexplist.DataTextField = "ExperimentName";
        rdbtnexplist.DataSource = ds.Tables[0];
        rdbtnexplist.DataBind();
        btnnext.Enabled = false;
        divmore.Visible = true;
    }

    protected void btnexp_Click(object sender, EventArgs e)
    {
        stuid = LoginCtrl.CheckLoginRedirect(this);
        if (rdbtnexplist.SelectedValue == "")
        {
            lblmessage.Text = "请选择实验!";
            return;
        }
        FrontManager fm = new FrontManager();
        if (fm.NewTempReservation(stuid,Convert.ToInt32(rdbtnexplist.SelectedValue.Trim())))
        {
            btnexp.Enabled = false;
            //lblmessage.Text = "预约成功,将转到登记页面!";
            //System.Threading.Thread.Sleep(5000);
            //Response.Write("<script>alert('预约成功,将转到登记页面!')</script>");
            Response.Redirect("ReservationLogin.aspx?logtype=in&dateindex=" + rdbtnexplist.SelectedValue.Trim());
        }
        else
        {
            lblmessage.Text = fm.ErrorMsg;
        }
    }
}
