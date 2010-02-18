using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using SysCom;

public partial class UserControl_EditMMT : System.Web.UI.UserControl
{
    /// <summary>
    /// The MMT Core.
    /// </summary>

    #region Properties
    /// <summary>
    /// On Operation Success, go to the page.
    /// </summary>
    public String OnSuccessGoTo
    {
        set { ViewState ["OnSuccessGoTo"] = value; }
        get { return ViewState ["OnSuccessGoTo"] as string; }
    }
    public Boolean Registration
    {
        set { ViewState["Registration"] = value; }
        get { return Convert.ToBoolean(ViewState["Registration"]); }
    }
    /// <summary>
    /// The Buttons' CssClass
    /// </summary>
    public String BtnCssClass
    {
        set { ViewState ["myBtnCssClass"] = value; }
        get { return ViewState ["myBtnCssClass"] as string; }
    }

    /// <summary>
    /// Show mode, could be: Activity, Registration, Notice, News, Passage
    /// Default to be Notice
    /// </summary>
    public PSGMODE Mode
    {
        set { ViewState ["myMode"] = value; }
        get
        {
            /*return (PSGMODE)Enum.Parse(
                typeof( PSGMODE ), ViewState ["myMode"] as string );*/
            return (PSGMODE)ViewState ["myMode"];
        }
    }

    /// <summary>
    /// Check if the MMT Control is used to post a new one.
    /// </summary>
    public Boolean NewPost
    {
        set { ViewState ["myNewPost"] = value; }
        get { return Convert.ToBoolean( ViewState ["myNewPost"] ); }
    }

    /// <summary>
    /// The Id used to get the MMT when to EDIT it.
    /// </summary>
    public string MMTID
    {
        set { ViewState ["myId"] = value; }
        get { return ViewState ["myId"] as string; }
    }

    /// <summary>
    /// The Department Id.
    /// </summary>
    public int DepartmentId
    {
        set { ViewState ["departmentId"] = Convert.ToInt32( value ); }
        get { return Convert.ToInt32( ViewState ["departmentId"] ); }
    }

    /// <summary>
    /// The editor's height.
    /// </summary>
    public Int32 EditHeight
    {
        set { default_editor.Height = value; }
        get { return Convert.ToInt32( default_editor.Height ); }
    }

    /// <summary>
    /// Allow Attachment
    /// </summary>
    public Boolean AllowAttachment
    {
        set { ViewState ["myAllowAttachment"] = Convert.ToBoolean( value ); }
        get { return Convert.ToBoolean( ViewState ["myAllowAttachment"] ); }
    }

    /// <summary>
    /// Toolbar Start Expanded or not.
    /// Set Only.
    /// </summary>
    public Boolean ToolbarStartExpanded
    {
        set { default_editor.ToolbarStartExpanded = value; }
        //get { return default_editor.ToolbarStartExpanded; }
    }

    SysCom.MMTDelegate.PostEvent myBeforeDelegate = null;
    public SysCom.MMTDelegate.PostEvent BeforePost { set { myBeforeDelegate += value; } }
    SysCom.MMTDelegate.PostEvent myAfterDelegate = null;
    public SysCom.MMTDelegate.PostEvent AfterPost { set { myAfterDelegate += value; } }

    #endregion

    #region Initialize

    protected void Initialize( )
    {
        if (null == ViewState ["myMode"])
            this.Mode = PSGMODE.Notice;
        if (null == ViewState ["myNewPost"])
            this.NewPost = true;
        if (null == ViewState["Registration"])
            this.NewPost = false;
        if (null == ViewState ["departmentId"])
            this.DepartmentId = 0;
        if ( null == ViewState ["myAllowAttachment"] )
            this.AllowAttachment = true;
    }

    #endregion

