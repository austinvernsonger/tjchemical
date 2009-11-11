using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using LabCenter.LabUtility.EmailUtility;

public partial class LabCenter_Repair_UserControl_MailHtmlContent : System.Web.UI.UserControl
{
    public delegate string delegatertstring();
    public event delegatertstring GetEmailContent;
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void btnEmail_Click(object sender, EventArgs e)
    {
        //using LabCenter.LabUtility.EmailUtility;
        //首先初始化一个Smtp邮差实体
        SmtpMailer sm = new SmtpMailer();
        //然后可以通过配置文件配置之
        if(!sm.SenderConfig(AppDomain.CurrentDomain.BaseDirectory+"/LabCenter/XmlConfig/MailConfig.xml"))
        {
            Response.Write(sm.LastError);
        }
        //再填入邮件的接受者，主题，内容
        sm.Receiver = tbEmail.Text;
        sm.Subject = "实验中心提醒";
        sm.Body = GetEmailContent();
        //最后就Send
        if (!sm.Send())
        {
            //如果失败，通过LastError属性查看错误信息
            Response.Write(sm.LastError);
        }
        else 
        {
            Response.Write("发送成功");
        }
    }
}
