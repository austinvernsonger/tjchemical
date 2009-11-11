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

using Report.Descriptor;
using Report.Serializer;
using Report.Controls;
using Report.Validator;

public partial class Report_Control_Editor : System.Web.UI.UserControl,IReportControl
{
    /// <summary>
    /// name of the report in the session
    /// </summary>
    const string ReportDescriptorSessionName = "Editor_ReportDescriptorSessionName";
    ReportDescriptor report;

    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            //The first time this page is loaded 
            //clear the old session if has any
            report = null;
            SaveSession();
        }
        else
        {
            //when post back
            //load the report on edit from session
            LoadSession();
        }
        GenerateWarnningMessage();
        CreateControl();
    }

    private void CreateControl()
    {
        if (null != report)//if there is a report being edit
        {
            //clear the placeholder
            this.PlaceHolder_Report.Controls.Clear();
            //load it's control to the place holder as edit mode
            this.PlaceHolder_Report.Controls.Add(report.ControlAdapter.CreateControl(this) as Control);
        }
    }
 

    protected void BN_LoadFile_Click(object sender, EventArgs e)
    {
        LoadFile();
        Refresh();
    }
    private void LoadFile()
    {
        //load the report file file
        ReportSerializer serializer = new ReportSerializer(Hidden_DescriptorFilePath.Text);
        report = serializer.Deserialize();
        // if the deserialization fails
        if (null == report)
        {
            SetErrorMessage("读取文件失败");
            return;
        }
        //set to Edit mode
        report.SetDisplayMode(DisplayMode.Edit);
        //if it success save it to the session
        SaveSession();
        return;
    }

    private void SaveSession()
    {
        Session[ReportDescriptorSessionName] = report;
    }

    private void LoadSession()
    {
        report = Session[ReportDescriptorSessionName] as ReportDescriptor;
    }

    private void Refresh()
    {
        Timer_Refresh.Enabled = true ;
    }

    private void SetErrorMessage(string str)
    {
        Label_ErrorMessage.Text = str;
    }

    #region IReportControl 成员
    public void SetKeyValue(string value)
    {
        return;
    }

    public void SetReportDescriptorFilePath(string path)
    {
        this.Hidden_DescriptorFilePath.Text = path;
    }

    public void SetReportResultFilePath(string path)
    {
        this.Hidden_ResultFilePath.Text = path;
        //Check if there is any result in the file
        //Setup a new Result Serializer and try to deserialization the result
        ResultSerializer x = new ResultSerializer(path,"");
        x.Path = path;
        //if success there is existing result
        if (x.Deserialize())
        {
            Hidden_HasOldResult.Text = "true";
        }
    }

    public bool SaveResult()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// save the report descriptor to the specified file
    /// </summary>
    /// <returns>true for success</returns>
    public bool SaveDescriptor()
    {
        //if there is nothing to save
        //so to the caller the call is success
        //this editor doesn't need to anything
        if (null == report)
        {
            SetErrorMessage("没有内容可以保存");
            return true;
        }

        //check validation
        if (!report.Validate(new EditValidator()))
        {
            SetErrorMessage("问卷中存在错误,修复后重试");
            return false;
        }

        //create a serializer
        ReportSerializer x = new ReportSerializer(Hidden_DescriptorFilePath.Text);
        //check if the serializer success
        if (!x.Serialize(report))
        {
            SetErrorMessage("存取文件过程中出现错误");
            return false;
        }
        //all fine
        SetErrorMessage("保存成功");
        return true;
    }

    #endregion

    protected void BN_NewReport_Click(object sender, EventArgs e)
    {
        //create new report descriptor
        report = new ReportDescriptor();
        //set to edit mode
        report.SetDisplayMode(DisplayMode.Edit);
        //save it to the session
        SaveSession();
        //refresh the control
        Refresh();
    }

    private void GenerateWarnningMessage()
    {
        if ("".Equals(Hidden_DescriptorFilePath.Text))
        {
            BulletedList_WarnningMessage.Items.Add("没有设定问卷描述路径。");
        }
        if ("".Equals(Hidden_ResultFilePath.Text))
        {
            BulletedList_WarnningMessage.Items.Add("没有设定问卷结果路径。");
        }
        if (!"".Equals(Hidden_HasOldResult.Text))
        {
            BulletedList_WarnningMessage.Items.Add("已有结果在结果文件中。");
            //this.BN_EditReport.Attributes.Add("onclick", "if(!window.confirm('你确定要删除已有结果？')){window.event.returnValue=false;}");
            this.ConfirmButtonExtender1.Enabled = true;
        }
    }

    protected void BN_EditReport_Click(object sender, EventArgs e)
    {
        //clear the placeholder
        this.PlaceHolder_Report.Controls.Clear();
        LoadFile();
        //if there is existing result
        if (!"".Equals(Hidden_HasOldResult.Text))
        {
            ResultSerializer x = new ResultSerializer(this.Hidden_ResultFilePath.Text, "");
            //clear the result
            x.clear();
        }
        //Panel_StartEdit.Visible = false;
        Panel_Edit.Visible = true;
        Refresh();
    }
    protected void BN_CancelEdit_Click(object sender, EventArgs e)
    {
        //the user want to cancel the edit and the previous edit should have no effect on the file
        //clean the session
        report = null;
        SaveSession();
        //close the edit panel
        Panel_Edit.Visible = false;
        Panel_StartEdit.Visible = true;
    }
    protected void BN_CheckResult_Click(object sender, EventArgs e)
    {
        Session["Result_ReportResultSessionName_ResultPage"] = Hidden_ResultFilePath.Text;
        Session["Result_ReportDescriptorSessionName_ResultPage"] = Hidden_DescriptorFilePath.Text;
        String prefix = Request.ApplicationPath;
        if (!prefix.EndsWith("/")) prefix += "/";
        Response.Redirect(prefix + "Report/ResultTest.aspx");
    }
}
