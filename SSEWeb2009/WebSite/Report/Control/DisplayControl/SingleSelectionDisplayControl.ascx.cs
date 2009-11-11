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

using Report.Controls;
using Report.Descriptor;

public partial class Report_Control_DisplayControl_SingleSelectionDesplayControl : System.Web.UI.UserControl,IItemControl
{
    ItemDescriptor item;

    protected void Page_Load(object sender, EventArgs e)
    {
        Label_Name.Text = item.Name;
        this.RadioButtonList_Selections.Items.Clear();
        foreach (string str in item.Infos)
        {
            this.RadioButtonList_Selections.Items.Add(str);
        }

        if (item.ResultDescriptor.LastResult != "")
        {
            RadioButtonList_Selections.SelectedValue = item.ResultDescriptor.LastResult;
        }
    }

    #region IItemControl 成员

    public void  SetDescriptor(Report.Descriptor.AbstractDescriptor Desc)
    {
        item = Desc as ItemDescriptor;
    }

    public string  GetResult()
    {
        return (this.RadioButtonList_Selections.SelectedItem == null) ? "" : RadioButtonList_Selections.SelectedItem.Text;
    }

    public void  SetEditable(bool editable)
    {
        RadioButtonList_Selections.Enabled = editable;
    }

    public void  SetMessage(ArrayList StringList)
    {
        BulletedList_ErrorMessage.Items.Clear();
        foreach (string str in StringList)
        {
            BulletedList_ErrorMessage.Items.Add(str);
        }
    }

    public void  RefreshControl()
    {
        return;
    }

    #endregion
}
