using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class MasterPages_default : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
            ifrm_btmbar.Attributes["src"] = ConstValue.PureURL + "MasterPages/frame_btmbar.aspx";
    }

    private void SwitchRoundCorner_Day(Boolean Statue)
    {
/*
        rndcnrex_first_day.Enabled = Statue;
        rndcnrex_second_day.Enabled = Statue;
        rndcnrex_third_day.Enabled = Statue;*/

    }

    private void SwitchRoundCorner_Night(Boolean Statue)
    {
/*
        rndcnrex_first_night.Enabled = Statue;
        rndcnrex_second_night.Enabled = Statue;
        rndcnrex_third_night.Enabled = Statue;*/

    }
}
