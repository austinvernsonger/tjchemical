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


public partial class LabCenter_Equipment_UserDeviceApplyTable : System.Web.UI.Page
{
    string strApplierId;  //得到申请用户的名字
    protected void Page_Load(object sender, EventArgs e)
    {
        strApplierId = Session["IdentifyNumber"].ToString();
        this.btndel.Attributes.Add("onClick", "javascript:return   confirm('确定要取消申请吗？');");
        if (!IsPostBack)
        {
            bandgrid();
            GridView2_bandgrid();

        }
    }
    private void bandgrid()
    {
        UserDeviceApplyingTable udat = new UserDeviceApplyingTable(strApplierId);

        DataSet ds1 = udat.getUserDeviceApplyingTable();


        this.GridView1.DataSource = ds1;
        this.GridView1.DataBind();

        for (int i = 0; i <= this.GridView1.Rows.Count - 1; i++)
        {
            string sStatus1 = ds1.Tables[0].Rows[i].ItemArray[4].ToString();
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
            else if (sStatus1.Equals("3"))
            {
                ((Label)GridView1.Rows[i].FindControl("Label6")).Text = "已领取";

            }
            else
            {
                ((Label)GridView1.Rows[i].FindControl("Label6")).Text = "申请中";
            }
        }
    }

    private void GridView2_bandgrid()
    {
        UserDeviceAppliedTable udat = new UserDeviceAppliedTable(strApplierId);

        DataSet ds1 = udat.getUserDeviceAppliedTable();


        this.GridView2.DataSource = ds1;
        this.GridView2.DataBind();

        for (int i = 0; i <= this.GridView2.Rows.Count - 1; i++)
        {
            string sStatus1 = ds1.Tables[0].Rows[i].ItemArray[4].ToString();
            if (sStatus1.Equals("2"))
            {
                ((Label)GridView2.Rows[i].FindControl("Label6")).Text = "拒绝";
                ((Label)GridView2.Rows[i].FindControl("Label6")).ForeColor = System.Drawing.Color.White;
                ((Label)GridView2.Rows[i].FindControl("Label6")).BackColor = System.Drawing.Color.Red;

            }
            else if (sStatus1.Equals("1"))
            {
                ((Label)GridView2.Rows[i].FindControl("Label6")).Text = "允许";
                ((Label)GridView2.Rows[i].FindControl("Label6")).BackColor = System.Drawing.Color.Blue;
                ((Label)GridView2.Rows[i].FindControl("Label6")).ForeColor = System.Drawing.Color.White;

            }
            else if (sStatus1.Equals("3"))
            {
                ((Label)GridView2.Rows[i].FindControl("Label6")).Text = "已领取";

            }
            else
            {
                ((Label)GridView2.Rows[i].FindControl("Label6")).Text = "申请中";
            }
        }

    }


    
   /*
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        ViewState["id"] = GridView1.SelectedValue.ToString();
        BindDetailView(ViewState["id"].ToString());
    }
   
    private void BindDetailView(string SelectId)
    {



        DeviceApplyTableDetails datd = new DeviceApplyTableDetails(SelectId);
        DataSet ds2 = datd.getDeviceApplyTableDetails();


        this.DetailsView1.DataSource = ds2;
        this.DetailsView1.DataBind();

        
    }
    */

   


    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.GridView1.PageIndex = e.NewPageIndex;
        bandgrid();
    }

    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.GridView2.PageIndex = e.NewPageIndex;
        GridView2_bandgrid();
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
    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
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
                DeviceApplyTableDelete datd = new DeviceApplyTableDelete(strApplyId);
                datd.DeleteMaterialApplyTable();







            }
        }
        bandgrid();
        Response.Write("<script>alert('取消申请成功！')</script>");

    }


}

