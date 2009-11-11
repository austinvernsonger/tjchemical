<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NewOpenDevice.aspx.cs" Inherits="LabCenter_Equipment_DeviceApply_NewOpenDevice" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <script type="text/javascript">
    function HideSuccess(){
    document.getElementById("Label1").style.display="none";
    }
    </script>
</head>
<body>
    <form id="form1" runat="server">
<div style="height: 223px">
        <asp:Label ID="添加新的可借用设备" runat="server" Text="" Visible="false" ForeColor="Red" Font-Bold="true"></asp:Label>
        <asp:Table ID="Table1" runat="server">
            <asp:TableRow ID="TableRow1" runat="server">
                <asp:TableCell ID="TableCell1" runat="server">设备名称：</asp:TableCell>
                <asp:TableCell ID="TableCell2" runat="server">
                    <asp:TextBox ID="tbDeviceId" runat="server" Width="284px" onfocus="HideSuccess()"></asp:TextBox>
                    </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="TableRow2" runat="server">
            <asp:TableCell ID="TableCell3" runat="server">备注：</asp:TableCell>
            <asp:TableCell ID="TableCell4" runat="server">
            <asp:TextBox ID="tbRemark" runat="server" TextMode="MultiLine" Height="97px" Width="284px" onfocus="HideSuccess()"></asp:TextBox>
            </asp:TableCell>
            </asp:TableRow>


            <asp:TableRow ID="TableRow4" runat="server">
            <asp:TableCell ID="TableCell28" runat="server">
            <asp:Button ID="btnSubmit" runat="server" Text="提交" OnClick="btnSubmit_Click" />
            </asp:TableCell>
            <asp:TableCell ID="TableCell5" runat="server">
            </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <asp:Label ID="Label1" runat="server" Text="添加成功" Visible="False"></asp:Label>
    </div>
    </form>
</body>
</html>
