<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ElaborateCourse.aspx.cs" Inherits="Teaching_Admin_ElaborateCourse" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register src="../LinkListEx.ascx" tagname="LinkListEx" tagprefix="uc3" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div >查询精品课程：</div>
        <div>年度：</div>
        <asp:TextBox ID="ElaborateCourse_Year" runat="server"></asp:TextBox>
        <div>项目负责人：</div>
        <asp:TextBox ID="ElaborateCourse_Person" runat="server"></asp:TextBox>
        <div>项目名称：</div>
        <asp:TextBox ID="ElaborateCourse_ProjectName" runat="server"></asp:TextBox>
        <asp:Button ID="ElaborateCourseSearch" runat="server" Text="查询" 
            onclick="ElaborateCourseSearch_Click" />
       
    </div>
    <uc3:LinkListEx ID="LinkListExContent" runat="server" QuerySQL="select S.CourseID as ID,S.ProjectName as Title,T.CourseID as Content,0 as ContentType,-1 as FS   from [ElaborateCourse]as S,[ElaborateCourse]as T where S.CourseID = T.CourseID" 
    TargetPage="/Teaching/Admin/ElaborateCourseContent.aspx" />

    </form>
</body>
</html>
