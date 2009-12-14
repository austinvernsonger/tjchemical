<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="Login_ChangePassword" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>
    <script language=javascript>
    function CheckPassword(source, arguments)
    {
        var userName =document.getElementById("UserName");
        var oBao = new ActiveXObject("Microsoft.XMLHTTP");
         oBao.open("Get","CheckPassword.aspx?Password=" + document.getElementById("tbOldPassword").value,false);  
         oBao.send();
        var strResult = oBao.responseText;

        //如果返回 1 就代表可以使用，否则不能通过验证
        if (Number(strResult) == 1)
             arguments.IsValid = false;    
        else
             arguments.IsValid = true;
    }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    <br />
    <table class="style1">
        <tr>
            <td>
                <span style="float:right">旧密码：</span>
            </td>
            <td>
    
        <asp:TextBox ID="tbOldPassword" runat="server" Width="152px"
            TextMode="Password"></asp:TextBox>
    
                <asp:CustomValidator ID="CustomValidator1" runat="server" 
                    ErrorMessage="密码错误" ClientValidationFunction="CheckPassword" ControlToValidate="tbOldPassword"></asp:CustomValidator>
    
            </td>
        </tr>
        <tr>
            <td>
            <span style="float:right">新密码：</span>
            </td>
            <td>
        <asp:TextBox ID="tbNewPassword" runat="server" Width="152px" TextMode="Password"></asp:TextBox>
                <asp:CompareValidator ID="CompareValidator1" runat="server" 
                    ErrorMessage="两次输入密码不一致" ControlToCompare="tbNewPassword" ControlToValidate="tbPasswordCommit"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td>
                <span style="float:right">再次输入密码：</span>
            </td>
            <td>
    <asp:TextBox ID="tbPasswordCommit" runat="server" Width="152px" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
    </table>
    <asp:Button ID="btnChangePassword" runat="server" Text="确认" 
        onclick="btnChangePassword_Click" />
    <input id="clean" type="reset" value="重置" /></form>
</body>
</html>
