using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using LabCenter.Reservation;
using LabCenter.LabUtility.LoginUtility;

public partial class LabCenter_Reservation_ArrangeExperiment : System.Web.UI.Page
{
    string termspath = AppDomain.CurrentDomain.BaseDirectory+
                           @"LabCenter\XmlConfig\Terms.xml";
    string weekspath = AppDomain.CurrentDomain.BaseDirectory +
                           @"LabCenter\XmlConfig\weeks.xml";
    //string[] weekarray = new string[] { "第一周", "第二周", "第三周", "第四周", "第五周", "第六周", "第七周", "第八周", 
    //                        "第九周","第十周","第十一周","第十二周","第十三周","第十四周","第十五周","第十六周","第十七周"};
    //string basicconfigpath = AppDomain.CurrentDomain.BaseDirectory +
    //                       @"LabCenter\XmlConfig\basicConfig.xml";
    string timetablepath = AppDomain.CurrentDomain.BaseDirectory +
                           @"LabCenter\XmlConfig\TimeTable.xml";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
           
                LoginCtrl.CheckAuthorityRedirect(this, 8, 1);

           
            TermList tl = BackManager.GetTermList(termspath);
            for (int i = 0; i < tl.Terms.Count; i++)
            {
                ListItem termli = new ListItem(tl.Terms[i].ToString());
                DropDownList1.Items.Add(termli);
            }
            WeekList wl = BackManager.GetWeekList(weekspath);
            for (int j = 0; j < wl.Weeks.Count; j++)
            {
                //ListItem weekli = new ListItem(weekarray[Convert.ToInt32(wl.Weeks[j])-1], wl.Weeks[j].ToString());
                ListItem weekli = new ListItem(wl.Weeks[j].ToString());
                DropDownList2.Items.Add(weekli);
            }
        }
    }

    protected void btnselect_Click(object sender, EventArgs e)
    {
        string strterm = DropDownList1.SelectedItem.Text.Trim();
        string strweek = DropDownList2.SelectedItem.Text.Trim();
        //BasicConfig bc = BackManager.GetBasicConfig(basicconfigpath);

        PanelNewTTShow.Visible = false;

        //选择的是以前的时间
        if (BasicConfig.CurrentTerm > Convert.ToInt32(strterm) || BasicConfig.CurrentTerm == Convert.ToInt32(strterm) && BasicConfig.CurrentWeek > Convert.ToInt32(strweek))
        {
            //btnedittime.Visible = false;
            btnSaveAll.Visible = false;
            
            DataSet dst = BackManager.GetHistoryExperiment(Convert.ToInt32(strterm),Convert.ToInt32(strweek));
            if (dst == null || dst.Tables.Count == 0 || dst.Tables[0].Rows.Count == 0)
            {
                cblExperiment.Visible = false;
                TTE.Visible = false;
                Write("该周未安排实验!");
                return;
            }
            else
            {
                cblExperiment.Visible = true;
                cblExperiment.Enabled = false;

                TTE.Visible = true;
                
                btnSaveAll.Visible = false;

                cblExperiment.DataSource = dst;
                cblExperiment.DataTextField = "ExperimentName";
                cblExperiment.DataValueField = "ExperimentID";
                cblExperiment.DataBind();
                
                
                //。。。

                foreach (ListItem li in cblExperiment.Items)
                { li.Selected = true; }

                //。。。


                //实验时间表显示
                TimeTableManager ttm = new TimeTableManager();
                List<TimeSpanStd> tsslist = ttm.GetTimeSpanStdList(strterm, strweek);
                TimeTable tt = TimeSpanTableAdapter.ToTimeTable(tsslist);
                TTE.EditOff = true;
                TTE.TTable = tt;
            }
        }
        else//选择了未来或现在的某一周
        {
            DataSet ds = BackManager.GetvalidExperiment();
            if(ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
            {
                Write("当前无有效实验可安排!");
                return;
            }
            else
            {
                PanelNewTTShow.Visible = true;

                //btnedittime.Visible = true;
                //btnedittime.Enabled = true;
                cblExperiment.Visible = true;
                cblExperiment.Enabled = true;

                TTE.Visible = true;

                btnSaveAll.Visible = true;
                btnSaveAll.Enabled = true;

                cblExperiment.DataSource = ds;
                cblExperiment.DataTextField = "ExperimentName";
                cblExperiment.DataValueField = "ExperimentID";
                cblExperiment.DataBind();

                List<Experiment> le = ExperimentManager.GetSelectedExperiment(Convert.ToInt32(strterm), Convert.ToInt32(strweek));
                foreach (ListItem li in cblExperiment.Items)
                {
                    for (int i=0;i!=le.Count;++i)
                    {
                        if (le[i].ID==int.Parse(li.Value))
                        {
                            li.Selected = true;
                        }
                    }
                }

                //实验时间表显示
                TimeTableManager ttm = new TimeTableManager();
                List<TimeSpanStd> tsslist = ttm.GetTimeSpanStdList(strterm, strweek);
                TimeTable tt = TimeSpanTableAdapter.ToTimeTable(tsslist);
                TTE.EditOff = false;
                TTE.TTable = tt;
            }
        }
    }

    /// <summary>
    /// 废
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnsave_Click(object sender, EventArgs e)
    {
        List<int> experimentidlist = new List<int>();
        foreach(ListItem li in cblExperiment.Items)
        {
            if (li.Selected)
            {
                experimentidlist.Add(Convert.ToInt32(li.Value));
            }
        }
        if(experimentidlist.Count == 0)
        {
            Write("该周未安排实验,没有数据需要保存!");
            return;
        }

        //if (!BackManager.ArrangeExperiment(Convert.ToInt32(DropDownList1.SelectedItem.Text.Trim()),
        //Convert.ToInt32(DropDownList2.SelectedItem.Value), experimentidlist,null))
        //{
        //    Write("BackManager.ErrorMsg");
        //    return;
        //}
        Write("安排实验成功!");
    }


    protected void btnSaveAll_Click(object sender, EventArgs e)
    {
        SaveArrange();
    }

    protected void SaveArrange()
    {
        List<int> experimentidlist = new List<int>();
        foreach (ListItem li in cblExperiment.Items)
        {
            if (li.Selected)
            {
                experimentidlist.Add(Convert.ToInt32(li.Value));
            }
        }
        if (experimentidlist.Count == 0 || experimentidlist.Count > 3)
        {
            Write("至少要安排的1个实验才能继续，但最多也不能超过3个哦!");
            return;
        }
        Session["experimentlist"] = experimentidlist;
        Session["term"] = DropDownList1.SelectedItem.Text.Trim();
        Session["week"] = DropDownList2.SelectedValue;


        //确定控件
        if(true==TTE.Visible)
        {
            string strterm = DropDownList1.SelectedItem.Text.Trim();
            string strweek = DropDownList2.SelectedItem.Value;
            TimeTable tt = TTE.GetCleanTimeTable();
            if (Session["term"] != null && Session["week"] != null && Session["experimentlist"] != null)
            {
                if (!BackManager.ArrangeExperiment(Convert.ToInt32(Session["term"]),
                Convert.ToInt32(Session["week"]), (List<int>)Session["experimentlist"], tt))
                {
                    Write(BackManager.ErrorMsg);
                    return;
                }
                Write("保存成功!");
                TTE.Visible = false;
                PanelNewTTShow.Visible = false;
                cblExperiment.Visible = false;
                btnSaveAll.Visible = false;
            }
        }
        else
        {
            Write("Something Wrong!");
        }

    }

    protected void Write(String s)
    {
        Response.Write("<span style=\"color: #0099ff\">"+s+"</span>");
    }

    protected void btnLinkEdit_Click(object sender, EventArgs e)
    {
        String toUrl = "http://" + HttpContext.Current.Request.Url.Authority
            + HttpContext.Current.Request.ApplicationPath
            + "/LabCenter/Reservation/Back/EditDefaultTime.aspx";
        Response.Write("<script>window.open('"+toUrl+"');</script>");
    }
    protected void btnUseDefault_Click(object sender, EventArgs e)
    {
        TimeTable tt = BackManager.GetDefaultTimeTable(timetablepath);
        TTE.EditOff = false;
        TTE.TTable = tt;
    }
}
