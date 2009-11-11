<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MyTestArragement.aspx.cs"
    Inherits="Engineering_StuBackMag_MyTestArragement" %>

<%@ Register src="../Control/sitmap.ascx" tagname="sitmap" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title> 我的期末考试安排--工程硕士中心</title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="font-size: 25px">
            我的期末考试安排
        </div>
        <hr />
        <br />
        <div>
            <asp:Label ID="lblMessage" runat="server" Text="当前还没有考试安排信息:-)" 
                ForeColor="#999999"></asp:Label>
            <asp:Table ID="Table1" runat="server" BorderColor="Gray" BorderStyle="Solid" 
                BorderWidth="1px" CellPadding="0" CellSpacing="0" GridLines="Both" 
                Width="700px">
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server" Height="31px" HorizontalAlign="Center" 
                        BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px">学期</asp:TableCell>
                    <asp:TableCell runat="server" HorizontalAlign="Center" BorderColor="#666666" 
                        BorderStyle="Solid" BorderWidth="1px">课程名称</asp:TableCell>
                    <asp:TableCell runat="server" HorizontalAlign="Center" BorderColor="#666666" 
                        BorderStyle="Solid" BorderWidth="1px">考试时间</asp:TableCell>
                    <asp:TableCell runat="server" HorizontalAlign="Center" BorderColor="#666666" 
                        BorderStyle="Solid" BorderWidth="1px">考试地点</asp:TableCell>
                    <asp:TableCell runat="server" HorizontalAlign="Center" BorderColor="#666666" 
                        BorderStyle="Solid" BorderWidth="1px">监考老师</asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </div>
    </form>
</body>
</html>
