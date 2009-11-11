<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AssignPaperDisagree.aspx.cs" Inherits="Engineering_AdminBakMag_AssignPaperDisagree" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <base target="_self" />
</head>
<body>
    <form id="form1" runat="server">
    
    <div style="margin:14px 0 0 14px">
        不批准该生的答辩申请
        </div>
     <br />
   <div style="margin:0 0 0 14px">
    <div>
        <table width="500px">
            <tr>
                <td width="80" height="31" align="left" valign="middle">
                    姓名：</td>
                <td width="400" align="left" valign="middle">
                    <asp:Label ID="lblName" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td height="31" align="left" valign="middle">
                    学号：</td>
                <td align="left" valign="middle">
                    <asp:Label ID="lblStuNo" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
     <br />
     <div>
        不批准的理由：<br />
         <asp:TextBox ID="tbReason" runat="server" Height="127px" TextMode="MultiLine" 
             Width="407px"></asp:TextBox>
     </div>
     <br />
     <div>
         <asp:Button ID="btOk" runat="server" Text="确定" Height="31px" Width="90px" 
             onclick="btOk_Click" />
         &nbsp;&nbsp;&nbsp;
         <asp:Button ID="btCancel" runat="server" Text="返回" Height="31px" Width="90px" 
             OnClientClick="window.close()" />
     </div>
     <br />
     <div>
         <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
     </div>
     </div>
    </form>
</body>
</html>
