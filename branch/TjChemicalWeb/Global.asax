<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        // Code that runs on application startup
        SMBL.Global.WebSite.Boot();
        // Cache the config file and 
        // Start the error system and log system
        SMBL.Core.Kernel.Initialize();
        // Start the file system

        // Start the database system
        SMBL.ADBS.ConnectionControl.Initialize();
        // Start the file system
        SMBL.AFS.DocumentPool.Initialize();
        WebSiteRegister.RegisterDepartment();
    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown
        SMBL.ADBS.ConnectionControl.Terminate();
    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // Code that runs when an unhandled error occurs
        Exception exp = Server.GetLastError();

        // Process the exception
        //SMBL.Global.BasicErrorSystem.UnhandledError(exp);
        Int64 ErrorId = SMBL.Core.ErrorSystem.CatchError(exp);
        ConstValue._errorSession.Add(ErrorId, exp);
        Server.ClearError();

        // Redirect to some page?
        Response.Redirect("~/SystemError.aspx?err=" + ErrorId.ToString());
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
