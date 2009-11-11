using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Web.UI.WebControls;


using SysCom;
using Department.Interface;


/// <summary>
/// 页面：SysMgr_SetAdmin - 设置部门管理员
/// 作者：Constantine
/// 最近一次修改时间：2009-6-24
/// </summary>
public partial class SysMgr_SetAdmin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["IdentifyNumber"] == null)
        {
            SysCom.Login.LoginRedirect(Request.Url.ToString());
        }

        if (!IsPostBack)
        {
            // 填充listview
            for (int i = 0; i < DepartmentList.Departments.Count; ++i)
            {
                String keyStr = DepartmentList.Departments[i].Key;

                lbDepartment.Items.Add(keyStr);
            }

            try
            {
                Dictionary<String, String> teacherCollection = BasicTeacherInfo.GetTeacherIdAndName();

                // 再来填充另一个listview
                foreach (KeyValuePair<String, String> kvPair in teacherCollection)
                {
                    ListItem li = new ListItem();
                    li.Text = kvPair.Value;
                    li.Value = kvPair.Key;

                    lbTeacher.Items.Add(li);
                }

            }
            catch (System.Exception ex)
            {
                String aa = ex.Message;
            }
        }


        this.lbNotice.Visible = false;
    }

    /// <summary>
    /// 保存数据
    /// </summary>
    /// <param name="sender">sender</param>
    /// <param name="e">e</param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (lbDepartment.SelectedItem == null || lbTeacher.SelectedItem == null)
        {
            this.lbNotice.Text = "请选择对应的部门和老师!";
            this.lbNotice.Visible = true;
            return;
        }

        String dep = lbDepartment.SelectedItem.Text;
        String tec = lbTeacher.SelectedItem.Value;

        for (int i = 0; i < DepartmentList.Departments.Count;++i )
        {
            if (DepartmentList.Departments[i].Key.Equals(dep))
            {
                ((IGetAuthList)DepartmentList.Departments[i].Value).SetAsAdmin(tec);
                this.lbNotice.Text = "保存数据成功!";
                this.lbNotice.Visible = true;
                return;
            }
        }
        // 你是不是想说，好简单啊……嗯
    }
}
