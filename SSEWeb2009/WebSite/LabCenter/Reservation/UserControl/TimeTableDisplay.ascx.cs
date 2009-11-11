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

public partial class LabCenter_Reservation_UserControl_TimeTableDisplay : System.Web.UI.UserControl,INamingContainer
{
    Boolean m_editoff;
    TimeTable m_tt;
    int m_count;

    /// <summary>
    /// 读取所有Session里的数据
    /// </summary>
    void LoadSession()
    {
        try
        {
            m_editoff = (Boolean)Session["Lab_TT_EditOff" + this.ID];
            m_tt = (TimeTable)Session["Lab_TT" + this.ID];
            m_count = (int)Session["Lab_TT_Comp_Count" + this.ID];
        }
        catch (System.Exception e)
        {
            e.ToString();
            //Response.Write(e.ToString());
        }
    }

    /// <summary>
    /// 写回数据到Session里
    /// </summary>
    void SaveSession()
    {
        Session["Lab_TT_EditOff" + this.ID] = m_editoff;
        Session["Lab_TT" + this.ID] = m_tt;
        Session["Lab_TT_Comp_Count" + this.ID] = m_count;
    }

    /// <summary>
    /// 编辑开关
    /// </summary>
    public Boolean EditOff
    {
        get
        {
            LoadSession();
            return m_editoff;
        }
        set
        {
            LoadSession();
            m_editoff = value;
            SaveSession();
            //Refresh();
        }
    }

    /// <summary>
    /// TimeTable对象设置和获取
    /// </summary>
    public TimeTable TTable
    {
        get
        {
            return GetTimeTableFromControl();
        }
        set
        {
            m_tt = value;
            SaveSession();
            Refresh();
        }
    }

    /// <summary>
    /// 刷新
    /// </summary>
    void Refresh()
    {
        Timer_Refresh.Enabled = true;
    }

    /// <summary>
    /// 加载控件
    /// </summary>
    void LoadControls()
    {
        LoadSession();
        AddDelButtonVisibleChange(!m_editoff);
        if(m_tt!=null)
        {
            MyTimeSpan mts;

            MonPlace.Controls.Clear();
            for(int i=0;i!=m_tt.Monday.Count;++i)
            {
                mts = m_tt.Monday[i];
                mts.enddayofweek = -1 == mts.enddayofweek ? 1 : mts.enddayofweek;
                LabCenter_UserControl_TimeSpanEdit tse =
                    (LabCenter_UserControl_TimeSpanEdit)CreateTimeSpanEdit("1_"+i.ToString(),mts);
                MonPlace.Controls.Add(tse);
            }

            TuePlace.Controls.Clear();
            for (int i = 0; i != m_tt.Tuesday.Count; ++i)
            {
                mts = m_tt.Tuesday[i];
                mts.enddayofweek = -1 == mts.enddayofweek ? 2 : mts.enddayofweek;
                LabCenter_UserControl_TimeSpanEdit tse =
                    (LabCenter_UserControl_TimeSpanEdit)CreateTimeSpanEdit("2_"+i.ToString(),mts);
                TuePlace.Controls.Add(tse);
            }

            WedPlace.Controls.Clear();
            for (int i = 0; i != m_tt.Wednesday.Count; ++i)
            {
                mts = m_tt.Wednesday[i];
                mts.enddayofweek = -1 == mts.enddayofweek ? 3 : mts.enddayofweek;
                LabCenter_UserControl_TimeSpanEdit tse =
                    (LabCenter_UserControl_TimeSpanEdit)CreateTimeSpanEdit("3_"+i.ToString(),mts);
                WedPlace.Controls.Add(tse);
            }

            ThuPlace.Controls.Clear();
            for (int i = 0; i != m_tt.Thursday.Count; ++i)
            {
                mts = m_tt.Thursday[i];
                mts.enddayofweek = -1 == mts.enddayofweek ? 4 : mts.enddayofweek;
                LabCenter_UserControl_TimeSpanEdit tse =
                    (LabCenter_UserControl_TimeSpanEdit)CreateTimeSpanEdit("4_"+i.ToString(),mts);
                ThuPlace.Controls.Add(tse);
            }

            FriPlace.Controls.Clear();
            for (int i = 0; i != m_tt.Friday.Count; ++i)
            {
                mts = m_tt.Friday[i];
                mts.enddayofweek = -1 == mts.enddayofweek ? 5 : mts.enddayofweek;
                LabCenter_UserControl_TimeSpanEdit tse =
                    (LabCenter_UserControl_TimeSpanEdit)CreateTimeSpanEdit("5_"+i.ToString(),mts);
                FriPlace.Controls.Add(tse);
            }

            SatPlace.Controls.Clear();
            for (int i = 0; i != m_tt.Saturday.Count; ++i)
            {
                mts = m_tt.Saturday[i];
                mts.enddayofweek = -1 == mts.enddayofweek ? 6 : mts.enddayofweek;
                LabCenter_UserControl_TimeSpanEdit tse =
                    (LabCenter_UserControl_TimeSpanEdit)CreateTimeSpanEdit("6_"+i.ToString(),mts);
                SatPlace.Controls.Add(tse);
            }

        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //初始化+保存
            m_editoff = false;
            m_tt = new TimeTable();
            m_count = 0;
            SaveSession();
        }
        LoadControls();
    }


