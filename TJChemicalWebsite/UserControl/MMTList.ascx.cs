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
using SysCom;
using System.IO;
using System.Text.RegularExpressions;

public partial class UserControl_MMTList : System.Web.UI.UserControl
{
    ////////////////////////////////////////////////////////////////
    // Attribute
    ////////////////////////////////////////////////////////////////

    private Int32 myDepartmentId = 0;
    /// <summary>
    /// Department Id, to get the MMT of the department
    /// </summary>
    public Int32 DepartmentId { set { myDepartmentId = value; lb_DepartmentId.Text = myDepartmentId.ToString( ); } }

    private String myKeyWrod = null;
    /// <summary>
    /// To get the MMT include the Key word.
    /// </summary>
    public String KeyWord { set { myKeyWrod = value; lb_KeyWord.Text = myKeyWrod; } }

    private Boolean myInternalOnly = false;
    /// <summary>
    /// If only show the internal MMT.
    /// </summary>
    public Boolean InternalOnly { set { myInternalOnly = value; lb_InternalOnly.Text = myInternalOnly.ToString( ); } }

    private PSGMODE myMode = PSGMODE.Passage;
    /// <summary>
    /// The Mode of the MMT: passage, notice, news, activity, registration
    /// </summary>
    public PSGMODE Mode 
    {
        set 
        {
            myMode = value;
            lb_Mode.Text = myMode.ToString( ); 
        }
        get
        {
            return myMode;
        }
    }

    private String myLabel = null;
    /// <summary>
    /// The label to query the notice.
    /// </summary>
    public String Label
    {
        set
        {
            myLabel = value;
            lb_Label.Text = myLabel;
            ViewState ["MyLabel"] = value;
        }
    }

    private Boolean myMgrStatue = false;
    /// <summary>
    /// If the control should show the mangement component.
    /// </summary>
    public Boolean Management { set { myMgrStatue = value; lb_MgrState.Text = myMgrStatue.ToString( ); } get { return myMgrStatue; } }

    private String myDateTime = null;
    /// <summary>
    /// The date time to query the MMT.
    /// </summary>
    public String DateTime { set { myDateTime = value; lb_Date.Text = myDateTime; } }

    private String myURL = null;
    /// <summary>
    /// The URL the Page to show.
    /// </summary>
    public String ShowURL { set { myURL = value; } get { return myURL; } }

    private Int32 myPageSize = 10;
    /// <summary>
    /// The page size of the control
    /// </summary>
    public Int32 PageSize { set { myPageSize = value; } }

    private Boolean myShowCount = true;
    /// <summary>
    /// Whether show the click Count
    /// </summary>
    public Boolean ShowClickCount { set { myShowCount = value; } get { return myShowCount; } }

    private Boolean myShowTime = true;
    /// <summary>
    /// Whether show the modify time
    /// </summary>
    public Boolean ShowTime { set { myShowTime = value; } get { return myShowTime; } }

    private Boolean myAllowPaging = true;
    /// <summary>
    /// If need to show the paging.
    /// </summary>
    public Boolean AllowPaging { set { myAllowPaging = value; } }

    private Boolean myNeedThumbnail = false;
    /// <summary>
    /// If need to show the paging.
    /// </summary>
    public Boolean NeedThumbnail { set { myNeedThumbnail = value; } get { return myNeedThumbnail; } }

    private String myEmptyString = "没有读取到任何记录。";
    /// <summary>
    /// When find no records, show the sentense.
    /// </summary>
    public String EmptyString
    {
        set { myEmptyString = value; }
        get { return myEmptyString; }
    }

    private SysCom.MMTDelegate.RowsEvent myGetRows = null;
    /// <summary>
    /// The delegate function will be invoke after 
    /// generate the grid view.
    /// the parameter of the delegate will return
    /// the rows of the current page of the grid view.
    /// </summary>
    public SysCom.MMTDelegate.RowsEvent GetRows
    {
        set { myGetRows = new SysCom.MMTDelegate.RowsEvent( value ); }
        get { return myGetRows; }
    }

    protected SysCom.MMTDelegate.PostEvent dMarkDelete = null;
    protected SysCom.MMTDelegate.PostEvent dRecover = null;
    protected SysCom.MMTDelegate.PostEvent dDelete = null;

