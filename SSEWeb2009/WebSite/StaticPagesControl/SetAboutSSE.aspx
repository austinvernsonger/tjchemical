<%@ Page Language="C#" MasterPageFile="~/MasterPages/blank.master" AutoEventWireup="true" CodeFile="SetAboutSSE.aspx.cs" Inherits="StaticPagesControl_SetAboutSSE" Title="Admin Only" %>

<%@ Register src="../UserControl/EditMMT.ascx" tagname="EditMMT" tagprefix="uc1" %>

<asp:Content ID="ctnt_head" ContentPlaceHolderID="phctnt_head" Runat="Server">
</asp:Content>
<asp:Content ID="ctnt_body" ContentPlaceHolderID="phctnt_body" Runat="Server">
    <uc1:EditMMT ID="mmt_aboutsse" runat="server" DepartmentId="-1" 
        MMTID="STATIC_ABOUT_SSE" Mode="passage" NewPost="False" 
        onsuccessgoto="~/StaticPages/AboutSSE.aspx" AllowAttachment="false" />
</asp:Content>