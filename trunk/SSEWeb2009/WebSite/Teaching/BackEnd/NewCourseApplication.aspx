<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NewCourseApplication.aspx.cs" Inherits="Teaching_BackEnd_NewCourseApplication" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<link href="../../CssClass/TeachingBackEnd.css" rel="stylesheet" type="text/css" />
<head runat="server">
    <title></title>
</head>
<body>
    <form runat="server">
    <fieldset>
    <legend>开课申请表</legend>
    <dl>
    <dt><asp:Label ID="Label1" runat="server" Text="任课教师"></asp:Label></dt>
    <dd><asp:Label ID="TeacherName" runat="server"></asp:Label></dd> 
    
    <dt><asp:Label ID="Label2" runat="server" Text="课程名称"></asp:Label></dt>
    <dd><asp:TextBox ID="CourseName" runat="server" MaxLength="20"></asp:TextBox></dd>
 
    <dt><asp:Label ID="Label3" runat="server" Text="上课时数"></asp:Label></dt>
    <dd><asp:TextBox ID="Hour" runat="server" MaxLength="3"></asp:TextBox>学时</dd>
    <dt><asp:Label ID="Label4" runat="server" Text="授课语种"></asp:Label></dt>
    <dd><asp:DropDownList ID="Language" runat="server" Height="48px" Width="114px">
            <asp:ListItem>中文</asp:ListItem>
            <asp:ListItem>英语</asp:ListItem>
            <asp:ListItem>日语</asp:ListItem>
            <asp:ListItem>德语</asp:ListItem>
            <asp:ListItem>法语</asp:ListItem>
        </asp:DropDownList></dd>
    <dt><asp:Label ID="Label5" runat="server" Text="开课时间"></asp:Label></dt>   
    <dd><asp:Calendar ID="CourseTime" runat="server" Height="200px" Width="220px" 
            BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" 
            DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" 
            ForeColor="#003399">
            <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
            <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
            <WeekendDayStyle BackColor="#CCCCFF" />
            <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
            <OtherMonthDayStyle ForeColor="#999999" />
            <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
            <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
            <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" 
                Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
        </asp:Calendar></dd>
    <dt><asp:Label ID="Label6" runat="server" Text="开课次数"></asp:Label></dt>
    <dd><asp:TextBox ID="CourseNumber" runat="server"></asp:TextBox>次</dd>
    <dt><asp:Label ID="Label7" runat="server" Text="授课对象"></asp:Label></dt>
    <dd><asp:DropDownList ID="Target" runat="server">
            <asp:ListItem>本科生</asp:ListItem>
            <asp:ListItem>研究生</asp:ListItem>
        </asp:DropDownList></dd>
    <dt><asp:Label ID="Label8" runat="server" Text="授课对象年级"></asp:Label></dt>
    <dd><asp:TextBox ID="TargetGrade" runat="server"></asp:TextBox></dd>
    </dl>
    <dl>
    <dt><asp:Label ID="Label9" runat="server" Text="开设课程理由"></asp:Label></dt>
    <dd><asp:TextBox ID="Reason" runat="server" Height="309px" TextMode="MultiLine"
            Width="555px" MaxLength="500"></asp:TextBox></dd>

    </dl>
    </fieldset>

           <asp:Button ID="bnSubmit" runat="server" onclick="bnSubmit_Click" Text="提交" 
            Width="74px" UseSubmitBehavior="False" />
        <asp:Button ID="Cancel" runat="server" onclick="bnCancel_Click" Text="返回" 
            Width="52px" />
                </form>
</body>
</html>
