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
using System.Text.RegularExpressions;
using LabCenter.LabUtility.LoginUtility;

public partial class 实验预约_Initialize : System.Web.UI.Page
{
    string basicconfpath = AppDomain.CurrentDomain.BaseDirectory +
                           @"LabCenter\XmlConfig\basicConfig.xml";

    string multiStudentLabpath = AppDomain.CurrentDomain.BaseDirectory +
                           @"LabCenter\XmlConfig\MultiStudentLab.xml";

    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!Page.IsPostBack)
        {
           
            LoginCtrl.CheckAuthorityRedirect(this, 8, 1);

             
            //BasicConfig bc = (BasicConfig)BackManager.GetBasicConfig(basicconfpath);
            tbcurterm.Text = BasicConfig.CurrentTerm.ToString();
            tbBeginDay.Text = BasicConfig.BeginDay;
            tbdevicecount.Text = BasicConfig.RemainCount.ToString();
            tbtime1.Text = BasicConfig.TimeConstraint1.ToString();
            tbtime2.Text = BasicConfig.TimeConstraint2.ToString();
            tbtime3.Text = BasicConfig.TimeConstraint3.ToString();
            tbtime4.Text = BasicConfig.TimeConstraint4.ToString();
            lblCurWeek.Text = BasicConfig.CurrentWeek.ToString();
            if (BasicConfig.ReservationState)
            {
                chkstate.Checked = true;
            }
            else
            {
                chkstate.Checked = false;
            }
            tbIPCheckRegex.Text = BasicConfig.IPCheckRegex;
            lblsave.Text = "";
        }
        
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            //BasicConfig newbc = new BasicConfig();
            BasicConfig.CurrentTerm = Convert.ToInt32(tbcurterm.Text.Trim());
            BasicConfig.BeginDay = tbBeginDay.Text;
            BasicConfig.RemainCount = Convert.ToInt32(tbdevicecount.Text.Trim());
            BasicConfig.TimeConstraint1 = Convert.ToInt32(tbtime1.Text.Trim());
            BasicConfig.TimeConstraint2 = Convert.ToInt32(tbtime2.Text.Trim());
            BasicConfig.TimeConstraint3 = Convert.ToInt32(tbtime3.Text.Trim());
            BasicConfig.TimeConstraint4 = Convert.ToInt32(tbtime4.Text.Trim());
            BasicConfig.ReservationState = chkstate.Checked;
            BasicConfig.IPCheckRegex = tbIPCheckRegex.Text.Trim();

            if (!BackManager.SetBasicConfig(BasicConfig.uniquebc, basicconfpath))
            {
                lblsave.Text = "保存修改失败!";
                return;
            }
            lblsave.Text = "保存修改成功!";
            lblCurWeek.Text = BasicConfig.CurrentWeek.ToString();

            //int term;
            //int week;
            //FrontManager fm = new FrontManager();
            //if (!BasicConfig.ReservationState)
            //{
            //    term = (int)BasicConfig.CurrentTerm;
            //    week = (int)BasicConfig.CurrentWeek;
            //    fm.CheckAllForPenalty(term, week);//整体刷不良记录
            //}
        }
    }

    protected void val_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (args.Value.Trim() == "")
        {
            args.IsValid = false;
            return;
        }
        Regex intvalueregex = new Regex("^\\d+$");

        Match m = intvalueregex.Match(args.Value.Trim());
        if (m.Success)
        {
            args.IsValid = true;
        }
        else
            args.IsValid = false;
    }
    protected void val_ServerValidate2(object source, ServerValidateEventArgs args)
    {
        if (args.Value.Trim() == "")
        {
            args.IsValid = false;
            return;
        }
        args.IsValid = true;
    }
    protected void btnrefreshBadRecord_Click(object sender, EventArgs e)
    {
        int term = (int)BasicConfig.CurrentTerm;
        int week = (int)BasicConfig.CurrentWeek;
        FrontManager fm = new FrontManager();
        fm.CheckAllForPenalty(term, week, multiStudentLabpath);//整体刷不良记录
        lblsave.Text = "刷新完成!";
    }
}
