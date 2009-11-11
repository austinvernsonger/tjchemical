<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MyScoreInfo.aspx.cs" Inherits="Engineering_StuBackMag_MyScoreInfo" %>

<%@ Register src="../Control/sitmap.ascx" tagname="sitmap" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>我的考试成绩--工程硕士中心</title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="font-size: 25px">
        我的考试成绩
    </div>
    <hr />
    <br />
    <div>
        <asp:Panel ID="Panel1" runat="server">
            <asp:Table ID="Table1" runat="server" BorderColor="Black" BorderStyle="Solid" 
                CellPadding="0" CellSpacing="0" GridLines="Both" Width="700px">
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server" BorderStyle="Solid" Height="31px" 
                        HorizontalAlign="Center" BackColor="#CCCCCC" BorderColor="#666666" 
                        BorderWidth="1px">课程性质</asp:TableCell>
                    <asp:TableCell runat="server" BorderStyle="Solid" Height="31px" 
                        HorizontalAlign="Center" BackColor="#CCCCCC" BorderColor="#666666" 
                        BorderWidth="1px">课程类别</asp:TableCell>
                    <asp:TableCell runat="server" BorderStyle="Solid" Height="31px" 
                        HorizontalAlign="Center" BackColor="#CCCCCC" BorderColor="#666666" 
                        BorderWidth="1px">考试时间</asp:TableCell>
                    <asp:TableCell runat="server" BorderStyle="Solid" Height="31px" 
                        HorizontalAlign="Center" Width="180px" BackColor="#CCCCCC" 
                        BorderColor="#666666" BorderWidth="1px">课程名称</asp:TableCell>
                    <asp:TableCell runat="server" BorderStyle="Solid" Height="31px" 
                        HorizontalAlign="Center" BackColor="#CCCCCC" BorderColor="#666666" 
                        BorderWidth="1px">学时</asp:TableCell>
                    <asp:TableCell runat="server" BorderStyle="Solid" Height="31px" 
                        HorizontalAlign="Center" BackColor="#CCCCCC" BorderColor="#666666" 
                        BorderWidth="1px">学分</asp:TableCell>
                    <asp:TableCell runat="server" BorderStyle="Solid" Height="31px" 
                        HorizontalAlign="Center" BackColor="#CCCCCC" BorderColor="#666666" 
                        BorderWidth="1px">成绩</asp:TableCell>
                    <asp:TableCell runat="server" BorderStyle="Solid" Height="31px" 
                        HorizontalAlign="Center" BackColor="#CCCCCC" BorderColor="#666666" 
                        BorderWidth="1px">成绩性质</asp:TableCell>
                </asp:TableRow>        
            </asp:Table>
        </asp:Panel>
        <p>
            <asp:Label ID="lblDegreeCredit" runat="server"></asp:Label>
            &nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblNonDegreeCredit" runat="server"></asp:Label>
            &nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblTotalCredit" runat="server"></asp:Label>
        </p>
    </div>
    </form>
</body>
</html>
