<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PersonalSummary.aspx.cs" Inherits="Teaching_BackEnd_PersonalSummary" %>

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
        个人总结</p>
    <FCKeditorV2:FCKeditor ID="PersonalSummary" runat="server" Height="800px">
    </FCKeditorV2:FCKeditor>
    <p>
        <asp:Button ID="Submit" runat="server" onclick="Submit_Click" Text="提交" />
        <asp:Button ID="Button2" runat="server" Text="取消" />
        <br />
    </p>
    </div>
    </form>
</body>
</html>
