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
using Report.Serializer;

public partial class Report_Control_DisplayControl_StudentIdDisplayControlControl : System.Web.UI.UserControl, IItemControl
{

    ItemDescriptor item;
    protected void Page_Load(object sender, EventArgs e)
    {
        Label_lItemName.Text = item.Name;
        TB_Result.Text = item.ResultDescriptor.LastResult == ""?GetStudentId():item.ResultDescriptor.LastResult;
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
        TB_Result.Enabled = false;
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

    protected string GetStudentId()
    {
        string Id = Session["IdentifyNumber"] as string;
        return Id == null ? "" : Id;
    }
    #endregion
}
