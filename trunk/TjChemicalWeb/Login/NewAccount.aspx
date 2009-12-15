<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NewAccount.aspx.cs" Inherits="Login_NewAccount" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
</head>
<body>
<form id="form1" runat="server">
    <table style="font-size:12px; font-family:宋体">
        <tr>
            <td>
                帐号
            </td>
            <td>
                <asp:TextBox ID="tbAccount" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                密码</td>
            <td>
                <asp:TextBox ID="tbPassword" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                帐号状态</td>
            <td>
                <asp:DropDownList ID="ddlAccountState" runat="server">
                    <asp:ListItem Selected="True" Value="0">正常</asp:ListItem>
                    <asp:ListItem Value="1">冻结</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                E-mail地址</td>
            <td>
                <asp:TextBox ID="tbSafetyEmail" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                E-mail认证</td>
            <td>
                <asp:CheckBox ID="cbEmailValidation" runat="server" />
            </td>
        </tr>
    </table>
    <asp:Button ID="btnInsert" runat="server" Text="添加" onclick="btnInsert_Click" />
    &nbsp;<input id="Reset1" type="reset" value="清空" />
    <p>
        &nbsp;</p>
    </form>
</body>
</html>
