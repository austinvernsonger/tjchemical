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
using System.IO;
using System.Data.OleDb;

public partial class LabCenter_Equipment_DeviceInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {     
       
       
              if (!IsPostBack)
                            {        
                                LoginCtrl.CheckAuthorityRedirect(this, 7, 1);
                               
                            }  
                          
             
       
        this.btndel.Attributes.Add("onClick", "javascript:return   confirm('确定删除吗？');");
        this.Button1.Attributes.Add("onClick", "javascript:return   confirm('确定导出吗？');");
        if (!IsPostBack)
        {
            bandgrid();

        }
    }
    protected void GridView1_OnRowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt16(e.CommandArgument.ToString());

        if (e.CommandName == "Details")
        {
            string SelectId = GridView1.DataKeys[index].Value.ToString().Trim();
            ViewState["id"] = SelectId;
            EquipDetails ed = new EquipDetails(SelectId);
            DataSet ds2 = ed.getEquipDetails();

            this.DetailsView1.DataSource = ds2;
            this.DetailsView1.DataBind();
        }
        if (e.CommandName == "Page")
        {

        }


    }
    private void bandgrid()
    {
        EquiView ev = new EquiView();
        DataSet ds1 = ev.EquipmentView();
        this.GridView1.DataSource = ds1;
        this.GridView1.DataBind();
    }
 
    
    private void BindDetailView(string SelectId)
    {

        EquipDetails ed = new EquipDetails(SelectId);
        DataSet ds2 = ed.getEquipDetails();

        this.DetailsView1.DataSource = ds2;
        this.DetailsView1.DataBind();

    }
    protected void ImportBtn_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile)
        {
            string extension = Path.GetExtension(FileUpload1.PostedFile.FileName).ToUpper();
            if (extension!=".XLS")
            {
                ImportLabel.Text = "文件格式不正确，请导入Excel文件";
                return;
            }
            string filename = FileUpload1.PostedFile.FileName;
            DataSet ds = ImportExcel(filename);
            for (int i = 0; i < ds.Tables[0].Rows.Count;i++ )
            {
                string[]str=new string [14];
                for (int j = 0; j < 14;j++ )
                {
                    str[j] = ds.Tables[0].Rows[i][j].ToString();
                    
                }
                DeviceInsertEquip die = new DeviceInsertEquip(str[0], str[1], str[2], str[3], str[4], str[5], str[6], str[7], str[8], str[9], str[10], str[11], str[12], str[13]);
                die.InsertEquip();
            }
            bandgrid();
        }
    }
    private DataSet ImportExcel(string strFileName)
    {
        if (strFileName == "")
            return null;
        string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" +
                         "Data Source=" + strFileName + ";" +
             "Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1\"";
        OleDbConnection dbconn = new OleDbConnection(strConn);
        dbconn.Open();
        DataSet ExcelDs = new DataSet();
        try
        {

            OleDbDataAdapter ExcelDA = new OleDbDataAdapter("SELECT *  FROM [Sheet1$]", strConn);
            ExcelDA.Fill(ExcelDs, "ExcelInfo");
        }
        catch (Exception err)
        {
            System.Console.WriteLine(err.ToString());
        }
        return ExcelDs;
    }
    protected void AddBtn_Click(object sender, EventArgs e)
    {
        DetailsView1.ChangeMode(DetailsViewMode.Insert);
       
    }
    protected void DetailsView1_ModeChanging(object sender, DetailsViewModeEventArgs e)
    {
        //判断模式
        // if (e.NewMode == DetailsViewMode.Insert)
         //{
           // DetailsView1.ChangeMode(DetailsViewMode.Insert);
        //}
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
        string strDeviceId = ((TextBox)DetailsView1.Rows[0].Cells[1].Controls[0]).Text.ToString();
        string strDeviceName = ((TextBox)DetailsView1.Rows[1].Cells[1].Controls[0]).Text.ToString();
        string strModel = ((TextBox)DetailsView1.Rows[2].Cells[1].Controls[0]).Text.ToString();
        string strFormat = ((TextBox)DetailsView1.Rows[3].Cells[1].Controls[0]).Text.ToString();
        string strAccount = ((TextBox)DetailsView1.Rows[4].Cells[1].Controls[0]).Text.ToString();
        string strPrice = ((TextBox)DetailsView1.Rows[5].Cells[1].Controls[0]).Text.ToString();
        string strDate = ((TextBox)DetailsView1.Rows[6].Cells[1].Controls[0]).Text.ToString();
        string strFactory = ((TextBox)DetailsView1.Rows[7].Cells[1].Controls[0]).Text.ToString();
        string strStatus = ((TextBox)DetailsView1.Rows[8].Cells[1].Controls[0]).Text.ToString();
        string strLocation = ((TextBox)DetailsView1.Rows[9].Cells[1].Controls[0]).Text.ToString();
        string strLocation2 = ((TextBox)DetailsView1.Rows[10].Cells[1].Controls[0]).Text.ToString();
        string strUser = ((TextBox)DetailsView1.Rows[11].Cells[1].Controls[0]).Text.ToString();
        string strAdmin = ((TextBox)DetailsView1.Rows[12].Cells[1].Controls[0]).Text.ToString();
        string strRemark = ((TextBox)DetailsView1.Rows[13].Cells[1].Controls[0]).Text.ToString();

        DeviceInsertEquip die = new DeviceInsertEquip(strDeviceId, strDeviceName, strModel, strFormat, strAccount, strPrice, strDate, strFactory, strStatus, strLocation, strLocation2, strUser, strAdmin, strRemark);
        die.InsertEquip();
        bandgrid();
        DetailsView1.ChangeMode(DetailsViewMode.ReadOnly);
        //BindDetailView(ViewState["id"].ToString());
        ViewState["id"] = strDeviceId;
        BindDetailView(strDeviceId);
       
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.GridView1.PageIndex = e.NewPageIndex;
        bandgrid();
    }

    protected void DetailsView1_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
    {
        string strDeviceId = ViewState["id"].ToString();//为什么不能取出第一个值？
           //string strDeviceId=((TextBox)DetailsView1.Rows[0].Cells[1].Controls[0]).Text.ToString();
        string strDeviceName = ((TextBox)DetailsView1.Rows[1].Cells[1].Controls[0]).Text.ToString();
        string strModel = ((TextBox)DetailsView1.Rows[2].Cells[1].Controls[0]).Text.ToString();
        string strFormat = ((TextBox)DetailsView1.Rows[3].Cells[1].Controls[0]).Text.ToString();
        string strAccount = ((TextBox)DetailsView1.Rows[4].Cells[1].Controls[0]).Text.ToString();
        string strPrice = ((TextBox)DetailsView1.Rows[5].Cells[1].Controls[0]).Text.ToString();
        string strDate = ((TextBox)DetailsView1.Rows[6].Cells[1].Controls[0]).Text.ToString();
        string strFactory = ((TextBox)DetailsView1.Rows[7].Cells[1].Controls[0]).Text.ToString();
        string strStatus = ((TextBox)DetailsView1.Rows[8].Cells[1].Controls[0]).Text.ToString();
        string strLocation = ((TextBox)DetailsView1.Rows[9].Cells[1].Controls[0]).Text.ToString();
        string strLocation2 = ((TextBox)DetailsView1.Rows[10].Cells[1].Controls[0]).Text.ToString();
        string strUser = ((TextBox)DetailsView1.Rows[11].Cells[1].Controls[0]).Text.ToString();
        string strAdmin = ((TextBox)DetailsView1.Rows[12].Cells[1].Controls[0]).Text.ToString();
        string strRemark = ((TextBox)DetailsView1.Rows[13].Cells[1].Controls[0]).Text.ToString();

        DeviceUpdateEquip due = new DeviceUpdateEquip(strDeviceId, strDeviceName, strModel, strFormat, strAccount, strPrice, strDate, strFactory, strStatus, strLocation, strLocation2, strUser, strAdmin, strRemark);
        due.UpdateEquip();
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
        bool deleted = false;
        for (int i = 0; i <= this.GridView1.Rows.Count - 1; i++)
        {
            CheckBox check = (CheckBox)this.GridView1.Rows[i].FindControl("checkdel");
            if (check.Checked == true)
            {
                
                string strDeviceId = GridView1.DataKeys[i].Value.ToString();
                DeviceDeleteEquip dde = new DeviceDeleteEquip(strDeviceId);
                dde.DeleteEquip();
                deleted = true;
          
            }
        }
        if (!deleted)
        {
            Response.Write("<script>alert('没有选择任何项！')</script>");
            return;
        }
        bandgrid();
        
        Response.Write("<script>alert('删除成功！')</script>");
       

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        ExportEquiView eev = new ExportEquiView();


        DataSet ds3 = eev.getExportEquiView();
        string strfileName = "设备信息表.xls";
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
