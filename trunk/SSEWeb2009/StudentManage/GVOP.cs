using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls ;
using System.Data;
using System.Web;


namespace StudentManages
{
    public class GVOP
    {
        public GVOP()
        { 
        }

        public static void Sorting(string sortExp,GridView gv,DataTable dt)
        {
            string sortExpression = sortExp;
            string sortDirection = "ASC";
            if (sortExpression == gv.Attributes["SortExpression"])
            {
                sortDirection = (gv.Attributes["SortDirection"].ToString() == sortDirection ? "DESC" : "ASC");
            }
            gv.Attributes["SortExpression"] = sortExpression;
            gv.Attributes["SortDirection"] = sortDirection;

            //GridView的一个字符串，它包含列名，后跟“ASC”（升序）或“DESC”（降序）。在默认情况下列按升序排序。多个列可用逗号隔开。
            if ((!string.IsNullOrEmpty(sortExpression)) && (!string.IsNullOrEmpty(sortDirection)))
            {
                dt.DefaultView.Sort = string.Format("{0} {1}", sortExpression, sortDirection);
            }
            gv.DataSource = dt;
            gv.DataBind();
        }

        public static void Paging(int newPageIndex,DataTable dt,GridView gv)
        {
            gv.PageIndex = newPageIndex;
            gv.DataSource = dt;
            gv.DataBind();
        }

        public static void Paging(int newPageIndex, GridView gv)
        {
            gv.PageIndex = newPageIndex;
            gv.DataBind();
        }

        public static string  Alert(string text)
        {
            return "<script language=javascript>alert('" + text + "');</script>";
        }
    }
}
