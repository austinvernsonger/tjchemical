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
using Report.Validator;
using Report.Validator.EditorValidator;

public partial class Report_Control_EditControl_ReportEditControl : System.Web.UI.UserControl,IItemControl
{
    ReportDescriptor report;

    protected void Page_Load(object sender, EventArgs e)
    {
        TB_ReportName.Text = report.Name;

        CreateControl();
    }

    private void CreateControl()
    {
        if (report != null)
        {
            //clear the old controls
            PlaceHolder_SubItem.Controls.Clear();
            //add the edit controls for each item in the report
            foreach (AbstractDescriptor Ad in report.Items)
            {
                this.PlaceHolder_SubItem.Controls.Add(Ad.ControlAdapter.CreateControl(this) as Control);
            }
            //Name validation check on the sub items
            report.Validate(new EditValidator());
        }
    }

    #region IItemControl 成员

    public void SetDescriptor(AbstractDescriptor Desc)
    {
        report = Desc as ReportDescriptor;
        GeneralEditor1.SetDescriptor(Desc);
    }

    public string GetResult()
    {
        throw new NotImplementedException();
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
        CreateControl();
        Refresh();
    }
    #endregion

    private ItemType StringToType(string str)
    {
        switch (str)
        {
            case "文本项": return ItemType.TEXT;
            case "子问卷": return ItemType.REPORT;
            case "单选项": return ItemType.SINGLESELECT;
            case "富文本项" : return ItemType.RICHTEXT;
            case "学号" :return ItemType.STUDENTID;
            case "审核": return ItemType.ADMINCHECK;
            default: return ItemType.UNSPECIFIED;
        }
    }
    private void Refresh()
    {
        Timer_Refresh.Enabled = true;
    }
    protected void BN_AddItem_Click(object sender, EventArgs e)
    {
        AbstractDescriptor item;

        if (StringToType(DropDownList_ItemType.Text) == ItemType.REPORT)//the user new a sub report
        {
            item = new ReportDescriptor();
        }
        else//the user new an item
        {
            item = new ItemDescriptor();
            item.Type = StringToType(DropDownList_ItemType.Text);//set item Type
        }
        //set parent
        item.Parent = report;

        //fuck this....
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
        report.Items.Add(item);
        //refresh the controls
        Refresh();
    }

    protected void TB_ReportName_TextChanged(object sender, EventArgs e)
    {
        report.Name = TB_ReportName.Text;
        report.Validate(new EditValidator());
    }

}