    public SysCom.MMTDelegate.PostEvent OnMarkDelete
    {
        set { dMarkDelete = new SysCom.MMTDelegate.PostEvent( value ); }
        get { return dMarkDelete; }
    }

    public SysCom.MMTDelegate.PostEvent OnRecover
    {
        set { dRecover = new SysCom.MMTDelegate.PostEvent( value ); }
        get { return dRecover; }
    }

    public SysCom.MMTDelegate.PostEvent OnDelete
    {
        set { dDelete = new SysCom.MMTDelegate.PostEvent( value ); }
        get { return dDelete; }
    }

    /// <summary>
    /// Specifial News style for default page.
    /// </summary>
    public bool SpecifialNews
    {
        set { ViewState ["SpecifialNews"] = value; }
        get { return Convert.ToBoolean( ViewState ["SpecifialNews"] ); }
    }

    public int ReturnWords
    {
        set { ViewState ["ReturnWords"] = value; }
        get 
        {
            if ( ViewState ["ReturnWords"] == null ) return 10;
            return Convert.ToInt32( ViewState ["ReturnWords"] ); 
        }
    }

    public string Target
    {
        set { ViewState ["Target"] = value; }
        get
        {
            if ( ViewState ["Target"] == null ) return "_self";
            return ViewState ["Target"] as string;
        }
    }

    public int TitleMaxLength
    {
        set { ViewState ["TitleMaxLength"] = value; }
        get
        {
            if ( ViewState ["TitleMaxLength"] == null ) return 0;
            return Convert.ToInt32( ViewState ["TitleMaxLength"] );
        }
    }

    /////////////////////////////////////////////////////////////////
    // Style Sheet
    /////////////////////////////////////////////////////////////////
    private String myItemCssClass = null;
    /// <summary>
    /// The CssClass of the Title Item;
    /// </summary>
    public String ItemCssClass { set { myItemCssClass = value; } get { return myItemCssClass; } }

    /// <summary>
    /// Special Css Class for the first line.
    /// Enable when SpecialNews is set to TRUE
    /// </summary>
    public string FirstLineSpecialCssClass
    {
        set { ViewState ["FLSCssClass"] = value; }
        get { return ViewState ["FLSCssClass"] as string; }
    }

    /// <summary>
    /// First Line's item's css class
    /// </summary>
    public string FirstLineContentCssClass
    {
        set { ViewState ["FLCCssClass"] = value; }
        get { return ViewState ["FLCCssClass"] as string; }
    }

    /// <summary>
    /// Time div's Css Class
    /// </summary>
    public string TimeCssClass
    {
        set { ViewState ["TimeCssClass"] = value; }
        get { return ViewState ["TimeCssClass"] as string; }
    }

    /// <summary>
    /// FirstLineTimeCssClass
    /// </summary>
    public string FirstLineTimeCssClass
    {
        set { ViewState ["FirstLineTimeCssClass"] = value; }
        get { return ViewState ["FirstLineTimeCssClass"] as string; }
    }

    /////////////////////////////////////////////////////////////////
    // Method
    /////////////////////////////////////////////////////////////////
    /// <summary>
    /// Page Load
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load( object sender, EventArgs e )
    {
        if ( ViewState ["MyLabel"] != null )
            lb_Label.Text = ViewState ["MyLabel"].ToString( );
        theList.PageSize = myPageSize;
        //theList.AllowPaging = myAllowPaging;
        //theList.FooterRow.Visible = myAllowPaging;
        theList.PagerSettings.Visible = myAllowPaging;

        if ( myMode == PSGMODE.Notice )
        {
            if ( myDateTime != null )
            {
                theList.DataSourceID = objDS_Notice.ID;
            }
            else
            {
                theList.DataSourceID = objDS_Notice_noDate.ID;
            }
            //theList.DataBind();
        }
    }

