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


public partial class StudentManage_AdministratorContestVerif : System.Web.UI.Page
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

            GVContestVerifyUpdate(gradeStr, classStr);//studentID(-1表示不用考虑后两个参数),SAP
            ClearDetail();
        }
    }

    private void ClearDetail()
    {
        lblMaxTotalPoint.Text = "";
        GVStudentContest.DataSource = null;
        GVStudentContest.DataBind();
        lblName.Text = "";
        lblStudentID.Text = "";
    }

    private void GVContestVerifyUpdate(string gradeStr, string classStr)
    {
        StringBuilder sb = new StringBuilder("select s.StudentID,s.Name,s.Grade,s.Class,ss.CTW,ss.CTP,ss.CPA ");
        sb.Append("from Student s ");
        sb.Append("join StudentScholarship ss ");
        sb.Append("on ss.StudentID = s.StudentID ");
        sb.Append("and s.Grade='");
        sb.Append(gradeStr);
        sb.Append("' and s.Class='");
        sb.Append(classStr);
        sb.Append("'");

        DataSet ds = sqlBaseOp.Select(sb.ToString());
        Session["GVContestVerify_DT"] = ds.Tables[0];
        GVContestVerify.DataSource = ds;
        GVContestVerify.DataBind();
    }



    protected string GetStatus(object _ctw)
    {
        string ctw = Convert.ToString(_ctw);
        if (ctw == "")
        {
            return "未审核";
        }
        else
            return "已审核";

    }

    protected void GVContestVerify_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Verify")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow gvrow = GVContestVerify.Rows[index];
            string studentID = gvrow.Cells[0].Text;
            string name = gvrow.Cells[1].Text;
            lblName.Text = name;
            lblStudentID.Text = studentID;
            GVStudentContestUpdate(studentID);
        }
    }

    private void GVStudentContestUpdate(string studentID)
    {
        StringBuilder sb = new StringBuilder(" select c.ID,c.Name,c.Weight,cs.StudentID,cs.Rank,cs.Status,cr.Point ");
        sb.Append("from Contest c,ContestStudent cs,ContestRank cr ");
        sb.Append("where StudentID='");
        sb.Append(studentID);
        sb.Append("' and c.ID=cs.ID and cs.ID=cr.ID and cs.Rank=cr.Rank");
        DataSet ds = sqlBaseOp.Select(sb.ToString());
        //SetStatusSession(ds.Tables[0]);
        Session["GVStudentContest_DT"] = ds.Tables[0];
        GVStudentContest.DataSource = ds;
        GVStudentContest.DataBind();
    }

    protected string GetWeightName(object _weight)
    {
        string weight = Convert.ToString(_weight);
        switch (weight)
        {
            case "4":
                return "一类";
            case "3":
                return "二类";
            case "2":
                return "三类";
            case "1":
                return "四类";
            default:
                return "";
        }
    }

    protected string GetPointName(object _point)
    {
        string point = Convert.ToString(_point);
        switch (point)
        {
            case "3":
                return "一等奖";
            case "2":
                return "二等奖";
            case "1":
                return "三等奖";
            case "0":
                return "四等奖";
            default:
                return "";

        }
    }

    protected void GVStudentContest_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //绑定“审核状态”数据
        string studentID = lblStudentID.Text;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string ID = e.Row.Cells[0].Text;

            StringBuilder sb = new StringBuilder("select Status from ContestStudent ");
            sb.Append("where ID='");
            sb.Append(ID);
            sb.Append("' and StudentID='");
            sb.Append(studentID);
            sb.Append("'");
            DataSet ds = sqlBaseOp.Select(sb.ToString());
            DataTable dt = ds.Tables[0];
            string status = Convert.ToString(((DataRow)dt.Rows[0]).ItemArray[0]);

            DropDownList ddl = (DropDownList)e.Row.FindControl("DDLVerify");
            if (status == "")
                ddl.SelectedValue = "NULL";
            else
                ddl.SelectedValue = status;
        }
    }


    protected void DDLVerify_OnSelectedIndexChanged(Object sender, EventArgs e)
    {
        string str = ((DropDownList)sender).SelectedValue;
        DDLVerifyHF.Value = str;
    }

    protected void GVStudentContest_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Verify")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            string ID = GVStudentContest.Rows[index].Cells[0].Text.ToString();
            string status = DDLVerifyHF.Value;
            string studentID = lblStudentID.Text;

            StringBuilder sb = new StringBuilder("update ContestStudent set Status=");
            if (status == "NULL")
                sb.Append(status);
            else
            {
                status = status == "True" ? "1" : "0";
                sb.Append("'");
                sb.Append(status);
                sb.Append("' ");
            }
            sb.Append(" where StudentID='");
            sb.Append(studentID);
            sb.Append("' and ID='");
            sb.Append(ID);
            sb.Append("'");
            sqlBaseOp.Update(sb.ToString());
            GVStudentContestUpdate(studentID);
        }
    }
    protected void btnSave_Click1(object sender, EventArgs e)
    {
        //如果所有审核都通过，重新绑定GVContestVerify修改Status值，并计算总学分，总绩点。
        //如果有一项非审核通过，不修改GVContestVerify

        string studentID = lblStudentID.Text;
        StringBuilder sb = new StringBuilder("select Status from ContestStudent where StudentID='");
        sb.Append(studentID);
        sb.Append("'");
        DataSet ds = sqlBaseOp.Select(sb.ToString());
        DataTable dt = ds.Tables[0];
        bool hasUnVerify = false;
        foreach (DataRow row in dt.Rows)
        {
            foreach (DataColumn column in dt.Columns)
            {
                if (row[column].ToString() == "")
                {
                    hasUnVerify = true;
                    break;
                }
            }
            if (hasUnVerify)
                break;
        }
        if (!hasUnVerify)//全部审核过，可以计算总绩点，总学分
        {
            sb = new StringBuilder("select cr.Point,c.Weight,cs.Status from ContestStudent cs,ContestRank cr,Contest c where cs.StudentID='");
            sb.Append(studentID);
            sb.Append("' and cs.ID=cr.ID and cr.ID=c.ID and cs.Rank=cr.Rank");
            ds = sqlBaseOp.Select(sb.ToString());
            dt = ds.Tables[0];
            int weight;
            int point;
            int totalWeight = 0;
            int totalPoint = 0;
            foreach (DataRow row in dt.Rows)
            {
                if (row["Status"].ToString() == "True")
                {
                    weight = Convert.ToInt32(row["Weight"].ToString());
                    point = Convert.ToInt32(row["Point"].ToString());
                    totalWeight += weight;
                    totalPoint += weight * point;
                }
            }

            sb = new StringBuilder("update StudentScholarship set CTW='");
            sb.Append(totalWeight);
            sb.Append("',CTP='");
            sb.Append(totalPoint);
            sb.Append("' where StudentID='");
            sb.Append(studentID);
            sb.Append("'");
            sqlBaseOp.Update(sb.ToString());
            GVContestVerifyUpdate(gradeHF.Value, classHF.Value);
        }
        else
        {
            sb = new StringBuilder("update StudentScholarship set CTW=NULL,CTP=NULL where StudentID='");
            sb.Append(studentID);
            sb.Append("'");
        }
        sqlBaseOp.Update(sb.ToString());
        GVContestVerifyUpdate(gradeHF.Value, classHF.Value);
    }
   
    protected void btnMaxTotalPoint_Click(object sender, EventArgs e)
    {
        //先检验，所有的学生都审核过了，再计算
        int maxWeight = 0;
        int curCTW = 0;
        //用两个表求交比较好，因为筛选条件是会变得 
       
        DataTable dt = (DataTable)Session["GVContestVerify_DT"];
        foreach (DataRow row in dt.Rows)
        {
            string studentID = row[0].ToString();
            StringBuilder sb = new StringBuilder("select Status from ContestStudent where StudentID='");
            sb.Append(studentID);
            sb.Append("'");
            if (sqlBaseOp.HasNull(sb.ToString()))
            {
                //有未审核的学生
                maxWeight = -1;
                break;
            }
            else
            {
                curCTW = Convert.ToInt32(row[4].ToString());
                maxWeight = Math.Max(maxWeight, curCTW);
            }
        }

        if (maxWeight == -1)
        {
            lblMaxTotalPoint.Text = "";
            Response.Write("<script language=javascript>alert('尚有未检验的竞赛项目，无法计算总学分最大值');</script>");
        }
        else
        {
            lblMaxTotalPoint.Text = maxWeight.ToString();
            maxWeightHF.Value = maxWeight.ToString(); ;
        }
    }

    protected void BtnPointAve_Click(object sender, EventArgs e)
    {
        if (lblMaxTotalPoint.Text != "")
        {
            float maxWeight = float.Parse(maxWeightHF.Value);
            StringBuilder sb = new StringBuilder("update StudentScholarship set CPA=CTP/");
            sb.Append(maxWeight.ToString());
            sb.Append(".00 where StudentID in (select ss.StudentID from StudentScholarship ss,Student s where ss.StudentID=s.StudentID and s.Grade='");
            sb.Append(gradeHF.Value);
            sb.Append("' and s.Class='");
            sb.Append(classHF.Value);
            sb.Append("')");//否则仅保留整数部分
            sqlBaseOp.Update(sb.ToString());
            GVContestVerifyUpdate(gradeHF.Value, classHF.Value);
        }
        else
        {
            Response.Write("<script language=javascript>alert('请先计算总学分最大值');</script>");
        }
    }
    protected void GVContestVerify_Sorting(object sender, GridViewSortEventArgs e)
    {
        GVOP.Sorting(e.SortExpression.ToString(), (GridView)sender, (DataTable)Session["GVContestVerify_DT"]);
    }

    protected void GVContestVerify_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GVOP.Paging(e.NewPageIndex, (DataTable)Session["GVContestVerify_DT"],(GridView) sender);
    }

    protected void GVStudentContest_Sorting(object sender, GridViewSortEventArgs e)
    {
        GVOP.Sorting(e.SortExpression.ToString(), (GridView)sender, (DataTable)Session["GVStudentContest_DT"]);
    }
    
    protected void GVStudentContest_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GVOP.Paging(e.NewPageIndex, (DataTable)Session["GVStudentContest_DT"], (GridView)sender);

    }
}
