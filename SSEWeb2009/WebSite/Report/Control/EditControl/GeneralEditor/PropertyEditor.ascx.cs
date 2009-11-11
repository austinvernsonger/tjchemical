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

public partial class Report_Control_EditControl_GeneralEditor_PropertyEditor : System.Web.UI.UserControl
{
    AbstractDescriptor Desc;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Desc.DisplayDescriptor.EditMode== EditMode.Detail)
        {
            Panel1.Visible = true;
        }
        else
        {
            Panel1.Visible = false;
        }
        DescToControl();
    }
    protected void BN_Confirm_Click(object sender, EventArgs e)
    {
        ControlToDesc();
    }

    public void SetDescriptor(AbstractDescriptor Desc)
    {
        this.Desc = Desc;
    }

    protected void DescToControl()
    {
        if (Desc == null)
        {
            return;
        }
        this.CB_IsKey.Checked = Desc.ResultDescriptor.IsKey;
        this.CB_MustNotEmpty.Checked = Desc.ResultDescriptor.MustNotEmpty;
        this.TB_MaxSize.Text = Desc.ResultDescriptor.MaxSize.ToString();
        this.DropDownList_ResultEditMode.Text = ResultEditModeToString(Desc.ResultDescriptor.ResultEditMode);
        this.DropDownList_ResultViewMode.Text = ResultViewModeToString(Desc.ResultDescriptor.ResultViewMode);
    }

    protected void ControlToDesc()
    {
        if (Desc == null)
        {
            return;
        }

        Desc.ResultDescriptor.IsKey = this.CB_IsKey.Checked;
        Desc.ResultDescriptor.MustNotEmpty = this.CB_MustNotEmpty.Checked;
        Desc.ResultDescriptor.MaxSize = int.Parse(this.TB_MaxSize.Text);
        Desc.ResultDescriptor.ResultEditMode = StringToResultEditMode(DropDownList_ResultEditMode.Text);
        Desc.ResultDescriptor.ResultViewMode = StringToResultViewMode(DropDownList_ResultViewMode.Text);

        Desc.ControlAdapter.RefreshControl();
    }

    protected void Refresh()
    {
        this.Timer_Refresh.Enabled = true;
    }
    protected void Button_Open_Click(object sender, EventArgs e)
    {
        //Panel1.Visible = !Panel1.Visible;
        if (Desc.DisplayDescriptor.EditMode == EditMode.Detail)
        {
            Desc.DisplayDescriptor.EditMode = EditMode.Brief;
        }
        else
        {
            Desc.DisplayDescriptor.EditMode = EditMode.Detail;
        }
        Desc.ControlAdapter.RefreshControl();
    }

    protected ResultEditMode StringToResultEditMode(string str)
    {
        switch (str)
        {
            case "前后台": return ResultEditMode.Both;
            case "前台": return ResultEditMode.OnlyFront;
            case "后台": return ResultEditMode.OnlyBack;
            default: return ResultEditMode.Both;
        }
    }

    protected ResultViewMode StringToResultViewMode(string str)
    {
        switch (str)
        {
            case "显示": return ResultViewMode.View;
            case "隐藏": return ResultViewMode.Hide;
            default: return ResultViewMode.View;
        }
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
    protected void CB_IsKey_CheckedChanged(object sender, EventArgs e)
    {
        Desc.ResultDescriptor.IsKey = this.CB_IsKey.Checked;
    }
    protected void CB_MustNotEmpty_CheckedChanged(object sender, EventArgs e)
    {
        Desc.ResultDescriptor.MustNotEmpty = this.CB_MustNotEmpty.Checked;
    }
    protected void TB_MaxSize_TextChanged(object sender, EventArgs e)
    {
        Desc.ResultDescriptor.MaxSize = int.Parse(this.TB_MaxSize.Text);
    }
    protected void DropDownList_ResultEditMode_TextChanged(object sender, EventArgs e)
    {
        Desc.ResultDescriptor.ResultEditMode = StringToResultEditMode(DropDownList_ResultEditMode.Text);
    }

    protected void DropDownList_ResultViewMode_TextChanged(object sender, EventArgs e)
    {
        Desc.ResultDescriptor.ResultViewMode = StringToResultViewMode(DropDownList_ResultViewMode.Text);
    }
    protected void Timer_Refresh_Tick(object sender, EventArgs e)
    {

    }
}
