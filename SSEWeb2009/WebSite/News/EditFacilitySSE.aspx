<%@ Page Language="C#" MasterPageFile="~/MasterPages/News.master" AutoEventWireup="true" CodeFile="EditFacilitySSE.aspx.cs" Inherits="News_EditFacilitySSE" Title="无标题页" %>

<%@ Register src="../UserControl/EditMMT.ascx" tagname="EditMMT" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderDefault" Runat="Server">
    <uc1:EditMMT ID="EditMMT1" runat="server" MMTID="STATIC_Facility_SSE" NewPost="false"  EditHeight="800"/>
</asp:Content>

