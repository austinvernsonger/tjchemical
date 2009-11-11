using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Teaching.Ops;

public partial class Teaching_TeacherInfo : System.Web.UI.Page
{
    //protected System.Web.UI.WebControls.TextBox TestBox1;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Request.QueryString["Orientation"] != null)
        {
            LinkListEx.QuerySQL = "select S.ID,T.Name as Title,Achievement as Content,0 as ContentType,-1 as FS   from [TeachersStructure]as S,[Teacher]as T where S.TeacherID = T.TeacherID and [Orientation]=" + Request.QueryString["Orientation"];
            LinkListEx.ReBindData();
        }
    }

}
