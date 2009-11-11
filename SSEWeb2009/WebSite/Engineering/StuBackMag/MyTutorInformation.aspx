<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MyTutorInformation.aspx.cs" Inherits="Engineering_StuBackMag_MyTutorInformation" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>我的导师--工程硕士中心</title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="font-size: 25px">
        我的导师
    </div>
    <hr />
    <br />
    <asp:Label ID="lbMessage" runat="server" ForeColor="#999999"></asp:Label> 
    <div id="div_tutor" runat="server">
        <table width="700">
            <tr>
                <td height="31" colspan="2" align="left" valign="middle" bgcolor="#F7F7F7">
                    导师基本信息</td>
            </tr>
            <tr>
                <td width="100" height="31" align="right" valign="middle">
                    姓名：</td>
                <td width="600" align="left" valign="middle">
                    <asp:Label ID="lblName" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td height="31" align="right" valign="middle">
                    性别：</td>
                <td align="left" valign="middle">
                    <asp:Label ID="lblGender" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td height="31" align="right" valign="middle">
                    职称：</td>
                <td align="left" valign="middle">
                    <asp:Label ID="lblTitle" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td height="31" align="right" valign="middle">
                    研究领域：</td>
                <td align="left" valign="middle">
                    <asp:Label ID="lblReasearch" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td height="31" align="right" valign="middle">
                    电话：</td>
                <td align="left" valign="middle">
                    <asp:Label ID="lblTelephone" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td height="31" align="right" valign="middle">
                    邮箱：</td>
                <td align="left" valign="middle">
                    <asp:Label ID="lblEmail" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td height="31" colspan="2" align="left" valign="middle" bgcolor="#F7F7F7">
                    科研项目</td>
            </tr>
            <tr>
                <td height="140" colspan="2" align="center" valign="middle">
                    <asp:TextBox ID="tbProject" runat="server" Height="135px" ReadOnly="True" 
                        TextMode="MultiLine" Width="690px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td height="31" colspan="2" align="left" valign="middle" bgcolor="#F7F7F7">
                    获奖情况</td>
            </tr>
            <tr>
                <td height="140" colspan="2" align="center" valign="middle">
                    <asp:TextBox ID="tbRewards" runat="server" Height="135px" ReadOnly="True" 
                        TextMode="MultiLine" Width="690px"></asp:TextBox>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
