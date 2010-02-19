<%@ Page Language="C#" MasterPageFile="~/MasterPage/BackSys.master" AutoEventWireup="true" CodeFile="EditNotice.aspx.cs" Inherits="Notice_EditNotice" Title="Untitled Page" %>

<%@ Register src="~/UserControl/EditMMT.ascx" tagname="EditMMT" tagprefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
     <uc1:EditMMT ID="EditMMT1" runat="server" DepartmentId="3"  Mode="notice" NewPost="false" Registration="true"/>
</asp:Content>

