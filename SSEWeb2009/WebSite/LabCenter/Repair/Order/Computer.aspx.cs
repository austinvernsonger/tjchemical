using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using LabCenter.Repair;
using LabCenter.LabUtility.LoginUtility;

public partial class LabCenter_Repair_Order_Computer : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(IsPostBack)
        {
            this.lblRetmsg.Visible = true;
        }
        else
        {
            LoginCtrl.CheckLoginRedirect(this);

            InitializeNumber();

            InitializeDescription();
        }
    }

    void InitializeNumber()
    {
        ComputerNumbers cn;
        object o = Application["LabCenter_ComputerNumbers"];
        if (null==o)
        {
            string path = MapPath("~/LabCenter/XmlConfig/ComputerNumberConfig.xml");
            cn = new ComputerNumbers(path);
            //cn.CNumberList.Add(new KeyValuePair<int, int>(416, 20));
            //cn.CNumberList.Add(new KeyValuePair<int, int>(430, 60));
            //cn.Serialize();
            cn.Deserialize();
            Application["LabCenter_ComputerNumbers"] = cn;
        }
        else
        {
            cn = o as ComputerNumbers;
        }
        foreach (KeyValuePair<int,int> kvp in cn.CNumberList)
        {
            ddlCpNum_Room.Items.Add(kvp.Key.ToString());
        }
        ddlCpNum_Room.Items.Insert(0, "");
    }

    void InitializeDescription()
    {
        ComputerFailureDescriptions cfd;
        object o = Application["LabCenter_ComputerFailureDescriptions"];

        if (null == o)
        {
            string path = MapPath("~/LabCenter/XmlConfig/ComputerFailureDescriptionConfig.xml");
            cfd = new ComputerFailureDescriptions(path);
            cfd = (ComputerFailureDescriptions)cfd.Deserialize();
            Application["LabCenter_ComputerFailureDescriptions"] = cfd;
        }
        else
        {
            cfd = o as ComputerFailureDescriptions;
        }
        foreach (String s in cfd.Failures)
        {
            cblDescriptions.Items.Add(s);
        }
        cblDescriptions.Items.Add("其它");
    }

    protected void ddlCpNum_Room_OnSelectedIndexChanged(object sender,EventArgs e)
    {
        String room = ddlCpNum_Room.Text;
        if (room.Equals(""))
        {
            ddlCpNum_Num.Items.Clear();
        }
        else
        {
            int maxnumber = 0;
            int roomnumber=int.Parse(room);
            ComputerNumbers cn = Application["LabCenter_ComputerNumbers"] as ComputerNumbers;
            foreach (KeyValuePair<int, int> kvp in cn.CNumberList)
            {
                if (kvp.Key==roomnumber)
                {
                    maxnumber = kvp.Value;
                    break;
                }
            }
            ddlCpNum_Num.Items.Clear();
            for (int i = 1; i <= maxnumber;++i )
            {
                ddlCpNum_Num.Items.Add(i.ToString("000"));
            }
            ddlCpNum_Num.Items.Insert(0, "");
        }
    }
    

    protected void btnNewCpOrder_Click(object sender,EventArgs e)
    {
        string reporter_id;
        //获取登陆账号
        reporter_id=LoginCtrl.CheckLoginRedirect(this);

        //reporter_id = "000000";

        ComputerManager cpm = new ComputerManager();
        string cp_num=ddlCpNum_Room.Text+"-"+ddlCpNum_Num.Text;
        string discrip = GetDescription();
        string retmsg;
        if(!cpm.NewOrder(reporter_id, cp_num, discrip))
        {
            retmsg = cpm.ErrorMsg;
        }
        else
        {
            retmsg = "感谢您的提交！您提交的问题如下:" + GetDescription();
            ddlCpNum_Room.Text = "";
            ddlCpNum_Num.Text = "";
            tbDescription.Text = "";
            for (int i = 0; i != cblDescriptions.Items.Count;++i )
            {
                cblDescriptions.Items[i].Selected = false;
            }
        }
        lblRetmsg.Text = retmsg;
    }
    String GetDescription()
    {
        String str = "";
        int count=1;
        for (int i = 0; i <= cblDescriptions.Items.Count-2;++i )
        {
            if (cblDescriptions.Items[i].Selected)
            {
                str += (count++).ToString() + "." + cblDescriptions.Items[i].Value + "\n";
            }
        }
        if (cblDescriptions.Items[cblDescriptions.Items.Count-1].Selected)
        {
            String other = tbDescription.Text.Trim();
            if (!other.Equals(""))
            {
                str += (count++).ToString() + "." + tbDescription.Text;
            }
        }
        return str;
    }
}
