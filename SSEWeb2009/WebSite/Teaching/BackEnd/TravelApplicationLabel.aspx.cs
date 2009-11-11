using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Teaching;
using Teaching.Ops;

public partial class Teaching_BackEnd_TravelApplicationLabel : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["IdentifyNumber"] == null)
                SysCom.Login.LoginRedirect(Request.Url.ToString());
            opsTeachingQuery QueryName = new opsTeachingQuery("select Name from Teacher where TeacherID = \'" + Session["IdentifyNumber"].ToString()+"\'");
            QueryName.Do();
            if (QueryName.mResult.Tables.Count == 0 || QueryName.mResult.Tables[0].Rows.Count == 0)
                SysCom.Login.LoginRedirect(Request.Url.ToString());
            RequestPerson.Text = QueryName.mResult.Tables[0].Rows[0][0].ToString();
            String ArticleId = Request.QueryString["ID"];
            if (ArticleId == null)
                return;
            opsTeachingQuery opsQuery = new opsTeachingQuery("select PersonTogether, TravelPlace, TravelCompany, PreStartDate, PreEndDate, FundsBudget, TravelTask, Other from TravelApplication where RequestID = " + ArticleId);
            opsQuery.Do();
            PersonTogether.Text = opsQuery.mResult.Tables[0].Rows[0][0].ToString();
            TravelPlace.Text = opsQuery.mResult.Tables[0].Rows[0][1].ToString();
            TravelCompany.Text = opsQuery.mResult.Tables[0].Rows[0][2].ToString();
            PreStartDate.Text = ((DateTime)opsQuery.mResult.Tables[0].Rows[0][3]).ToString("yyyy-MM-dd");
            PreEndDate.Text = ((DateTime)opsQuery.mResult.Tables[0].Rows[0][4]).ToString("yyyy-MM-dd");
            FundsBudget.Text = ((Decimal)opsQuery.mResult.Tables[0].Rows[0][5]).ToString("C");
            TravelTask.Text = opsQuery.mResult.Tables[0].Rows[0][6].ToString();
            Other.Text = opsQuery.mResult.Tables[0].Rows[0][7].ToString();
        }
    }
}
