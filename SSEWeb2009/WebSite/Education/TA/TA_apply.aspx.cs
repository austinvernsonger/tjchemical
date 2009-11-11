using System;
using System.Windows.Forms;
using System.Collections;
using System.Configuration;
using System.Data;
//using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
//using System.Xml.Linq;
using Education.src;
using Education.Sql;

public partial class Education_TA_TA_apply : System.Web.UI.Page
{
    private String mAccount = "";
    private String mName = "";
    private int mScore = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            // get the ID
            if (mAccount == "")
            {
                // goto login 
            }
            BindDataById(mAccount);
            LabelID.Text = mAccount;
            LabelName.Text = mName;
        }
        String currentCourse = DropDownListCourse.SelectedItem.ToString();
        BindTeacherName(currentCourse);
    }

    protected void BindDataById(String ID)
    {
        DataSet courseSet = GetAllCourse();
        DropDownListCourse.DataSource = courseSet.Tables[0].DefaultView;
        DropDownListCourse.DataTextField = "CourseName";
        DropDownListCourse.DataBind();
    }

    protected void GetName()
    {
        String SQL = "select Name from Student where StudentID=" + mAccount + "";
        DataSet nameSet = EducationDbOpe.DoQuery(SQL, "Account");//疑问 数据库名
        mName = nameSet.Tables[0].Rows[0].ToString();
    }

    protected DataSet GetAllCourse()
    {
        String SQL = "select CourseName from Course where Target=1";
        return EducationDbOpe.DoQuery(SQL, "Teaching");
    }

    protected void BindTeacherName(String courseName)
    {
        String SQL = "select Name from Teacher join TeacherOrdinary on Teacher.TeacherID = " +
            "TeacherOrdinary.TeacherID where TeacherOrdinary.CourseName=" + courseName + "";
        DataSet teacherSet = EducationDbOpe.DoQuery(SQL, "Teaching");
        DropDownListTeacher.DataSource = teacherSet.Tables[0].DefaultView;
        DropDownListTeacher.DataTextField = "Name";
        DropDownListTeacher.DataBind();
    }
    protected void Buttonapply_Click(object sender, EventArgs e)
    {
        if (CheckBoxCourse.Checked)
        {
            try
            {
                mScore = Convert.ToInt32(TextBoxScore.Text);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("您输入的成绩格式不正确，请重新输入！");
                return;
            }
        }

        TA_ApplyInfo theInfo = new TA_ApplyInfo(mName, mAccount,
            DropDownListTeacher.SelectedItem.Text,
            DropDownListCourse.SelectedItem.Text,
            CheckBoxCourse.Checked,
            mScore,
            TextBoxIntroduce.Text,
            TextBoxPhone.Text,
            TextBoxEmail.Text,
            TextBoxComment.Text
            );
        EducationDbOpe.DoExecute(new sqlAddTAapply(theInfo));

    }
    protected void CheckBoxCourse_CheckedChanged(object sender, EventArgs e)
    {
        if (CheckBoxCourse.Checked == true)
        {
            TextBoxScore.Enabled = true;
        }
    }
}

    

