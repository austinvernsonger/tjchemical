<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login_Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>登录--同济大学软件学院</title>
    <link href="../CssClass/login_bright.css" rel="stylesheet" type="text/css" />
    <link href="../CssClass/Bright.css" rel="stylesheet" type="text/css" />
    <script language='javascript' type='text/javascript'>    
        var secs =5; //倒计时的秒数       
        var srl;
        function Load(url){  
        srl=url;
        for(var i=5;i>=0;i--)
        { 
        window.setTimeout('doUpdate(' + i + ')', (secs-i) * 1000);
        }
        }
        function doUpdate(num) 
        {
        document.getElementById('showurl').innerHTML = '在'+num+'秒后自动跳转到以下页面';
        if(num == 0) { window.location=srl; 
        }  
        }   
    </script>
</head>
<body>
<form id="form1" runat="server">
    <div id="div_logo">
        <asp:Image ID="imgLogo" runat="server" ImageUrl="../Resources/Bright/Logo.png"/>
    </div>
    <div id="div_login">
    <div id="login_left">&nbsp;
    </div>
    <div id="login_right">
    <asp:Panel ID="pLogin" runat="server">
    <div id="login_err">&nbsp;
        <asp:Label ID="lbErrorMessage" runat="server"></asp:Label>
    </div>
    <div id="login_input">
        <asp:TextBox ID="tbUserName" runat="server" CssClass="InputBox"></asp:TextBox>
        <asp:TextBox ID="tbPassWord" runat="server" TextMode="Password" CssClass="InputBox"></asp:TextBox>
        <asp:HyperLink ID="lnk_finepwd" runat="server" NavigateUrl="~/Login/FindPassword.aspx" CssClass="Label">忘记密码？</asp:HyperLink>
    </div>
    <div id="login_btn">
        <asp:ImageButton ID="btnLogin" runat="server" onclick="btnLogin_Click" ImageUrl="~/Resources/Bright/login_btn.png"/>
    </div>
    </asp:Panel>
    <asp:Panel ID="pSucceed" runat="server" Visible="False" CssClass="suc_holder">
    <asp:Label ID="Label2" runat="server" Text="登录成功"></asp:Label>
    <div id="showurl"></div>
    <asp:HyperLink ID="hlToUrl" runat="server">HyperLink</asp:HyperLink>
    </asp:Panel>
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