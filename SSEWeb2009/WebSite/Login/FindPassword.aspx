<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FindPassword.aspx.cs" Inherits="Login_FindPassword" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <link href="../CssClass/login_bright.css" rel="stylesheet" type="text/css" />
    <link href="../CssClass/Bright.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="div_logo">
        <asp:Image ID="imgLogo" runat="server" ImageUrl="../Resources/Bright/Logo.png"/>
    </div>
    <div id="div_login">
    <div id="login_left">&nbsp;
    </div>
    <div id="pw_right">
        <div id="pw_input">
        <asp:TextBox ID="tbAccountId" runat="server" CssClass="PwInputBox"></asp:TextBox>
        </div>
        <div id="pw_btn">
        <asp:ImageButton ID="btnOk" runat="server" onclick="btnOk_Click" ImageUrl="~/Resources/Bright/pw_btn.png"/>
        </div>
    </div>
    </div>
    <div id="login_back">
        <asp:HyperLink ID="HyperLink1" runat="server" ImageUrl="~/Resources/Bright/login_back.png" NavigateUrl="~/Default.aspx">HyperLink</asp:HyperLink>
    </div>
    <div id="div_bottom">
    <!--Bottom Panel-->         
    <asp:Panel id="bottom_bar" runat="server" CssClass="bottom_bar">
	    <table border="0" cellpadding="0" id="bottom_table">
          <tr>
            <td>上海市嘉定区曹安公路4800号</td>
            <td style="text-align:right;">CopyRight 2009 SSE,TJU</td>
          </tr>
          <tr>
            <td>电话：69579374 | 传真：69589374 | E-mail：<a href="mailto:sse@tongji.edu.cn">sse@tongji.edu.cn</a></td>
            <td style="text-align:right;">
                <asp:HyperLink ID="lnk_dev" runat="server" NavigateUrl="#">Developer Team</asp:HyperLink>
            </td>
          </tr>
        </table>
    </asp:Panel> 
    </div>
    </form>
</body>
</html>
