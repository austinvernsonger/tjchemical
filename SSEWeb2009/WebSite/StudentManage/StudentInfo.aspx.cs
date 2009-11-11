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

public partial class StudentManage_Student : System.Web.UI.Page
{
    private bool isUpdateSuccess = true;

    protected void Page_Load(object sender, EventArgs e)
    {
        string curStudentID = (string)Session["IdentifyNumber"];
        SqlDataSource1.SelectCommand = "select * from Student where StudentID='" + curStudentID+"'";
    }


    protected string ReturnSex(object _sexnum)
    {
        if ((bool)_sexnum)
            return "男";
        else
            return "女";
    }

    protected void ButtonOK_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)//验证
        {
            if (isUpdateSuccess) Response.Write("<script language=javascript>alert('修改成功');</script>");
            else Response.Write("<script language=javascript>alert('修改失败');</script>");
        }
    }

    protected void TxtNativeProvince_Changed(object sender, EventArgs e)
    {
        SqlDataSource1.UpdateCommand = "Update Student set NativeProvince=@TxtNativeProvince where StudentID=" + (string)Session["IdentifyNumber"];
        SqlDataSource1.UpdateParameters.Add("TxtNativeProvince", ((TextBox)sender).Text.Trim());
        if (SqlDataSource1.Update() == 0) isUpdateSuccess = false;
    }

    protected void TxtDormitory_Changed(object sender, EventArgs e)
    {
        SqlDataSource1.UpdateCommand = "Update Student set Dormitory=@TxtDormitory where StudentID='" + (string)Session["IdentifyNumber"]+"'";
        SqlDataSource1.UpdateParameters.Add("TxtDormitory", ((TextBox)sender).Text.Trim());
        if (SqlDataSource1.Update() == 0) isUpdateSuccess = false;
    }

    protected void TxtPosition_Changed(object sender, EventArgs e)
    {
        SqlDataSource1.UpdateCommand = "Update Student set Position=@TxtPosition where StudentID=" + (string)Session["IdentifyNumber"];
        SqlDataSource1.UpdateParameters.Add("TxtPosition", ((TextBox)sender).Text.Trim());
        if (SqlDataSource1.Update() == 0) isUpdateSuccess = false;

    }

    protected void TxtMobilePhone_Changed(object sender, EventArgs e)
    {
        SqlDataSource1.UpdateCommand = "Update Student set MobilePhone=@TxtMobilePhone where StudentID=" + (string)Session["IdentifyNumber"];
        SqlDataSource1.UpdateParameters.Add("TxtMobilePhone", ((TextBox)sender).Text.Trim());
        if (SqlDataSource1.Update() == 0) isUpdateSuccess = false;

    }

    protected void TxtFixedPhone_Changed(object sender, EventArgs e)
    {
        SqlDataSource1.UpdateCommand = "Update Student set FixedPhone=@TxtFixedPhone where StudentID=" + (string)Session["IdentifyNumber"];
        SqlDataSource1.UpdateParameters.Add("TxtFixedPhone", ((TextBox)sender).Text.Trim());
        if (SqlDataSource1.Update() == 0) isUpdateSuccess = false;

    }

    protected void TxtAdvantage_Changed(object sender, EventArgs e)
    {
        SqlDataSource1.UpdateCommand = "Update Student set Advantage=@TxtAdvantage where StudentID=" + (string)Session["IdentifyNumber"];
        SqlDataSource1.UpdateParameters.Add("TxtAdvantage", ((TextBox)sender).Text.Trim());
        if (SqlDataSource1.Update() == 0) isUpdateSuccess = false;

    }


    protected void TxtHomeAddress_Changed(object sender, EventArgs e)
    {
        SqlDataSource1.UpdateCommand = "Update Student set HomeAddress=@TxtHomeAddress where StudentID=" + (string)Session["IdentifyNumber"];
        SqlDataSource1.UpdateParameters.Add("TxtHomeAddress", ((TextBox)sender).Text.Trim());
        if (SqlDataSource1.Update() == 0) isUpdateSuccess = false;

    }
}
