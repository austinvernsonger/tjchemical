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

public partial class Report_Control_DisplayControl_TextDisplayControl : System.Web.UI.UserControl,IItemControl
{

    ItemDescriptor item;
    protected void Page_Load(object sender, EventArgs e)
    {     
        Labe_lItemName.Text = item.Name;
        TB_Result.Text = item.ResultDescriptor.LastResult;
        TB_Result.Attributes.Add("onFocus", "this.style.backgroundColor='#Ffcc66';");
        TB_Result.Attributes.Add("onblur", "this.style.backgroundColor='#Ffffff';");
    }

    #region IItemControl 成员

    public void SetDescriptor(AbstractDescriptor Desc)
    {
        item = Desc as ItemDescriptor;
    }

    public string GetResult()
    {
        return TB_Result.Text;
    }

    public void SetEditable(bool editable)
    {
        this.TB_Result.Enabled = editable;
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
