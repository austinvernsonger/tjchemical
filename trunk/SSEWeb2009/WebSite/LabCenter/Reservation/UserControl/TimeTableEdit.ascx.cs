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

using LabCenter.Reservation;

public partial class LabCenter_Reservation_UserControl_TimeTableEdit : System.Web.UI.UserControl,INamingContainer
{
    private Boolean m_editoff=false;
    /// <summary>
    /// 记得要先设置EditOff再设置TimeTable
    /// </summary>
    public Boolean EditOff
    {
        set
        {
            LoadSession();
            m_editoff = value;
            SaveSession();
        }
    }

    int[] countarray;

    void LoadSession()
    {
        countarray = (int[])Session["TTCount_" + this.ID];
        object o = Session["TTEditOff_" + this.ID];
        if (o!=null)
        {
            m_editoff = (Boolean)o;
        }
    }

    void SaveSession()
    {
        Session["TTCount_" + this.ID] = countarray;
        Session["TTEditOff_" + this.ID] = m_editoff;
    }

    public TimeTable TTable
    {
        set { SetNewTimeTable(value); }
    }

    int GetLoadedTimes(int dayofweek)
    {
        return countarray[dayofweek];
    }

    void SetLoadedTimes(int value, int dayofweek)
    {
        countarray[dayofweek] = value;
    }