    protected void Page_Load( object sender, EventArgs e )
    {
        if (!IsPostBack)
        {
            Initialize( );
            SysCom.MMT editMMT = null;
            // Clear the Session
            Session["CheckList"] = null;
            error_layer.Visible = false;    
            post_btn.CssClass = this.BtnCssClass;

            ReportFormID.Text = SysCom.IdGenerator.GenerateId();
            ReportDataID.Text = SysCom.IdGenerator.GenerateId();

            // Show Attachment page.
            // ifrm_upload.Visible = myAllowAttachment;
            //SysCom.MMT editMMT = null;
            if (!this.NewPost)
            {
                // Get the MMT
                if (this.MMTID == null) this.MMTID = Request.Params["MMTID"];
                if (this.MMTID != null)
                {
                    editMMT = new SysCom.MMT(this.MMTID);
                    if (!editMMT.IsValidated) this.NewPost = true;
                }
                else this.NewPost = true;
            }

            // Check if is to post a new MMT or not.
            if ( !this.NewPost )
            {
                // Set Button To Update
                div_post_btn.Visible = false;
                title_txt.Text = editMMT.Title;
                // Get the content
                editMMT.GetContent( );
                String tmp = editMMT.Content;
                tmp = tmp.Replace("<html><head><meta http-equiv=\"content-Type\" content=\"text/html\"; charset=\"utf-8\"><base target='_top' /></head><body>", "");
                tmp=tmp.Replace("</body></html>", "");
                default_editor.Value = tmp;


                string _mode = editMMT.Mode;
                _mode = editMMT.Mode [0].ToString( ).ToUpper( ) + editMMT.Mode.Substring( 1 );

                this.Mode = (PSGMODE)Enum.Parse( typeof(PSGMODE), _mode );
                // Set Labels
                tag_lst.SetSelectedTag( editMMT.Labels );

                // Set Attachment
                if ( editMMT.HasAttachment )
                {
                    // Set to Session
                    Session ["CheckList"] = editMMT.Attechments;
                }

                // Set Time and location
                startTime.SetDateTime( editMMT.StartTime );
                endTime.SetDateTime( editMMT.EndTime );
                location_txt.Text = editMMT.Location;

                if ( editMMT.ReportFormId != null && editMMT.ReportFormId.Trim( ) != "" )
                {
                    // Registration
                    this.ReportFormID.Text = editMMT.ReportFormId.Trim( );
                    this.ReportDataID.Text = editMMT.ReportDataSet.Trim( );
                }
            }
            else
            {
                div_update_btn.Visible = false;
                editMMT = new SysCom.MMT( Session ["IdentifyNumber"].ToString( ), this.DepartmentId );
            }
            Session ["_editMMT"] = editMMT;
            Session ["__post__mmt__id"] = editMMT.ID;
            if ( this.Mode == PSGMODE.Passage || this.Mode == PSGMODE.News )
            {
                label_pnl.Visible = false;
                Time_Location_Div.Visible = false;
                div_registration.Visible = false;
            }
            else if ( this.Mode == PSGMODE.Notice )
            {
                Time_Location_Div.Visible = false;
                div_registration.Visible = false;
            }
            else if ( this.Mode == PSGMODE.Activity )
            {
                label_pnl.Visible = false;
                div_registration.Visible = false;
            }
            if (this.Registration)
            {
                div_registration.Visible = true;
                label_pnl.Visible = false;
                location_txt.Enabled = false;
                // Add the page path here.
                // The prefix is the root path of the website.
                // Add the page path directly in the quote.
                // Use this.ReportFormID and this.ReportDataID, please.
                //ifrm_reg.Attributes["src"] = ConstValue.PureURL + "Report/Default.aspx?"
                ifrm_reg.Attributes["src"] = ConstValue.PureURL + "Report/DefaultDraggable.aspx?"
                    + "ReportFormID=" + this.ReportFormID.Text
                    + "&ReportDataID=" + this.ReportDataID.Text;
            }
        }
    }

    protected void post_btn_Click(object sender, EventArgs e)
    {
        // Check Session Statue.
        if ( Session ["IdentifyNumber"] == null )
            SysCom.Login.LoginRedirect( Request.Url.ToString( ) );
        SysCom.MMT editMMT = (SysCom.MMT)Session ["_editMMT"];
        if ( this.MMTID != null ) editMMT.ID = this.MMTID;
        // Invoke the post event
        if ( myBeforeDelegate != null ) myBeforeDelegate( editMMT.ID );

        editMMT.Title = title_txt.Text;
        editMMT.Content = default_editor.Value;
        editMMT.Mode = this.Mode.ToString( ).ToLower( );
        //Activity, Registration, Notice, News, Passage
        if ( this.Mode == PSGMODE.Activity )
        {
            editMMT.StartTime = startTime.GetDateTime( );
            editMMT.EndTime = endTime.GetDateTime( );
            editMMT.Location = location_txt.Text;
        }
        if (this.Registration)
        {
            editMMT.StartTime = startTime.GetDateTime( );
            editMMT.EndTime = endTime.GetDateTime( );
            editMMT.ReportFormId = this.ReportFormID.Text;
            editMMT.ReportDataSet = this.ReportDataID.Text;
            // Do something...
        }
        // Ask the label module to check if is Internal
        if ( this.Mode == PSGMODE.Notice )
        {
            editMMT.IsInternal = ( tag_lst.GetSelectedTagList( ) == null );
            // Ask the label module to get the labels
            if ( !editMMT.IsInternal )
            {
                List<String> labels = tag_lst.GetSelectedTagList();
                for (int i = 0; i < labels.Count; ++i)
                    editMMT.AddLabel( labels [i] );
            }
        }
        // Add Attachment
        if (Session["CheckList"] != null)
        {
            List<SysCom.Attachment> CheckList = (List<SysCom.Attachment>)Session["CheckList"];
            for (int i = 0; i < CheckList.Count; ++i)
                editMMT.AddAttechment( CheckList [i].FileName, CheckList [i].FileExtension );
        }
        // Post the MMT
        if ( editMMT.Post( ) )
        {
            if ( myAfterDelegate != null ) myAfterDelegate( editMMT.ID );
            if (!string.IsNullOrEmpty(this.OnSuccessGoTo))// Response.Write("<script language='javascript'>window.open('" + this.OnSuccessGoTo + "','_blank' );</script>"); 
            Response.Redirect(this.OnSuccessGoTo);
            lb_error.Text = "提交成功！";
        }
        else
            lb_error.Text = "提交失败：" + editMMT.GetLastError( );
        error_layer.Visible = true;
        this.NewPost = false;
        div_post_btn.Visible = false;
        div_update_btn.Visible = true;
    }

