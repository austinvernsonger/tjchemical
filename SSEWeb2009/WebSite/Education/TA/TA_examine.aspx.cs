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
using Education.src;
using Education.Sql;

public partial class Education_TA_TA_examine : System.Web.UI.Page
{

    private DataSet ds = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            String SQL = "select apply_num,id,course_id from assistant_apply where examine_state=0";
            ds = EducationDbOpe.DoQuery(SQL);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                String id = ds.Tables[0].Rows[i]["id"].ToString();
                ds.Tables[0].Rows[i][id] = EducationDbOpe.GetNameByID(id);
            }
            GridViewApplys.DataSource = ds.Tables[0].DefaultView;
            GridViewApplys.DataBind();
        }
    }
    protected void OnButtonPush(object sender, DataGridCommandEventArgs e)
    {
        int num = Convert.ToInt32(e.Item.Cells[0]);
        switch (e.CommandName)
        {

            case "details":
                this.Session["num"] = num;

                // goto details view
                break;
            case "agree":
                num = Convert.ToInt32(e.Item.Cells[0]);
                sqlAgreeAssistant theagreesql = new sqlAgreeAssistant(num);
                EducationDbOpe.DoExecute(theagreesql);
                ds.Tables[0].Rows[num].Delete();
                break;
            case "reject":
                num = Convert.ToInt32(e.Item.Cells[0]);
                sqlRejectAssistant therejectsql = new sqlRejectAssistant(num);
                EducationDbOpe.DoExecute(therejectsql);
                ds.Tables[0].Rows[num].Delete();
                break;
            default: break;
        }
    }
}
