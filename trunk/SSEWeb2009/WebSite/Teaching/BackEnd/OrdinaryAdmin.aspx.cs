using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Teaching;
using Teaching.Ops;

public partial class Teaching_BackEnd_OrdinaryAdmin : System.Web.UI.Page
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
        SelectOrdinaryAdmin();
    }

    protected void Submit_Click(object sender, EventArgs e)
    {
        UpdateTeacherCommon();
        UpdateOrdinaryAdmin();
    }
}
