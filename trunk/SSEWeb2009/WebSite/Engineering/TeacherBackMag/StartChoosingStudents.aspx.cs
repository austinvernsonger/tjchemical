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
using System.Collections.Generic;

public partial class Engineering_TeacherBackMag_StartChoosingStudents : System.Web.UI.Page
{
    private string teacherID ;
    public List<string> will = new List<string>();
    private bool status = false;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["IdentifyNumber"] == null)
        {
            SysCom.Login.LoginRedirect(Request.Url.ToString());
        }
        teacherID = Session["IdentifyNumber"].ToString();
        if (!IsPostBack)
        {
            if (Request["id"] != null && Request["id"] != "")
            {
                ViewState["tMagID"]= Convert.ToInt32(Request["id"]);
                bindGvChoosingStu();
            }
        }
    }
    public string GetStuWill(string stuWill)
    {
            return "第" + stuWill + "志愿";
    }
    protected void btSave_Click(object sender, EventArgs e)
    {
        btSave.Visible = false;
        btModify.Visible = true;
       
        TeacherManage tMag = new TeacherManage();
        int num = gvChoosingStu.Rows.Count;
        for (int i=0; i < num; i++)
        {
            CheckBox cbox = (CheckBox)gvChoosingStu.Rows[i].FindControl("cbSelect");
            string stuid = gvChoosingStu.Rows[i].Cells[0].Text;
            if (true == cbox.Checked)
            {
                tMag.UpdateTeaChooseStu(1, stuid, teacherID);
            }
            else
            {
                tMag.UpdateTeaChooseStu(0, stuid, teacherID);
            }
            cbox.Enabled = false;
        }
         
    }
    protected void btModify_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < gvChoosingStu.Rows.Count; i++)
        {
            CheckBox cb = (CheckBox)gvChoosingStu.Rows[i].FindControl("cbSelect");
            cb.Enabled = true;
        }
        btModify.Visible = false;
        btSave.Visible = true;
    }
    protected void bindGvChoosingStu()
    {
        int tMagID = (int)ViewState["tMagID"];
        StudentManage sMag = new StudentManage();
        DataSet ds = sMag.GetTeaChooseStuInfo(tMagID, teacherID);
        
        int num = ds.Tables[0].Rows.Count;
        if (num > 0)
        {
            //有学生选择该教师
            lblMessage.Text = "该教学点共有" + num + "人选择了我：";
            lblGrade.Text = ds.Tables[0].Rows[0]["Grade"].ToString();
            lblSchool.Text = ds.Tables[0].Rows[0]["TeaSchoolName"].ToString();
            int i;
            for (i = 0; i < num; i++)
            {
                if (Convert.ToInt32(ds.Tables[0].Rows[i]["TeaWill"]) == 1)
                {
                    break;
                }
            }
            if (i == num)
            {
                //未选择
                btSave.Visible = true;
                btModify.Visible = false;
            }
            else
            {
                //选择
                btModify.Visible = true;
                btSave.Visible = false;
                status = true;
            }
        }
        gvChoosingStu.DataSource = ds.Tables[0];
        gvChoosingStu.DataBind();
    }
    protected void gvChoosingStu_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.DataItem != null)
        {
            CheckBox cb = (CheckBox)e.Row.FindControl("cbSelect");
            if (cb.Checked == true)
            {
                e.Row.BackColor = System.Drawing.Color.LightBlue;
            }
        }
    }
    protected void gvChoosingStu_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void cbSelect_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox cbox = (CheckBox)sender;
        if (cbox.Checked == true)
        {
            for (int i = 0; i < gvChoosingStu.Rows.Count; i++)
            {
                CheckBox cb = (CheckBox)gvChoosingStu.Rows[i].FindControl("cbSelect");
                if (cb.Checked == true)
                {
                    gvChoosingStu.Rows[i].BackColor = System.Drawing.Color.LightBlue;
                }
            }
        }
        else
        {
            for (int i = 0; i < gvChoosingStu.Rows.Count; i++)
            {
                CheckBox cb = (CheckBox)gvChoosingStu.Rows[i].FindControl("cbSelect");
                if (cb.Checked == false)
                {
                    gvChoosingStu.Rows[i].BackColor = System.Drawing.Color.White;
                }
            }
        }
    }
    protected void gvChoosingStu_DataBound(object sender, EventArgs e)
    {
        if (status == true)
        {
            for (int i = 0; i < gvChoosingStu.Rows.Count; i++)
            {
                CheckBox cb = (CheckBox)gvChoosingStu.Rows[i].FindControl("cbSelect");
                cb.Enabled = false;
            }
        }
    }
}
