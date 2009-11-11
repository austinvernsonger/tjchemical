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

public partial class LabCenter_UserControl_TimeSpanDisplay : System.Web.UI.UserControl
{
    public LabCenter_UserControl_TimeSpanDisplay()
    {

    }

    public Boolean EditOff
    {
        get
        {
            return !tbFromTime.Enabled;
        }
        set
        {
            tbFromTime.Enabled = !value;
            tbToTime.Enabled = !value;
            ddlCurDayofWeek.Enabled = !value;
        }
    }

    public string FromTime
    {
        get
        {
            return tbFromTime.Text;
        }
        set
        {
            if (tbFromTime != null)
            {
                tbFromTime.Text = value;
            }
        }
    }

    public string ToTime
    {
        get
        {
            return tbToTime.Text;
        }
        set
        {
            if (tbToTime != null)
            {
                tbToTime.Text = value;
            }
        }
    }

    public int ToDayofWeek
    {
        get
        {
            return int.Parse(ddlCurDayofWeek.SelectedItem.Value);
        }
        set
        {
            if (ddlCurDayofWeek != null)
            {
                ListItem li = ddlCurDayofWeek.Items.FindByValue(value.ToString());
                if (li != null)
                {
                    ddlCurDayofWeek.SelectedValue = li.Value;
                }
            }
        }
    }

    
    protected void Page_Load(object sender, EventArgs e)
    {
    }

}
