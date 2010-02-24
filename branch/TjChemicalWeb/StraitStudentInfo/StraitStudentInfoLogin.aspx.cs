using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class StraitStudentInfo_StraitStudentInfoLogin : System.Web.UI.Page
{
    private String strStudentID;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["IdentifyNumber"] == null)
            SysCom.Login.LoginRedirect(Request.Url.ToString());
        if (Session["Authority"].ToString() != "Admin")
        {
            SysCom.Login.LoginRedirect(Request.Url.ToString());
        }
        if (!IsPostBack)
        {
            if (Request.QueryString["id"].ToString().Trim() == String.Empty)
            {
                GoBack();
            }
            strStudentID = Request.QueryString["id"].ToString().Trim();
            InitalizeControl();
        }
    }
    private void InitalizeControl()
    {
        DataSet Rs = StundentInfoManagement.StraitStudentInfoEx.SelectStraitStudentBasicInfo(strStudentID);
        if (Rs.Tables[0].Rows.Count == 0)
        {
            GoBack();
        }
        lbStudentID.Text = strStudentID;
        lbName.Text = Rs.Tables[0].Rows[0][0].ToString();
        DropDownListRegisteredResidenceBeforeSchool.SelectedValue = Rs.Tables[0].Rows[0][1].ToString();
        txtFamilyMemberNum.Text = Rs.Tables[0].Rows[0][2].ToString();
        txtFamilySalary.Text = Rs.Tables[0].Rows[0][3].ToString();
        DropDownListDiBao.SelectedValue = Rs.Tables[0].Rows[0][4].ToString();
        DropDownListGuCan.SelectedValue = Rs.Tables[0].Rows[0][5].ToString();
        DropDownListSingleParent.SelectedValue = Rs.Tables[0].Rows[0][6].ToString();
        DropDownListMartyrChild.SelectedValue = Rs.Tables[0].Rows[0][7].ToString();
        DropDownListApply.SelectedValue = Rs.Tables[0].Rows[0][8].ToString();
        txtExplainThings.Text = Rs.Tables[0].Rows[0][9].ToString();
        DropDownListStraitDegree.SelectedValue = Rs.Tables[0].Rows[0][10].ToString();
    }
    private void GoBack()
    {
        String strurl = "http://" + HttpContext.Current.Request.Url.Authority + HttpContext.Current.Request.ApplicationPath;
        if (!strurl.EndsWith("/")) strurl += "/";
        strurl += "StraitStudentInfo/StraitStudentInfoManage.aspx";
        Response.Redirect(strurl);
    }
    protected void btCommit_Click(object sender, EventArgs e)
    {
        if(StundentInfoManagement.StraitStudentInfoEx.UpdateStraitStudent(
            lbStudentID.Text.Trim(),
            Convert.ToInt16(DropDownListRegisteredResidenceBeforeSchool.SelectedValue.Trim()),
            txtFamilyMemberNum.Text.Trim(),
            txtFamilySalary.Text.Trim(),
            Convert.ToInt16(DropDownListDiBao.SelectedValue.Trim()),
            Convert.ToInt16(DropDownListGuCan.SelectedValue.Trim()),
            Convert.ToInt16(DropDownListSingleParent.SelectedValue.Trim()),
            Convert.ToInt16(DropDownListMartyrChild.SelectedValue.Trim()),
            Convert.ToInt16(DropDownListApply.SelectedValue.Trim()),
            txtExplainThings.Text.Trim(),
            Convert.ToInt16(DropDownListStraitDegree.SelectedValue.Trim())))
        {
            Response.Write("<script>alert('保存成功！');</script>");
            GoBack();
        }
        Response.Write("<script>alert('保存失败！');</script>");
    }
}
