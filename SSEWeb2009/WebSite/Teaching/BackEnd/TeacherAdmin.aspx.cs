using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Teaching;
using Teaching.Ops;

public partial class Teaching_BackEnd_TeacherAdmin : System.Web.UI.Page
{

    protected void Initialize()
    {
        if (Session["IdentifyNumber"] == null)
            SysCom.Login.LoginRedirect(Request.Url.ToString());
        opsTeachingQuery QueryName = new opsTeachingQuery("select Name, Gender, Birthday, Address, Telephone, Fax, Email, Title, Post, Memo, LastDegree, LastCollege from Teacher where TeacherID = '" + Session["IdentifyNumber"].ToString() + "'");
        QueryName.Do();
        if (QueryName.mResult.Tables.Count == 0 || QueryName.mResult.Tables[0].Rows.Count == 0)
            SysCom.Login.LoginRedirect(Request.Url.ToString());
        if (!IsPostBack)
        {
            Name.Text = QueryName.mResult.Tables[0].Rows[0][0].ToString();
            if ((bool)QueryName.mResult.Tables[0].Rows[0][1])
                Gender.Text = "女";
            else
                Gender.Text = "男";
            if (!(QueryName.mResult.Tables[0].Rows[0][2] is DBNull))
                Birthday.VisibleDate = Birthday.SelectedDate = (DateTime)QueryName.mResult.Tables[0].Rows[0][2];
            Address.Text = QueryName.mResult.Tables[0].Rows[0][3].ToString();
            Telephone.Text = QueryName.mResult.Tables[0].Rows[0][4].ToString();
            Fax.Text = QueryName.mResult.Tables[0].Rows[0][5].ToString();
            Email.Text = QueryName.mResult.Tables[0].Rows[0][6].ToString();
            TitleName.Text = QueryName.mResult.Tables[0].Rows[0][7].ToString();
            Post.Text = QueryName.mResult.Tables[0].Rows[0][8].ToString();
            Memo.Text = QueryName.mResult.Tables[0].Rows[0][9].ToString();
            LastDegree.Text = QueryName.mResult.Tables[0].Rows[0][10].ToString();
            LastCollege.Text = QueryName.mResult.Tables[0].Rows[0][11].ToString();
        }
    }

    protected void UpdateTeacherCommon()
    {
        String sql = "update Teacher set Address = \'" + TextConverter.ProcessString(Address.Text) + "\', ";
        sql += "Telephone = \'" + TextConverter.ProcessString(Telephone.Text) + "\', ";
        sql += "Fax = \'" + TextConverter.ProcessString(Fax.Text) + "\', ";
        sql += "Email = \'" + TextConverter.ProcessString(Email.Text) + "\', ";
        sql += "Title = \'" + TextConverter.ProcessString(TitleName.Text) + "\', ";
        sql += "Post = \'" + TextConverter.ProcessString(Post.Text) + "\', ";
        sql += "LastDegree = \'" + TextConverter.ProcessString(LastDegree.Text) + "\', ";
        sql += "LastCollege = \'" + TextConverter.ProcessString(LastCollege.Text) + "\', ";
        sql += "Memo = \'" + TextConverter.ProcessString(TitleName.Text);
        sql += "\' where TeacherID = '" + Session["IdentifyNumber"].ToString() + "'";
        opsTeachingExec update = new opsTeachingExec(sql);
        update.Do();
    }

    protected void SelectOrdinaryTeacher()
    {
        if (!IsPostBack)
        {
            opsTeachingQuery QueryName = new opsTeachingQuery("select TitleTime, TutorTime, ResearchAspect, ThesisIssue, ResearchDuty, ResearchAward, EducationReform, CompetitiveCourse, CourseName, CourseType, CourseProperty, EducationAward, StudentCompetition, StudentTerm, StudentCurrent, GraduateCount from TeacherOrdinary where TeacherID = '" + Session["IdentifyNumber"].ToString() + "'");
            QueryName.Do();
            if (QueryName.mResult.Tables.Count == 0 || QueryName.mResult.Tables[0].Rows.Count == 0)
                SysCom.Login.LoginRedirect(Request.Url.ToString());
            if (!(QueryName.mResult.Tables[0].Rows[0][0] is System.DBNull))
                TitleTime.VisibleDate = TitleTime.SelectedDate = (DateTime)QueryName.mResult.Tables[0].Rows[0][0];
            if (!(QueryName.mResult.Tables[0].Rows[0][1] is System.DBNull))
                TutorTime.VisibleDate = TutorTime.SelectedDate = (DateTime)QueryName.mResult.Tables[0].Rows[0][1];
            ResearchAspect.Text = QueryName.mResult.Tables[0].Rows[0][2].ToString();
            ThesisIssue.Text = QueryName.mResult.Tables[0].Rows[0][3].ToString();
            ResearchDuty.Text = QueryName.mResult.Tables[0].Rows[0][4].ToString();
            ResearchAward.Text = QueryName.mResult.Tables[0].Rows[0][5].ToString();
            EducationReform.Text = QueryName.mResult.Tables[0].Rows[0][6].ToString();
            CompetitiveCourse.Text = QueryName.mResult.Tables[0].Rows[0][7].ToString();
            CourseName.Text = QueryName.mResult.Tables[0].Rows[0][8].ToString();
            if (!(QueryName.mResult.Tables[0].Rows[0][9] is System.DBNull))
            {
                CourseType.Text = CourseType.Items[(byte)QueryName.mResult.Tables[0].Rows[0][9]].Text;
            }
            if (!(QueryName.mResult.Tables[0].Rows[0][10] is System.DBNull))
            {
                CourseProperty.Text = CourseProperty.Items[(byte)QueryName.mResult.Tables[0].Rows[0][10]].Text;
            }
            EducationAward.Text = QueryName.mResult.Tables[0].Rows[0][11].ToString();
            StudentCompetition.Text = QueryName.mResult.Tables[0].Rows[0][12].ToString();
            if (!(QueryName.mResult.Tables[0].Rows[0][13] is System.DBNull))
            {
                StudentTerm.Text = QueryName.mResult.Tables[0].Rows[0][13].ToString();
            }
            if (!(QueryName.mResult.Tables[0].Rows[0][14] is System.DBNull))
            {
                StudentCurrent.Text = QueryName.mResult.Tables[0].Rows[0][14].ToString();
            }
            if (!(QueryName.mResult.Tables[0].Rows[0][15] is System.DBNull))
            {
                GraduateCount.Text = QueryName.mResult.Tables[0].Rows[0][15].ToString();
            }
        }
    }

