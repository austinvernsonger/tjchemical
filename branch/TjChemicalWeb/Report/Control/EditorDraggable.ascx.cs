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

using System.Collections.Generic;  //


using Report.Descriptor;
using Report.Serializer;
using Report.Controls;
using Report.Validator;



public partial class Report_Control_EditorDragable : System.Web.UI.UserControl, IReportControl
{
    /// <summary>
    /// name of the report in the session
    /// </summary>
    const string ReportDescriptorSessionName = "Editor_ReportDescriptorSessionName";
    ReportDescriptor report;
    private int Num_Choice = 0;
    private bool m_flags = false;


    private int id_SingleSelect_InEdit = -1;

   // private int temp_recorder = -1;  //记录当前在编辑的单选index  初始状态为-1
  
    /*static*/
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //The first time this page is loaded 
            //clear the old session if has any
            report = null;
            SaveSession();
            ///////////////////////////////////
            Session["save_hidden_id"] = "";
            
        }
        else
        {
            //when post back
            //load the report on edit from session
            LoadSession();

            Hidden_EventCtrl_InEditor.Value = getPostBackControlName();

            AddItemInReport(Hidden_ReportFullName_InEditor.Value, Hidden_ItemCtrlType_InEditor.Value, Hidden_ItemIndex_InEditor.Value);
        
            Hidden_ReportFullName_InEditor.Value = "";
            Hidden_ItemCtrlType_InEditor.Value = "";
            Hidden_ItemIndex_InEditor.Value = "";
            CreateControl();
            this.PlaceHolder_Report.Controls.Clear();
        }
        GenerateWarnningMessage();
        CreateControl();

        //...
        this.ImageButton_Text.Attributes.Add("onmouseover", "Javascript:ChangeImg(this,'/TjChemicalWeb/Report/Resource/Image/yellow_text.png');");
        this.ImageButton_Text.Attributes.Add("onmouseout", "Javascript:ChangeImg(this,'/TjChemicalWeb/Report/Resource/Image/blue_text.png');");
        this.ImageButton_Report.Attributes.Add("onmouseover", "Javascript:ChangeImg(this,'/TjChemicalWeb/Report/Resource/Image/yellow_report.png');");
        this.ImageButton_Report.Attributes.Add("onmouseout", "Javascript:ChangeImg(this,'/TjChemicalWeb/Report/Resource/Image/blue_report.png');");
        this.ImageButton_SingleSelect.Attributes.Add("onmouseover", "Javascript:ChangeImg(this,'/TjChemicalWeb/Report/Resource/Image/yellow_singleselect.png');");
        this.ImageButton_SingleSelect.Attributes.Add("onmouseout", "Javascript:ChangeImg(this,'/TjChemicalWeb/Report/Resource/Image/blue_singleselect.png');");
        this.ImageButton_RichText.Attributes.Add("onmouseover", "Javascript:ChangeImg(this,'/TjChemicalWeb/Report/Resource/Image/yellow_richtext.png');");
        this.ImageButton_RichText.Attributes.Add("onmouseout", "Javascript:ChangeImg(this,'/TjChemicalWeb/Report/Resource/Image/blue_richtext.png');");
        this.ImageButton_Admin.Attributes.Add("onmouseover", "Javascript:ChangeImg(this,'/TjChemicalWeb/Report/Resource/Image/yellow_Admin.png');");
        this.ImageButton_Admin.Attributes.Add("onmouseout", "Javascript:ChangeImg(this,'/TjChemicalWeb/Report/Resource/Image/blue_Admin.png');");
        this.ImageButton_StudentID.Attributes.Add("onmouseover", "Javascript:ChangeImg(this,'/TjChemicalWeb/Report/Resource/Image/yellow_studentid.png');");
        this.ImageButton_StudentID.Attributes.Add("onmouseout", "Javascript:ChangeImg(this,'/TjChemicalWeb/Report/Resource/Image/blue_studentid.png');");
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

    private void SaveSession()
    {
        Session[ReportDescriptorSessionName] = report;
     
        Session["num_choice"] = Num_Choice;
     
        Session["flags"] = m_flags;

      //  Session["temp_recorder"] = temp_recorder;
        Session["singleselect_inedit"] = id_SingleSelect_InEdit;
    }

    private void LoadSession()
    {
        report = Session[ReportDescriptorSessionName] as ReportDescriptor;
        //PlaceHolder_SaveTextbox = Session["test"] as PlaceHolder;
        Num_Choice = (int)Session["num_choice"];
        m_flags = (bool)Session["flags"];

      //  temp_recorder = (int)Session["temp_recorder"];
        id_SingleSelect_InEdit = (int)Session["singleselect_inedit"];
    }

    private void Refresh()
    {
        Timer_Refresh.Enabled = true;
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
        ResultSerializer x = new ResultSerializer(path, "");
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

    private void LoadFile()
    {
        //load the report file file
        ReportSerializer serializer = new ReportSerializer(Hidden_DescriptorFilePath.Text);
        report = serializer.Deserialize();
        // if the deserialization fails
        if (null == report)
        {
            Label_ErrorReadFile.Text = "读取文件失败"; 
            SetErrorMessage("读取文件失败");
            return;
        }
        //set to Edit mode
        report.SetDisplayMode(DisplayMode.Edit);
        //if it success save it to the session
        SaveSession();
        return;
    }

    protected void BN_LoadFile_Click(object sender, EventArgs e)
    {
        this.PlaceHolder_Report.Controls.Clear();
        LoadFile();
        Refresh();
    }

    protected void BN_NewReport_Click(object sender, EventArgs e)
    {
        this.PlaceHolder_Report.Controls.Clear();
        //create new report descriptor
        report = new ReportDescriptor();
        //set to edit mode
        report.SetDisplayMode(DisplayMode.Edit);
        //save it to the session
        SaveSession();

        //refresh the control
        Refresh();
    }

    protected void BN_CancelEdit_Click(object sender, EventArgs e)
    {
        //the user want to cancel the edit and the previous edit should have no effect on the file
        //clean the session
        report = null;
        SaveSession();
        //close the edit panel
       // Panel_Edit.Visible = false;
        Panel_Edit.Style.Add("display", "none");
        Panel_StartEdit.Visible = true;
    }

    protected void Button_Save_Click(object sender, EventArgs e)
    {
        SaveDescriptor();
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
       // Panel_Edit.Visible = true;
        Panel_Edit.Style.Add("display", string.Empty);
        Panel_CtrlGroup.Style.Add("display", string.Empty);
        Refresh();
    }
    protected void BN_CheckResult_Click(object sender, EventArgs e)
    {
        Session["Result_ReportResultSessionName_ResultPage"] = Hidden_ResultFilePath.Text;
        Session["Result_ReportDescriptorSessionName_ResultPage"] = Hidden_DescriptorFilePath.Text;
        String prefix = Request.ApplicationPath;
        if (!prefix.EndsWith("/")) prefix += "/";
        Response.Redirect(prefix + "Report/ResultTest.aspx");
    }

    private ItemType StringToType(string str)
    {
        switch (str)
        {
            case "TEXT": return ItemType.TEXT;
            case "REPORT": return ItemType.REPORT;
            case "SINGLESELECT": return ItemType.SINGLESELECT;
            case "RICHTEXT": return ItemType.RICHTEXT;
            case "STUDENTID": return ItemType.STUDENTID;
            case "ADMIN": return ItemType.ADMINCHECK;
            default: return ItemType.UNSPECIFIED;
        }
    }

    private void AddItemInReport(string strFullName, string strItemType, string strIndex)
    {
        if (strItemType == "" || strFullName == "" || strIndex == "")
        {
            return;
        }

        int iIndex;
        try
        {
            iIndex = int.Parse(strIndex);
        }
        catch (System.Exception e)
        {
            return;
        }

        ReportDescriptor ReportAdd = report.FindDescriptorByFullName(strFullName) as ReportDescriptor;
        if (ReportAdd == null)
        {
            return;
        }

        AbstractDescriptor item;
        if (StringToType(strItemType) == ItemType.REPORT)//the user new a sub report
        {
            item = new ReportDescriptor();
        }
        else//the user new an item
        {
            item = new ItemDescriptor();
            item.Type = StringToType(strItemType);//set item Type
        }
        //set parent
        item.Parent = ReportAdd;

        //////////////////////////////////////////////////////////////////////////
        if (item.Type == ItemType.STUDENTID)
        {
            item.Name = "学号";
            item.ResultDescriptor.IsKey = true;
        }
        if (item.Type == ItemType.ADMINCHECK)
        {
            item.Name = "审核";
        }
        //////////////////////////////////////////////////////////////////////////

        //add to report
        //ReportAdd.Items.Add(item);
        try
        {
            ReportAdd.Items.Insert(iIndex, item);
        }
        catch (System.Exception e)
        {
            return;
        }

        SaveSession();
    }
   
    private void ModifyItemInReport(string ParentFullName, string ItemTypeModify, string ItemIndexModify)
    { 
        if (ItemTypeModify == "" || ItemIndexModify == "")
        {
            return;
        }

        int iIndex;
        try
        {
            iIndex = int.Parse(ItemIndexModify);
        }
        catch (System.Exception e)
        {
            return;
        }


/*

        if (test_same_singleselect(iIndex) == false && ItemTypeModify == "SINGLESELECT")
        {
            return;
        }
*/




        ReportDescriptor ReportModify;
        if (ParentFullName == "")
        {
            //最外层元素
            ReportModify = report;
            //判断类型
            switch (ItemTypeModify)
            {
                case "REPORT":
                    string strReportNameModified = TextBox_ReportName_InEditor.Text;
                    ReportModify.Name = strReportNameModified;
                    break;
                default:
                    return;
            }
            //ReportModify.ControlAdapter.RefreshControl();
        } 
        else
        {
            ReportModify = report.FindDescriptorByFullName(ParentFullName) as ReportDescriptor;
            if (ReportModify == null)
            {
                return;
            }

            //判断类型
            switch (ItemTypeModify)
            {
                case "REPORT":
                    string strReportNameModified = TextBox_ReportName_InEditor.Text;
                    ReportModify.Items[iIndex].Name = strReportNameModified;
                    break;

                case "RICHTEXT":
                    string strRichTextNameModified = TextBox_RichTextName_InEditor.Text;
                    ReportModify.Items[iIndex].Name = strRichTextNameModified;

                    ReportModify.Items[iIndex].ResultDescriptor.IsKey = this.CB_IsKey.Checked;
                    ReportModify.Items[iIndex].ResultDescriptor.MustNotEmpty = this.CB_MustNotEmpty.Checked;
                    ReportModify.Items[iIndex].ResultDescriptor.MaxSize = int.Parse(this.TB_MaxSize.Text);
                    ReportModify.Items[iIndex].ResultDescriptor.ResultEditMode = StringToResultEditMode(DropDownList_ResultEditMode.Text);
                    ReportModify.Items[iIndex].ResultDescriptor.ResultViewMode = StringToResultViewMode(DropDownList_ResultViewMode.Text);
                    break;

                case "TEXT":
                    string strTextNameModified = TextBox_TextName_InEditor.Text;
                    ReportModify.Items[iIndex].Name = strTextNameModified;

                    ReportModify.Items[iIndex].ResultDescriptor.IsKey = this.CB_IsKey.Checked;
                    ReportModify.Items[iIndex].ResultDescriptor.MustNotEmpty = this.CB_MustNotEmpty.Checked;
                    ReportModify.Items[iIndex].ResultDescriptor.MaxSize = int.Parse(this.TB_MaxSize.Text);
                    ReportModify.Items[iIndex].ResultDescriptor.ResultEditMode = StringToResultEditMode(DropDownList_ResultEditMode.Text);
                    ReportModify.Items[iIndex].ResultDescriptor.ResultViewMode = StringToResultViewMode(DropDownList_ResultViewMode.Text);
                    break;
                case "SINGLESELECT":
                    string strSingleSelectNameModified = TextBox_SingleSelectName_InEditor.Text;
                    ReportModify.Items[iIndex].Name = strSingleSelectNameModified;

                  //  ((ReportModify.Items[iIndex]) as ItemDescriptor).Infos.Add("");
                    ReportModify.Items[iIndex].ResultDescriptor.IsKey = this.CB_IsKey.Checked;
                    ReportModify.Items[iIndex].ResultDescriptor.MustNotEmpty = this.CB_MustNotEmpty.Checked;
                    ReportModify.Items[iIndex].ResultDescriptor.MaxSize = int.Parse(this.TB_MaxSize.Text);
                    ReportModify.Items[iIndex].ResultDescriptor.ResultEditMode = StringToResultEditMode(DropDownList_ResultEditMode.Text);
                    ReportModify.Items[iIndex].ResultDescriptor.ResultViewMode = StringToResultViewMode(DropDownList_ResultViewMode.Text);
                    break;
                default:
                    return;
            }
            //ReportModify.Items[iIndex].ControlAdapter.RefreshControl();
        }
    }

    protected void TextBox_ReportName_InEditor_TextChanged(object sender, EventArgs e)
    {
        this.PlaceHolder_Report.Controls.Clear();
        ModifyItemInReport(Hidden_ParentFullName_InEditor.Value, Hidden_ItemCtrlTypeModify_InEditor.Value, Hidden_ItemIndexModify_InEditor.Value);
        Hidden_ParentFullName_InEditor.Value = "";
        Hidden_ItemCtrlTypeModify_InEditor.Value = "";
        Hidden_ItemIndexModify_InEditor.Value = "";
        Refresh();
    }


    protected void TextBox_RichTextName_InEditor_TextChanged(object sender,EventArgs e)
    {
        //this.PlaceHolder_Report.Controls.Clear();
        ModifyItemInReport(Hidden_ParentFullName_InEditor.Value, Hidden_ItemCtrlTypeModify_InEditor.Value, Hidden_ItemIndexModify_InEditor.Value);
        Hidden_ParentFullName_InEditor.Value = "";
        Hidden_ItemCtrlTypeModify_InEditor.Value = "";
        Hidden_ItemIndexModify_InEditor.Value = "";
        Refresh();
    }

    protected void TextBox_TextName_InEditor_TextChanged(object sender, EventArgs e)
    {
        //this.PlaceHolder_Report.Controls.Clear();
        ModifyItemInReport(Hidden_ParentFullName_InEditor.Value, Hidden_ItemCtrlTypeModify_InEditor.Value, Hidden_ItemIndexModify_InEditor.Value);
        Hidden_ParentFullName_InEditor.Value = "";
        Hidden_ItemCtrlTypeModify_InEditor.Value = "";
        Hidden_ItemIndexModify_InEditor.Value = "";
        Refresh();
    }
    /// <summary>
    /// 单选相关处理
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void TextBox_SingleSelectName_InEditor_TextChanged(object sender,EventArgs e)
    {
        ModifyItemInReport(Hidden_ParentFullName_InEditor.Value, Hidden_ItemCtrlTypeModify_InEditor.Value, Hidden_ItemIndexModify_InEditor.Value);
        
        Hidden_ParentFullName_InEditor.Value = "";
        Hidden_ItemCtrlTypeModify_InEditor.Value = "";
        Hidden_ItemIndexModify_InEditor.Value = "";
        Refresh();
    }
    protected void TextBox_Choice_TextChanged(object sender, EventArgs e)
    {
        TextBox tempReceiver = (TextBox)sender;
        string content = tempReceiver.Text;
        string getid = tempReceiver.ID.Substring(14);
        int id = int.Parse(getid);
        ModifyItemInSingleSelect(Hidden_ParentFullName_InEditor.Value, Hidden_ItemCtrlTypeModify_InEditor.Value, Hidden_ItemIndexModify_InEditor.Value,content,id);
        Hidden_ParentFullName_InEditor.Value = "";
        Hidden_ItemCtrlTypeModify_InEditor.Value = "";
        Hidden_ItemIndexModify_InEditor.Value = "";
        Refresh();
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
       
        string ItemIndexModify = Hidden_ItemIndexModify_InEditor.Value;
        if (ItemIndexModify=="")
        {
           // ItemIndexModify = Session["fit_one_bug_index"] as string;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert ", "alert( '您的选择失效，请重新选择 ') ", true);
            return;
        }
        int iIndex;
        try
        {
            iIndex = int.Parse(ItemIndexModify);
        }
        catch (System.Exception ex)
        {
            return;
        }

        if (test_same_singleselect(iIndex) == false)
        {
            return;
        }

        Num_Choice++;
        Session["num_choice"] = Num_Choice;
        Refresh();
    }
    protected void btnDelect_Click(object sender, EventArgs e)
    {
       
        Button tempReceiver = (Button)sender;
        string getid = tempReceiver.ID.Substring(16);
        int id = int.Parse(getid);
        string ItemTypeModify=Hidden_ItemCtrlTypeModify_InEditor.Value;
        string ParentFullName=Hidden_ParentFullName_InEditor.Value;
        string ItemIndexModify = Hidden_ItemIndexModify_InEditor.Value;

        if (ItemTypeModify == "" || ItemIndexModify == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert ", "alert( '您的选择失效，请重新选择 ') ", true);
            return;
        }

        int iIndex;
        try
        {
            iIndex = int.Parse(ItemIndexModify);
        }
        catch (System.Exception ex)
        {
            return;
        }

        if (test_same_singleselect(iIndex) == false )
        {
            return;
        }


        Num_Choice--;
        Session["num_choice"] = Num_Choice;
        ReportDescriptor ReportModify;
        ReportModify = report.FindDescriptorByFullName(ParentFullName) as ReportDescriptor;
        if (ReportModify == null)
        {
            return;
        }
        if (((ReportModify.Items[iIndex]) as ItemDescriptor).Infos.Count < id)
        {
            Refresh();
            return;
        }
        else
        {
            ((ReportModify.Items[iIndex]) as ItemDescriptor).Infos.RemoveAt((id - 1));
            Session["temp_list"] = ((ReportModify.Items[iIndex]) as ItemDescriptor).Infos;

            PlaceHolder_SaveTextbox.Controls.Clear();
        }
        Refresh();
        
    }
  
    protected void CB_IsKey_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox chk = sender as CheckBox;
        if (chk.Checked) 
        {
            //选中
            CB_MustNotEmpty.Checked = true;
            DropDownList_ResultViewMode.Text = "显示";
        }

        ModifyItemInReport(Hidden_ParentFullName_InEditor.Value, Hidden_ItemCtrlTypeModify_InEditor.Value, Hidden_ItemIndexModify_InEditor.Value);
        Hidden_ParentFullName_InEditor.Value = "";
        Hidden_ItemCtrlTypeModify_InEditor.Value = "";
        Hidden_ItemIndexModify_InEditor.Value = "";
        Refresh();
    }
    protected void CB_MustNotEmpty_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox chk = sender as CheckBox;
        if ((CB_IsKey.Checked == true) && (chk.Checked == false)) 
        {
            chk.Checked = true;
        }

        ModifyItemInReport(Hidden_ParentFullName_InEditor.Value, Hidden_ItemCtrlTypeModify_InEditor.Value, Hidden_ItemIndexModify_InEditor.Value);
        Hidden_ParentFullName_InEditor.Value = "";
        Hidden_ItemCtrlTypeModify_InEditor.Value = "";
        Hidden_ItemIndexModify_InEditor.Value = "";
        Refresh();
    }
    protected void TB_MaxSize_TextChanged(object sender, EventArgs e)
    {
        ModifyItemInReport(Hidden_ParentFullName_InEditor.Value, Hidden_ItemCtrlTypeModify_InEditor.Value, Hidden_ItemIndexModify_InEditor.Value);
        Hidden_ParentFullName_InEditor.Value = "";
        Hidden_ItemCtrlTypeModify_InEditor.Value = "";
        Hidden_ItemIndexModify_InEditor.Value = "";
        Refresh();
    }
    protected void DropDownList_ResultEditMode_TextChanged(object sender, EventArgs e)
    {
        ModifyItemInReport(Hidden_ParentFullName_InEditor.Value, Hidden_ItemCtrlTypeModify_InEditor.Value, Hidden_ItemIndexModify_InEditor.Value);
        Hidden_ParentFullName_InEditor.Value = "";
        Hidden_ItemCtrlTypeModify_InEditor.Value = "";
        Hidden_ItemIndexModify_InEditor.Value = "";
        Refresh();
    }
    protected void DropDownList_ResultViewMode_TextChanged(object sender, EventArgs e)
    {
        DropDownList ddl = sender as DropDownList;
        if (CB_IsKey.Checked == true) 
        {
            ddl.Text = "显示";
        }

        ModifyItemInReport(Hidden_ParentFullName_InEditor.Value, Hidden_ItemCtrlTypeModify_InEditor.Value, Hidden_ItemIndexModify_InEditor.Value);
        Hidden_ParentFullName_InEditor.Value = "";
        Hidden_ItemCtrlTypeModify_InEditor.Value = "";
        Hidden_ItemIndexModify_InEditor.Value = "";
        Refresh();
    }

    protected ResultEditMode StringToResultEditMode(string str)
    {
        switch (str)
        {
            case "前后台": return ResultEditMode.Both;
            case "前台": return ResultEditMode.OnlyFront;
            case "后台": return ResultEditMode.OnlyBack;
            default: return ResultEditMode.Both;
        }
    }

    protected ResultViewMode StringToResultViewMode(string str)
    {
        switch (str)
        {
            case "显示": return ResultViewMode.View;
            case "隐藏": return ResultViewMode.Hide;
            default: return ResultViewMode.View;
        }
    }

    private string getPostBackControlName()
    {

        Control control = null;

        //first we will check the "__EVENTTARGET" because if post back made by       the controls 

        //which used "_doPostBack" function also available in Request.Form collection. 

        string ctrlname = Page.Request.Params["__EVENTTARGET"];

        if (ctrlname != null && ctrlname != String.Empty)
        {

            //control = Page.FindControl(ctrlname);
            return ctrlname;

        }

        // if __EVENTTARGET is null, the control is a button type and we need to 

        // iterate over the form collection to find it

        else
        {

            string ctrlStr = String.Empty;

            //Control c = null;

            foreach (string ctl in Page.Request.Form)
            {

                //handle ImageButton they having an additional "quasi-property" in their Id which identifies 

                //mouse x and y coordinates

                if (ctl.EndsWith(".x") || ctl.EndsWith(".y"))
                {

                    ctrlStr = ctl.Substring(0, ctl.Length - 2);
                    return ctrlStr;

                    //c = Page.FindControl(ctrlStr);

                }

//                 else
//                 {
// 
//                     c = Page.FindControl(ctl);
// 
//                 }
// 
//                 if (c is System.Web.UI.WebControls.Button ||
// 
//                          c is System.Web.UI.WebControls.ImageButton)
//                 {
// 
//                     control = c;
// 
//                     break;
// 
//                 }

            }

            return "";
        }

        //return control.ID;
    }

    private void ModifyItemInSingleSelect(string ParentFullName, string ItemTypeModify, string ItemIndexModify, string content,int id)
    {
        if (ItemTypeModify == "" || ItemIndexModify == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert ", "alert( '您的选择失效，请重新选择 ') ", true);
            return;
        }

        int iIndex;
        try
        {
            iIndex = int.Parse(ItemIndexModify);
        }
        catch (System.Exception e)
        {
            return;
        }

        if (test_same_singleselect(iIndex) == false )
        {
            return;
        }


        ReportDescriptor ReportModify;
        ReportModify = report.FindDescriptorByFullName(ParentFullName) as ReportDescriptor;
        if (ReportModify == null)
        {
            return;
        }
        if (((ReportModify.Items[iIndex]) as ItemDescriptor).Infos.Count>=id)
        {
            ((ReportModify.Items[iIndex]) as ItemDescriptor).Infos[id - 1] = content;
        }
        else
        {
            bool flag = false;
            foreach (string str in ((ReportModify.Items[iIndex]) as ItemDescriptor).Infos)
            {
                if (str == content)
                {
                    flag = true;
                    break;
                }

            }
            if (flag == false)
            {
                ((ReportModify.Items[iIndex]) as ItemDescriptor).Infos.Add(content);
            }
        }
    }

    protected void PanelControl_OnLoad(object sender, EventArgs e)
    {
        if (m_flags==true)
        {
            List<string> templist = Session["temp_list"] as List<string>;

            //Panel_ItemAttrSingleSelect.Controls.Clear();
            //PlaceHolder_SaveTextbox.Controls.Clear();
 
            for (int i=0;i<Num_Choice;i++)
            {
                TextBox newTextBox = new TextBox();
                newTextBox.Text = "New Choice";
                string tempID = "TextBox_Choice" + (i+1);
                newTextBox.ID = tempID;
                if (i < templist.Count)
                 {
                     newTextBox.Text = templist[i];
                 }

               // newTextBox.Text = "test!!!!!!!!!!!!!!!!!!!!!!1";


                newTextBox.AutoPostBack = true;
                newTextBox.TextChanged += TextBox_Choice_TextChanged;
                PlaceHolder_SaveTextbox.Controls.Add(newTextBox);
            

                Literal Literal1 = new Literal();
                Literal1.Text = "&nbsp;";
                PlaceHolder_SaveTextbox.Controls.Add(Literal1);
             
                Button newButten_Delect = new Button();
                string newID_Del = "Delect_NewChoice" + (i + 1);
                newButten_Delect.ID = newID_Del;
                newButten_Delect.Text = "删除";
                newButten_Delect.Click += btnDelect_Click;
                PlaceHolder_SaveTextbox.Controls.Add(newButten_Delect);
             
 
                Literal Literal3 = new Literal();
                Literal3.Text = "<br>";
                PlaceHolder_SaveTextbox.Controls.Add(Literal3);
             
                
            }
        }
        else
        {
            Session["fit_one_bug_index"] = Hidden_ItemIndexModify_InEditor.Value;
            Session["fit_one_bug_FullName"] = Hidden_ParentFullName_InEditor.Value;
        }
       
    }

    protected void btnLoadSelect_Click(object sender, EventArgs e)
    {
        Button_LoadSelect.Enabled = false;
        m_flags = true;
        Session["flags"] = m_flags;
        Button_add.Enabled = true;
        string ItemTypeModify = Hidden_ItemCtrlTypeModify_InEditor.Value;
        string ParentFullName = Hidden_ParentFullName_InEditor.Value;
        string ItemIndexModify = Hidden_ItemIndexModify_InEditor.Value;

        if (ItemIndexModify == "")  //fix a bug
        {
           // return;
            ParentFullName = Session["fit_one_bug_FullName"] as string;
            ItemIndexModify = Session["fit_one_bug_index"] as string;
        }

        int iIndex;
        try
        {
            iIndex = int.Parse(ItemIndexModify);
        }
        catch (System.Exception ex)
        {
            return;
        }

      //  temp_recorder = iIndex;  //记录当前正在编辑的单选
      //  Session["temp_recorder"] = temp_recorder;
        id_SingleSelect_InEdit = iIndex;
        Session["singleselect_inedit"] = iIndex;

        //
        if (Hidden_SaveIndex.Value=="")
        {
            Hidden_SaveIndex.Value = iIndex.ToString();
        }
        //

        ReportDescriptor ReportModify;
        ReportModify = report.FindDescriptorByFullName(ParentFullName) as ReportDescriptor;
        if (ReportModify == null)
        {
            return;
        }
        Num_Choice = ((ReportModify.Items[iIndex]) as ItemDescriptor).Infos.Count;
        Session["temp_list"] = ((ReportModify.Items[iIndex]) as ItemDescriptor).Infos;/////////////////
        Session["num_choice"] = Num_Choice;
        for (int i = 0; i < Num_Choice; i++)
        {
            TextBox newTextBox = new TextBox();
            newTextBox.Text = "New Choice";
            string tempID = "TextBox_Choice" + (i + 1);
            newTextBox.ID = tempID;

            newTextBox.Text = ((ReportModify.Items[iIndex]) as ItemDescriptor).Infos[i];

            newTextBox.AutoPostBack = true;
            newTextBox.TextChanged += TextBox_Choice_TextChanged;
            PlaceHolder_SaveTextbox.Controls.Add(newTextBox);


            Literal Literal2 = new Literal();
            Literal2.Text = "&nbsp;";
            PlaceHolder_SaveTextbox.Controls.Add(Literal2);


            Button newButten_Delect = new Button();
            string newID_Del = "Delect_NewChoice" + (i + 1);
            newButten_Delect.ID = newID_Del;
            newButten_Delect.Text = "删除";
            newButten_Delect.Click += btnDelect_Click;
            PlaceHolder_SaveTextbox.Controls.Add(newButten_Delect);


            Literal Literal3 = new Literal();
            Literal3.Text = "<br>";
            PlaceHolder_SaveTextbox.Controls.Add(Literal3);


        }
      
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Session["num_choice"] = 0;
        Session["flags"] = false;
        Num_Choice = 0;
        m_flags = false;
        Button_add.Enabled = false;
        Button_LoadSelect.Enabled = true;
       // temp_recorder = -1;
       // Session["temp_recorder"] = temp_recorder;
        id_SingleSelect_InEdit = -1;
        Session["singleselect_inedit"] = -1;

        Hidden_SaveIndex.Value = "";


        Refresh();
    }

    /*
    protected void On_ValueChanged(object sender, EventArgs e)
    {
       // Session["save_hidden_id"] = Hidden_SaveIndex.Value;
       // Refresh();
    }
    
    protected void hiddenID_Onload(object sender, EventArgs e)
    {
        Hidden_SaveIndex.Value = Session["save_hidden_id"] as string;
    }*/


    private bool test_same_singleselect(int id_now)
    {
        if (id_SingleSelect_InEdit==id_now)
        {
            return true;
        }
        else
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert ", "alert( '您之前的编辑单选控件并未保存，请单击编辑完毕保存后再编辑其他单选 ') ", true);
            return false;
        }
        
    }
}

