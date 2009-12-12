<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        // Code that runs on application startup
        SunMkr.Kernel.Platform.Instance.Start();
    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown
        SunMkr.Kernel.Platform.Instance.End();
    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // Code that runs when an unhandled error occurs
        Exception exp = Server.GetLastError();
        string ErrorID = SunMkr.Sys.ErrorSystem.CatchError(exp);
        SunMkr.Com.Mail.MailSender.Send("jiasong.song@gmail.com", "医学院系统错误", "");
        
        Response.Clear();
        Response.Write("System Error...<br />");
        Response.Write("The Author has been notified by the system mail.");
        Response.Close();
        Server.ClearError();

        // Restart automactially
        SunMkr.Kernel.Platform.Instance.Restart();
    }

    void Session_Start(object sender, EventArgs e) 
    {
        // Code that runs when a new session is started

    }

    void Session_End(object sender, EventArgs e) 
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }
       
</script>
