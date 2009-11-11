<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TeachingOutline.aspx.cs" Inherits="Teaching_BackEnd_TeachingOutline" %>

<%@ Register assembly="FredCK.FCKeditorV2" namespace="FredCK.FCKeditorV2" tagprefix="FCKeditorV2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        教学大纲<br />
        <FCKeditorV2:FCKeditor ID="TeachingOutline" runat="server" Height="800px">
        </FCKeditorV2:FCKeditor>
        <asp:Button ID="Submit" runat="server" onclick="Submit_Click" Text="提交" />
        <asp:Button ID="Cancel" runat="server" Text="取消" />
        <br />
    
    </div>
    </form>
</body>
</html>
