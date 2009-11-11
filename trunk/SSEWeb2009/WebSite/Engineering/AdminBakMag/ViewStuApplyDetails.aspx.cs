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
using Department.Engineering;

public partial class Engineering_AdminBakMag_ViewStuApplyDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["IdentifyNumber"] == null)
        //{
        //    SysCom.Login.LoginRedirect(Request.Url.ToString());
        //}
        if (Request["applyID"] != null && Request["applyID"] != "")
        {
            int applyID = Convert.ToInt32(Request["applyID"]);
            StatusChgAppMgr scm = new StatusChgAppMgr();
            DataSet ds = scm.GetUnhandleAppInfoByAppID(applyID);
            dvApplyInfo.DataSource = ds.Tables[0];
            dvApplyInfo.DataBind();
        }
    }
    public string GetBackTime(object o)
    {
        if (o != System.DBNull.Value)
        {
            return Convert.ToDateTime(o).ToString("yyyy-MM-dd");
        }
        else
        {
            return "";
        }
    }
    public string GetApplyResult(int applyResult)
    {
        if (applyResult == 0)
        { 
            //当前申请还未处理
            return "";
        }
        else if (applyResult ==1)
        {
            //当前申请被批准
            return "批准";
        }
        else
        { 
            //当前申请未被批准
            return "不批准";
        }
    }
}
