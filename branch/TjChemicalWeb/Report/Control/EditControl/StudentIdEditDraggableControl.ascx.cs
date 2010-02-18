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


public partial class Report_Control_EditControl_StudentIdEditDraggableControl : System.Web.UI.UserControl, IItemControl
{
    ItemDescriptor item;
    protected void Page_Load(object sender, EventArgs e)
    {
        Label_lItemName.Text = item.Name;
    }
    #region IItemControl 成员

    public void SetDescriptor(Report.Descriptor.AbstractDescriptor Desc)
    {
        item = Desc as ItemDescriptor;
        GeneralEditor1.SetDescriptor(Desc);
    }

    public string GetResult()
    {
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
        return;
    }

    #endregion
}
