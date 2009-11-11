<%@ Page Language="C#" MasterPageFile="~/MasterPages/blank.master" AutoEventWireup="true" CodeFile="ActivityEdit.aspx.cs" Inherits="SysMgr_ActivityEdit" Title="无标题页" %>

<%@ Register src="../UserControl/EditMMT.ascx" tagname="EditMMT" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="phctnt_head" Runat="Server">
    <link rel="stylesheet" type="text/css" href="../CssClass/sysmgr_contentstyle.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="phctnt_body" Runat="Server">
    <h3 class="titleblue">活动发布</h3>
    <uc1:EditMMT ID="EditMMT1" runat="server" Mode="Activity" NewPost="true" DepartmentId="0" EditHeight="600"/>
</asp:Content>

