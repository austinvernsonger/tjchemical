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

public partial class LabCenter_Equipment_MaterialApplyTable : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoginCtrl.CheckAuthorityRedirect(this, 7, 2);
        }
        this.btndel.Attributes.Add("onClick", "javascript:return   confirm('确定删除吗？');");
        if (!IsPostBack)
        {
            bandgrid();

        }
    }
    private void bandgrid()
    {
        MaterialApplyTable mat = new MaterialApplyTable();

        DataSet ds1 = mat.getMaterialApplyTable();
        this.GridView1.DataSource = ds1;
        this.GridView1.DataBind();
        for (int i = 0; i <= this.GridView1.Rows.Count - 1; i++)
        {
            string sStatus1 = ds1.Tables[0].Rows[i].ItemArray[5].ToString();
            if (sStatus1.Equals("2"))
            {
                ((Label)GridView1.Rows[i].FindControl("Label6")).Text = "拒绝";
                ((Label)GridView1.Rows[i].FindControl("Label6")).ForeColor = System.Drawing.Color.White;
                ((Label)GridView1.Rows[i].FindControl("Label6")).BackColor = System.Drawing.Color.Red;

            }
            else if (sStatus1.Equals("1"))
            {
                ((Label)GridView1.Rows[i].FindControl("Label6")).Text = "允许";
                ((Label)GridView1.Rows[i].FindControl("Label6")).BackColor = System.Drawing.Color.Blue;
                ((Label)GridView1.Rows[i].FindControl("Label6")).ForeColor = System.Drawing.Color.White;

            }
            else
            {
                ((Label)GridView1.Rows[i].FindControl("Label6")).Text = "申请中";
            }
        }

        
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        ViewState["id"] = GridView1.SelectedValue.ToString();
        BindDetailView(ViewState["id"].ToString());
    }
    private void BindDetailView(string SelectId)
    {

        MaterialApplyTableDetails matd = new MaterialApplyTableDetails(SelectId);
        DataSet ds2 = matd.getEquipDetails();


        this.DetailsView1.DataSource = ds2;
        this.DetailsView1.DataBind();

       /*   用来把Detail中的状态数字转化为文字说明
       string sStatus2 = ds2.Tables[0].Rows[0].ItemArray[5].ToString();
        if (sStatus2.Equals("2"))
        {
            ((Label)DetailsView1.Rows[0].FindControl("Label6")).Text = "拒绝";
        }
        else if (sStatus2.Equals("1"))
        {
            ((Label)DetailsView1.Rows[0].FindControl("Label6")).Text = "允许";
        }
        else
        {
            ((Label)DetailsView1.Rows[0].FindControl("Label6")).Text = "申请中";
        }
        */
        
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

    

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.GridView1.PageIndex = e.NewPageIndex;
        bandgrid();
    }

    protected void DetailsView1_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
    {
       // string strBeforeMaterialName = ViewState["id"].ToString();//为什么不能取出第一个值？



        string strApplyId = ((TextBox)DetailsView1.Rows[0].FindControl("TextBox1")).Text.ToString();
        string strStatus = ((DropDownList)DetailsView1.Rows[5].FindControl("DropDownList1")).SelectedValue.ToString();

        string strRemark = ((TextBox)DetailsView1.Rows[6].FindControl("TextBox7")).Text.ToString();

        MaterialApplyTableUpdate matu = new MaterialApplyTableUpdate(strApplyId, strStatus, strRemark);
        matu.UpdateMaterialApplyTable();
        
       
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

                string strApplyId = GridView1.DataKeys[i].Value.ToString();
                MaterialApplyTableDelete matd = new MaterialApplyTableDelete(strApplyId);
                matd.DeleteMaterialApplyTable();


               


            }
        }
        bandgrid();
        Response.Write("<script>alert('删除成功！')</script>");

    }


}
