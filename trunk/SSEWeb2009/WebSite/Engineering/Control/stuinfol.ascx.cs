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
using Department.Engineering;

public partial class Engineering_Control_stuinfol : System.Web.UI.UserControl
{
    public StudentInfo stuInfo = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        string stuid = Request["stuID"];
        StudentManage stuMag = new StudentManage();
        stuInfo = stuMag.GetStudentInfo(stuid);
    }
}
