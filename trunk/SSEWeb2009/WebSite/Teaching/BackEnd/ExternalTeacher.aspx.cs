using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Teaching;
using Teaching.Ops;

public partial class Teaching_BackEnd_ExternalTeacher : System.Web.UI.Page
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

    protected void SelectExternalTeacher()
    {
        if (!IsPostBack)
        {
            opsTeachingQuery QueryName = new opsTeachingQuery("select WorkPlace, TutorType, ResearchAspect, ThesisIssue, ResearchDuty, ResearchAward, CourseName, CourseType, CourseProperty from TeacherExternal where TeacherID = '" + Session["IdentifyNumber"].ToString() + "'");
            QueryName.Do();
            if (QueryName.mResult.Tables.Count == 0 || QueryName.mResult.Tables[0].Rows.Count == 0)
                SysCom.Login.LoginRedirect(Request.Url.ToString());
            WorkPlace.Text = QueryName.mResult.Tables[0].Rows[0][0].ToString();
            if (!(QueryName.mResult.Tables[0].Rows[0][1] is System.DBNull))
            {
                TutorType.SelectedIndex = (byte)QueryName.mResult.Tables[0].Rows[0][1];
            }
            ResearchAspect.Text = QueryName.mResult.Tables[0].Rows[0][2].ToString();
            ThesisIssue.Text = QueryName.mResult.Tables[0].Rows[0][3].ToString();
            ResearchDuty.Text = QueryName.mResult.Tables[0].Rows[0][4].ToString();
            ResearchAward.Text = QueryName.mResult.Tables[0].Rows[0][5].ToString();
            CourseName.Text = QueryName.mResult.Tables[0].Rows[0][6].ToString();
            if (!(QueryName.mResult.Tables[0].Rows[0][7] is System.DBNull))
            {
                CourseType.SelectedIndex = (byte)QueryName.mResult.Tables[0].Rows[0][7];
            }
            if (!(QueryName.mResult.Tables[0].Rows[0][8] is System.DBNull))
            {
                CourseProperty.SelectedIndex = (byte)QueryName.mResult.Tables[0].Rows[0][8];
            }
        }
    }

    protected void UpdateExternalTeacher()
    {
        String sql = "update TeacherExternal set ";
        sql += "WorkPlace = \'" + TextConverter.ProcessString(WorkPlace.Text) + "\', ";
        sql += "TutorType = " + TutorType.SelectedIndex + ", ";
        sql += "ResearchAspect = \'" + TextConverter.ProcessString(ResearchAspect.Text) + "\', ";
        sql += "ThesisIssue = \'" + TextConverter.ProcessString(ThesisIssue.Text) + "\', ";
        sql += "ResearchDuty = \'" + TextConverter.ProcessString(ResearchDuty.Text) + "\', ";
        sql += "ResearchAward = \'" + TextConverter.ProcessString(ResearchAward.Text) + "\', ";
        sql += "CourseName = \'" + TextConverter.ProcessString(CourseName.Text) + "\', ";
        sql += "CourseType = " + CourseType.SelectedIndex + ", ";
        sql += "CourseProperty = " + CourseProperty.SelectedIndex + " ";
        sql += "where TeacherID = \'" + Session["IdentifyNumber"].ToString() + "\'";
        opsTeachingExec update = new opsTeachingExec(sql);
        update.Do();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        SelectExternalTeacher();
    }
    protected void Submit_Click(object sender, EventArgs e)
    {
        UpdateTeacherCommon();
        UpdateExternalTeacher();
    }
}
