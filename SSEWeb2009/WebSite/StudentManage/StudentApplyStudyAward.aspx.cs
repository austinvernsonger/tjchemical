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
using StudentManages;
using StudentManages.Sql;

using System.Text;

public partial class StudentManage_StudentApplyStudyAward : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SDS_StudentScholarship.SelectCommand = "select SASE from StudentScholarship where StudentID=" + Convert.ToString(Session["IdentifyNumber"]);
            //获取绩点和社会自评

            DataView tmp = (DataView)SDS_StudentScholarship.Select(new DataSourceSelectArguments());
            string sase = Convert.ToString(tmp[0][0]);
            TxtSASE.Text = sase;
        }
    }
    protected void ButtonAdd_Click(object sender, EventArgs e)
    {
        //try
        //{
            ClearStudentScholarship();
            SDS_ContestStudent.Insert();
            GVOP.Alert("添加成功！");
        //}
        //catch
        //{
        //    GVOP.Alert("添加失败！");
        //}
    }
    protected string GetName(object _id)
    {
        SDS_Contest_ID_Name.SelectParameters["ID"].DefaultValue = _id.ToString();
        DataView tmp = (DataView)SDS_Contest_ID_Name.Select(new DataSourceSelectArguments());
        string returnStr = Convert.ToString(tmp[0][0]);
        return returnStr;
    }

    protected string GetRank(object _rank)
    {
        int rank=Convert.ToInt32(_rank);
        string returnStr;
        switch (rank)
        { 
            case 0:
                returnStr = "入围奖";
                break;
            case 1:
                returnStr = "三等奖";
                break;
            case 2:
                returnStr = "二等奖";
                break;
            case 3:
                returnStr = "一等奖";
                break;
            default:
                returnStr = "";
                break;
        }
        return returnStr;
    }

    protected string GetStatus(object _status)
    {
        if (_status is DBNull)
            return "未审核";
        else
        {
            int status = Convert.ToInt32(_status);
            if (status == 0)
                return "审核未通过";
            else
                return "审核通过";
        }
    }



    protected void Button1_Click(object sender, EventArgs e)
    {
        string studentID = Convert.ToString(Session["IdentifyNumber"]);
        if (TxtSASE.Text == "")
            Response.Write( GVOP.Alert("社会活动自评为0分！"));
        else
        {
            SDS_StudentScholarship.UpdateCommand = "update StudentScholarship set SASE ='" + TxtSASE.Text 
                + "',SAP=NULL,TotalPoint=NULL where StudentID=" + Convert.ToString(Session["IdentifyNumber"]);
            try
            {
                SDS_StudentScholarship.Update();
                GVOP.Alert("提交成功！");
            }
            catch
            {
                GVOP.Alert("提交失败！");
            }

        }
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        ClearStudentScholarship();
    }

    private void ClearStudentScholarship()
    {
        //studentscholarship中，ctw,ctp,cpa,totalpoing均为null
        BaseOperate sqlBs = new BaseOperate();
        string studentID = Convert.ToString(Session["IdentifyNumber"]);
        StringBuilder sb = new StringBuilder("update StudentScholarship set CTW=NULL,CTP=NULL,CPA=NULL,TotalPoint=NULL "); 
        sb.Append("where StudentID='");
        sb.Append(studentID);
        sb.Append("'");
        sqlBs.Update(sb.ToString());
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        DataView dv = (DataView)SDS_ContestStudent.Select(DataSourceSelectArguments.Empty);
        GVOP.Paging(e.NewPageIndex,(GridView)sender);

    }
}
