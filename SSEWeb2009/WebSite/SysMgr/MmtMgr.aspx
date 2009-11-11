<%@ Page Title="软件学院网站管理系统 - [富文本管理]" Language="C#" MasterPageFile="~/MasterPages/ManageSite.master" AutoEventWireup="true" CodeFile="MmtMgr.aspx.cs" Inherits="SysMgr_MmtMgr" %>
<%@ Register Src="~/UserControl/ViewMMT.ascx" TagName="ViewMMT" TagPrefix="uc" %>
<%@ Register Src="~/UserControl/MMTList.ascx" TagName="MMTList" TagPrefix="uc" %>

<%@ Register src="../UserControl/EditMMT.ascx" tagname="EditMMT" tagprefix="uc1" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="head" Runat="Server">
    <link rel="stylesheet" type="text/css" href="../CssClass/sysmgr_contentstyle.css" />
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="ContentPlaceHolderDefault" Runat="Server">
    <h3 class="h3style">
        富文本管理</h3>
    <hr size="0" noshade="noshade" color="#999999" />
    <div class="divstyle">
        <asp:LinkButton ID="lbNews" runat="server" onclick="lbNews_Click">新闻</asp:LinkButton>| 
        <asp:LinkButton ID="lbActivity" runat="server" onclick="lbActivity_Click">活动</asp:LinkButton> | 
        <asp:LinkButton ID="lbNotice" runat="server" onclick="lbNotice_Click">通知</asp:LinkButton>| 
        <br /> 
        <h3 runat="server" id="titleh3" class="titleblue">新闻管理</h3>
        <br />
        <uc:MMTList ID="mmtList" runat="server" DepartmentId="0" ShowTime="True" ShowClickCount="True" Management="True" EmptyString="No" PageSize="10" AllowPaging="True" ShowURL="~/News/NewsEdit.aspx"/>
     </div>
</asp:Content>

