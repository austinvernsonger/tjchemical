<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CourseDetails.aspx.cs" Inherits="Engineering_CourseDetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <base target="_self" />
</head>
<body>
    <form id="form1" runat="server">
    <div style="margin:12px 0 0 12px">
        <div>课程详细信息</div>
        <br />
        <br />
        <div>
            <asp:Table ID="Table1" runat="server" BorderColor="Black" BorderStyle="Solid" 
                CellPadding="0" CellSpacing="0" GridLines="Horizontal" Width="523px">
                <asp:TableRow runat="server" Height="31px">
                    <asp:TableCell runat="server">课程名称：</asp:TableCell>
                    <asp:TableCell runat="server" ColumnSpan="3">
                        <asp:Label ID="lbCourseName" runat="server"></asp:Label></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow runat="server" Height="31px">
                    <asp:TableCell runat="server" Width="80px">开课学期：</asp:TableCell>
                    <asp:TableCell runat="server" Width="250px">
                        <asp:Label ID="lbCourseTime" runat="server"></asp:Label></asp:TableCell>
                    <asp:TableCell runat="server" Width="80px">课程类别：</asp:TableCell>
                    <asp:TableCell runat="server">
                        <asp:Label ID="lbCategory" runat="server"></asp:Label></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow runat="server" Height="31px">
                    <asp:TableCell runat="server">课程性质：</asp:TableCell>
                    <asp:TableCell runat="server">
                        <asp:Label ID="lbProperty" runat="server"></asp:Label></asp:TableCell>
                    <asp:TableCell runat="server">考核方式：</asp:TableCell>
                    <asp:TableCell runat="server">
                        <asp:Label ID="lbExamMode" runat="server"></asp:Label></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow runat="server" Height="31px">
                    <asp:TableCell runat="server">教学方式：</asp:TableCell>
                    <asp:TableCell runat="server">
                        <asp:Label ID="lbInstruMode" runat="server"></asp:Label></asp:TableCell>
                    <asp:TableCell runat="server">开课学院：</asp:TableCell>
                    <asp:TableCell runat="server">软件学院</asp:TableCell>
                </asp:TableRow>
                <asp:TableRow runat="server" Height="31px">
                    <asp:TableCell runat="server">双语教学：</asp:TableCell>
                    <asp:TableCell runat="server">
                        <asp:Label ID="lbDialossia" runat="server"></asp:Label></asp:TableCell>
                    <asp:TableCell runat="server">课程学分：</asp:TableCell>
                    <asp:TableCell runat="server">
                        <asp:Label ID="lbCredit" runat="server"></asp:Label></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow runat="server" Height="31px">
                    <asp:TableCell runat="server">课程学时：</asp:TableCell>
                    <asp:TableCell runat="server">
                        <asp:Label ID="lbCreditHour" runat="server"></asp:Label></asp:TableCell>
                    <asp:TableCell runat="server">任课教师：</asp:TableCell>
                    <asp:TableCell runat="server">
                        <asp:Label ID="lbTeacher" runat="server"></asp:Label></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow runat="server" Height="31px">
                    <asp:TableCell runat="server">上课时间：</asp:TableCell>
                    <asp:TableCell runat="server" ColumnSpan="3">
                        <asp:Label ID="lbPeriod" runat="server"></asp:Label></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow runat="server" Height="31px">
                    <asp:TableCell runat="server">上课地点：</asp:TableCell>
                    <asp:TableCell runat="server" ColumnSpan="3">
                        <asp:Label ID="lbPlace" runat="server"></asp:Label></asp:TableCell>
                </asp:TableRow>
            </asp:Table> 
        </div>
        <p style="text-align:center; height: 15px; width: 520px;">
            <asp:LinkButton ID="LinkButton1" runat="server" OnClientClick="window.close();">关闭窗口</asp:LinkButton></p>
    </div>
    </form>
</body>
</html>
