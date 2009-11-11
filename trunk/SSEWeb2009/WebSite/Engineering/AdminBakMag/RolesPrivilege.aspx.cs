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

public partial class Engineering_AdminBakMag_RolesPrivilege : System.Web.UI.Page
{
    private int roleID;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["id"] != null && Request["id"] != "")
        {
            //更改角色权限
            roleID = Convert.ToInt32(Request["id"]);
            if (!IsPostBack)
            {
                btModify.Visible = true;
                btSave.Visible = false;
                //绑定角色
                bindRole();
                //绑定权限
              bindPrivilege();
            }
        }
        else
        { 
            //添加新角色，并为新角色添加权限
            div_adm.Visible = true;
            div_student.Visible = true;
            div_teacher.Visible = true;
        }
    }
    protected void bindRole()
    {
        RoleManage rMag = new RoleManage();
        string roleName = rMag.GetRoleName(roleID);
        if (roleName != null)
        {
            div_updateRole.Visible = true;
            lblRole.Text = roleName;
        }
        switch (roleID)
        {
            case 1: div_adm.Visible = true; break;//管理员
            case 2:
            case 3: div_teacher.Visible = true; break;//教师
            case 4: div_student.Visible = true; break;//学生
            default:
                div_adm.Visible = true;
                div_teacher.Visible = true;
                div_student.Visible = true;
                break;
        }
    }
    protected void bindPrivilege()
    {
        switch (roleID)
        {
            case 1: InitialAdmPrivilege(); break;
            case 2: InitialTeacherPrivilege(); lblTeacher.Text = "教师相关权限："; break;
            case 3: InitialTeacherPrivilege(); lblTeacher.Text = "导师相关权限："; break;
            case 4: InitialStuPrivilege(); break;
        }
        
    }
    protected void btModify_Click(object sender, EventArgs e)
    {
        if (roleID == 1)
        {
            for (int i = 1; i < 26; i++)
            {
                CheckBox cb = (CheckBox)form1.FindControl("CheckBox_A" + i.ToString());
                cb.Enabled = true;
            }
        }
        if (roleID == 4)
        {
            for (int i = 1; i < 21; i++)
            {
                CheckBox cb = (CheckBox)form1.FindControl("CheckBox_C" + i.ToString());
                cb.Enabled = true;
            }
        }
        if (roleID == 2 || roleID ==3)
        {
            for (int i = 1; i < 9; i++)
            {
                CheckBox cb = (CheckBox)form1.FindControl("CheckBox_B" + i.ToString());
                cb.Enabled = true;
            }
        }
        btModify.Visible = false;
        btSave.Visible = true;
    }
    protected void btSave_Click(object sender, EventArgs e)
    {
        if (roleID == 1)
        {
            for (int i = 1; i < 26; i++)
            {
                CheckBox cb = (CheckBox)form1.FindControl("CheckBox_A" + i.ToString());
                cb.Enabled = false;
            }
            SaveAdmPrivilegeModifier();
        }
        if (roleID == 4)
        {
            for (int i = 1; i < 21; i++)
            {
                CheckBox cb = (CheckBox)form1.FindControl("CheckBox_C" + i.ToString());
                cb.Enabled = false;
            }
            SaveStuPrivilegeModifier();
        }
        if (roleID == 2 || roleID == 3)
        {
            for (int i = 1; i < 9; i++)
            {
                CheckBox cb = (CheckBox)form1.FindControl("CheckBox_B" + i.ToString());
                cb.Enabled = false;
            }
            SaveTeacherPrivilegeModify();
        }
        btSave.Visible = false;
        btModify.Visible = true;
        
    }
    protected void SaveAdmPrivilegeModifier()
    {
        RoleManage rMag = new RoleManage();
        try
        {
            rMag.DeleteRoleFunc(roleID);
            if (CheckBox_A1.Checked == true)
            {
                rMag.AddRoleFunc(roleID, "1-9");
            }
            if (CheckBox_A2.Checked == true)
            {
                rMag.AddRoleFunc(roleID, "1-10");
            }
            if (CheckBox_A3.Checked == true)
            {
                rMag.AddRoleFunc(roleID, "1-11");
            }
            if (CheckBox_A4.Checked == true)
            {
                rMag.AddRoleFunc(roleID, "1-12");
            }
            if (CheckBox_A5.Checked == true)
            {
                rMag.AddRoleFunc(roleID, "1-13");
            }
            if (CheckBox_A6.Checked == true)
            {
                rMag.AddRoleFunc(roleID, "1-14");
            }
            if (CheckBox_A7.Checked == true)
            {
                rMag.AddRoleFunc(roleID, "1-15");
            }
            if (CheckBox_A8.Checked == true)
            {
                rMag.AddRoleFunc(roleID, "1-16");
            }
            if (CheckBox_A9.Checked == true)
            {
                rMag.AddRoleFunc(roleID, "1-17");
            }
            if (CheckBox_A10.Checked == true)
            {
                rMag.AddRoleFunc(roleID, "1-18");
            }
            if (CheckBox_A11.Checked == true)
            {
                rMag.AddRoleFunc(roleID, "1-19");
            }
            if (CheckBox_A12.Checked == true)
            {
                rMag.AddRoleFunc(roleID, "1-20");
            }
            if (CheckBox_A13.Checked == true)
            {
                rMag.AddRoleFunc(roleID, "1-21");
            }
            if (CheckBox_A14.Checked == true)
            {
                rMag.AddRoleFunc(roleID, "1-22");
            }
            if (CheckBox_A15.Checked == true)
            {
                rMag.AddRoleFunc(roleID, "1-25");
            }
            if (CheckBox_A16.Checked == true)
            {
                rMag.AddRoleFunc(roleID, "1-26");
            }
            if (CheckBox_A17.Checked == true)
            {
                rMag.AddRoleFunc(roleID, "1-27");
            }
            if (CheckBox_A18.Checked == true)
            {
                rMag.AddRoleFunc(roleID, "1-28");
            }
            if (CheckBox_A19.Checked == true)
            {
                rMag.AddRoleFunc(roleID, "1-29");
            }
            if (CheckBox_A20.Checked == true)
            {
                rMag.AddRoleFunc(roleID, "1-30");
            }
            if (CheckBox_A21.Checked == true)
            {
                rMag.AddRoleFunc(roleID, "1-31");
            }
            if (CheckBox_A22.Checked == true)
            {
                rMag.AddRoleFunc(roleID, "1-32");
            }
            if (CheckBox_A23.Checked == true)
            {
                rMag.AddRoleFunc(roleID, "1-33");
            }
            if (CheckBox_A24.Checked == true)
            {
                rMag.AddRoleFunc(roleID, "1-34");
            }
            if (CheckBox_A25.Checked == true)
            {
                rMag.AddRoleFunc(roleID, "1-35");
            }
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('修改成功')</script>");
        }
        catch
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('修改失败，请重试')</script>");
        }
    }
    protected void SaveStuPrivilegeModifier()
    {
        RoleManage rMag = new RoleManage();
        try
        {
            rMag.DeleteRoleFunc(roleID);
            if (CheckBox_C1.Checked == true)
            {
                rMag.AddRoleFunc(roleID, "4-1");
            }
            if (CheckBox_C2.Checked == true)
            {
                rMag.AddRoleFunc(roleID, "4-3");
            }
            if (CheckBox_C3.Checked == true)
            {
                rMag.AddRoleFunc(roleID, "4-4");
            }
            if (CheckBox_C4.Checked == true)
            {
                rMag.AddRoleFunc(roleID, "4-5");
            }
            if (CheckBox_C5.Checked == true)
            {
                rMag.AddRoleFunc(roleID, "4-6");
            }
            if (CheckBox_C6.Checked == true)
            {
                rMag.AddRoleFunc(roleID, "4-7");
            }
            if (CheckBox_C7.Checked == true)
            {
                rMag.AddRoleFunc(roleID, "4-8");
            }
            if (CheckBox_C8.Checked == true)
            {
                rMag.AddRoleFunc(roleID, "4-9");
            }
            if (CheckBox_C9.Checked == true)
            {
                rMag.AddRoleFunc(roleID, "4-10");
            }
            if (CheckBox_C10.Checked == true)
            {
                rMag.AddRoleFunc(roleID, "4-11");
            }
            if (CheckBox_C11.Checked == true)
            {
                rMag.AddRoleFunc(roleID, "4-12");
            }
            if (CheckBox_C12.Checked == true)
            {
                rMag.AddRoleFunc(roleID, "4-13");
            }
            if (CheckBox_C13.Checked == true)
            {
                rMag.AddRoleFunc(roleID, "4-14");
            }
            if (CheckBox_C14.Checked == true)
            {
                rMag.AddRoleFunc(roleID, "4-15");
            }
            if (CheckBox_C15.Checked == true)
            {
                rMag.AddRoleFunc(roleID, "4-16");
            }
            if (CheckBox_C16.Checked == true)
            {
                rMag.AddRoleFunc(roleID, "4-17");
            }
            if (CheckBox_C17.Checked == true)
            {
                rMag.AddRoleFunc(roleID, "4-18");
            }
            if (CheckBox_C18.Checked == true)
            {
                rMag.AddRoleFunc(roleID, "4-20");
            }
            if (CheckBox_C19.Checked == true)
            {
                rMag.AddRoleFunc(roleID, "4-21");
            }
            if (CheckBox_C20.Checked == true)
            {
                rMag.AddRoleFunc(roleID, "4-22");
            }
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('修改成功')</script>");
        }
        catch
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('修改失败，请重试')</script>");
        }
    }
    protected void SaveTeacherPrivilegeModify()
    { 
        RoleManage rMag = new RoleManage();
        try
        {
            rMag.DeleteRoleFunc(roleID);
            if (CheckBox_B1.Checked == true)
            {
                rMag.AddRoleFunc(roleID, "2-2");
            }
            if (CheckBox_B2.Checked == true)
            {
                rMag.AddRoleFunc(roleID, "2-3");
            }
            if (CheckBox_B3.Checked == true)
            {
                rMag.AddRoleFunc(roleID, "2-5");
            }
            if (CheckBox_B4.Checked == true)
            {
                rMag.AddRoleFunc(roleID, "2-6");
            }
            if (CheckBox_B5.Checked == true)
            {
                rMag.AddRoleFunc(roleID, "2-8");
            }
            if (CheckBox_B6.Checked == true)
            {
                rMag.AddRoleFunc(roleID, "2-9");
            }
            if (CheckBox_B7.Checked == true)
            {
                rMag.AddRoleFunc(roleID, "2-10");
            }
            if (CheckBox_B8.Checked == true)
            {
                rMag.AddRoleFunc(roleID, "2-12");
            }
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('修改成功')</script>");
        }
        catch
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('修改失败，请重试')</script>");
        }
    }
    protected void InitialStuPrivilege()
    {
        for (int i = 1; i < 21; i++)
        {
            CheckBox cb = (CheckBox)form1.FindControl("CheckBox_C" + i.ToString());
            cb.Enabled = false;
        }
        RoleManage rMag = new RoleManage();
        DataSet ds= rMag.GetRoleFunc(roleID);
        if (ds.Tables[0].Rows.Count == 0)
        {
            for (int i = 1; i < 21; i++)
            {
                CheckBox cb = (CheckBox)form1.FindControl("CheckBox_C" + i.ToString());
                cb.Checked = false;
            }
        }
        else
        {
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if (string.Compare(dr["FuncID"].ToString().Trim(), "4-1")==0)
                {
                    CheckBox_C1.Checked = true;
                }
                if (string.Compare(dr["FuncID"].ToString().Trim(), "4-3")==0)
                {
                    CheckBox_C2.Checked = true;
                }
                if (string.Compare(dr["FuncID"].ToString().Trim(), "4-4")==0)
                {
                    CheckBox_C3.Checked = true;
                }
                if (string.Compare(dr["FuncID"].ToString().Trim(), "4-5")==0)
                {
                    CheckBox_C4.Checked = true;
                }
                if (string.Compare(dr["FuncID"].ToString().Trim(), "4-6")==0)
                {
                    CheckBox_C5.Checked = true;
                }
                if (string.Compare(dr["FuncID"].ToString().Trim(), "4-7")==0)
                {
                    CheckBox_C6.Checked = true;
                }
                if (string.Compare(dr["FuncID"].ToString().Trim(), "4-8")==0)
                {
                    CheckBox_C7.Checked = true;
                }
                if (string.Compare(dr["FuncID"].ToString().Trim(), "4-9")==0)
                {
                    CheckBox_C8.Checked = true;
                }
                if (string.Compare(dr["FuncID"].ToString().Trim(), "4-10")==0)
                {
                    CheckBox_C9.Checked = true;
                }
                if (string.Compare(dr["FuncID"].ToString().Trim(), "4-11")==0)
                {
                    CheckBox_C10.Checked = true;
                }
                if (string.Compare(dr["FuncID"].ToString().Trim(), "4-12")==0)
                {
                    CheckBox_C11.Checked = true;
                }
                if (string.Compare(dr["FuncID"].ToString().Trim(), "4-13")==0)
                {
                    CheckBox_C12.Checked = true;
                }
                if (string.Compare(dr["FuncID"].ToString().Trim(), "4-14")==0)
                {
                    CheckBox_C13.Checked = true;
                }
                if (string.Compare(dr["FuncID"].ToString().Trim(), "4-15")==0)
                {
                    CheckBox_C14.Checked = true;
                }
                if (string.Compare(dr["FuncID"].ToString().Trim(), "4-16")==0)
                {
                    CheckBox_C15.Checked = true;
                }
                if (string.Compare(dr["FuncID"].ToString().Trim(), "4-17")==0)
                {
                    CheckBox_C16.Checked = true;
                }
                if (string.Compare(dr["FuncID"].ToString().Trim(), "4-18")==0)
                {
                    CheckBox_C17.Checked = true;
                }
                if (string.Compare(dr["FuncID"].ToString().Trim(), "4-20")==0)
                {
                    CheckBox_C18.Checked = true;
                }
                if (string.Compare(dr["FuncID"].ToString().Trim(), "4-21")==0)
                {
                    CheckBox_C19.Checked = true;
                }
                if (string.Compare(dr["FuncID"].ToString().Trim(), "4-22") == 0)
                {
                    CheckBox_C20.Checked = true;
                }
            }
        }
    }
    protected void InitialAdmPrivilege()
    {
        for (int i = 1; i < 26; i++)
        {
            CheckBox cb = (CheckBox)form1.FindControl("CheckBox_A" + i.ToString());
            cb.Enabled = false;
        }
        RoleManage rMag = new RoleManage();
        DataSet ds = rMag.GetRoleFunc(roleID);
        if (ds.Tables[0].Rows.Count  > 0)
        {
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if (string.Compare(dr["FuncID"].ToString().Trim(), "1-9") == 0)
                {
                    CheckBox_A1.Checked = true;
                }
                if (string.Compare(dr["FuncID"].ToString().Trim(), "1-10") == 0)
                {
                    CheckBox_A2.Checked = true;
                }
                if (string.Compare(dr["FuncID"].ToString().Trim(), "1-11") == 0)
                {
                    CheckBox_A3.Checked = true;
                }
                if (string.Compare(dr["FuncID"].ToString().Trim(), "1-12") == 0)
                {
                    CheckBox_A4.Checked = true;
                }
                if (string.Compare(dr["FuncID"].ToString().Trim(), "1-13") == 0)
                {
                    CheckBox_A5.Checked = true;
                }
                if (string.Compare(dr["FuncID"].ToString().Trim(), "1-14") == 0)
                {
                    CheckBox_A6.Checked = true;
                }
                if (string.Compare(dr["FuncID"].ToString().Trim(), "1-15") == 0)
                {
                    CheckBox_A7.Checked = true;
                }
                if (string.Compare(dr["FuncID"].ToString().Trim(), "1-16") == 0)
                {
                    CheckBox_A8.Checked = true;
                }
                if (string.Compare(dr["FuncID"].ToString().Trim(), "1-17") == 0)
                {
                    CheckBox_A9.Checked = true;
                }
                if (string.Compare(dr["FuncID"].ToString().Trim(), "1-18") == 0)
                {
                    CheckBox_A10.Checked = true;
                }
                if (string.Compare(dr["FuncID"].ToString().Trim(), "1-19") == 0)
                {
                    CheckBox_A11.Checked = true;
                }
                if (string.Compare(dr["FuncID"].ToString().Trim(), "1-20") == 0)
                {
                    CheckBox_A12.Checked = true;
                }
                if (string.Compare(dr["FuncID"].ToString().Trim(), "1-21") == 0)
                {
                    CheckBox_A13.Checked = true;
                }
                if (string.Compare(dr["FuncID"].ToString().Trim(), "1-22") == 0)
                {
                    CheckBox_A14.Checked = true;
                }
                if (string.Compare(dr["FuncID"].ToString().Trim(), "1-25") == 0)
                {
                    CheckBox_A15.Checked = true;
                }
                if (string.Compare(dr["FuncID"].ToString().Trim(), "1-26") == 0)
                {
                    CheckBox_A16.Checked = true;
                }
                if (string.Compare(dr["FuncID"].ToString().Trim(), "1-27") == 0)
                {
                    CheckBox_A17.Checked = true;
                }
                if (string.Compare(dr["FuncID"].ToString().Trim(), "1-28") == 0)
                {
                    CheckBox_A18.Checked = true;
                }
                if (string.Compare(dr["FuncID"].ToString().Trim(), "1-29") == 0)
                {
                    CheckBox_A19.Checked = true;
                }
                if (string.Compare(dr["FuncID"].ToString().Trim(), "1-30") == 0)
                {
                    CheckBox_A20.Checked = true;
                }
                if (string.Compare(dr["FuncID"].ToString().Trim(), "1-31") == 0)
                {
                    CheckBox_A21.Checked = true;
                }
                if (string.Compare(dr["FuncID"].ToString().Trim(), "1-32") == 0)
                {
                    CheckBox_A22.Checked = true;
                }
                if (string.Compare(dr["FuncID"].ToString().Trim(), "1-33") == 0)
                {
                    CheckBox_A23.Checked = true;
                }
                if (string.Compare(dr["FuncID"].ToString().Trim(), "1-34") == 0)
                {
                    CheckBox_A24.Checked = true;
                }
                if (string.Compare(dr["FuncID"].ToString().Trim(), "1-35") == 0)
                {
                    CheckBox_A25.Checked = true;
                }
            }
        }
    }
    protected void InitialTeacherPrivilege()
    {
        for (int i = 1; i < 9; i++)
        {
            CheckBox cb = (CheckBox)form1.FindControl("CheckBox_B" + i.ToString());
            cb.Enabled = false;
        }
        RoleManage rMag = new RoleManage();
        DataSet ds = rMag.GetRoleFunc(roleID);
        if (ds.Tables[0].Rows.Count == 0)
        {
            for (int i = 1; i < 9; i++)
            {
                CheckBox cb = (CheckBox)form1.FindControl("CheckBox_B" + i.ToString());
                cb.Checked = false;
            }
        }
        else
        {
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if (string.Compare(dr["FuncID"].ToString().Trim(), "2-2") == 0)
                {
                    CheckBox_B1.Checked = true;
                }
                if (string.Compare(dr["FuncID"].ToString().Trim(), "2-3") == 0)
                {
                    CheckBox_B2.Checked = true;
                }
                if (string.Compare(dr["FuncID"].ToString().Trim(), "2-5") == 0)
                {
                    CheckBox_B3.Checked = true;
                }
                if (string.Compare(dr["FuncID"].ToString().Trim(), "2-6") == 0)
                {
                    CheckBox_B4.Checked = true;
                }
                if (string.Compare(dr["FuncID"].ToString().Trim(), "2-8") == 0)
                {
                    CheckBox_B5.Checked = true;
                }
                if (string.Compare(dr["FuncID"].ToString().Trim(), "2-9") == 0)
                {
                    CheckBox_B6.Checked = true;
                }
                if (string.Compare(dr["FuncID"].ToString().Trim(), "2-10") == 0)
                {
                    CheckBox_B7.Checked = true;
                }
                if (string.Compare(dr["FuncID"].ToString().Trim(), "2-12") == 0)
                {
                    CheckBox_B8.Checked = true;
                }
            }
        }
    }
}
