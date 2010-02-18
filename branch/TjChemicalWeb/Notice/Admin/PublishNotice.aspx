<%@ Page Language="C#" MasterPageFile="~/MasterPage/BackSys.master" AutoEventWireup="true" CodeFile="PublishNotice.aspx.cs" Inherits="Notice_Admin_PublishNotice" Title="Untitled Page" %>

<%@ Register src="~/UserControl/EditMMT.ascx" tagname="EditMMT" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  
    <uc1:EditMMT ID="EditMMT1" runat="server" DepartmentId="3" Mode="notice" NewPost="True" Registration="true" AllowAttachment="true" />
  
</asp:Content>

