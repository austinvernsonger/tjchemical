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
using System.Collections.Generic;

using LabCenter.Reservation;
using System.Text;
using LabCenter.LabUtility.LoginUtility;

public partial class LabCenter_Reservation_Back_CheckTotalInfo : System.Web.UI.Page
{
    string termspath = AppDomain.CurrentDomain.BaseDirectory+
                           @"LabCenter\XmlConfig\Terms.xml";
    string bcpath = AppDomain.CurrentDomain.BaseDirectory +
                           @"LabCenter\XmlConfig\BasicConfig.xml";
    readonly static string CheckBoxListName = "_CheckBoxList";
    //readonly static string CheckBoxContentName = "CheckBoxContentName";

    

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           
                LoginCtrl.CheckAuthorityRedirect(this, 8, 1);

            
            //读取所有学期配置
            TermList tl = BackManager.GetTermList(termspath);
            for (int i = 0; i < tl.Terms.Count; i++)
            {
                ListItem termli = new ListItem(tl.Terms[i].ToString());
                ddlterm.Items.Add(termli);
            }
            //放入记录checkbox状态的array到session
            List<int> cbliststatus = new List<int>();
            Session[CheckBoxListName] = cbliststatus;

            ddlterm.Items.Insert(0, "");
        }
    }

    protected void ddlterm_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet ds = _GetBindDataAll();
        if (ds != null)
        {
            GV.DataSource = ds;
            GV.DataBind();
        }
    }

    protected DataSet _GetBindData()
    {
        List<int> list=(List<int>)Session[CheckBoxListName];
        if (list != null)
        {
            CheckTotalInfoManager c = new CheckTotalInfoManager();
            DataSet ds = c.GetTotalInfo(this.ddlterm.SelectedItem.Text, list);
            return ds;
        }
        else
        {
            return null;
        }
    }

    protected DataSet _GetBindDataAll()
    {
        CheckTotalInfoManager c = new CheckTotalInfoManager();
        DataSet ds = c.GetTotalInfo(this.ddlterm.SelectedItem.Text);
        return ds;
    }

    protected void btnselectterm_Click(object sender, EventArgs e)
    {
        DataSet ds = _GetBindData();
        if (ds != null)
        {
            GV.DataSource = ds;
            GV.DataBind();
        }
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
    protected void btnexport_Click(object sender, EventArgs e)
    {
        DataSet ds = _GetBindData();
        if (ds!=null)
        {
            CreateExcel(ds, "实验统计信息.xls");
        }
    }

    
}
