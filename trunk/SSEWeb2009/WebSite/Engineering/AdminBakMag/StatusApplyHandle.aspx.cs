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

public partial class Engineering_AdminBakMag_StatusApplyHandle : System.Web.UI.Page
{
    private int _applyid;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["id"] != null)
        {
            _applyid = Convert.ToInt32(Request["id"]);
            if (!IsPostBack)
            {
                BindDetailView();
            }
       }
    }

    protected void BindDetailView()
    {
        StatusChgAppMgr sca = new StatusChgAppMgr();
        DataSet ds = sca.GetUnhandleAppInfoByAppID(_applyid);
        dvappInfo.DataSource = ds.Tables[0];
        dvappInfo.DataBind();
    }

    public string GetApplyResult(int res)
    {
        if (res == 0)
        {
            return "";
        }
        if (res == 1)
        {
            return "批准";
        }
        if (res == 2)
        {
            return "不批准";
        }
        else
        {
            return "有错误";
        }
    }
    protected void dvappInfo_ModeChanging(object sender, DetailsViewModeEventArgs e)
    {
        if (e.NewMode == DetailsViewMode.Edit)
        {
            dvappInfo.ChangeMode(DetailsViewMode.Edit);
            BindDetailView();
        }
        else if (e.CancelingEdit == true)
        {
            if (dvappInfo.CurrentMode == DetailsViewMode.Edit)
            {
                dvappInfo.ChangeMode(DetailsViewMode.ReadOnly);
                BindDetailView();
            }
        }
    }
    protected void dvappInfo_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
    {
        int applyId = Convert.ToInt32(dvappInfo.DataKey.Value);
        DropDownList ddapplyResult = (DropDownList)dvappInfo.Rows[9].FindControl("ddlResult");
        int applyResult = Convert.ToInt32(ddapplyResult.SelectedValue);
        string applyRemark =((TextBox)dvappInfo.Rows[10].FindControl("tbSuggestion")).Text;

        StatusChgAppMgr sca = new StatusChgAppMgr();
        
        bool isUpdate = sca.HandleStatusChgApp(applyId, applyResult, applyRemark);
        if (isUpdate == true)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('处理成功！')</script>");
            dvappInfo.ChangeMode(DetailsViewMode.ReadOnly);
            BindDetailView();
        }
    }
}
