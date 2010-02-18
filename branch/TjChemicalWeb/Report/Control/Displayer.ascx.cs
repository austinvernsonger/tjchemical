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
using Report.Serializer;
using Report.Controls;
using Report.Validator;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using System.Web.Hosting;
using System.Collections.Generic;

public partial class Report_Control_Displayer : System.Web.UI.UserControl,IReportControl
{
    const string ReportDescriptorSessionName = "Displayer_ReportDescriptorSessionName";
    ReportDescriptor report;
    DisplayMode mode;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SaveSession();
        }

        LoadSession();
        if (null == report)
        {
            ReportSerializer x = new ReportSerializer(Hidden_DescriptorFilePAth.Text);
            report = x.Deserialize();
            if (null != report)
            {
                report.SetDisplayMode(mode);
            }
        }
        GetExistResult();
        CreateControl();
    }


    private void SaveSession()
    {
        Session[ReportDescriptorSessionName] = report;
    }

    private void LoadSession()
    {
        report = Session[ReportDescriptorSessionName] as ReportDescriptor;
    }

    public void SetDisplayMode(DisplayMode mode)
    {
        this.mode = mode;
    }

    public void SetDescriptor(AbstractDescriptor desc)
    {
        this.report = desc as ReportDescriptor;
        this.BN_Submit.Visible = true;
        SaveSession();
    }

    #region IReportControl 成员

    public void SetReportDescriptorFilePath(string path)
    {
        Hidden_DescriptorFilePAth.Text = path;
    }

    public void SetReportResultFilePath(string path)
    {
        Hidden_ResultFilePath.Text = path;
    }

    public void SetKeyValue(string value)
    {
        Hidden_KeyValue.Text = value;
    }

    public bool SaveResult()
    {
        if (!report.Validate(new MacroResultValidator()))
        {
            Label_Message.Text = "提交失败";
            return false;
        }
        List<KeyValuePair<string, string>> list = report.GetResult();
        ResultSerializer rs = new ResultSerializer(Hidden_ResultFilePath.Text, "");
        AbstractDescriptor absdesc = report.GetKeyDescriptor();
        if (absdesc!=null)
        {
            rs.PrimKey = absdesc.FullName;
        }
        rs.Serialize(list);
        Label_Message.Text = "提交成功";
        return true;
    }

    public bool SaveDescriptor()
    {
        throw new NotImplementedException();
    }

    #endregion

    private void CreateControl()
    {
        if (null != report)
        {
            this.PlaceHolder_Report.Controls.Add(report.ControlAdapter.CreateControl(this) as Control);
        }
        else
        {
            this.BN_Submit.Visible = false;
        }
    }

    protected void GetExistResult()
    {
        //if there is a report then do the following
        if (report == null)
        {
            return;
        }

        //see if the report has a key item
        ItemDescriptor KeyItem;
        if ((KeyItem = report.GetKeyDescriptor() as ItemDescriptor) == null)
        {
            //doesn't have key item
            //what the hell.... then why do u set a value to it....
            return;
        }

        //if the key value hasn't been set try to get it from session
        if (Hidden_KeyValue.Text == "")
        {
            //see if the key type is student id
            if (KeyItem.Type == ItemType.STUDENTID)
            {
                string Id = Session["IdentifyNumber"] as string;
                Hidden_KeyValue.Text = Id == null ?  "" : Id ;
            }
        }

        //if it has key value now
        if (Hidden_KeyValue.Text != "")
        {
            //go and find the result
            ResultSerializer x = new ResultSerializer(Hidden_ResultFilePath.Text,KeyItem.FullName);
            List<KeyValuePair<string,string>> LastResult = x.DeserializeRecord(Hidden_KeyValue.Text);
            if (null != LastResult)
            {
                //set it to the report
                report.SetLastResult(LastResult);
            }         
        }
    }


    protected void Button2_Click(object sender, EventArgs e)
    {
        if (report==null)
        {
            return;
        }
        SaveResult();
        //Timer1.Enabled = true;
    }
}
