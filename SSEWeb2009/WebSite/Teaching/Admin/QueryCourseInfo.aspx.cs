using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Teaching;
using Teaching.Ops;

public partial class Teaching_Admin_QueryCourseInfo : System.Web.UI.Page
{
    private DataTable course = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        opsTeachingQuery QueryName = new opsTeachingQuery("select * from [Course]");
        QueryName.Do();
        if (!(QueryName.mResult.Tables.Count == 0 || QueryName.mResult.Tables[0].Rows.Count == 0))
        {
            course = QueryName.mResult.Tables[0].Copy();
            course.Columns.Remove(course.Columns["Target"]);
            course.Columns.Add("授课对象");
            for (int i = 0; i < QueryName.mResult.Tables[0].Rows.Count;i++ )
            {
                course.Rows[i]["授课对象"] = QueryName.mResult.Tables[0].Rows[i]["Target"].ToString() == "False" ? "本科生" : "研究生";
            }
            CourseGridView.DataSource = course;
            CourseGridView.DataBind();
        }
    }

    protected void GridViewSortEventHandler(object sender, GridViewSortEventArgs e)
    {
        String sortExpression = e.SortExpression;
        if (CourseGridView.Attributes["SortDirection"] != "DESC")
        {
            CourseGridView.Attributes["SortDirection"] = "DESC";
            SortGridView(sortExpression, " DESC");
        }
        else
        {
            CourseGridView.Attributes["SortDirection"] = "ASC";
            SortGridView(sortExpression, " ASC");
        }
    }

    private void SortGridView(string sortExpression, string direction)
    {
        DataView dv = new DataView(course);
        dv.Sort = sortExpression + direction;
        CourseGridView.DataSource = dv;
        CourseGridView.DataBind();
    }

    protected void CourseGridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        for (int i = 0; i < e.Row.Cells.Count; i++)//获取总列数
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[i].Attributes.Add("title", "tttttttttt");
            }
        }
    }
}
