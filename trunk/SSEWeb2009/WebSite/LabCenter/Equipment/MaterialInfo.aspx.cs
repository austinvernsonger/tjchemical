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
using System.Text;

using LabCenter.LabUtility.LoginUtility;

public partial class LabCenter_Equipment_MaterialInfo : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        this.btndel.Attributes.Add("onClick", "javascript:return   confirm('确定删除吗？');");
        this.Button1.Attributes.Add("onClick", "javascript:return   confirm('确定导出吗？');");
        if (!IsPostBack)
        {     
            LoginCtrl.CheckAuthorityRedirect(this, 7, 1);
                    
            bandgrid();

        }
    }
    private void bandgrid()
    {
       // EquiView ev = new EquiView();
        MaterialInfo mi = new MaterialInfo();
        DataSet ds1 = mi.getMaterialInfo();
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

        MaterialInfoDetails mid = new MaterialInfoDetails(SelectId);
        DataSet ds2 = mid.getEquipDetails();


        this.DetailsView1.DataSource = ds2;
        this.DetailsView1.DataBind();

    }
    protected void DetailsView1_ModeChanging(object sender, DetailsViewModeEventArgs e)
    {
        //判断模式
       // if (e.NewMode == DetailsViewMode.Insert)
        //{
       //     DetailsView1.ChangeMode(DetailsViewMode.Insert);
       // }
        if (e.NewMode == DetailsViewMode.Edit)
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
        string strMaterialName = ((TextBox)DetailsView1.Rows[0].Cells[1].Controls[0]).Text.ToString();
        
        string strAccount = ((TextBox)DetailsView1.Rows[1].Cells[1].Controls[0]).Text.ToString();
        string strUnit = ((TextBox)DetailsView1.Rows[2].Cells[1].Controls[0]).Text.ToString();
        
        string strStatus = ((TextBox)DetailsView1.Rows[3].Cells[1].Controls[0]).Text.ToString();
        
        string strRemark = ((TextBox)DetailsView1.Rows[4].Cells[1].Controls[0]).Text.ToString();

        MaterialInfoInsert mii= new MaterialInfoInsert(strMaterialName, strAccount, strUnit, strStatus, strRemark);
        mii.InsertMaterialInfo();
        bandgrid();
        DetailsView1.ChangeMode(DetailsViewMode.ReadOnly);
        ViewState["id"] = GridView1.Rows.Count;
        BindDetailView(ViewState["id"].ToString());
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.GridView1.PageIndex = e.NewPageIndex;
        bandgrid();
    }

    protected void DetailsView1_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
    {
        string strBeforeMaterialName = ViewState["id"].ToString();//为什么不能取出第一个值？
        string strAfterMaterialName = ((TextBox)DetailsView1.Rows[0].Cells[1].Controls[0]).Text.ToString();

        string strAccount = ((TextBox)DetailsView1.Rows[1].Cells[1].Controls[0]).Text.ToString();
        string strUnit = ((TextBox)DetailsView1.Rows[2].Cells[1].Controls[0]).Text.ToString();

        string strStatus = ((TextBox)DetailsView1.Rows[3].Cells[1].Controls[0]).Text.ToString();

        string strRemark = ((TextBox)DetailsView1.Rows[4].Cells[1].Controls[0]).Text.ToString();

        MaterialInfoUpdate miu = new MaterialInfoUpdate(strBeforeMaterialName,strAfterMaterialName, strAccount, strUnit, strStatus, strRemark);
        miu.UpdateMaterialInfo();
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

     protected void AddButton_Click(object sender, EventArgs e)
     {
         DetailsView1.ChangeMode(DetailsViewMode.Insert);
     }

    protected void btndel_Click(object sender, EventArgs e)
    {
        for (int i = 0; i <= this.GridView1.Rows.Count - 1; i++)
        {
            CheckBox check = (CheckBox)this.GridView1.Rows[i].FindControl("checkdel");
            if (check.Checked == true)
            {

                string strMaterialName = GridView1.DataKeys[i].Value.ToString();
                MaterialInfoDelete mid = new MaterialInfoDelete(strMaterialName);
                mid.DeleteMaterialInfo();


            }
        }
        bandgrid();
        Response.Write("<script>alert('删除成功！')</script>");

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        MaterialInfo mi = new MaterialInfo();
        DataSet ds3 = mi.getMaterialInfo();


        
        string strfileName = "耗材信息表.xls";
        CreateExcel(ds3, strfileName);

    }

    public void CreateExcel(DataSet ds, string fileName)
    {

        StringBuilder strb = new StringBuilder();
        strb.Append(" <html xmlns:o=\"urn:schemas-microsoft-com:office:office\"");
        strb.Append("xmlns:x=\"urn:schemas-microsoft-com:office:excel\"");
        strb.Append("xmlns=\"http://www.w3.org/TR/REC-html40\"");
        strb.Append(" <head> <meta http-equiv='Content-Type' content='text/html; charset=gb2312'>");
        strb.Append(" <style>"); strb.Append(".xl26"); strb.Append(" {mso-style-parent:style0;");
        strb.Append(" font-family:\"Times New Roman\", serif;"); strb.Append(" mso-font-charset:0;");
        strb.Append(" mso-number-format:\"@\";}"); strb.Append(" </style>"); strb.Append(" <xml>");
        strb.Append(" <x:ExcelWorkbook>"); strb.Append(" <x:ExcelWorksheets>"); strb.Append(" <x:ExcelWorksheet>");
        strb.Append(" <x:Name>Sheet1 </x:Name>");
        strb.Append(" <x:WorksheetOptions>");
        strb.Append(" <x:DefaultRowHeight>285 </x:DefaultRowHeight>");
        strb.Append(" <x:Selected/>"); strb.Append(" <x:Panes>");
        strb.Append(" <x:Pane>"); strb.Append(" <x:Number>3 </x:Number>");
        strb.Append(" <x:ActiveCol>1 </x:ActiveCol>");
        strb.Append(" </x:Pane>"); strb.Append(" </x:Panes>");
        strb.Append(" <x:ProtectContents>False </x:ProtectContents>");
        strb.Append(" <x:ProtectObjects>False </x:ProtectObjects>");
        strb.Append(" <x:ProtectScenarios>False </x:ProtectScenarios>");
        strb.Append(" </x:WorksheetOptions>");
        strb.Append(" </x:ExcelWorksheet>");
        strb.Append(" <x:WindowHeight>6750 </x:WindowHeight>");
        strb.Append(" <x:WindowWidth>10620 </x:WindowWidth>");
        strb.Append(" <x:WindowTopX>480 </x:WindowTopX>");
        strb.Append(" <x:WindowTopY>75 </x:WindowTopY>");
        strb.Append(" <x:ProtectStructure>False </x:ProtectStructure>");
        strb.Append(" <x:ProtectWindows>False </x:ProtectWindows>");
        strb.Append(" </x:ExcelWorkbook>"); strb.Append(" </xml>");
        strb.Append("");
        strb.Append(" </head> <body> <table align=\"center\" style='border-collapse:collapse;table-layout:fixed'> <tr>");
        if (ds.Tables.Count > 0)
        {
            //写列标题 
            int columncount = ds.Tables[0].Columns.Count;
            for (int columi = 0; columi < columncount; columi++)
            {
                strb.Append(" <td> <b>" + ds.Tables[0].Columns[columi] + " </b> </td>");
            }
            strb.Append(" </tr>");
            //写数据
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                strb.Append(" <tr>");
                for (int j = 0; j < ds.Tables[0].Columns.Count; j++)
                {
                    strb.Append(" <td class='xl26'>" + ds.Tables[0].Rows[i][j].ToString() + " </td>");
                }
                strb.Append(" </tr>");
            }
        }
        strb.Append(" </body> </html>");
        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.Buffer = true;
        HttpContext.Current.Response.Charset = "GB2312";
        /*
        Response.AppendHeader("Content-Disposition", "attachment;filename=" + fileName); 
         */
        HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.UTF7;
        HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(fileName, Encoding.UTF8).ToString());


        HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
        //设置输出流为简体中文 
        HttpContext.Current.Response.ContentType = "application/ms-excel";
        //设置输出文件类型为excel文件。 
        this.EnableViewState = false;
        HttpContext.Current.Response.Write(strb);
        HttpContext.Current.Response.End();
    } 
    
}