    protected void UpdateOrdinaryTeacher()
    {
        String sql = "update TeacherOrdinary set ";
        if (TitleTime.SelectedDate.ToString() != "0001-1-1 0:00:00")
            sql += "TitleTime = \'" + TitleTime.SelectedDate.ToString() + "\', ";
        if (TutorTime.SelectedDate.ToString() != "0001-1-1 0:00:00")
            sql += "TutorTime = \'" + TutorTime.SelectedDate.ToString() + "\', ";
        sql += "ResearchAspect = \'" + TextConverter.ProcessString(ResearchAspect.Text) + "\', ";
        sql += "ThesisIssue = \'" + TextConverter.ProcessString(ThesisIssue.Text) + "\', ";
        sql += "ResearchDuty = \'" + TextConverter.ProcessString(ResearchDuty.Text) + "\', ";
        sql += "ResearchAward = \'" + TextConverter.ProcessString(ResearchAward.Text) + "\', ";
        sql += "EducationReform = \'" + TextConverter.ProcessString(EducationReform.Text) + "\', ";
        sql += "CompetitiveCourse = \'" + TextConverter.ProcessString(CompetitiveCourse.Text) + "\', ";
        sql += "CourseName = \'" + TextConverter.ProcessString(CourseName.Text) + "\', ";
        sql += "CourseType = " + CourseType.SelectedIndex + ", ";
        sql += "CourseProperty = " + CourseProperty.SelectedIndex + ", ";
        sql += "EducationAward = \'" + TextConverter.ProcessString(EducationAward.Text) + "\', ";
        sql += "StudentCompetition = \'" + TextConverter.ProcessString(StudentCompetition.Text) + "\', ";
        sql += "StudentTerm = \'" + TextConverter.ProcessString(StudentTerm.Text) + "\', ";
        sql += "StudentCurrent = \'" + TextConverter.ProcessString(StudentCurrent.Text) + "\', ";
        sql += "GraduateCount = \'" + TextConverter.ProcessString(GraduateCount.Text) + "\' ";
        sql += "where TeacherID = '" + Session["IdentifyNumber"].ToString() + "'";
        opsTeachingExec update = new opsTeachingExec(sql);
        update.Do();
    }

    protected void SelectOrdinaryAdmin()
    {
        if (!IsPostBack)
        {
            opsTeachingQuery QueryName = new opsTeachingQuery("select Department, Major, ReformThesis, ReformDuty, EducationAward from TeacherAdministrator where TeacherID = '" + Session["IdentifyNumber"].ToString() + "'");
            QueryName.Do();
            if (QueryName.mResult.Tables.Count == 0 || QueryName.mResult.Tables[0].Rows.Count == 0)
                SysCom.Login.LoginRedirect(Request.Url.ToString());
            Department.Text = QueryName.mResult.Tables[0].Rows[0][0].ToString();
            Major.Text = QueryName.mResult.Tables[0].Rows[0][1].ToString();
            ReformThesis.Text = QueryName.mResult.Tables[0].Rows[0][2].ToString();
            ReformDuty.Text = QueryName.mResult.Tables[0].Rows[0][3].ToString();
            EducationAward.Text = QueryName.mResult.Tables[0].Rows[0][4].ToString();
        }
    }

    protected void UpdateOrdinaryAdmin()
    {
        String sql = "update TeacherAdministrator set ";
        sql += "Department = \'" + TextConverter.ProcessString(Department.Text) + "\', ";
        sql += "Major = \'" + TextConverter.ProcessString(Major.Text) + "\', ";
        sql += "ReformThesis = \'" + TextConverter.ProcessString(ReformThesis.Text) + "\', ";
        sql += "ReformDuty = \'" + TextConverter.ProcessString(ReformDuty.Text) + "\', ";
        sql += "EducationAward = \'" + TextConverter.ProcessString(EducationAward.Text) + "\' ";
        sql += "where TeacherID = '" + Session["IdentifyNumber"].ToString() + "'";
        opsTeachingExec update = new opsTeachingExec(sql);
        update.Do();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        SelectOrdinaryTeacher();
        SelectOrdinaryAdmin();
    }
    protected void Submit_Click(object sender, EventArgs e)
    {
        UpdateTeacherCommon();
        UpdateOrdinaryTeacher();
        UpdateOrdinaryAdmin();
    }
}
