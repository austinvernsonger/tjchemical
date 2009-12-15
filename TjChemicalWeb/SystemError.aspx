<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SystemError.aspx.cs" Inherits="SystemError" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="System_Error_d" runat="server" Text="Oops...System Error!" 
            Font-Bold="False" Font-Names="Comic Sans MS" Font-Size="18px" 
            ForeColor="#FF6600"></asp:Label>
        <br />
        <br />
        
        <asp:Label ID="Message_d" runat="server" Font-Bold="True" 
            Font-Names="Courier New" Font-Size="16px" ForeColor="Red" 
            Text="Message" Visible="False"></asp:Label>
        <br />
        <asp:Label ID="lb_message" runat="server" Font-Names="Courier New" 
            Font-Size="13px" Visible="False"></asp:Label>
        
        <br />
        <br />

        <asp:Label ID="Method_d" runat="server" Font-Bold="True" 
            Font-Names="Courier New" Font-Size="16px" ForeColor="Red" Text="Method" 
            Visible="False"></asp:Label>
        <br />
        <asp:Label ID="lb_method" runat="server" Font-Names="Courier New" 
            Font-Size="13px" Font-Bold="False" Visible="False"></asp:Label>
        
        <br />
        <br />

        <asp:Label ID="ExpType_d" runat="server" Font-Bold="True" 
            Font-Names="Courier New" Font-Size="16px" ForeColor="Red" 
            Text="Exception Type" Visible="False"></asp:Label>
        <br />
        <asp:Label ID="lb_exptype" runat="server" Font-Names="Courier New" 
            Font-Size="13px" Visible="False"></asp:Label>
        
        <br />
        <br />

        <asp:Label ID="Source_d" runat="server" Font-Bold="True" 
            Font-Names="Courier New" Font-Size="16px" ForeColor="Red" 
            Text="Source" Visible="False"></asp:Label>
        <br />
        <asp:Label ID="lb_Source" runat="server" Font-Names="Courier New" 
            Font-Size="13px" Visible="False"></asp:Label>
        
        <br />
        <br />

        <asp:Label ID="StackTrace_d" runat="server" Font-Bold="True" 
            Font-Names="Courier New" Font-Size="16px" ForeColor="Red" 
            Text="Stack Trace" Visible="False"></asp:Label>
        <br />
        <asp:Label ID="lb_stacktrace" runat="server" Font-Names="Courier New" 
            Font-Size="13px" Visible="False"></asp:Label>
        
    </div>
    </form>
</body>
</html>
