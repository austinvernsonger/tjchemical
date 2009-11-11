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

public partial class Report_Control_EditControl_TextEditControl : System.Web.UI.UserControl,IItemControl
{
    ItemDescriptor item;

    protected void Page_Load(object sender, EventArgs e)
    {
        TB_ItemName.Text = item.Name;
    }

    #region IItemControl 成员

    public void SetDescriptor(AbstractDescriptor Desc)
    {
        item = Desc as ItemDescriptor;
        this.GeneralEditor1.SetDescriptor(item);
        this.PropertyEditor1.SetDescriptor(item);
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
        Refresh();
    }

    #endregion
    private void Refresh()
    {
        Timer_Refresh.Enabled = true;
    }
    protected void TB_ItemName_TextChanged(object sender, EventArgs e)
    {
        item.Name = TB_ItemName.Text;
        Refresh();
    }
}