    protected void update_btn_Click(object sender, EventArgs e)
    {
        // Check Session Statue.
        if ( Session ["IdentifyNumber"] == null )
            SysCom.Login.LoginRedirect( Request.Url.ToString( ) );
        SysCom.MMT editMMT = (SysCom.MMT)Session ["_editMMT"];
        if ( myBeforeDelegate != null ) myBeforeDelegate( editMMT.ID );
        editMMT.Title = title_txt.Text;
        editMMT.Content = default_editor.Value;

        //Activity, Registration, Notice, News, Passage
        if ( this.Mode == PSGMODE.Activity )
        {
            editMMT.StartTime = startTime.GetDateTime();
            editMMT.EndTime = endTime.GetDateTime();
            editMMT.Location = location_txt.Text;
        }
        if ( this.Mode == PSGMODE.Registration )
        {
            //editMMT.StartTime = startTime.GetDateTime();
            //editMMT.EndTime = endTime.GetDateTime();
            //editMMT.ReportFormId = SysCom.IdGenerator.GenerateId();
            //editMMT.ReportDataSet = SysCom.IdGenerator.GenerateId();
            // Do something...
        }

        // Modify Labels
        if (editMMT.Mode.Equals("notice") && !editMMT.IsInternal)
        {
            List<String> _addLabels = this.differentList<String>(editMMT.Labels, tag_lst.GetSelectedTagList());
            if (_addLabels.Count > 0)
                for (int i = 0; i < _addLabels.Count; ++i) editMMT.AddLabel(_addLabels[i]);
            List<String> _delLabels = this.differentList<String>(tag_lst.GetSelectedTagList(), editMMT.Labels);
            if (_delLabels.Count > 0)
                for (int i = 0; i < _delLabels.Count; ++i) editMMT.DeleteLabel(_delLabels[i]);
        }

        // Modify Attachment
        if (Session["CheckList"] != null)
        {
            List<SysCom.Attachment> _addAttach = this.differentList<SysCom.Attachment>(
                editMMT.Attechments, (List<SysCom.Attachment>)Session["CheckList"]);
            if (_addAttach.Count > 0)
            {
                for (int i = 0; i < _addAttach.Count; ++i)
                    editMMT.AddAttechment(_addAttach[i].FileName, _addAttach[i].FileExtension);
            }
            List<SysCom.Attachment> _delAttach = this.differentList<SysCom.Attachment>(
                (List<SysCom.Attachment>)Session["CheckList"], editMMT.Attechments);
            if (_delAttach.Count > 0)
            {
                for (int i = 0; i < _delAttach.Count; ++i)
                    editMMT.DeleteAttechment(_delAttach[i].FileName, _delAttach[i].FileExtension);
            }
        }

        // Update the MMT
        if (editMMT.Update())
        {
            if (myAfterDelegate != null) myAfterDelegate(editMMT.ID);
            if (!string.IsNullOrEmpty(this.OnSuccessGoTo)) Response.Write("<script language='javascript'>alert('提交成功');window.open('" + this.OnSuccessGoTo + "','_blank' );</script>"); 
            lb_error.Text = "提交成功！";
        }
        else
            lb_error.Text = "提交失败：" + editMMT.GetLastError();
        error_layer.Visible = true;
    }

    private List<T> differentList<T>(List<T> _src, List<T> _dest)
    {
        List<T> _rtn = new List<T>();
        for (int i = 0; i < _dest.Count; ++i)
        {
            if (!_src.Contains(_dest[i]))
                _rtn.Add(_dest[i]);
        }
        return _rtn;
    }
}
