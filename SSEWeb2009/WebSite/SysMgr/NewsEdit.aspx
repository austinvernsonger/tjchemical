<%@ Page Language="C#" MasterPageFile="~/MasterPages/blank.master" AutoEventWireup="true" CodeFile="NewsEdit.aspx.cs" Inherits="SysMgr_NewsEdit" Title="无标题页" %>
<%@ Register src="~/UserControl/EditMMT.ascx" tagname="EditMMT" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="phctnt_head" Runat="Server">
    <link rel="stylesheet" type="text/css" href="../CssClass/sysmgr_contentstyle.css" />
</asp:Content>  
<asp:Content ID="Content2" ContentPlaceHolderID="phctnt_body" Runat="Server">
    <h3 class="titleblue">新闻发布</h3>
    <uc1:EditMMT ID="edit_news" runat="server" Mode="News" DepartmentId="0" EditHeight="600" />
</asp:Content>

