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

public partial class Report_Control_EditControl_ReportEditDraggableControl : System.Web.UI.UserControl, IItemControl
{
    ReportDescriptor report;
 
    protected void Page_Load(object sender, EventArgs e)
    {
        Label_ReportNameInReportCtrl.Text = report.Name;
        Hidden_ReportFullName.Text = report.FullName;
        Hidden_ItemTypeForAttr.Text = "REPORT";
        if (report.Parent == null)
        {
            //最外层的控件
            Hidden_ParentFullName.Text = "";
        }
        else
        {
            Hidden_ParentFullName.Text = report.Parent.FullName;
        }
        CreateControl();
//         PlaceHolder_SubItem.Controls.Clear();
//         CreateControl();
    }

    private void CreateControl()
    {
        if (report != null)
        {
            //clear the old controls
            PlaceHolder_SubItem.Controls.Clear();
            //add display controls for each items
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

    private void Refresh()
    {
        Timer_Refresh.Enabled = true;
    }
}
