using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

/// <summary>
/// Summary description for ConstValue
/// </summary>
public class ConstValue
{
    public ConstValue()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    static private String _url = null;
    static public String PureURL
    {
        get
        {
                _url = "http://" + HttpContext.Current.Request.Url.Authority + 
                    HttpContext.Current.Request.ApplicationPath;
                if (!_url.EndsWith("/")) _url += "/";
            return _url;
        }
    }

    static public Hashtable _errorSession = new Hashtable();
}
