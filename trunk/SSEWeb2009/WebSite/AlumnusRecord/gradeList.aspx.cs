using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class gradeList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string type = Request.QueryString["type"];
        
        if(type == null || type.Trim() == "" || type.Equals("underGraduate"))
        {
            this.XmlDs1.XPath = @"/grades/grade[@graduatingType='本科']";  
            //Context.Response.Write("UnderGraduates list...");
        }else{
            this.XmlDs1.XPath = @"/grades/grade[@graduatingType='硕士']";
            //Context.Response.Write("PostGraduates list...");
        }                
    }
}