    /// <summary>
    /// Limit Length;
    /// </summary>
    /// <param name="Input"></param>
    /// <returns></returns>
    protected string LimitLength( object Input )
    {
        string _Input = Input as string;
        _Input = _Input.Trim();
        if ( TitleMaxLength == 0 ) return _Input;
        if ( TitleMaxLength >= _Input.Length ) return _Input;
        _Input = _Input.Substring( 0, TitleMaxLength );
        _Input += "...";
        return _Input;
    }

    protected void ExpandLineOne( )
    {
        if ( theList.Rows.Count <= 0 ) return;
        GridViewRow _lineOne = theList.Rows [0];
        TableCell _cell = _lineOne.Cells [0];
        Label _div = new Label( );
        PlaceHolder phd = null;
        foreach ( Control ctrl in _cell.Controls )
        {
            if ( ctrl.ID == "hdf_id" )
            {
                HiddenField _hId = ctrl as HiddenField;
                // MMTID's ID
                string mmtID = _hId.Value;
                try
                {
                    StreamReader _html = new StreamReader(
                        string.Format( @"{0}\Information\{1}.html",
                            SMBL.Global.WebSite.AppPath, mmtID ) );
                    // Get the html
                    string _content = _html.ReadToEnd( );
                    // Replace all html mark
                    Regex x_html = new Regex( "<[^>]*>" );
                    _content = x_html.Replace( _content, "" );

                    if ( this.ReturnWords < _content.Length )
                        _content = _content.Substring( 0, this.ReturnWords );
                    _content += "...";

                    //HtmlGenericControl _div = new HtmlGenericControl( "div" );
                    _div.Style.Add( "width", "100%" );
                    _div.Text = _content;
                    _div.Attributes["class"] = FirstLineContentCssClass;
                }
                catch { _div.Text = "Content not find..."; }
                //_cell.Controls.Add( _div );
            }
            else if ( ctrl.ID == "main_line" )
            {
                HtmlGenericControl main_div = ctrl as HtmlGenericControl;
                main_div.Style.Clear();
                foreach ( Control _2ndCtrl in main_div.Controls )
                {
                    if (_2ndCtrl.ID == "to_expand")
                    {
                        HtmlGenericControl to_expand_div = _2ndCtrl as HtmlGenericControl;
                        to_expand_div.Style.Clear();
                        to_expand_div.Attributes["class"] = FirstLineContentCssClass;
                        foreach (Control _3rdCtrl in to_expand_div.Controls)
                        {
                            if (_3rdCtrl.ID == "phd_expand") phd = _3rdCtrl as PlaceHolder;
                        }
                    }
                    else if (_2ndCtrl.ID == "main_ctnt")
                    {
                        HtmlGenericControl title_div = _2ndCtrl as HtmlGenericControl;
                        title_div.Style.Clear();
                        title_div.Attributes["class"] = FirstLineSpecialCssClass;
                    }
                    else if (_2ndCtrl.ID == "time_div")
                    {
                        HtmlGenericControl time_div = _2ndCtrl as HtmlGenericControl;
                        time_div.Style.Clear();
                        time_div.Attributes["class"] = FirstLineTimeCssClass;
                    }
                }
            }
        }
        //_cell.Controls.Add( _div );
        if ( phd != null )
            phd.Controls.Add( _div );
    }

    protected void AfterDataBound( object sender, EventArgs e )
    {
        if ( Mode == SysCom.PSGMODE.News && SpecifialNews ) ExpandLineOne( );
    }

    protected void MarkDeleteClick( object sender, EventArgs e )
    {
        LinkButton lbtn = sender as LinkButton;
        string MMTID = lbtn.ToolTip;
        if ( lbtn.Text == "删除" )
        {
            MMTStatic.MarkDelete( MMTID );
            lbtn.Text = "恢复";
            if ( dMarkDelete != null )
                dMarkDelete( MMTID );
        }
        else
        {
            MMTStatic.Recover( MMTID );
            lbtn.Text = "删除";
            if ( dRecover != null )
                dRecover( MMTID );
        }
    }

    protected void DeleteClick( object sender, EventArgs e )
    {
        LinkButton lbtn = sender as LinkButton;
        //string MMTID = lbtn.ID;
        MMTStatic.Delete( lbtn.ToolTip );
        if ( dDelete != null )
            dDelete( lbtn.ToolTip );
        theList.DataBind( );
    }
}
