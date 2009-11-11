<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NewCourseApplicationLabel.aspx.cs" Inherits="Teaching_BackEnd_NewCourseApplicationLabel" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<link href="../../CssClass/TeachingBackEnd.css" rel="stylesheet" type="text/css" />
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="Form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    <fieldset>
    <legend>开课申请表</legend>
    <dl>
    <dt><asp:Label ID="Label5" runat="server" Text="任课教师"></asp:Label></dt>
    <dd><asp:Label ID="TeacherName" runat="server"></asp:Label></dd>
    
    <dt><asp:Label ID="Label1" runat="server" Text="课程名称"></asp:Label></dt>
    <dd><asp:Label ID="CourseName" runat="server"></asp:Label></dd>
    
    <dt><asp:Label ID="Label2" runat="server" Text="上课时数"></asp:Label></dt>
    <dd><asp:Label ID="Hour" runat="server"></asp:Label>学时</dd>
    
    <dt><asp:Label ID="Label3" runat="server" Text="授课语种"></asp:Label></dt>
    <dd><asp:Label ID="Language" runat="server"></asp:Label></dd>
    
    <dt><asp:Label ID="Label4" runat="server" Text="开课时间"></asp:Label></dt>    
    <dd><asp:Label ID="CourseTime" runat="server"></asp:Label></dd>

    <dt><asp:Label ID="Label6" runat="server" Text="开课次数"></asp:Label></dt>
    <dd><asp:Label ID="CourseNumber" runat="server"></asp:Label></dd>

    <dt><asp:Label ID="Label7" runat="server" Text="授课对象"></asp:Label></dt>
    <dd><asp:Label ID="Target" runat="server" Text="Label"></asp:Label></dd>
    
    <dt><asp:Label ID="Label8" runat="server" Text="授课对象年级"></asp:Label></dt>
    <dd><asp:Label ID="TargetGrade" runat="server"></asp:Label></dd>
    </dl>
    <dl>
    <dt><asp:Label ID="Label9" runat="server" Text="开设课程理由"></asp:Label></dt>
    <dd><asp:TextBox ID="Reason" runat="server" Height="322px" TextMode="MultiLine"
            Width="555px" MaxLength="500" ReadOnly="True"></asp:TextBox></dd>
    </dl>
    </fieldset>
    </form>
</body>
</html>