    /// <summary>
    /// 设置+/-操作按钮的可视性
    /// </summary>
    /// <param name="isvisible"></param>
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

    protected override void OnPreRender(EventArgs e)
    {
        //base.OnPreRender(e);
        //LoadSession();
        //LoadControls();
    }
    
    /// <summary>
    /// 创建自定义控件
    /// </summary>
    /// <returns></returns>
    public LabCenter_UserControl_TimeSpanEdit CreateTimeSpanEdit(string ID_fix,MyTimeSpan mts)
    {
        LabCenter_UserControl_TimeSpanEdit c = (LabCenter_UserControl_TimeSpanEdit)LoadControl("TimeSpanEdit.ascx");
        c.ID = "LabCenter_Component_" + this.ID + "_" + ID_fix;
        c.EditOff = m_editoff;
        c.FromTime = mts.begin;
        c.ToTime = mts.end;
        c.ToDayofWeek = mts.enddayofweek;
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
        MyTimeSpan mts = new MyTimeSpan();
        mts.enddayofweek = todayofweek;
        switch(fromdayofweek)
        {
            case 1:
                m_tt.Monday.Add(mts);
                break;
            case 2:
                m_tt.Tuesday.Add(mts);
                break;
            case 3:
                m_tt.Wednesday.Add(mts);
                break;
            case 4:
                m_tt.Thursday.Add(mts);
                break;
            case 5:
                m_tt.Friday.Add(mts);
                break;
            case 6:
                m_tt.Saturday.Add(mts);
                break;
        }
        SaveSession();
        Refresh();
    }

    /// <summary>
    /// 删去星期X的最后一个时间段
    /// </summary>
    /// <param name="fromdayofweek">星期X</param>
    private void DeleteLastTimeSpanControl(int fromdayofweek)
    {
        LoadSession();
        Boolean refresh = false;
        switch (fromdayofweek)
        {
            case 1:
                if (m_tt.Monday.Count!=0)
                {
                    m_tt.Monday.RemoveAt(m_tt.Monday.Count - 1);
                    refresh = true;
                }
                break;
            case 2:
                if (m_tt.Tuesday.Count != 0)
                {
                    m_tt.Tuesday.RemoveAt(m_tt.Tuesday.Count - 1);
                    refresh = true;
                }
                break;
            case 3:
                if (m_tt.Wednesday.Count != 0)
                {
                    m_tt.Wednesday.RemoveAt(m_tt.Wednesday.Count - 1);
                    refresh = true;
                } 
                break;
            case 4:
                if (m_tt.Thursday.Count != 0)
                {
                    m_tt.Thursday.RemoveAt(m_tt.Thursday.Count - 1);
                    refresh = true;
                }
                break;
            case 5:
                if (m_tt.Friday.Count != 0)
                {
                    m_tt.Friday.RemoveAt(m_tt.Friday.Count - 1);
                    refresh = true;
                } 
                break;
            case 6:
                if (m_tt.Saturday.Count != 0)
                {
                    m_tt.Saturday.RemoveAt(m_tt.Saturday.Count - 1);
                    refresh = true;
                } 
                break;
        }
        if (refresh)
        {
            SaveSession();
            Refresh();
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

    /// <summary>
    /// 获取当前的TimeTable（不包含无效)
    /// </summary>
    /// <returns></returns>
    public TimeTable GetCleanTimeTable()
    {
        LoadSession();
        TimeTable tt = (TimeTable)m_tt.Clone();
        //TimeTable tt = GetTimeTableFromControl();
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


#region -----------------------------> +/-按钮事件

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
        AddTimeSpanControl(2, 2);
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
#endregion
    
}