    /// <summary>
    /// 更新时间表
    /// </summary>
    /// <param name="tt">时间表</param>
    public void SetNewTimeTable(TimeTable tt)
    {
        TimeTable m_tt = tt;
        LoadSession();
        AddDelButtonVisibleChange(!m_editoff);

        //礼拜一
        SetLoadedTimes(m_tt.Monday.Count, 1);
        MonPlace.Controls.Clear();
        int icount = 0;
        foreach (MyTimeSpan mts in m_tt.Monday)
        {
            LabCenter_UserControl_TimeSpanEdit tse =
                (LabCenter_UserControl_TimeSpanEdit)CreateTimeSpanEdit("1_" + (icount++).ToString());
            tse.FromTime = mts.begin;
            tse.ToTime = mts.end;
            tse.ToDayofWeek = -1 == mts.enddayofweek ? 1 : mts.enddayofweek;
            MonPlace.Controls.Add(tse);
        }

#region 体力活————————————礼拜二到礼拜六
        //礼拜二
        SetLoadedTimes(m_tt.Tuesday.Count, 2);
        TuePlace.Controls.Clear();
        icount = 0;
        foreach (MyTimeSpan mts in m_tt.Tuesday)
        {
            LabCenter_UserControl_TimeSpanEdit tse =
                (LabCenter_UserControl_TimeSpanEdit)CreateTimeSpanEdit("2_" + (icount++).ToString());
            tse.FromTime = mts.begin;
            tse.ToTime = mts.end;
            tse.ToDayofWeek = -1 == mts.enddayofweek ? 2 : mts.enddayofweek;
            TuePlace.Controls.Add(tse);
        }

        //礼拜三
        SetLoadedTimes(m_tt.Wednesday.Count, 3);
        WedPlace.Controls.Clear();
        icount = 0;
        foreach (MyTimeSpan mts in m_tt.Wednesday)
        {
            LabCenter_UserControl_TimeSpanEdit tse =
                (LabCenter_UserControl_TimeSpanEdit)CreateTimeSpanEdit("3_" + (icount++).ToString());
            tse.FromTime = mts.begin;
            tse.ToTime = mts.end;
            tse.ToDayofWeek = -1 == mts.enddayofweek ? 3 : mts.enddayofweek;
            WedPlace.Controls.Add(tse);
        }

        //礼拜四
        SetLoadedTimes(m_tt.Thursday.Count, 4);
        ThuPlace.Controls.Clear();
        icount = 0;
        foreach (MyTimeSpan mts in m_tt.Thursday)
        {
            LabCenter_UserControl_TimeSpanEdit tse =
                (LabCenter_UserControl_TimeSpanEdit)CreateTimeSpanEdit("4_" + (icount++).ToString());
            tse.FromTime = mts.begin;
            tse.ToTime = mts.end;
            tse.ToDayofWeek = -1 == mts.enddayofweek ? 4 : mts.enddayofweek;
            ThuPlace.Controls.Add(tse);
        }

        //礼拜五
        SetLoadedTimes(m_tt.Friday.Count, 5);
        FriPlace.Controls.Clear();
        icount = 0;
        foreach (MyTimeSpan mts in m_tt.Friday)
        {
            LabCenter_UserControl_TimeSpanEdit tse =
                (LabCenter_UserControl_TimeSpanEdit)CreateTimeSpanEdit("5_" + (icount++).ToString());
            tse.FromTime = mts.begin;
            tse.ToTime = mts.end;
            tse.ToDayofWeek = -1 == mts.enddayofweek ? 5 : mts.enddayofweek;
            FriPlace.Controls.Add(tse);
        }

        //礼拜六
        SetLoadedTimes(m_tt.Saturday.Count, 6);
        SatPlace.Controls.Clear();
        icount = 0;
        foreach (MyTimeSpan mts in m_tt.Saturday)
        {
            LabCenter_UserControl_TimeSpanEdit tse =
                (LabCenter_UserControl_TimeSpanEdit)CreateTimeSpanEdit("6_" + (icount++).ToString());
            tse.FromTime = mts.begin;
            tse.ToTime = mts.end;
            tse.ToDayofWeek = -1 == mts.enddayofweek ? 6 : mts.enddayofweek;
            SatPlace.Controls.Add(tse);
        }
#endregion
    }

    

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            countarray = new int[7];
            m_editoff = false;
            SaveSession();
        }
        LoadControls();
    }

    protected void AddDelButtonVisibleChange(Boolean isvisible)
    {
        MonAdd.Visible = isvisible;
        MonDel.Visible = isvisible;
        TueAdd.Visible = isvisible;
        TueDel.Visible = isvisible;
        WedAdd.Visible = isvisible;
        WedDel.Visible = isvisible;
        ThuAdd.Visible = isvisible;
        ThuDel.Visible = isvisible;
        FriAdd.Visible = isvisible;
        FriDel.Visible = isvisible;
        SatAdd.Visible = isvisible;
        SatDel.Visible = isvisible;
    }

    /// <summary>
    /// 加载控件
    /// </summary>
    public void LoadControls()
    {
        LoadSession();
        
        int iCount = GetLoadedTimes(1);
        for (int i = 0; i != iCount; ++i)
        {
            Control c = CreateTimeSpanEdit("1_"+i.ToString());
            MonPlace.Controls.Add(c);
        }

#region 体力活——————————————————>

        iCount = GetLoadedTimes(2);
        for (int i = 0; i != iCount; ++i)
        {
            Control c = CreateTimeSpanEdit("2_" + i.ToString());
            TuePlace.Controls.Add(c);
        }

        iCount = GetLoadedTimes(3);
        for (int i = 0; i != iCount; ++i)
        {
            Control c = CreateTimeSpanEdit("3_" + i.ToString());
            WedPlace.Controls.Add(c);
        }

        iCount = GetLoadedTimes(4);
        for (int i = 0; i != iCount; ++i)
        {
            Control c = CreateTimeSpanEdit("4_" + i.ToString());
            ThuPlace.Controls.Add(c);
        }

        iCount = GetLoadedTimes(5);
        for (int i = 0; i != iCount; ++i)
        {
            Control c = CreateTimeSpanEdit("5_" + i.ToString());
            FriPlace.Controls.Add(c);
        }

        iCount = GetLoadedTimes(6);
        for (int i = 0; i != iCount; ++i)
        {
            Control c = CreateTimeSpanEdit("6_" + i.ToString());
            SatPlace.Controls.Add(c);
        }

#endregion

        
    }

    /// <summary>
    /// 创建自定义控件
    /// </summary>
    /// <returns></returns>
    public LabCenter_UserControl_TimeSpanEdit CreateTimeSpanEdit(string id)
    {
        LabCenter_UserControl_TimeSpanEdit c = (LabCenter_UserControl_TimeSpanEdit)LoadControl("TimeSpanEdit.ascx");
        c.ID = "TimeSpan_"+this.ID+"_"+id;
        c.EditOff = m_editoff;
        return c;
    }

    /// <summary>
    /// 给星期X添加一个时间段
    /// </summary>
    /// <param name="fromdayofweek">星期X</param>
    /// <param name="todayofweek">至星期</param>
    void AddTimeSpanControl(int fromdayofweek, int todayofweek)
    {
        LoadSession();
        int icount = GetLoadedTimes(fromdayofweek);
        Control c = CreateTimeSpanEdit(fromdayofweek.ToString() + "_" + (icount++).ToString());
        switch (fromdayofweek)
        {
            case 1:
                MonPlace.Controls.Add(c);
                break;
            case 2:
                TuePlace.Controls.Add(c);
                break;
            case 3:
                WedPlace.Controls.Add(c);
                break;
            case 4:
                ThuPlace.Controls.Add(c);
                break;
            case 5:
                FriPlace.Controls.Add(c);
                break;
            case 6:
                SatPlace.Controls.Add(c);
                break;
        }
        SetLoadedTimes(icount, fromdayofweek);
        SaveSession();
    }

    

    /// <summary>
    /// 删去星期X的最后一个时间段
    /// </summary>
    /// <param name="fromdayofweek">星期X</param>
    private void DeleteLastTimeSpanControl(int fromdayofweek)
    {
        if(GetLoadedTimes(fromdayofweek)>0)
        {
            switch (fromdayofweek)
            {
                case 1:
                    MonPlace.Controls.RemoveAt(MonPlace.Controls.Count - 1);
                    break;
                case 2:
                    TuePlace.Controls.RemoveAt(TuePlace.Controls.Count - 1);
                    break;
                case 3:
                    WedPlace.Controls.RemoveAt(WedPlace.Controls.Count - 1);
                    break;
                case 4:
                    ThuPlace.Controls.RemoveAt(ThuPlace.Controls.Count - 1);
                    break;
                case 5:
                    FriPlace.Controls.RemoveAt(FriPlace.Controls.Count - 1);
                    break;
                case 6:
                    SatPlace.Controls.RemoveAt(SatPlace.Controls.Count - 1);
                    break;
            }
            
            SetLoadedTimes(GetLoadedTimes(fromdayofweek) - 1, fromdayofweek);
        }
    }

    /// <summary>
    /// 从控件获得TimeTable
    /// </summary>
    /// <returns></returns>
    private TimeTable GetTimeTableFromControl()
    {
        TimeTable tt = new TimeTable();
        tt.Monday = _Help_GetTimeTableFromControl(MonPlace);
        tt.Tuesday = _Help_GetTimeTableFromControl(TuePlace);
        tt.Wednesday = _Help_GetTimeTableFromControl(WedPlace);
        tt.Thursday = _Help_GetTimeTableFromControl(ThuPlace);
        tt.Friday = _Help_GetTimeTableFromControl(FriPlace);
        tt.Saturday = _Help_GetTimeTableFromControl(SatPlace);
        return tt;
    }

    private List<MyTimeSpan> _Help_GetTimeTableFromControl(PlaceHolder pholder)
    {
        List<MyTimeSpan> mtimespanlist = new List<MyTimeSpan>(10);
        foreach(Object obj in pholder.Controls)
        {
            LabCenter_UserControl_TimeSpanEdit tse = obj as LabCenter_UserControl_TimeSpanEdit;
            if(tse!=null)
            {
                MyTimeSpan mts = new MyTimeSpan();
                mts.begin = tse.FromTime;
                mts.end = tse.ToTime;
                mts.enddayofweek = tse.ToDayofWeek;
                mtimespanlist.Add(mts);
            }
        }
        return mtimespanlist;
    }

    void Refresh()
    {
        Timer_Refresh.Enabled = true;
    }

    /// <summary>
    /// 获取当前的TimeTable（不包含无效)
    /// </summary>
    /// <returns></returns>
    public TimeTable GetCleanTimeTable()
    {
        TimeTable tt = GetTimeTableFromControl();
        if(tt!=null)
        {
            tt.CleanUp();
            return tt;
        }
        else
        {
            return new TimeTable();
        }
    }



    protected void MonAdd_Click(object sender, EventArgs e)
    {
        AddTimeSpanControl(1, 1);
    }
    protected void MonDel_Click(object sender, EventArgs e)
    {
        DeleteLastTimeSpanControl(1);
    }
    protected void TueAdd_Click(object sender, EventArgs e)
    {
        AddTimeSpanControl(2,2);
    }
    protected void TueDel_Click(object sender, EventArgs e)
    {
        DeleteLastTimeSpanControl(2);
    }
    protected void WedAdd_Click(object sender, EventArgs e)
    {
        AddTimeSpanControl(3, 3);
    }
    protected void WedDel_Click(object sender, EventArgs e)
    {
        DeleteLastTimeSpanControl(3);
    }
    protected void ThuAdd_Click(object sender, EventArgs e)
    {
        AddTimeSpanControl(4, 4);
    }
    protected void ThuDel_Click(object sender, EventArgs e)
    {
        DeleteLastTimeSpanControl(4);
    }
    protected void FriAdd_Click(object sender, EventArgs e)
    {
        AddTimeSpanControl(5, 5);
    }
    protected void FriDel_Click(object sender, EventArgs e)
    {
        DeleteLastTimeSpanControl(5);
    }
    protected void SatAdd_Click(object sender, EventArgs e)
    {
        AddTimeSpanControl(6, 6);
    }
    protected void SatDel_Click(object sender, EventArgs e)
    {
        DeleteLastTimeSpanControl(6);
    }
}
