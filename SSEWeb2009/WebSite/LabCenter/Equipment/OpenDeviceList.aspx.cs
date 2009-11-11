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
using LabCenter.Equipment;
using LabCenter.LabUtility.LoginUtility;

public partial class LabCenter_Equipment_OpenDeviceList : System.Web.UI.Page
{
    static private string id;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            id = (string)Session["IdentifyNumber"];
            LoginCtrl.CheckAuthorityRedirect(this, 7, 1);
        }
      
        this.btndel.Attributes.Add("onClick", "javascript:return   confirm('确定删除吗？');");
        if (!IsPostBack)
        {
            bandgrid();

        }
    }
    private void bandgrid()
    {
        OpenDeviceList odl = new OpenDeviceList();
        DataSet ds1=odl.getOpenDeviceList();
        this.GridView1.DataSource = ds1;
        this.GridView1.DataBind();
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        ViewState["id"] = GridView1.SelectedValue.ToString();
        BindDetailView(ViewState["id"].ToString());
    }
    private void BindDetailView(string SelectId)
    {

       
        OpenDeviceDetails odd = new OpenDeviceDetails(SelectId);
        DataSet ds2 = odd.getOpenDeviceDetails();

        this.DetailsView1.DataSource = ds2;
        this.DetailsView1.DataBind();

    }
    protected void DetailsView1_ModeChanging(object sender, DetailsViewModeEventArgs e)
    {
        //判断模式
        if (e.NewMode == DetailsViewMode.Insert)
        {
            DetailsView1.ChangeMode(DetailsViewMode.Insert);
        }
        else if (e.NewMode == DetailsViewMode.Edit)
        {
            DetailsView1.ChangeMode(DetailsViewMode.Edit);
            BindDetailView(ViewState["id"].ToString());
        }
        else if (e.CancelingEdit)
        {
            //取消插入模式
            if (DetailsView1.CurrentMode == DetailsViewMode.Insert)
            {
                DetailsView1.ChangeMode(DetailsViewMode.ReadOnly);
                BindDetailView(ViewState["id"].ToString());
            }
            //取消编辑模式
            else if (DetailsView1.CurrentMode == DetailsViewMode.Edit)
            {
                DetailsView1.ChangeMode(DetailsViewMode.ReadOnly);
                BindDetailView(ViewState["id"].ToString());
            }
        }
    }

    protected void DetailsView1_ItemInserting(object sender, DetailsViewInsertEventArgs e)
    {
        string strDeviceId = ((TextBox)DetailsView1.Rows[0].Cells[1].Controls[0]).Text.ToString();
        
        string strRemark = ((TextBox)DetailsView1.Rows[1].Cells[1].Controls[0]).Text.ToString();

        
        OpenDeviceInsert odi = new OpenDeviceInsert(strDeviceId, strRemark);
        odi.InsertOpenDevice();
        bandgrid();
        DetailsView1.ChangeMode(DetailsViewMode.ReadOnly);
        BindDetailView(ViewState["id"].ToString());
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.GridView1.PageIndex = e.NewPageIndex;
        bandgrid();
    }

    protected void DetailsView1_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
    {
        string strBeforeDeviceId = ViewState["id"].ToString();//为什么不能取出第一个值？
        string strAfterDeviceId=((TextBox)DetailsView1.Rows[0].Cells[1].Controls[0]).Text.ToString();
       
        string strRemark = ((TextBox)DetailsView1.Rows[1].Cells[1].Controls[0]).Text.ToString();


        OpenDeviceUpdate odu = new OpenDeviceUpdate(strBeforeDeviceId,strAfterDeviceId, strRemark);
        odu.UpdateOpenDevice();
        bandgrid();
        DetailsView1.ChangeMode(DetailsViewMode.ReadOnly);
        BindDetailView(ViewState["id"].ToString());
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //鼠标经过时，行背景色变 
            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#ECF3E1'");
            //鼠标移出时，行背景色变 
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#FFFFFF'");
        }
    }

    protected void btndel_Click(object sender, EventArgs e)
    {
        for (int i = 0; i <= this.GridView1.Rows.Count - 1; i++)
        {
            CheckBox check = (CheckBox)this.GridView1.Rows[i].FindControl("checkdel");
            if (check.Checked == true)
            {

                string strDeviceId = GridView1.DataKeys[i].Value.ToString();
                OpenDeviceDelete odd = new OpenDeviceDelete(strDeviceId);
                odd.DeleteOpenDevice();
                    
                


            }
        }
        bandgrid();
        Response.Write("<script>alert('删除成功！')</script>");

    }


}
