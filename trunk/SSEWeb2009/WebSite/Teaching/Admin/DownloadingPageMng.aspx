<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DownloadingPageMng.aspx.cs" Inherits="Teaching_Admin_DownloadingPageMng" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <p>
        文件上传</p>
    <form id="form1" runat="server">
    <p>
        <asp:FileUpload ID="FileUpload1" runat="server" />
    </p>
    <div>
    
        <asp:Button ID="Submit" runat="server" onclick="Submit_Click" Text="提交" />
        <asp:Button ID="Cancel" runat="server" Text="取消" 
            PostBackUrl="~/Teaching/Admin/AdminManagement.aspx?Type=8" />
    
    </div>
    </form>
</body>
</html>
