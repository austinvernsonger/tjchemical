<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DefaultDraggable.aspx.cs" Inherits="Report_DefaultDragable" EnableEventValidation="False" %>
<%@ Register src="Control/EditorDraggable.ascx" tagname="Editor" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <link href="Resource/Css/ui.core.css" rel="stylesheet" type="text/css" />
    <link href="Resource/Css/ui.tabs.css" rel="stylesheet" type="text/css" />
    <link href="Resource/Css/DarggableStyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="Resource/Css/EditControlStyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="Resource/Css/DisplayControlStyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server" >
    <div>

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        
            <asp:Panel ID="Panel1" runat="server" style="width:600px">
                    <uc1:Editor ID="Editor1" runat="server" />
                    <br/>
            </asp:Panel>
            
            
        </ContentTemplate>
        
    </asp:UpdatePanel>
    
    </div>
    </form>
</body>
</html>
