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
using SysCom;

public partial class SysMgr_NewTeacher : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void AddAccount()
    {
        SavingTeacherInfo AA = new SavingTeacherInfo();
        AA.SetTeacherID(tbTeacherID.Text);
        AA.SetTeacherPassWord(tbPassword.Text);
        AA.SetAccountState(0);
        AA.SetEmailValidation(0);
        BasicTeacherInfo.AccountInsert(AA);
    }
    protected void AddTeacher()
    {
        SavingTeacherInfo AT = new SavingTeacherInfo();
        AT.SetTeacherID(tbTeacherID.Text);
        AT.SetTeacherName(tbName.Text);
        AT.SetGender(tbGender.SelectedItem.Value);
        if (tbTeacherAttribute.SelectedItem.Value == "0")
        {
            AT.SetIsTeacherOrdinary(true);
        }
        else
        {
            AT.SetIsTeacherOrdinary(false);
        }
        
        BasicTeacherInfo.TeacherInsert(AT);
    }
    protected void AddInfo_Click(object sender, EventArgs e)
    {
        if (tbTeacherID.Text=="")
        {
            Warning.Visible = true;
            Warning.Text = "请填写ID";
            return;
        }
        if (tbName.Text=="")
        {
            Warning.Visible = true;
            Warning.Text = "请填写姓名";
            return;
        }
        if (tbPassword.Text=="")
        {
            Warning.Visible = true;
            Warning.Text = "请填写密码";
            return;
        }
        Warning.Visible = false;
        AddAccount();
        AddTeacher();
        Response.Write("<script>alert('添加成功！')</script>");
    }
    protected void Cancel_Click(object sender, EventArgs e)
    {
        tbTeacherID.Text = "";
        tbPassword.Text = "";
        tbName.Text = "";
    }
}
