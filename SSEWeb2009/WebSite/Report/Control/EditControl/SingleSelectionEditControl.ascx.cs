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

public partial class Report_Control_EditControl_SingleSelectionEditControl : System.Web.UI.UserControl,IItemControl
{
    ItemDescriptor item;

    protected void Page_Load(object sender, EventArgs e)
    {
        TB_Name.Text = item.Name;

        foreach (string str in item.Infos)
        {
            if (DropDownList_Selection.Items.FindByValue(str) == null)
            {
                DropDownList_Selection.Items.Add(str);
            }
        }
    }

    #region IItemControl 成员

    public void SetDescriptor(AbstractDescriptor Desc)
    {
        item = Desc as ItemDescriptor;
        GeneralEditor1.SetDescriptor(Desc);
        PropertyEditor1.SetDescriptor(Desc);
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

    protected void BN_AddSelection_Click(object sender, EventArgs e)
    {
        item.Infos.Add(TB_Selection.Text);
        Refresh();
    }
    protected void BN_DeleteSelection_Click(object sender, EventArgs e)
    {
        item.Infos.Remove(DropDownList_Selection.Text);
        DropDownList_Selection.Items.Remove(DropDownList_Selection.Items.FindByValue(DropDownList_Selection.Text));
        Refresh();
    }


    protected void TB_Name_TextChanged(object sender, EventArgs e)
    {
        item.Name = TB_Name.Text;
        Refresh();
    }
}
