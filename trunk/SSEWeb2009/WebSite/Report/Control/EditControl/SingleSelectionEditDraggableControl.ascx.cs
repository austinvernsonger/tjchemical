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
using Report.Controls;

public partial class Report_Control_EditControl_SingleSelectionEditDraggableControl : System.Web.UI.UserControl, IItemControl
{
    ItemDescriptor item;

    protected void Page_Load(object sender, EventArgs e)
    {
        Label_SingleSelectionName.Text = item.Name;
        Hidden_ItemTypeForAttr.Text = "SINGLESELECT";
        Hidden_ParentFullName.Text = item.Parent.FullName;
        DescToControl();

       
        this.RadioButtonList_Selections.Items.Clear();
        foreach (string str in item.Infos)
        {
            if (this.RadioButtonList_Selections.Items.FindByValue(str) == null)
            {
               this.RadioButtonList_Selections.Items.Add(str);
            }
            
        }
    }


    #region IItemControl 成员

    public void SetDescriptor(AbstractDescriptor Desc)
    {
        item = Desc as ItemDescriptor;
        GeneralEditor1.SetDescriptor(Desc);
    }

    public string GetResult()
    {
        //this is an edit control 
        //no use for result
        return "";
    }

    public void SetEditable(bool editable)
    {
        return;
    }

    public void SetMessage(ArrayList StringList)
    {
        BulletedList_ErrorMessage.Items.Clear();
        foreach (string str in StringList)
        {
            BulletedList_ErrorMessage.Items.Add(str);
        }
    }

    public void RefreshControl()
    {
        Refresh();
    }

    protected void Refresh()
    {
        Timer_Refresh.Enabled = true;
    }

    #endregion

    protected void DescToControl()
    {
        if (item == null)
        {
            return;
        }
        this.CB_IsKey.Text = item.ResultDescriptor.IsKey.ToString();
        this.CB_MustNotEmpty.Text = item.ResultDescriptor.MustNotEmpty.ToString();
        this.TB_MaxSize.Text = item.ResultDescriptor.MaxSize.ToString();
        this.DropDownList_ResultEditMode.Text = ResultEditModeToString(item.ResultDescriptor.ResultEditMode);
        this.DropDownList_ResultViewMode.Text = ResultViewModeToString(item.ResultDescriptor.ResultViewMode);
    }

    protected string ResultEditModeToString(ResultEditMode mode)
    {
        switch (mode)
        {
            case ResultEditMode.Both: return "前后台";
            case ResultEditMode.OnlyBack: return "后台";
            case ResultEditMode.OnlyFront: return "前台";
            default: return "";
        }
    }

    protected string ResultViewModeToString(ResultViewMode mode)
    {
        switch (mode)
        {
            case ResultViewMode.Hide: return "隐藏";
            case ResultViewMode.View: return "显示";
            default: return "";
        }
    }
  
/*
      protected void TB_Name_TextChanged(object sender, EventArgs e)
        {
            item.Name = Label_SingleSelectionName.Text;
            Refresh();
        }*/
   /*
     protected void DescToControl()
        {
            if (item == null)
            {
                return;
            }
            this.CB_IsKey.Text = item.ResultDescriptor.IsKey.ToString();
            this.CB_MustNotEmpty.Text = item.ResultDescriptor.MustNotEmpty.ToString();
            this.TB_MaxSize.Text = item.ResultDescriptor.MaxSize.ToString();
            this.DropDownList_ResultEditMode.Text = ResultEditModeToString(item.ResultDescriptor.ResultEditMode);
            this.DropDownList_ResultViewMode.Text = ResultViewModeToString(item.ResultDescriptor.ResultViewMode);
        }
    
        protected string ResultEditModeToString(ResultEditMode mode)
        {
            switch (mode)
            {
                case ResultEditMode.Both: return "前后台";
                case ResultEditMode.OnlyBack: return "后台";
                case ResultEditMode.OnlyFront: return "前台";
                default: return "";
            }
        }
    
        protected string ResultViewModeToString(ResultViewMode mode)
        {
            switch (mode)
            {
                case ResultViewMode.Hide: return "隐藏";
                case ResultViewMode.View: return "显示";
                default: return "";
            }
        }*/
    
    
}
