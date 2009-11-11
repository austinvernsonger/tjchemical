<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DeviceReturn.aspx.cs" Inherits="LabCenter_Equipment_DeviceApply_DeviceReturn" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
<div>
        <asp:Label ID="设备归还页面" runat="server" Text="" Visible="false" ForeColor="Red" Font-Bold="true"></asp:Label>
        <asp:Table ID="Table1" runat="server">
            <asp:TableRow ID="TableRow1" runat="server">
                <asp:TableCell ID="TableCell1" runat="server">请输入设备申请编号：</asp:TableCell>
                <asp:TableCell ID="TableCell2" runat="server">
                    <asp:TextBox ID="tbApplyId" runat="server" Width="284px"></asp:TextBox>
                    </asp:TableCell>
            </asp:TableRow>


            <asp:TableRow ID="TableRow4" runat="server">
            <asp:TableCell ID="TableCell28" runat="server">
            <asp:Button ID="btnReturn" runat="server" Text="提交" OnClick="btnReturn_Click" />
            </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </div>
    </form>
</body>
</html>
