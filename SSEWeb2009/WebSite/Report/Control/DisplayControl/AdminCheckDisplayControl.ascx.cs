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

public partial class Report_Control_DisplayControl_AdminCheckDisplayControl : System.Web.UI.UserControl,IItemControl
{
    ItemDescriptor item;

    protected void Page_Load(object sender, EventArgs e)
    {
        Label_Name.Text = item.Name;
        if (item.ResultDescriptor.LastResult != "")
        {
            DropDownList_Result.Text = item.ResultDescriptor.LastResult;
        }
        
    }

    #region IItemControl 成员

    public void SetDescriptor(AbstractDescriptor Desc)
    {
        item = Desc as ItemDescriptor;
    }

    public string GetResult()
    {
        return DropDownList_Result.Text;
    }

    public void SetEditable(bool editable)
    {
        if (item.DisplayDescriptor.DisplayMode != DisplayMode.DisplayBack)
        {
            DropDownList_Result.Enabled = false;
        }
        else
        {
            DropDownList_Result.Enabled = true;
        }
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
