﻿<%@ Page Language="C#" MasterPageFile="~/MasterPages/News.master" AutoEventWireup="true" CodeFile="EditAboutSSE.aspx.cs" Inherits="News_EditAboutSSE" Title="无标题页" %>

<%@ Register src="../UserControl/EditMMT.ascx" tagname="EditMMT" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderDefault" Runat="Server">
    <uc1:EditMMT ID="EditMMT1" runat="server" MMTID="STATIC_ABOUT_SSE" NewPost=false  EditHeight="800"/>
</asp:Content>

