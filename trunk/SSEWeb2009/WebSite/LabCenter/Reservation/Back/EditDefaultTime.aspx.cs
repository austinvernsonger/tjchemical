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

public partial class LabCenter_Reservation_Back_EditDefaulTime : System.Web.UI.Page
{
    string timetablepath = AppDomain.CurrentDomain.BaseDirectory +
                           @"LabCenter\XmlConfig\TimeTable.xml";

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
         
                LoginCtrl.CheckAuthorityRedirect(this, 8, 1);

            
            //if (Request.QueryString["url"]!=null)
            //{
            //    btnreturn.PostBackUrl = Request.QueryString["url"];
            //}
            
        }
    }
    protected override void OnLoadComplete(EventArgs e)
    {
        base.OnLoadComplete(e);
        if (!IsPostBack)
        {
            TimeTable tt = (TimeTable)BackManager.GetDefaultTimeTable(timetablepath);
            TimeTableEdit1.TTable = tt;
        }
    }

    protected void btnsave_Click(object sender, EventArgs e)
    {
        TimeTable tt = TimeTableEdit1.GetCleanTimeTable();        
        if (!BackManager.SetDefaultTimeTable(tt,timetablepath))
        {
            lblsave.Text = "保存失败!";
            return;
        }
        lblsave.Text = "保存成功!";
    }

}
