using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

/// <summary>
/// Summary description for WebSiteTime
/// </summary>
public class WebSiteTime
{
    public WebSiteTime()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    /// <summary>
    /// Is now day?
    /// </summary>
    static public Boolean IsDay
    {
        get 
        {
            if (HttpContext.Current.Session["ClientHour"] != null
                && HttpContext.Current.Session["ClientHour"].ToString() != "")
            {
                Int32 tmpHour = Convert.ToInt32(
                    HttpContext.Current.Session["ClientHour"]);
                return (tmpHour < 18 && tmpHour > 6);
            }
            return true;
        }
    }

    /// <summary>
    /// Is now night?
    /// </summary>
    static public Boolean IsNight
    {
        get { return !IsDay; }
    }

    /// <summary>
    /// Generate a Css Link String.
    /// The Css File must in /CssClass.
    /// </summary>
    /// <param name="CssFileName"></param>
    /// <returns></returns>
    static public String GenerateCssString(String CssFileName)
    {
        String prefix = "http://" + HttpContext.Current.Request.Url.Authority + 
            HttpContext.Current.Request.ApplicationPath;
        if (!prefix.EndsWith("/")) prefix += "/";
        String cssPath = prefix + "CssClass/";
        cssPath += CssFileName;
        return "<link href=\"" + cssPath +
            "\" rel=\"stylesheet\" type=\"text/css\" />";
    }

    /// <summary>
    /// Write a statement to link the css file according
    /// to the client's system time.
    /// In day, include CssFileName_Day, other wise include
    /// CssFileName_Night.
    /// </summary>
    /// <param name="CssFileName_Day">Day use Css File Name.</param>
    /// <param name="CssFileName_Night">Night use Css File Name.</param>
    static public void SetCssFile(
        String CssFileName_Day, 
        String CssFileName_Night)
    {
        if (IsDay) HttpContext.Current.Response.Write(
            GenerateCssString(CssFileName_Day));
        else HttpContext.Current.Response.Write(
            GenerateCssString(CssFileName_Night));
    }
}
