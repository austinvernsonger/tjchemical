<%@ Page Language="C#" MasterPageFile="~/MasterPages/blank.master" AutoEventWireup="true" CodeFile="NoticeEdit.aspx.cs" Inherits="SysMgr_NoticeEdit" Title="无标题页" %>

<%@ Register src="../UserControl/EditMMT.ascx" tagname="EditMMT" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="phctnt_head" Runat="Server">
    <link rel="stylesheet" type="text/css" href="../CssClass/sysmgr_contentstyle.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="phctnt_body" Runat="Server">
    <h3 class="titleblue">通知发布</h3>
    <uc1:EditMMT ID="EditMMT1" runat="server" Mode="notice" NewPost=true DepartmentId="0" EditHeight="500"/>
</asp:Content>

