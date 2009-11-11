<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Report_Default"%>
<%@ Register src="Control/Editor.ascx" tagname="Editor" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <link href="Resource/Css/EditControlStyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">


    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <asp:Panel ID="Panel1" runat="server" style="width:600px">
                    <uc1:Editor ID="Editor1" runat="server" />
                    <br/>
                    <asp:Button ID="Button1" runat="server" Text="保存" onclick="Button1_Click" />
            </asp:Panel>
        </ContentTemplate>
        
    </asp:UpdatePanel>

    


    </form>
</body>
</html>
