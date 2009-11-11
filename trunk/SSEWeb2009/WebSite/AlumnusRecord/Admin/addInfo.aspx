<%@ Page Title="发布信息" Language="C#" MasterPageFile="~/AlumnusRecord/Admin/MasterPageBack.master"
    AutoEventWireup="true" CodeFile="addInfo.aspx.cs" Inherits="AlumnusRecord_Admin_addInfo" %>

<%@ Register Src="../../UserControl/EditMMT.ascx" TagName="EditMMT" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="varContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <uc1:EditMMT ID="EditMMT1" runat="server" DepartmentId="1" Mode="news" NewPost="True"
        OnSuccessGoTo="addInfo.aspx" AllowAttachment="True" />
  
  
</asp:Content>
