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

/// <summary>
/// This is the control which is going to display the report(as an item)
/// so it will get the info of the report and display it
/// And create the control of its sun items
/// </summary>
public partial class Report_Control_DisplayControl_ReportDisplayControl : System.Web.UI.UserControl,IItemControl
{
    ReportDescriptor report;

    protected void Page_Load(object sender, EventArgs e)
    {
        Label_ReportName.Text = report.Name;
        CreateControl();
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
            //////////////////////////////////////////////////////////////////////////
            //here goes the validation
            //////////////////////////////////////////////////////////////////////////
        }
    }

    #region IItemControl 成员

    public void SetDescriptor(AbstractDescriptor Desc)
    {
        report = Desc as ReportDescriptor;
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
        //only create control is enough
        //because the structure of control will not change
        CreateControl();
    }
    #endregion



}
