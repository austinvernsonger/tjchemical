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

public partial class Report_Control_EditControl_GeneralEditor_GeneralEditor : System.Web.UI.UserControl
{
    AbstractDescriptor Desc;

    protected void Page_Load(object sender, EventArgs e)
    {
        SetVisibility();
    }
    protected void BN_Delete_Click(object sender, EventArgs e)
    {
        if (null != Desc)
        {
            Desc.Delete();
        }
    }

    public void SetDescriptor(AbstractDescriptor Desc)
    {
        this.Desc = Desc;
        SetVisibility();
    }

    protected void SetVisibility()
    {
        if (null == Desc)
        {
            this.Visible = false;
            return;
        }
        if (null == Desc.Parent)
        {
            this.Visible = false;
            return;
        }
        this.Visible = true;
        return;
    }
    
    protected void BN_MoveUP_Click(object sender, EventArgs e)
    {
        if (null != Desc)
        {
            Desc.Index = Desc.Index - 1;
        }
    }
    protected void BN_MoveDown_Click(object sender, EventArgs e)
    {
        if (null != Desc)
        {
            Desc.Index = Desc.Index + 1;
        }
    }
}
