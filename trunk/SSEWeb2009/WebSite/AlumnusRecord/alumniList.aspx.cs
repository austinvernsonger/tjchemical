using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AlumnusRecord;
using System.Text;

public partial class alumniList : System.Web.UI.Page
{
    private int m_AlumnusCountPerPage = 40;

    protected void Page_Load(object sender, EventArgs e)
    {
        this.gradeLabel.Text = Request.QueryString["year"]+"届"+(Request.QueryString["degree"] == "1"? "研究生":"本科生");


        if (!Page.IsPostBack)
        {
            try
            {
                

                int degree = Convert.ToInt32(Request.QueryString["degree"]);
                string gradYear = Request.QueryString["year"];

                GradeManager gm = new GradeManager();

                gm.GradeInfoPath = System.Web.HttpContext.Current.Server.MapPath(@"~/AlumnusRecord/Resources/GraduatingPhotographs/gradeinfo.xml");
                gm.ImageLocation = @"~/AlumnusRecord/Resources/GraduatingPhotographs";

                Grade grade = gm.GetGrade(degree, gradYear);

                if (grade != null)
                {
                    this.ImageGraduate.ImageUrl = grade.GradImageLocation;
                }

                int pageIndex;

                try
                {
                    pageIndex = Convert.ToInt32(Request.QueryString["page"]);
                }
                catch
                {
                    pageIndex = 1;
                }                

                BindDataList(degree, gradYear, pageIndex);
                
            }
            catch
            {
                this.ImageGraduate.ImageUrl = "???";//提供个头像？？ 
            }
        }
    }

    private void BindDataList(int degree, string gradYear, int pageIndex)
    {
        Alumnus al = new Alumnus();
        int count = al.GetAlumnusCount(degree, gradYear);

        int beginIndex;

        if (pageIndex <= 0)
        {
            pageIndex = 1;
            beginIndex = 1;
        }
        else
        {            
            if (count / m_AlumnusCountPerPage >= pageIndex)
            {
                beginIndex = 1 + (pageIndex - 1) * m_AlumnusCountPerPage;
            }
            else
            {
                if (count % m_AlumnusCountPerPage == 0)
                {
                    beginIndex = 1 + (pageIndex - 1) * m_AlumnusCountPerPage;
                    pageIndex = count / m_AlumnusCountPerPage;
                }
                else
                {
                    pageIndex = count / m_AlumnusCountPerPage + 1;
                    beginIndex = 1 + (pageIndex - 1) * m_AlumnusCountPerPage; 
                }
            }      
        }

        StringBuilder sb = new StringBuilder();
        int totalPages = count % m_AlumnusCountPerPage == 0 ? count / m_AlumnusCountPerPage : count / m_AlumnusCountPerPage + 1;

        for (int i = 1; i <= totalPages; i++)
        {            
            if (i == pageIndex)
                sb.Append(pageIndex.ToString()).Append("&nbsp;&nbsp;&nbsp;");
            else
            {                
                sb.Append(@"<a href='alumniList.aspx?").Append(@"degree=").Append(degree.ToString()).Append(@"&year=").Append(gradYear).Append(@"&page=").Append(i.ToString()).Append(@"'>").Append(i.ToString()).Append(@"</a>").Append(@"&nbsp;&nbsp;&nbsp;");
            }
        }

        this.LabelPages.Text = sb.ToString();        

        this.DataListAlumnus.DataSource = al.GetAlumnusNameID(degree, gradYear, beginIndex, m_AlumnusCountPerPage);
        this.DataListAlumnus.DataBind();
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        this.RegisterClientScriptBlock("e", "<script language=javascript>history.go(-2);</script>");
    }
}
