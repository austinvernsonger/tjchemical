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
using StudentFile;
public partial class StudentFile_StudentFileBasicInfo : System.Web.UI.Page
{
    private String strStudentID;
    private short type;
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
            if (Request.QueryString["id"] == null)
            {
                GoBack();
            }
            strStudentID = Request.QueryString["id"];
            if (Request.QueryString["Type"] == null)
            {
                GoBack();
            }
            if (Request.QueryString["Type"]=="add")
            {
                type = 0;
            }
            else if (Request.QueryString["Type"] == "edit")
            {
                type = 1;
            }
            else
            {
                GoBack();
            }
            InitializeControl();
            if (txtFileCreateTime.Text.Trim() == String.Empty)
            {
                txtFileCreateTime.Text = DateTime.Today.ToString();
            }
            if (txtFileSendTime.Text.Trim() == String.Empty)
            {
                txtFileSendTime.Text = DateTime.Today.ToString();
            }
            if (txtGradutaionTime.Text.Trim() == String.Empty)
            {
                txtGradutaionTime.Text = DateTime.Today.ToString();
            }
            if (txtStoreFileStartTime.Text.Trim() == String.Empty)
            {
                txtStoreFileStartTime.Text = DateTime.Today.ToString();
            }
            if (type == 1)
            {
                Rebind();
            }
            
        }
    }
    private void GoBack()
    {

        String strurl = "http://" + HttpContext.Current.Request.Url.Authority + HttpContext.Current.Request.ApplicationPath;
        if (!strurl.EndsWith("/")) strurl += "/";
        strurl += "StudentFile/StudentFileMng.aspx";
        Response.Redirect(strurl);
    }
    private void Rebind()
    {
        GridViewFileBind();
        GridViewArchivesNewBind();
    }
    protected String CheckContent(object TableContent)
    {
        if (TableContent == null)
        {
            return "";
        }
        return TableContent.ToString();
    }
    protected String DateStringFomate(String DateString)
    {
        if (DateString.Length > 11)
        {
            String[] splitDate = DateString.Split('/');
            String[] dateString = splitDate[2].Split(' ');
            String year = splitDate[0];
            String month = splitDate[1];
            String date = dateString[0];
            String Result = year + "/" + month + "/" + date;
            return Result;
        }
        return DateTime.Today.ToString();
    }
    protected String CheckDropDownListView(DropDownList Dp, Object a)
    {
        String content = a.ToString();
        ListItem Checkitem = Dp.Items.FindByValue(content);
        if (Checkitem == null)
        {
            return "-1";
        }
        return content;
    }
    private void InitializeControl()
    {
        DataSet QuestRS = StudentFileEx.SelectSingleStudentFileInfo(strStudentID);
        lbStudentID.Text = strStudentID;
        lbName.Text = CheckContent(QuestRS.Tables[0].Rows[0][0]);
        lbNativeProvince.Text = CheckContent(QuestRS.Tables[0].Rows[0][1]);
        lbStudentSource.Text = CheckContent(QuestRS.Tables[0].Rows[0][2]);
        DropDownListPoliticalStatus.SelectedValue = CheckDropDownListView(DropDownListPoliticalStatus,QuestRS.Tables[0].Rows[0][3]);
        DropDownListMemberInfo.SelectedValue = CheckDropDownListView(DropDownListMemberInfo,QuestRS.Tables[0].Rows[0][4]);
        DropDownListPartyMemberInfo.SelectedValue = CheckDropDownListView(DropDownListPartyMemberInfo,QuestRS.Tables[0].Rows[0][5]);
        txtFileCreateTime.Text = DateStringFomate(CheckContent(QuestRS.Tables[0].Rows[0][6]));
        txtFileSource.Text = CheckContent(QuestRS.Tables[0].Rows[0][7]);
        txtFileSourceType.Text = CheckContent(QuestRS.Tables[0].Rows[0][8]);
        txtGradutaionTime.Text = DateStringFomate(CheckContent(QuestRS.Tables[0].Rows[0][9]));
        txtFileSendTime.Text = DateStringFomate(CheckContent(QuestRS.Tables[0].Rows[0][10]));
        txtFileSendCompany.Text = CheckContent(QuestRS.Tables[0].Rows[0][11]);
        txtFileSendCompanyAddress.Text = CheckContent(QuestRS.Tables[0].Rows[0][12]);
        txtFileSendCompanyPost.Text = CheckContent(QuestRS.Tables[0].Rows[0][13]);
        txtFileSendCompanyContact.Text = CheckContent(QuestRS.Tables[0].Rows[0][14]);
        txtFileSendCompanyPhone.Text = CheckContent(QuestRS.Tables[0].Rows[0][15]);
        txtFileSendCompanyType.Text = CheckContent(QuestRS.Tables[0].Rows[0][16]);
        DropDownListStoreFile.SelectedValue = CheckDropDownListView(DropDownListStoreFile,QuestRS.Tables[0].Rows[0][17]);
        txtStoreFileStartTime.Text = DateStringFomate(CheckContent(QuestRS.Tables[0].Rows[0][18]));
    }
    private void GridViewFileBind()
    {
        strStudentID = lbStudentID.Text.Trim();
        DataSet QueryRS = StudentFileEx.SelectStudentArchivesContent(strStudentID);
        this.GridViewFile.DataSource = QueryRS;
        GridViewFile.DataBind();
    }
    protected void btFileSave_Click(object sender, EventArgs e)
    {
        if (txtContentTitle.Text.Trim()==String.Empty)
        {
            lbErrorMessage.Visible = true;
            lbErrorMessage.Text = "标题不可为空！";
            return;
        }
        strStudentID = lbStudentID.Text.Trim();
        if (!StudentFileEx.InsertStudentArchivesContent(txtContentTitle.Text.Trim(), txtFileContent.Text.Trim(), txtFileRemark.Text.Trim(), strStudentID))
        {
            lbErrorMessage.Visible = true;
            lbErrorMessage.Text = "插入失败！";
            return;
        }
        lbErrorMessage.Visible = true;
        lbErrorMessage.Text = "插入成功！";
        GridViewFileBind();
    }
    protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        strStudentID = lbStudentID.Text.Trim();
        int index = e.RowIndex;
        String SelectedID = this.GridViewFile.DataKeys[index].Value.ToString().Trim();
        if (!StudentFileEx.DeleteStudentArchivesContent(SelectedID,strStudentID))
        {
            lbErrorMessage.Visible = true;
            lbErrorMessage.Text = "删除失败！";
            return;
        }
        lbErrorMessage.Visible = true;
        lbErrorMessage.Text = "删除成功！";
        GridViewFileBind();
    }
    protected void bt_SaveArchives_Click(object sender, EventArgs e)
    {
        strStudentID = lbStudentID.Text.Trim();
        if (txtFileCreateTime.Text.Trim()==String.Empty)
        {
            txtFileCreateTime.Text = DateTime.Today.ToString();
        }
        if (txtFileSendTime.Text.Trim() == String.Empty)
        {
            txtFileSendTime.Text = DateTime.Today.ToString();
        }
        if (txtGradutaionTime.Text.Trim() == String.Empty)
        {
            txtGradutaionTime.Text = DateTime.Today.ToString();
        }
        if (txtStoreFileStartTime.Text.Trim() == String.Empty)
        {
            txtStoreFileStartTime.Text = DateTime.Today.ToString();
        }
        if (!StudentFileEx.UpdateStudentArchives(Convert.ToInt16(DropDownListMemberInfo.SelectedValue),Convert.ToInt16(DropDownListPartyMemberInfo.SelectedValue),
            txtFileCreateTime.Text.Trim(),txtFileSource.Text.Trim(),txtFileSourceType.Text.Trim(),txtGradutaionTime.Text.Trim(),txtFileSendTime.Text.Trim(),
            txtFileSendCompany.Text.Trim(),txtFileSendCompanyAddress.Text.Trim(),txtFileSendCompanyPost.Text.Trim(),txtFileSendCompanyContact.Text.Trim(),
            txtFileSendCompanyPhone.Text.Trim(),txtFileSendCompanyType.Text.Trim(),Convert.ToInt16(DropDownListStoreFile.SelectedValue),txtStoreFileStartTime.Text.Trim(),
            strStudentID))
        {
            lbErrorMessage.Visible = true;
            lbErrorMessage.Text = "更新失败！";
            return;
        }
        lbErrorMessage.Visible = true;
        lbErrorMessage.Text = "更新成功！";
    }
    private void GridViewArchivesNewBind()
    {
        strStudentID = lbStudentID.Text.Trim();
        DataSet ArchivesNewRs = StudentFileEx.SelectStudentArchivesNew(strStudentID);
        this.GridViewArchivesNew.DataSource = ArchivesNewRs;
        this.GridViewArchivesNew.DataBind();
    }
    protected void bt_AddArchivesNew_Click(object sender, EventArgs e)
    {
        strStudentID = lbStudentID.Text.Trim();
        if (txtAddTime.Text.Trim() == String.Empty)
        {
            lbErrorMessage.Visible = true;
            lbErrorMessage.Text = "添加时间不可为空！";
            return;
        }
        if (!StudentFileEx.InsertArchivesNew(txtAddTime.Text.Trim(),txtArchivesNewContent.Text.Trim(),txtAddPeople.Text.Trim(),txtArchivesNewRemark.Text.Trim(),strStudentID))
        {
            lbErrorMessage.Visible = true;
            lbErrorMessage.Text = "添加失败！";
            return;
        }
        lbErrorMessage.Visible = true;
        lbErrorMessage.Text = "添加成功！";
        GridViewArchivesNewBind();
    }
    protected void ArchivesNewOnRowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        strStudentID = lbStudentID.Text.Trim();
        int index = e.RowIndex;
        String SelectedID = this.GridViewArchivesNew.DataKeys[index].Value.ToString().Trim();
        if (!StudentFileEx.DeleteArchivesNew(Convert.ToInt64(SelectedID),strStudentID))
        {
            lbErrorMessage.Visible = true;
            lbErrorMessage.Text = "删除失败！";
            return;
        }
        lbErrorMessage.Visible = true;
        lbErrorMessage.Text = "删除成功！";
        GridViewArchivesNewBind();
    }
    protected void bt_Back_Click(object sender, EventArgs e)
    {
        GoBack();
    }
}
