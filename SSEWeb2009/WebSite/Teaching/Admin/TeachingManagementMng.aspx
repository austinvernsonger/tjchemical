<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TeachingManagementMng.aspx.cs" Inherits="Teaching_Admin_TeachingManagementMng" %>

<%@ Register assembly="FredCK.FCKeditorV2" namespace="FredCK.FCKeditorV2" tagprefix="FCKeditorV2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <p>
            教学管理条例管理</p>
        <p>
        <asp:DropDownList ID="Type" runat="server">
            <asp:ListItem>教师管理类条例</asp:ListItem>
            <asp:ListItem>学生培养类条例</asp:ListItem>
            <asp:ListItem>教学过程管理类条例</asp:ListItem>
        </asp:DropDownList>
        <br />
        文章标题：&nbsp;&nbsp;&nbsp; 
        <asp:TextBox ID="ArticleTitle" runat="server" Width="280px"></asp:TextBox>
    </p>
    <FCKeditorV2:FCKeditor ID="TeachingManagementArticle" runat="server" Height="800px">
    </FCKeditorV2:FCKeditor>
    <p>
        <asp:Button ID="Submit" runat="server" onclick="Submit_Click" Text="提交" />
        <asp:Button ID="Cancel" runat="server" 
            PostBackUrl="~/Teaching/Admin/AdminManagement.aspx?Type=4" Text="取消" />
    </p>
    <p>
        &nbsp;</p>
    </div>
    </form>
</body>
</html>
