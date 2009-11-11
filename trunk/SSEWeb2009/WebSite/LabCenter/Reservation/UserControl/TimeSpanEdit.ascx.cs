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

public partial class LabCenter_UserControl_TimeSpanEdit : System.Web.UI.UserControl
{
    public LabCenter_UserControl_TimeSpanEdit()
    {

    }
    public LabCenter_UserControl_TimeSpanEdit(bool editoff)
    {
        m_editoff = editoff;
    }
    public LabCenter_UserControl_TimeSpanEdit(string fromtime,string totime,int todayofweek)
    {
        FromTime = fromtime;
        ToTime = totime;
        ToDayofWeek = todayofweek;
    }

    private Boolean m_editoff = false;

    public Boolean EditOff
    {
        get
        {
            return m_editoff;
        }
        set
        {
            m_editoff = value;
        }
    }

    MyTimeSpan mt = new MyTimeSpan();

    public string FromTime
    {
        get
        {
            return mt.begin;
        }
        set
        {
            mt.begin = value ;
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
            return mt.end;
        }
        set
        {
            mt.end = value;
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
            //return mt.enddayofweek;
        }
        set
        {
            mt.enddayofweek = value;
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
        if(EditOff)
        {
            tbFromTime.Enabled = false;
            tbToTime.Enabled = false;
            ddlCurDayofWeek.Enabled = false;
        }
        tbFromTime.Text = mt.begin;
        tbToTime.Text = mt.end;
        if (ddlCurDayofWeek != null)
        {
            ListItem li = ddlCurDayofWeek.Items.FindByValue(mt.enddayofweek.ToString());
            if (li != null)
            {
                ddlCurDayofWeek.SelectedValue = li.Value;
                //li.Selected = true;
            }
        }
    }


    protected void tbFromTime_TextChanged(object sender, EventArgs e)
    {
        mt.begin = tbFromTime.Text;
    }
    protected void ddlCurDayofWeek_SelectedIndexChanged(object sender, EventArgs e)
    {
        mt.enddayofweek = int.Parse(ddlCurDayofWeek.SelectedItem.Value);
    }
    protected void tbToTime_TextChanged(object sender, EventArgs e)
    {
        mt.end = tbToTime.Text;
    }
}
