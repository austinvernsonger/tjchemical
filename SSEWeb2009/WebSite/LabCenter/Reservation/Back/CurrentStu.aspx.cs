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


public partial class 实验预约_CurrentStu : System.Web.UI.Page
{
    //string basicConfigpath = AppDomain.CurrentDomain.BaseDirectory +
    //                       @"LabCenter\XmlConfig\basicConfig.xml";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
          
                LoginCtrl.CheckAuthorityRedirect(this, 8, 1);

            
            if (HttpContext.Current.Cache["currentterm"] == null)
            {
                HttpContext.Current.Cache["currentterm"] = BasicConfig.CurrentTerm;
                HttpContext.Current.Cache["currentweek"] = BasicConfig.CurrentWeek;
            }
            //DataSet ds = BackManager.GetCurrentTimeSpan(BasicConfig.CurrentWeek);
            DataSet ds = BackManager.GetCurrentTimeSpan(BasicConfig.CurrentTerm,BasicConfig.CurrentWeek);
            if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
            {
                lblresult.Text = "当前时刻没有正在进行的实验!";
                return;
            }
        }
    }
}
