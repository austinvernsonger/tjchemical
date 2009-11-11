using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AlumnusRecord;

public partial class manageGrade : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
 
    protected void gradeGrid_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            string fileName = ((FileUpload)((GridView)sender).Rows[e.RowIndex].FindControl("FileUploadImage")).FileName;
            if (fileName == null || fileName.Trim() == "")
                return;

            GradeManager gm = new GradeManager();

            gm.GradeInfoPath = System.Web.HttpContext.Current.Server.MapPath(@"~/AlumnusRecord/Resources/GraduatingPhotographs/gradeinfo.xml");
            gm.ImageLocation = @"~/AlumnusRecord/Resources/GraduatingPhotographs";

            Label l;
            l = (Label)((GridView)sender).Rows[e.RowIndex].FindControl("LabelGradYear");
            string gradYear = l.Text;

            l = (Label)((GridView)sender).Rows[e.RowIndex].FindControl("LabelDegree");
            int degree = l.Text == "本科" ? 0 : 1;

            Grade grade = gm.GetGrade(degree, gradYear);

            if (gm.UpdateGradeImage((FileUpload)((GridView)sender).Rows[e.RowIndex].FindControl("FileUploadImage"), grade))
            {
                this.gradeGrid.DataBind();
            }
            else
            {
 
            }            
        }
        catch
        {
            return; 
        }

    }
    protected void gradeGrid_RowUpdated(object sender, GridViewUpdatedEventArgs e)
    {
        e.ExceptionHandled = true;
    }
}
