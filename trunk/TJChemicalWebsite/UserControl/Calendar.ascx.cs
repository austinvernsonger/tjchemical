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

public partial class UserControl_Calendar : System.Web.UI.UserControl
{
    Boolean myNeedHour = true;
    /// <summary>
    /// If need to show the time list.
    /// </summary>
    public Boolean NeedHour { set { myNeedHour = value; } }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DateTime date = DateTime.Now;
            // Add Year
            ddl_year.Items.Clear();
            for (int i = 0; i < 50; ++i)
                ddl_year.Items.Add((date.Year + i).ToString());
            ddl_year.SelectedIndex = 0;
            // Add Monty
            ddl_month.Items.Clear();
            for (int i = 1; i < 13; ++i)
                ddl_month.Items.Add(i.ToString());
            ddl_month.SelectedIndex = date.Month - 1;
            // Add Time
            ddl_hour.Items.Clear();
            for (int i = 0; i < 24; ++i)
            {
                ddl_hour.Items.Add(i.ToString() + ":00");
                ddl_hour.Items.Add(i.ToString() + ":30");
            }
            // Whether need to show the time.
            hour_div.Visible = myNeedHour;
            ddl_hour.SelectedIndex = 0;

            AddDay();
        }
    }

    protected void AddDay()
    {
        // Add Day
        int tmpMaxDays = 30;
        if (ddl_month.SelectedIndex == 1)    // Feb.
        {
            int tmpYear = Convert.ToInt32(ddl_year.SelectedValue);
            if (((tmpYear % 4) == 0 && (tmpYear % 100) != 0) || (tmpYear % 400) == 0)
                tmpMaxDays = 29;
            else tmpMaxDays = 28;
        }
        else if (ddl_month.SelectedIndex == 0 ||    // Jan.
            ddl_month.SelectedIndex == 2 ||         // Mar.
            ddl_month.SelectedIndex == 4 ||         // May
            ddl_month.SelectedIndex == 6 ||         // Jul.
            ddl_month.SelectedIndex == 7 ||         // Aug.
            ddl_month.SelectedIndex == 9 ||         // Ost.
            ddl_month.SelectedIndex == 11)          // Dec.
            tmpMaxDays = 31;
        else tmpMaxDays = 30;

        ddl_day.Items.Clear();
        for (int i = 1; i < tmpMaxDays + 1; ++i)
            ddl_day.Items.Add(i.ToString());
    }

    protected void ddl_month_SelectedIndexChanged(object sender, EventArgs e)
    {
        AddDay();
    }
    protected void ddl_year_SelectedIndexChanged(object sender, EventArgs e)
    {
        AddDay();
    }

    /// <summary>
    /// Format the date time
    /// </summary>
    /// <returns></returns>
    public DateTime GetDateTime()
    {
        return Convert.ToDateTime(ddl_year.SelectedValue + "-" + ddl_month.SelectedValue + 
            "-" + ddl_day.SelectedValue + " " + ddl_hour.SelectedValue);
    }

    public void SetDateTime(DateTime theDate)
    {
        DateTime _now = DateTime.Now;
        ddl_year.SelectedIndex = (theDate.Year - _now.Year);
        ddl_month.SelectedIndex = (theDate.Month - _now.Month);
        ddl_day.SelectedIndex = (theDate.Day - _now.Day);
        ddl_hour.Text = theDate.Hour + ":" + theDate.Minute;
    }
}
