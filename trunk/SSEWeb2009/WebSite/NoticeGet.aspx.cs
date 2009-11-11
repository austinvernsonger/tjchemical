using System;
using System.Data;
using System.Text;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class NoticeGet : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        String label=null;
        if (Request["Label"]!=null)
        {
            label=HttpUtility.UrlDecode(Request["Label"]);
        }
        String astr = "<ul>";
        DataTable dt = SysCom.MMTStatic.GetNotice(0, null,label, false, false).Tables[0];
        for(int i=0;i<dt.Rows.Count&&i<15;i++)
        {
            DataRow dr = dt.Rows[i];
            String substring = dr["Title"].ToString();
            substring=substring.Trim();
            if (substring.ToString().Length > 30)
            {
                substring = substring.Substring(0, 30) + "...";
            }
            astr += "<li><a href=\"" + ConstValue.PureURL + "NoticeDetail.aspx?MMTID=" + dr["ID"] + "\" target=\"_blank\">" + substring + "</a><span>" + dr["LastModifyTime"] + "</span></li>";
        }
        astr+="</ul>";
        _divnotice.InnerHtml = astr;
    }
}
