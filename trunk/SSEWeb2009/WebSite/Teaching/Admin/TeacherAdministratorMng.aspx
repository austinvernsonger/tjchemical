﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TeacherAdministratorMng.aspx.cs" Inherits="Teaching_Admin_TeacherAdministratorMng" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        删除管理员<br />
        <asp:GridView ID="TeacherAdminGridView" runat="server" AllowPaging="True" 
        AutoGenerateDeleteButton="True"
        OnPageIndexChanging="PageIndexChanging"
        DataKeyNames="TeacherID"
        onrowdeleting="OnRowDeleting">
    </asp:GridView>
        <br />
        新增管理员<asp:CheckBoxList ID="TeacherCBL" runat="server">
        </asp:CheckBoxList>
    <asp:Button ID="BtnAdd" runat="server" onclick="BtnAdd_Click" Text="新增" />
    </div>
    </form>
</body>
</html>
