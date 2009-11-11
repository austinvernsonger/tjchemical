<%@ Page Language="C#" MasterPageFile="~/MasterPages/default_menu.master" AutoEventWireup="true" CodeFile="FacilitySSE.aspx.cs" Inherits="StaticPages_FacilitySSE" Title="机构设置--同济大学软件学院" %>

<%@ Register src="../UserControl/ViewMMT.ascx" tagname="ViewMMT" tagprefix="uc1" %>
<asp:Content ID="ctnt_head" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="ctnt_body" ContentPlaceHolderID="phctnt_body" Runat="Server">
    <div style="width: 900px; margin-left: auto; margin-right: auto;">
        <uc1:ViewMMT ID="mmt_about" runat="server" MMTID="STATIC_Facility_SSE" ShowClickCount="False" ShowLabel="False" ShowTitle="False"  TitleChange="False"/>
    </div>
</asp:Content>
