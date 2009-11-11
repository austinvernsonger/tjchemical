<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CourseScoreList.aspx.cs" Inherits="Engineering_TeaSchoolBackMag_CourseScoreList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>    
        学科成绩&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        <asp:LinkButton ID="LinkButton1" runat="server" 
            PostBackUrl="~/Engineering/TeaSchoolBackMag/ViewCourseResult.aspx">返回上一页</asp:LinkButton>    
    </div>
    <div>    
        <br />
        年&nbsp;&nbsp;&nbsp; 级：&nbsp; 
        <asp:Label ID="lblGrade" runat="server"></asp:Label>
        <br />
        教学点：&nbsp;&nbsp;&nbsp; 
        <asp:Label ID="lblTeaSchool" runat="server"></asp:Label>
        <br />
        课程名称：<asp:Label ID="lblCourName" runat="server"></asp:Label>
        <br />
        任课教师：<asp:Label ID="lblTeachers" runat="server"></asp:Label>
        <br />
        选课人数：<asp:Label ID="lblStdNum" runat="server"></asp:Label>    
    </div>
    <div>
    
        <br />
        <asp:GridView ID="gvScoreList" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" ForeColor="#333333" GridLines="None">
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <Columns>
                <asp:BoundField DataField="StudentID" HeaderText="学号" />
                <asp:BoundField DataField="Name" HeaderText="姓名" />
                <asp:BoundField DataField="Degree" HeaderText="学位类别" />
                <asp:BoundField DataField="CourResult" HeaderText="成绩" />
            </Columns>
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#999999" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>
