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

public partial class Engineering_AdminBakMag_UserRoleManagement : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //绑定角色
            bindRole();
            //绑定部门用户
            bindAllTeacher();
            //绑定学院教师
            bindSchoolTeachers();
        }
    }
    protected void bindRole()
    {
        RoleManage rMag = new RoleManage();
        DataView dv = rMag.GetAllRolesExceptForStudentRoleList();
        ddlUsers.DataTextField = "RoleName";
        ddlUsers.DataValueField = "RoleId";
        ddlUsers.DataSource =dv;
        ddlUsers.DataBind();
    }
    protected void ddlUsers_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlUsers.SelectedIndex == 0)
        {
            lbUsers.Items.Clear();
        }
        else
        {
            //绑定该角色所对应的用户
            bindUsers();
        }
    }
    protected void bindUsers()
    {
        int roleID = Convert.ToInt32(ddlUsers.SelectedValue);
        RoleManage rMag = new RoleManage();
        DataSet ds = rMag.GetUsersByRoleID(roleID);
        lbUsers.DataTextField = "UserName";
        lbUsers.DataValueField = "UserID";
        lbUsers.DataSource = ds.Tables[0];
        lbUsers.DataBind();
    }
    protected void btDelete_Click(object sender, EventArgs e)
    {
        if (lbUsers.SelectedIndex == -1)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('请选择要删除的用户')</script>");
            return;
        }
        int roleID = Convert.ToInt32(ddlUsers.SelectedValue);
        string userID = lbUsers.SelectedValue;
        RoleManage rMag = new RoleManage();
        if (rMag.DeleteUserRole(roleID, userID) == true)
        {
            //删除成功
            bindUsers();
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('删除失败，请重试')</script>");
            return;
        }
    }
    protected void btAdd_Click(object sender, EventArgs e)
    {
        if (lbAllTeachers.SelectedIndex == -1)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('请选择要添加的教师')</script>");
            return;
        }
        if (ddlUsers.SelectedIndex == 0)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('请选择该教师在本部门所属的角色)</script>");
            return;
        }
        RoleManage rMag = new RoleManage();
        DataSet ds = null;
        int roleID = Convert.ToInt32(ddlUsers.SelectedValue);
         string teacherID = lbAllTeachers.SelectedValue.ToString().Trim();
        if (roleID == 5)
        { 
            //当前要为超级管理员角色添加用户
            //判断当前部门是否有超级管理员
            ds = rMag.GetUsersByRoleID(roleID);
            if (ds.Tables[0].Rows.Count > 0)
            {
                // 当前部门有超级管理员
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('一个部门只能有一个超级管理员')</script>");
                return;
            }
        }
        if (roleID == 1)
        { 
            //当前要为管理员角色添加用户
            //判断当前用户是否具有超级管理员权限
            ds = rMag.GetRolesSet(teacherID);
            if (ds.Tables[0].Rows.Count > 0)
            { 
                //当年用户在该部门有角色
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (Convert.ToInt32(ds.Tables[0].Rows[i]["RoleId"]) == 5)
                    {
                        //该用户具有超级管理员角色
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('该用户具有超级管理员角色，不能同时具有管理员角色')</script>");
                        return;
                    }
                }
            }
        }
        if (roleID == 2)
        { 
            //当前要为教师角色添加用户
            //判断当前用户是否也具有导师角色
            ds = rMag.GetRolesSet(teacherID);
            if (ds.Tables[0].Rows.Count > 0)
            {
                //当年用户在该部门有角色
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (Convert.ToInt32(ds.Tables[0].Rows[i]["RoleId"]) == 3)
                    {
                        //该用户具有导师角色
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('该用户已经具有导师角色，添加失败')</script>");
                        return;
                    }
                }
            }
        }
        if (roleID == 3)
        { 
            //当前要为导师角色添加用户
            //判断当前用户是否也具有教师角色
            ds = rMag.GetRolesSet(teacherID);
            if (ds.Tables[0].Rows.Count > 0)
            {
                //当年用户在该部门有角色
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (Convert.ToInt32(ds.Tables[0].Rows[i]["RoleId"]) == 2)
                    {
                        //该用户具有导师角色
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('该用户已经具有教师角色，添加失败')</script>");
                        return;
                    }
                }
            }
        }
        ds = rMag.GetUserAndRole(teacherID, roleID);
        if (ds.Tables[0].Rows.Count > 0)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('该用户所属角色已经存在')</script>");
            return;
        }
        if (rMag.AddUserRole(teacherID, roleID) == true)
        {
            //添加成功
            bindUsers();
        }
        else
        { 
            //添加失败
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('添加失败，请重试')</script>");
            return;
        }
    }
    protected void bindAllTeacher()
    {
        RoleManage rMag = new RoleManage();
        DataSet ds = rMag.GetAllUsers();
        lbAllTeachers.DataSource = ds.Tables[0];
        lbAllTeachers.DataTextField = "UserName";
        lbAllTeachers.DataValueField = "UserID";
        lbAllTeachers.DataBind();

        //lbTeachers.DataSource = ds.Tables[0];
        //lbTeachers.DataTextField = "UserName";
        //lbTeachers.DataValueField = "UserID";
        //lbTeachers.DataBind(); 
    }
    protected void bindSchoolTeachers()
    {
        TeacherManage tMag = new TeacherManage();
        DataSet ds = tMag.GetTeachersNotInMSE();
        lbSchoolTeachers.DataSource = ds.Tables[0];
        lbSchoolTeachers.DataTextField = "Name";
        lbSchoolTeachers.DataValueField = "TeacherID";
        lbSchoolTeachers.DataBind();
    }
    protected void btAddTeacher_Click(object sender, EventArgs e)
    {
        if (lbSchoolTeachers.SelectedIndex == -1)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('请选择要添加的用户')</script>");
            return;
        }
        string userID = lbSchoolTeachers.SelectedValue.Trim();
        string userName = lbSchoolTeachers.SelectedItem.Text.Trim();
        RoleManage rMag = new RoleManage();
        if (rMag.AddUser(userID, userName) == true)
        {
            bindAllTeacher();
            bindSchoolTeachers();
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('添加失败，请重试')</script>");
            return;
        }
    }
    protected void btDeleteTeacher_Click(object sender, EventArgs e)
    {
        if (lbAllTeachers.SelectedIndex == -1)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('请选择要删除的用户')</script>");
            return;
        }
         RoleManage rMag = new RoleManage();
        DataSet ds = null;
        string userID = lbAllTeachers.SelectedValue; 
        ds = rMag.GetRolesSet(userID);
        if (ds.Tables[0].Rows.Count > 0)
        { 
            //当前用户有角色
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (Convert.ToInt32(ds.Tables[0].Rows[i]["RoleId"]) == 5)
                { 
                    //该用户具有超级管理员这个角色
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('当前用户为超级管理员，不能删除')</script>");
                    return;
                }
            }
        }
       if(rMag.DeleteUserRoleByTran(userID) == true)
       {
            bindAllTeacher();
            bindSchoolTeachers();
       }
       else
       {
           Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('操作失败，请重试')</script>");
            return;
       }
    }
}
