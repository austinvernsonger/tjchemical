<%@ Page Language="C#" AutoEventWireup="true" CodeFile="__client_temp.aspx.cs" Inherits="__client_temp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Loading SSE Web...</title>
</head>
<body>
    <form id="frm_empty" runat="server">
    <asp:Label ID="lb_waiting" runat="server" 
        Text="Please wait. Loading SSE Web..." Font-Bold="True" 
        Font-Names="Candara,Arial" Font-Size="15px" ForeColor="#000099"></asp:Label>
    </form>
    <script type="text/javascript" language="javascript">
        var __client = (new Date()).getHours();
        //window.location = "__client_hour.aspx";
        window.location = '__client_hour.aspx?__clienthour=' + __client + 
            '&toUrl=<%=Request.Params["toUrl"]%>';
    </script>
</body>
</html>
