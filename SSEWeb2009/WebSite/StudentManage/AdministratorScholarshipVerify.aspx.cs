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

using StudentManages.Sql;
using System.Text;
using System.Collections.Generic;
using StudentManages;

public partial class StudentManage_AdministratorScholarshipVerify : System.Web.UI.Page
{
    BaseOperate sqlBaseOp;
    protected void Page_Load(object sender, EventArgs e)
    {
        sqlBaseOp = new BaseOperate();
    }

    protected void DDLGradeClass_SelectedIndexChanged(object sender, EventArgs e)
    {
         string str = DDLGradeClass.SelectedItem.Value;
         if (str != "-1")
         {
             Array strArr = str.Split(',');
             string gradeStr = Convert.ToString(strArr.GetValue(0));
             string classStr = Convert.ToString(strArr.GetValue(1));
             gradeHF.Value = gradeStr;
             classHF.Value = classStr;
             GVScholarUpdate(gradeStr, classStr);//studentID(-1表示不用考虑后两个参数),SAP
         }
    }
    private void GVScholarUpdate(string gradeStr, string classStr)
    {
        StringBuilder sb = new StringBuilder("select s.StudentID,s.Name,s.Grade,s.Class,ss.GPA,ss.SAP,ss.CPA,ss.TotalPoint ");
        sb.Append("from Student s ");
        sb.Append("join StudentScholarship ss ");
        sb.Append("on ss.StudentID = s.StudentID ");
        sb.Append("and s.Grade='");
        sb.Append(gradeStr);
        sb.Append("' and s.Class='");
        sb.Append(classStr);
        sb.Append("'");

        DataSet ds = sqlBaseOp.Select(sb.ToString());
        Session["GVScholar_DT"] = ds.Tables[0];
        GVScholar.DataSource = ds;
        GVScholar.DataBind();
    }

    
   
    protected void GVScholar_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GVOP.Paging(e.NewPageIndex, (DataTable)Session["GVScholar_DT"], (GridView)sender);
    }
    protected void GVScholar_OnSorting(object sender, GridViewSortEventArgs e)
    {
        GVOP.Sorting(e.SortExpression.ToString(), (GridView)sender, (DataTable)Session["GVScholar_DT"]);
    }

    protected void btnTPCalcu_Click(object sender, EventArgs e)
    {
        DataTable dt=(DataTable)Session["GVScholar_DT"];
        string reportStr="计算成功！";
        foreach (DataRow dr in dt.Rows)
        {
            string GPAStr = dr["GPA"].ToString();
            string SAPStr = dr["SAP"].ToString();
            string CPAStr = dr["CPA"].ToString();

            //如果有GPA或SAP或CPA为空，则计算不为空的项，并报告
            if (GPAStr == "" || SAPStr == "" || CPAStr == "")
            {
                reportStr = "个别同学总绩点尚未计算！";
                StringBuilder sb = new StringBuilder("update StudentScholarship set TotalPoint=NULL where StudentID='");
                sb.Append(dr["StudentID"].ToString());
                sb.Append("'");
                sqlBaseOp.Update(sb.ToString());
            }
            else
            {
                //计算 每一项 总绩点=GPA*0.75+CPA*0.15+SAP*0.1，并写入数据库
                double totalPoint = float.Parse(GPAStr) * 0.75 + float.Parse(SAPStr) * 0.15 + float.Parse(CPAStr) * 0.1;

                StringBuilder sb = new StringBuilder("update StudentScholarship set TotalPoint='");
                sb.Append(totalPoint);
                sb.Append("' where StudentID='");
                sb.Append(dr["StudentID"].ToString());
                sb.Append("'");
                sqlBaseOp.Update(sb.ToString());
            }
        }
        Response.Write(GVOP.Alert(reportStr));
        GVScholarUpdate(gradeHF.Value,classHF.Value);
    }
}
