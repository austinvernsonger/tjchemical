<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ArrangeExperiment.aspx.cs" Inherits="LabCenter_Reservation_ArrangeExperiment" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register Src="../UserControl/TimeTableEdit.ascx" TagName="TimeTableEdit" TagPrefix="uc1" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <link href="~/LabCenter/Reservation/UserControl/TabContainer.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label4" runat="server" AssociatedControlID="DropDownList1" Text="学年学期:"></asp:Label>
        <asp:DropDownList ID="DropDownList1" runat="server" AppendDataBoundItems="true">
            <asp:ListItem></asp:ListItem>
        </asp:DropDownList>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="DropDownList1"
            ErrorMessage="RequiredFieldValidator" ValidationGroup="Choose" 
            Text="(Required)" Visible="False"></asp:RequiredFieldValidator>
        <br /><br />
        <asp:Label ID="Label1" runat="server" Text="第几周:" AssociatedControlID="DropDownList2"></asp:Label>
        <asp:DropDownList ID="DropDownList2" runat="server" AppendDataBoundItems="true">
            <asp:ListItem></asp:ListItem>
            </asp:DropDownList>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="DropDownList2"
            ErrorMessage="RequiredFieldValidator" ValidationGroup="Choose" Text="(Required)"></asp:RequiredFieldValidator>
            <br /><br />
            <div>
        <asp:Button ID="btnselect" runat="server" ValidationGroup="Choose" Text="确定" OnClick="btnselect_Click" />&nbsp;
        &nbsp;<br />
        </div>
    </div>
    
    <hr />
    
    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </cc1:ToolkitScriptManager>
    
    <asp:CheckBoxList ID="cblExperiment" RepeatColumns="2" runat="server"></asp:CheckBoxList>
    
    <hr />
        
    <asp:Panel ID="PanelNewTTShow" runat="server" Visible="false">
        <asp:Label ID="Label2" runat="server" Text="Label">目前版本尚未完善，配置新实验时间表需要先修改默认时间表，在这里确认后保存。</asp:Label><br />
      
        <asp:Button ID="btnLinkEdit" runat="server" Text="配置默认时间表" 
            onclick="btnLinkEdit_Click" Visible="false" />
        <asp:Button ID="btnUseDefault" runat="server" Text="应用默认时间表" 
            onclick="btnUseDefault_Click" />
    </asp:Panel>
    <asp:UpdatePanel UpdateMode="Conditional" runat="server" ID="PanelTT">
        <ContentTemplate>
            <uc1:TimeTableEdit id="TTE" runat="server" Visible="false"></uc1:TimeTableEdit>
        </ContentTemplate>
    </asp:UpdatePanel>
        
    <asp:Button ID="btnSaveAll" runat="server" Text="保存" OnClick="btnSaveAll_Click" Visible="false" />
    </form>
</body>
</html>
