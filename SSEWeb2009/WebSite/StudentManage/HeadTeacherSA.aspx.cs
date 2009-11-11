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
using System.Text;
using StudentManages.Sql;
using StudentManages;
using System.Data.SqlClient;
using System.Collections.Generic;

public partial class StudentManage_HeadTeacherSA : System.Web.UI.Page
{
    BaseOperate sqlBaseOp;
    protected void Page_Load(object sender, EventArgs e)
    {
        sqlBaseOp = new BaseOperate();
        if (!IsPostBack)
        {
            //Session["IdentifyNumber"] = 0;
            StringBuilder sb = new StringBuilder("select Grade,Class from Privilege where ID='");
            sb.Append(Convert.ToString( Session["IdentifyNumber"]));
            sb.Append("' and Type='0'");
            DataSet GradeClassDS = sqlBaseOp.Select(sb.ToString());
            DataTable dt = GradeClassDS.Tables[0];

            List<string[]> GradeClassArr = new List<string[]>();
            foreach (DataRow row in dt.Rows)
            {
                string[] GradeClassEle = new string[2] ;
                GradeClassEle[0]=row[0].ToString();
                GradeClassEle[1] = row[1].ToString();
                GradeClassArr.Add(GradeClassEle);
            }
            InitialGradeClassDDL((List<string[]>)Session["HeadTeacher_GradeClass"]);

            this.GV_SA.Attributes.Add("SortExpression", "StudentID");
            this.GV_SA.Attributes.Add("SortDirection", "ASC");
        }
    }

    private void InitialGradeClassDDL( List<string[]> GradeClassArr)
    { 
        int len=GradeClassArr.Count;
    //将GradeClassArr中的项分析出来，列入DDL中
        foreach (string[] ele in GradeClassArr)
        {
            string tempstr1 = ele[0].ToString() + "级" + ele[1].ToString() + "班";
            string tempstr2 = ele[0].ToString() + "," + ele[1].ToString();
            ListItem li = new ListItem();
            li.Text = tempstr1;
            li.Value = tempstr2;
            DDL_Grade_Class.Items.Add(li);
        }
    }

    private DataSet CreateDataSet(string grade,string sclass,int studentID,float SAP)
    {
        //教师修改学生SAP
        //找到该学生ID,修改其SAP,重新写入数据库，重新绑定Grade和Class符合条件的学生数据
        if (studentID != -1)
        {
            StringBuilder sb = new StringBuilder("update StudentScholarship ");
            sb.Append("set SAP='");
            sb.Append(SAP);
            sb.Append("' where StudentID='");
            sb.Append(studentID);
            sb.Append("'");
            sqlBaseOp.Update(sb.ToString());
        }

        //找到指定Grade和Class的学生
        StringBuilder s = 
            new StringBuilder(" select ss.StudentID, ss.SASE, ss.SAP, s.Name, s.Grade,s.Class ");
        s.Append("from StudentScholarship  ss ");
        s.Append("join Student s ");
        s.Append("on ss.StudentID = s.StudentID ");
        s.Append("and s.Grade='");
        s.Append(grade);
        s.Append("' and s.Class='");
        s.Append(sclass);
        s.Append("'");

        return sqlBaseOp.Select(s.ToString());
    }

    protected void DDL_Grade_Class_SelectedIndexChanged(object sender, EventArgs e)
    {
        string str = DDL_Grade_Class.SelectedItem.Value;
        if (str != "-1")
        {
            Array strArr = str.Split(',');
            string gradeStr = Convert.ToString( strArr.GetValue(0));
            string classStr = Convert.ToString( strArr.GetValue(1));
            UpdateGVSA(gradeStr, classStr,-1,0);//studentID(-1表示不用考虑后两个参数),SAP
            ClearDetail();
        }
    }

    private void UpdateGVSA(string gradeStr,string classStr,int studentID,float SAP)
    {
        DataSet ds = CreateDataSet(gradeStr, classStr,studentID,SAP);
        DataTable dt = ds.Tables[0];
        Session["tempDateTable4Sorting"] = dt;
       
        GV_SA.DataSource = dt;
        GV_SA.DataBind();
    }

    protected void GV_SA_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if(e.CommandName=="Select")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow selectRow = GV_SA.Rows[index];
            string StudentName=selectRow.Cells[0].Text;
            string StudentID = selectRow.Cells[1].Text;
            //string SAP = selectRow.Cells[2].Text;
            string SAP = GV_SA.DataKeys[index].Value.ToString();
            string SASE = selectRow.Cells[3].Text;
            
            Lbl_Name.Text = StudentName;
            Lbl_ID.Text=StudentID;
            if (SAP == "")
                DDLPoint.SelectedValue = "-1";
            else
                DDLPoint.Text = SAP;
            Txt_SASE.Text = SASE;
        }
    }

    protected void DDLPoint_SelectedIndexChanged(object sender, EventArgs e)
    {
        string str = DDL_Grade_Class.SelectedItem.Value;
       
            Array strArr = str.Split(',');
            string gradeStr = Convert.ToString(strArr.GetValue(0));
            string classStr = Convert.ToString(strArr.GetValue(1));
            int studentID = Convert.ToInt32(Lbl_ID.Text);
            string SAPStr = ((DropDownList)sender).SelectedValue;
            float SAP = float.Parse(SAPStr);

            UpdateGVSA(gradeStr, classStr, studentID, SAP);
         
    }

    private void ClearDetail()
    {
        Lbl_ID.Text = "";
        Lbl_Name.Text = "";
        Txt_SASE.Text = "";
    }

    protected string GetStatus(object _status)
    {
        string statusStr = Convert.ToString(_status);
        if (statusStr == "")
            return "未评分";
        else
        {
            float status = float.Parse(statusStr);
            return statusStr;
        }
    }
    protected void Btn_Query_Click(object sender, EventArgs e)
    {

    }
    protected void GV_SA_Sorting(object sender, GridViewSortEventArgs e)
    {
        //ASC和DESC的切换
        string sortExpression = e.SortExpression.ToString();
        string sortDirection = "ASC";
        if (sortExpression == this.GV_SA.Attributes["SortExpression"])
        {
            sortDirection = (this.GV_SA.Attributes["SortDirection"].ToString() == sortDirection ? "DESC" : "ASC");
        }
        this.GV_SA.Attributes["SortExpression"] = sortExpression;
        this.GV_SA.Attributes["SortDirection"] = sortDirection;
        UpdateGVSAAfterSorting();

    }
    private void UpdateGVSAAfterSorting()
    {
        string sortExpression = this.GV_SA.Attributes["SortExpression"];
        string sortDirection = this.GV_SA.Attributes["SortDirection"];
        //GridView的一个字符串，它包含列名，后跟“ASC”（升序）或“DESC”（降序）。在默认情况下列按升序排序。多个列可用逗号隔开。
        DataTable dt = (DataTable)Session["tempDateTable4Sorting"];
        if ((!string.IsNullOrEmpty(sortExpression)) && (!string.IsNullOrEmpty(sortDirection)))
        {
            dt.DefaultView.Sort = string.Format("{0} {1}", sortExpression, sortDirection);
        }
        GV_SA.DataSource = dt;
        GV_SA.DataBind();
    }
  
  
    protected void GV_SA_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GV_SA.PageIndex =e.NewPageIndex ;
        DataTable dt = (DataTable)Session["tempDateTable4Sorting"];

        GV_SA.DataSource = dt;
        GV_SA.DataBind();
    }
}
