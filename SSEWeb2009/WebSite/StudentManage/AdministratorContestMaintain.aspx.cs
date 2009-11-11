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

public partial class StudentManage_AdministratorContestMaintain : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

   private static string tempID;

   protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
   {
       if (e.Row.RowType == DataControlRowType.DataRow)
       {
           SqlDataSource s = (SqlDataSource)e.Row.FindControl("SqlDataSource2");
           tempID = Convert.ToString(((DataRowView)e.Row.DataItem).Row.ItemArray[0]);
           s.SelectParameters[0].DefaultValue = tempID;
       }
   }

    protected string ReturnRank(object _rank)
    {
        int intRank = Convert.ToInt32(_rank);
        switch (intRank)
        { 
            case 0:
                return "入围奖";
            case 1:
                return "三等奖";
            case 2:
                return "二等奖";
            case 3:
                return "一等奖";
            default: return "";
        }
    }


    protected void BtnInsert_Click(object sender, EventArgs e)
    {
        try
        {
            SqlDataSource1.InsertParameters["Name"].DefaultValue = TxtName.Text;
            SqlDataSource1.InsertParameters["Weight"].DefaultValue = TxtWeight.Text;
            SqlDataSource1.InsertParameters["Year"].DefaultValue = TxtYear.Text;
            SqlDataSource1.Insert();
            GridView1.DataBind();
            if (GridView1.PageCount != 0)
                GridView1.PageIndex = GridView1.PageCount - 1;

            TxtName.Text = "";
            TxtYear.Text = "";
            TxtWeight.Text = "";
        }
        catch
        {
            Response.Write("<script language=javascript>alert('添加失败');</script>");
            WizardInsert.MoveTo(WizardStep1);
        }
    }

    protected void BtnInsertContestRank_Click(object sender, EventArgs e)
    {
        SqlDataSource s = GridView1.Rows[0].Cells[0].FindControl("SqlDataSource2") as SqlDataSource;
        
            s.InsertParameters["ID"].DefaultValue = tempID;

            try
            {
                for (int i = 0; i < 4; i++)
                {
                    string tempStr = "TxtPoint" + (i + 1).ToString();
                    TextBox tempTxt = (TextBox)((Wizard)sender).FindControl(tempStr);   //ai...page.findcontrol 果然是错的

                    s.InsertParameters["Point"].DefaultValue = tempTxt.Text;
                    s.InsertParameters["Rank"].DefaultValue = (3-i).ToString();
                    
                    s.Insert();
                    tempTxt.Text = "";
                }
              
                GridView1.DataBind();

                int index = 0;
                WizardStepBase step = WizardInsert.WizardSteps[index];
                WizardInsert.MoveTo(step);
            }
            catch
            {
                Response.Write("<script language=javascript>alert('sqldata2添加失败');</script>");
            }
    }
}
