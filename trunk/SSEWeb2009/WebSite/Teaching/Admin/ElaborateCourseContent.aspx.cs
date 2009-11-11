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
using Teaching.Ops;

public partial class Teaching_Admin_ElaborateCourseContent : System.Web.UI.Page
{
    public String IDText;
    public String YearText;
    public String ResPersonText;
    public String ProjectNameText;
    public String AsCashText;
    public String AsTimeText;
    public String StartimeText;
    public String EndtimeText;
    public String ElaborateNetText;
    public String SrcNetText;
    public String AddText;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["ID"] != null)
        {
            String ContentID = Request.QueryString["ID"];
            if (Session[ContentID] != null)
            {
                String CourseID = Session[ContentID].ToString();
                // Session.Remove(ContentID);

                opsTeachingQuery opsSelect = new opsTeachingQuery("select * from [ElaborateCourse] where CourseID =" + CourseID);
                opsSelect.Do();
                if (opsSelect.mResult.Tables.Count == 1 && opsSelect.mResult.Tables[0].Columns["CourseID"] != null)
                {
                    IDText =  opsSelect.mResult.Tables[0].Rows[0]["CourseID"].ToString();
                    YearText = opsSelect.mResult.Tables[0].Rows[0]["AcademicYear"].ToString();
                    ResPersonText =  opsSelect.mResult.Tables[0].Rows[0]["ResponsiblePerson"].ToString();
                    ProjectNameText =  opsSelect.mResult.Tables[0].Rows[0]["ProjectName"].ToString();
                    AsCashText = opsSelect.mResult.Tables[0].Rows[0]["FinancialAssistance"].ToString();
                    AsTimeText = opsSelect.mResult.Tables[0].Rows[0]["AssistanceTime"].ToString();
                    StartimeText = opsSelect.mResult.Tables[0].Rows[0]["StartTime"].ToString();
                    EndtimeText =  opsSelect.mResult.Tables[0].Rows[0]["EndTime"].ToString();
                    ElaborateNetText =  opsSelect.mResult.Tables[0].Rows[0]["URL"].ToString();
                    SrcNetText =  opsSelect.mResult.Tables[0].Rows[0]["InformationURL"].ToString();
                    AddText = opsSelect.mResult.Tables[0].Rows[0]["Memo"].ToString();
                }

            }
        }
    }
// 
//     public String GetContent()
//     {
//         //String ContentString = "";
// 
//         
//         return ContentString;
// 
//     }
}
