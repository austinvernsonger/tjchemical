using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using LabCenter.Authority;
using LabCenter.LabUtility.PerInfoUtility;
using LabCenter.LabUtility.LoginUtility;

public partial class _SearchManager : System.Web.UI.Page
{
    static private int value;
    static private int state;
    static private string constr;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoginCtrl.CheckLoginRedirect(this);
            string id = (string)Session["IdentifyNumber"];
            AuthorityManage am = new AuthorityManage();
          
              if (!am.IsSuper(id))
                        {
                            Response.Redirect("~/LabCenter/NoAuthority.aspx");
                        }
            
        }
    }
    protected void GridView1_OnRowCommand(object sender,GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt16(e.CommandArgument.ToString());
       
        if (e.CommandName=="Details")
        {
           string id = GridView1.DataKeys[index].Value.ToString().Trim();
           string name = GridView1.Rows[index].Cells[3].Text.ToString().Trim();
           Response.Redirect("AuthoManage.aspx?id=" + id + "&name=" + name);
        }
        if (e.CommandName=="Deletes")
        {
           // this.Session["managerID"] = GridView1.DataKeys[index].Value.ToString().Trim();
            AuthorityManage authoritymanage = new AuthorityManage();
            authoritymanage.DeleteManager(GridView1.DataKeys[index].Value.ToString().Trim());
            authoritymanage.DeleteAuthority(GridView1.DataKeys[index].Value.ToString().Trim());
            if (state==1)
            {
                if (value == 1)
                {
                    DataSet ds = authoritymanage.GetManagersByID(constr);
                    GridView1.DataSource = ds;
                    GridView1.DataBind();    
                }
                if (value == 2)
                {
                   
                    DataSet ds = authoritymanage.GetManagersByName(constr);
                    GridView1.DataSource = ds;
                    GridView1.DataBind();    
                }
                
            }
            if (state==2)
            {
                DataSet ds = authoritymanage.GetAllManagers();
                GridView1.DataSource = ds;
                GridView1.DataBind();  
            }
        }
        if (e.CommandName=="Page")
        {
            
        }
       
       
    }
    protected void AddSubmit_Click(object sender, EventArgs e)
    {
        string id = IDinput.Text.ToString().Trim();
        if (""==id)
        {
            Response.Write("工号或学号不能为空");
            Response.End();
            return;
        }

        string name = PersonInfoCtrl.GetNameByID(id);
        if (""==name)
        {
            Response.Write("不存在的ID");
            Response.End();
            return;
        }
        
        if (name!=null)
        {
            AuthorityManage am = new AuthorityManage();
            if (am.AddManager(id, name))
            {
                Response.Redirect("AuthoManage.aspx?id=" + id + "&name=" + name);
            }
           
        }
        else
        {

        }
       
    }
    protected void SearchSubmit_Click(object sender, EventArgs e)
    {
        state = 1;
        string condition = ConditionInput.Text.ToString();
        condition.Trim();
        constr = condition;
        AuthorityManage authoritymanage=new AuthorityManage();
        if (RadioButtonList1.SelectedValue == "1")
        {
            value = 1;
            DataSet ds = authoritymanage.GetManagersByID(condition);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
        if (RadioButtonList1.SelectedValue == "2")
        {
            value=2;
            DataSet ds = authoritymanage.GetManagersByName(condition);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }       
        GridView1.PageIndex = 1;
    }
    protected void GetAllSubmit_Click(object sender, EventArgs e)
    {
       state = 2;
       AuthorityManage authoritymanage = new AuthorityManage();
       DataSet ds = authoritymanage.GetAllManagers();
       GridView1.DataSource = ds;
       GridView1.DataBind();
       GridView1.PageIndex = 1;
    }
    protected void GridView1_PageIndexChanged(object sender, EventArgs e)
    {

    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        AuthorityManage authoritymanage = new AuthorityManage();
        if (state == 1)
        {
            if (value == 1)
            {
                DataSet ds = authoritymanage.GetManagersByID(constr);
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
            if (value == 2)
            {

                DataSet ds = authoritymanage.GetManagersByName(constr);
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
        }
        if (state == 2)
        {
            DataSet ds = authoritymanage.GetAllManagers();
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
    }
    protected void button7_Click(object sender, EventArgs e)
    {
        Response.Redirect("../../Repair/RepairDefault.aspx");
    }
    protected void button8_Click(object sender, EventArgs e)
    {
        Response.Redirect("SearchManager.aspx");
    }
}
