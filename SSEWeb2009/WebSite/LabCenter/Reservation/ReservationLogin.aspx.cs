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
using LabCenter.LabUtility.PublicUtility;
using System.Collections.Generic;

public partial class 实验预约_OrderLogin : System.Web.UI.Page
{
    //string basicConfigpath = AppDomain.CurrentDomain.BaseDirectory +
    //                       @"LabCenter\XmlConfig\basicConfig.xml";
    string multiStudentLabpath = AppDomain.CurrentDomain.BaseDirectory +
                           @"LabCenter\XmlConfig\MultiStudentLab.xml";

    static int MaxStudentsInAlab = 3;//多人实验人数上限

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!LoginIPCheck.Check(Request.UserHostAddress))
        {
            Response.Redirect("~/LabCenter/Default.aspx");
        }
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["logtype"] == null)
            {
                Response.Redirect("ReservationLogin_pre.aspx");
            }
            string stuid = LoginCtrl.CheckLoginRedirect(this);
            FrontManager fm = new FrontManager();
            string[] weekday = new string[] { "周日", "周一", "周二", "周三", "周四", "周五", "周六" };
            int term = BasicConfig.CurrentTerm;
            int week = BasicConfig.CurrentWeek;

            string logtypestr = Request.QueryString["logtype"].ToString();
            dateindex.Value = Request.QueryString["DateIndex"].ToString();
            if (logtypestr == "in")//登入
            {
                DataSet ds = fm.GetReservationDetails(int.Parse(dateindex.Value));
                if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
                {
                    lblrecord.Text = "取出预约详细信息失败!";
                    return;
                }
                lblexpname.Text += ds.Tables[0].Rows[0]["ExperimentName"].ToString();
                lblstarttime.Text += ds.Tables[0].Rows[0]["BeginTime"].ToString();
                if (ds.Tables[0].Rows[0]["EndDayOfWeek"].ToString() == ""
                    || ds.Tables[0].Rows[0]["EndDayOfWeek"].ToString() == ds.Tables[0].Rows[0]["BeginDayOfWeek"].ToString())
                {
                    lblendtime.Text += ds.Tables[0].Rows[0]["EndTime"].ToString();
                }
                else
                {
                    int dif = Convert.ToInt32(ds.Tables[0].Rows[0]["EndDayOfWeek"].ToString()) - Convert.ToInt32(ds.Tables[0].Rows[0]["BeginDayOfWeek"].ToString());
                    if (dif > 0)
                    {
                        lblendtime.Text += weekday[Convert.ToInt32(ds.Tables[0].Rows[0]["EndDayOfWeek"])] + ds.Tables[0].Rows[0]["EndTime"].ToString();
                    }
                    else //dif<0
                    {
                        lblendtime.Text += "下" + weekday[Convert.ToInt32(ds.Tables[0].Rows[0]["EndDayOfWeek"])] + ds.Tables[0].Rows[0]["EndTime"].ToString();
                    }
                }
                detailsdiv.Visible = true;
                lblrecord.Text = "";
            }
            else if (logtypestr == "out")//登出
            {
                lblexpname.Text += Request.QueryString["ExperimentName"].ToString();
                lblstarttime.Text += Request.QueryString["BeginTime"].ToString();
                lblendtime.Text += Request.QueryString["EndTime"].ToString();
                lbllogin.Text += Request.QueryString["LoginTime"].ToString();
                txtdevice.Text = Request.QueryString["DeviceID"].ToString();
                txtdevice.ReadOnly = true;
                btnlogin.Enabled = false;
                btnlogout.Enabled = true;
                ////
                StudentNo sn = fm.GetStudentNo(stuid, multiStudentLabpath);
                if (sn != null)
                {
                    foreach (string stuNo in sn.ValuesNo)
                    {
                        list1.Items.Add(stuNo);
                    }
                }

                txtStuNo.ReadOnly = true;
                btnadd.Enabled = false;
                btnremove.Enabled = false;
                ////
            }
        }
    }

    protected void val_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (args.Value.Trim() == "")
        {
            args.IsValid = false;
        }
        Regex intvalueregex = new Regex("^\\d+$");

        Match m = intvalueregex.Match(args.Value.Trim());
        if (m.Success)
        {
            if (Convert.ToInt32(args.Value.Trim()) <= BasicConfig.RemainCount 
                && Convert.ToInt32(args.Value.Trim()) >= 1)
            {
                args.IsValid = true;
            }
            else
                args.IsValid = false;
        }
        else
            args.IsValid = false;

        if (!args.IsValid)
        {
            cvdevice.Text = "请输入有效设备编号(范围:1至" + BasicConfig.RemainCount + ")";
        }
    }
    protected void btnlogin_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            //...
            string stuid = LoginCtrl.CheckLoginRedirect(this);
            FrontManager fm = new FrontManager();
            ////多人实验登入
            if (list1.Items.Count > 0)
            {
                List<string> otherstuids = new List<string>();
                foreach (ListItem li in list1.Items)
                {
                    otherstuids.Add(li.Text.Trim());
                }
                bool issucceed = fm.UpdateMultiStudentLab(stuid, otherstuids, multiStudentLabpath,true);
                if (!issucceed)
                {
                    lblrecord.Text = fm.ErrorMsg;
                    return;
                }
                else
                {
                    foreach (string sid in otherstuids)
                    {
                        if (!fm.AddRegInfo(sid, Convert.ToInt32(dateindex.Value.Trim()), DateTime.Now.ToString(), Convert.ToInt32(txtdevice.Text.Trim())))
                        {
                            lblrecord.Text = fm.ErrorMsg;
                            return;
                        }
                    }
                }
            }
            ////
            if (!fm.AddRegInfo(stuid, Convert.ToInt32(dateindex.Value.Trim()), DateTime.Now.ToString(), Convert.ToInt32(txtdevice.Text.Trim())))
            {
                lblrecord.Text = fm.ErrorMsg;
                return;
            }
            lbllogin.Text += DateTime.Now.ToString();
            txtdevice.ReadOnly = true;
            btnlogout.Enabled = true;
            btnlogin.Enabled = false;
            ////
            txtStuNo.ReadOnly = true;
            btnadd.Enabled = false;
            btnremove.Enabled = false;
        }
    }
    protected void btnlogout_Click(object sender, EventArgs e)
    {
        string stuid = LoginCtrl.CheckLoginRedirect(this);
        FrontManager fm = new FrontManager();
        ////
        if (list1.Items.Count > 0)
        {
            List<string> otherstuids = new List<string>();
            foreach (ListItem li in list1.Items)
            {
                otherstuids.Add(li.Text.Trim());
            }
            bool issucceed = fm.UpdateMultiStudentLab(stuid, otherstuids, multiStudentLabpath, false);
            if (!issucceed)
            {
                lblrecord.Text = fm.ErrorMsg;
                return;
            }
            else
            {
                foreach (string sid in otherstuids)
                {
                    if (!fm.UpdateRegInfo(sid, Convert.ToInt32(dateindex.Value.Trim())))
                    {
                        lblrecord.Text = fm.ErrorMsg;
                        return;//
                    }
                }
            }
        }
        ////
        if (!fm.UpdateRegInfo(stuid, Convert.ToInt32(dateindex.Value.Trim())))
        {
            lblrecord.Text = fm.ErrorMsg;
            return;//
        }
        lbllogout.Text += DateTime.Now.ToString();
        btnlogout.Enabled = false;
    }

    protected void val_StuNoValidate(object source, ServerValidateEventArgs args)
    {
        if (args.Value.Trim() == "")
        {
            args.IsValid = false;
        }
        Regex intvalueregex = new Regex("^\\d+$");

        Match m = intvalueregex.Match(args.Value.Trim());
        if (m.Success)
        {
            if (Convert.ToInt32(args.Value.Trim()) >= 1)
            {
                args.IsValid = true;
            }
            else
                args.IsValid = false;
        }
        else
            args.IsValid = false;

        if (!args.IsValid)
        {
            lbladdremrlt.Text = "请输入有效学号！";
            return;
        }
    }
    protected void btnadd_Click(object sender, EventArgs e)
    {
        string stuid = LoginCtrl.CheckLoginRedirect(this);
        string addstuid = txtStuNo.Text.Trim();
        if (!Account.ExistStudent(addstuid))
        {
            lbladdremrlt.Text = "学号不存在！";
            return;
        }

        if (stuid.Equals(addstuid))
        {
            lbladdremrlt.Text = "请输入与自己相异的学号！";
            txtStuNo.Focus();
            return;
        }

        List<string> stuidlst = new List<string>();
        if (list1.Items.Count > 0 && list1.Items.Count < MaxStudentsInAlab-1)
        {
            foreach (ListItem li in list1.Items)
            {
                stuidlst.Add(li.Text.Trim());
            }
            if (stuidlst.Contains(addstuid))
            {
                lbladdremrlt.Text = "请勿重复输入相同的学号！";
                txtStuNo.Focus();
                return;
            }
        }
        if (list1.Items.Count >= MaxStudentsInAlab-1)
        {
            lbladdremrlt.Text = "已达到多人实验人数上限，不能添加！";
            return;
        }

        lbladdremrlt.Text = "";
        list1.Items.Add(addstuid);
    }
    protected void btnremove_Click(object sender, EventArgs e)
    {
        List<string> stuidlst = new List<string>();
        if (list1.Items.Count == 0)
        {
            lbladdremrlt.Text = "列表中无学号！";
            return;
        }
        else
        {
            //txtStuNo.Text.Trim() == "" && 
            if (list1.SelectedIndex > -1)
            {
                lbladdremrlt.Text = "";
                list1.Items.RemoveAt(list1.SelectedIndex);
            }
            else
            {
                lbladdremrlt.Text = "请先选中要删除的学号！";
            }
            //if (!list1.Items.Contains(new ListItem(txtStuNo.Text.Trim())))
            //{
            //    lbladdremrlt.Text = "请输入列表中已有的学号！";
            //    txtStuNo.Focus();
            //    return;
            //}
            //else
            //{
            //    list1.Items.Remove(txtStuNo.Text.Trim());
            //}
        }
    }
}
