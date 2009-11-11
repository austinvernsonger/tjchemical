<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TuitionInfo.aspx.cs" Inherits="Engineering_StuBackMag_TuitionInfo" %>

<%@ Register src="../Control/sitmap.ascx" tagname="sitmap" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>我的学费信息--工程硕士中心</title>
</head>
<body>
    <form id="form1" runat="server">
        <div style=" font-size:25px">     
            我的学费信息    
        </div>
        <hr />
        <br />
        <div>
            <asp:Label ID="lblMessage" runat="server" Visible="False" ForeColor="#999999">你当前没有任何缴费信息:-)</asp:Label>
            <asp:Table ID="Table1" runat="server" BorderColor="Black" BorderStyle="Solid" 
                BorderWidth="1px" CellPadding="0" CellSpacing="0" GridLines="Both" 
                Width="650px">
                <asp:TableRow ID="TableRow1" runat="server" BorderStyle="Groove">
                    <asp:TableCell ID="TableCell1" runat="server" HorizontalAlign="Center" 
                        BackColor="#CCCCCC" Height="31px" Width="80px">学期</asp:TableCell>
                    <asp:TableCell ID="TableCell2" runat="server" HorizontalAlign="Center" 
                        BackColor="#CCCCCC" Width="150px">应缴费金额</asp:TableCell>
                    <asp:TableCell ID="TableCell3" runat="server" HorizontalAlign="Center" 
                        BackColor="#CCCCCC" Width="150px">实际缴费金额</asp:TableCell>
                    <asp:TableCell ID="TableCell4" runat="server" HorizontalAlign="Center" 
                        BackColor="#CCCCCC" Width="150px">缴费时间</asp:TableCell>
                    <asp:TableCell ID="TableCell5" runat="server" HorizontalAlign="Center" 
                        BackColor="#CCCCCC">备注</asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </div>
    </form>
</body>
</html>
