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
using LabCenter.LabUtility.PerInfoUtility;
using LabCenter.Authority;
using System.Xml;
using LabCenter.LabUtility.LoginUtility;

public partial class _AuthoManage : System.Web.UI.Page
{
    static private bool modifying = false;
    static private string id;
    static private string name;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string account=LoginCtrl.CheckLoginRedirect(this);
            
            AuthorityManage am = new AuthorityManage();
            if (!am.IsSuper(account))
            {
                Response.Redirect("~/LabCenter/NoAuthority.aspx");
            }
            id = Request.Params.Get("id");
            name=Request.Params.Get("name");
            IDLabel.Text = id;
            NameLabel.Text = name;
            GetAuthority();
        }
       

    }
    protected void AuthoChange_Click(object sender, EventArgs e)
    {
        if (!modifying)
        {
            AuthoChange.Text = "保存修改";
            Reverse.Enabled = true;
            EnableAll();
            modifying = true;
        }
        else
        {
            UpdateAuthority();
            AuthoChange.Text = "修改权限";
            Reverse.Enabled = false;
            UnEnableAll();
            modifying = false;
        }
    }
    protected void GetReturn_Click(object sender, EventArgs e)
    {
        Response.Redirect("SearchManager.aspx", true);
      //  AuthorityManage am = new AuthorityManage();
    }
    protected void SuperTransfer_Click(object sender, EventArgs e)
    {
        AuthorityManage am = new AuthorityManage();
        //am.TransferSuper(Session["IdentifyNumber"].ToString(), id, Server.MapPath("~/LabCenter/XmlConfig/FunctionConfig.xml"));
        am.TransferSuper("0000", id, Server.MapPath("~/LabCenter/XmlConfig/FunctionConfig.xml"));
        Response.Write("<script>alert('移交成功！将返回实验中心首页')</script>");
        Response.Redirect("~/LabCenter/homePage.aspx", true);
    }
    private void GetAuthority()
    {
        AuthorityManage am = new AuthorityManage();
        if (am.HasAuthority(id,1,1))
        {
            CheckBox1_1.Checked = true;
        }
        if (am.HasAuthority(id, 2, 1))
        {
            CheckBox2_1.Checked = true;
        }
        if (am.HasAuthority(id, 2, 2))
        {
            CheckBox2_2.Checked = true;
        }
        if (am.HasAuthority(id, 2, 3))
        {
            CheckBox2_3.Checked = true;
        }
        if (am.HasAuthority(id, 3, 1))
        {
            CheckBox3_1.Checked = true;
        }
        if (am.HasAuthority(id, 3, 2))
        {
            CheckBox3_2.Checked = true;
        }
        if (am.HasAuthority(id, 3, 3))
        {
            CheckBox3_3.Checked = true;
        }
        if (am.HasAuthority(id, 4, 1))
        {
            CheckBox4_1.Checked = true;
        }
        if (am.HasAuthority(id, 4, 2))
        {
            CheckBox4_2.Checked = true;
        }
        if (am.HasAuthority(id, 4, 3))
        {
            CheckBox4_3.Checked = true;
        }
        if (am.HasAuthority(id, 5, 1))
        {
            CheckBox5_1.Checked = true;
        }
        if (am.HasAuthority(id, 5, 2))
        {
            CheckBox5_2.Checked = true;
        }
        if (am.HasAuthority(id, 5, 3))
        {
            CheckBox5_3.Checked = true;
        }
        if (am.HasAuthority(id, 6, 1))
        {
            CheckBox6_1.Checked = true;
        }
        if (am.HasAuthority(id, 6, 2))
        {
            CheckBox6_2.Checked = true;
        }
        if (am.HasAuthority(id, 6, 3))
        {
            CheckBox6_3.Checked = true;
        }
        if (am.HasAuthority(id, 7, 1))
        {
            CheckBox7_1.Checked = true;
        }
        if (am.HasAuthority(id, 7, 2))
        {
            CheckBox7_2.Checked = true;
        }
        if (am.HasAuthority(id, 8, 1))
        {
            CheckBox8_1.Checked = true;
        }
       
        if (am.HasAuthority(id, 9, 1))
        {
            CheckBox9_1.Checked = true;
        }
        if (am.HasAuthority(id, 9, 2))
        {
            CheckBox9_2.Checked = true;
        }
        if (am.HasAuthority(id, 9, 3))
        {
            CheckBox9_3.Checked = true;
        }
    }
    private void EnableAll()
    {
        CheckBox1_1.Enabled = true;
        CheckBox2_1.Enabled = true;
        CheckBox2_2.Enabled = true;
        CheckBox2_3.Enabled = true;
        CheckBox3_1.Enabled = true;
        CheckBox3_2.Enabled = true;
        CheckBox3_3.Enabled = true;
        CheckBox4_1.Enabled = true;
        CheckBox4_2.Enabled = true;
        CheckBox4_3.Enabled = true;
        CheckBox5_1.Enabled = true;
        CheckBox5_2.Enabled = true;
        CheckBox5_3.Enabled = true;
        CheckBox6_1.Enabled = true;
        CheckBox6_2.Enabled = true;
        CheckBox6_3.Enabled = true;
        CheckBox7_1.Enabled = true;
        CheckBox7_2.Enabled = true;
        CheckBox8_1.Enabled = true;
        CheckBox9_1.Enabled = true;
        CheckBox9_2.Enabled = true;
        CheckBox9_3.Enabled = true;
    }
    private void UnEnableAll()
    {
        CheckBox1_1.Enabled = false;
        CheckBox2_1.Enabled = false;
        CheckBox2_2.Enabled = false;
        CheckBox2_3.Enabled = false;
        CheckBox3_1.Enabled = false;
        CheckBox3_2.Enabled = false;
        CheckBox3_3.Enabled = false;
        CheckBox4_1.Enabled = false;
        CheckBox4_2.Enabled = false;
        CheckBox4_3.Enabled = false;
        CheckBox5_1.Enabled = false;
        CheckBox5_2.Enabled = false;
        CheckBox5_3.Enabled = false;
        CheckBox6_1.Enabled = false;
        CheckBox6_2.Enabled = false;
        CheckBox6_3.Enabled = false;
        CheckBox7_1.Enabled = false;
        CheckBox7_2.Enabled = false;
        CheckBox8_1.Enabled = false;
        CheckBox9_1.Enabled = false;
        CheckBox9_2.Enabled = false;
        CheckBox9_3.Enabled = false;
    }
    private void UnCheckAll()
    {
        CheckBox1_1.Checked = false;
        CheckBox2_1.Checked = false;
        CheckBox2_2.Checked = false;
        CheckBox2_3.Checked = false;
        CheckBox3_1.Checked = false;
        CheckBox3_2.Checked = false;
        CheckBox3_3.Checked = false;
        CheckBox4_1.Checked = false;
        CheckBox4_2.Checked = false;
        CheckBox4_3.Checked = false;
        CheckBox5_1.Checked = false;
        CheckBox5_2.Checked = false;
        CheckBox5_3.Checked = false;
        CheckBox6_1.Checked = false;
        CheckBox6_2.Checked = false;
        CheckBox6_3.Checked = false;
        CheckBox7_1.Checked = false;
        CheckBox7_2.Checked = false;
        CheckBox8_1.Checked = false;
        CheckBox9_1.Checked = false;
        CheckBox9_2.Checked = false;
        CheckBox9_3.Checked = false;
    }
    protected void Reverse_Click(object sender, EventArgs e)
    {
        UnCheckAll();
        GetAuthority();
    }
    private void UpdateAuthority()
    {
        AuthorityManage am = new AuthorityManage();
        am.DeleteAuthority(id);
        if (CheckBox1_1.Checked)
        {
            am.AddAuthority(id, 1, 1);
        }
        if (CheckBox2_1.Checked)
        {
            am.AddAuthority(id, 2, 1);
        }
        if (CheckBox2_2.Checked)
        {
            am.AddAuthority(id, 2, 2);
        }
        if (CheckBox2_3.Checked)
        {
            am.AddAuthority(id, 2, 3);
        }
        if (CheckBox3_1.Checked)
        {
            am.AddAuthority(id, 3, 1);
        }
        if (CheckBox3_2.Checked)
        {
            am.AddAuthority(id, 3, 2);
        }
        if (CheckBox3_3.Checked)
        {
            am.AddAuthority(id, 3, 3);
        }
        if (CheckBox4_1.Checked)
        {
            am.AddAuthority(id, 4, 1);
        }
        if (CheckBox4_2.Checked)
        {
            am.AddAuthority(id, 4, 2);
        }
        if (CheckBox4_3.Checked)
        {
            am.AddAuthority(id, 4, 3);
        }
        if (CheckBox5_1.Checked)
        {
            am.AddAuthority(id, 5, 1);
        }
        if (CheckBox5_2.Checked)
        {
            am.AddAuthority(id, 5, 2);
        }
        if (CheckBox5_3.Checked)
        {
            am.AddAuthority(id, 5, 3);
        }
        if (CheckBox6_1.Checked)
        {
            am.AddAuthority(id, 6, 1);
        }
        if (CheckBox6_2.Checked)
        {
            am.AddAuthority(id, 6, 2);
        }
        if (CheckBox6_3.Checked)
        {
            am.AddAuthority(id, 6, 3);
        }
        if (CheckBox7_1.Checked)
        {
            am.AddAuthority(id, 7, 1);
        }
        if (CheckBox7_2.Checked)
        {
            am.AddAuthority(id, 7, 2);
        }
        if (CheckBox8_1.Checked)
        {
            am.AddAuthority(id, 8, 1);
        }
        if (CheckBox9_1.Checked)
        {
            am.AddAuthority(id, 9, 1);
        }
        if (CheckBox9_2.Checked)
        {
            am.AddAuthority(id, 9, 2);
        }
        if (CheckBox9_3.Checked)
        {
            am.AddAuthority(id, 9, 3);
        }

    }
}
