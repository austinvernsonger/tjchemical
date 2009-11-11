<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TeachingReformMng.aspx.cs" Inherits="Teaching_Admin_TeachingReformMng" %>

<%@ Register assembly="FredCK.FCKeditorV2" namespace="FredCK.FCKeditorV2" tagprefix="FCKeditorV2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <p>
            教学教改研究管理</p>
        <p>
            教改标题：&nbsp;&nbsp;&nbsp; 
        <asp:TextBox ID="ArticleTitle" runat="server" Width="166px"></asp:TextBox>
    </p>
    <FCKeditorV2:FCKeditor ID="TeachingReformArticle" runat="server" Height="800px">
    </FCKeditorV2:FCKeditor>
    <p>
        <asp:Button ID="Submit" runat="server" onclick="Submit_Click" Text="提交" />
        <asp:Button ID="Cancel" runat="server" 
            PostBackUrl="~/Teaching/Admin/AdminManagement.aspx?Type=9" Text="取消" />
    </p>
    <p>
        &nbsp;</p>
    </div>
    </form>
</body>
</html>
