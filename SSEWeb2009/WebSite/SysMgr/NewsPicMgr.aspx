<%@ Page Language="C#" MasterPageFile="~/MasterPages/ManageSite.master" AutoEventWireup="true" CodeFile="NewsPicMgr.aspx.cs" Inherits="SysMgr_NewsPicMgr" Title="软件学院网站管理系统 - [新闻图片管理]" %>
<%@ Register src="../UserControl/NewsPicInfoControl.ascx" tagname="NewsPicInfoControl" tagprefix="uc" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="ContentMain" ContentPlaceHolderID="ContentPlaceHolderDefault" Runat="Server">
     <h3 class="h3style">
        新闻图片管理</h3>
    <hr size="0" noshade="noshade" color="#999999"/>
    <div class="divstyle">
         <asp:PlaceHolder ID="placeHolder" runat="server">
        </asp:PlaceHolder>
    </div>
</asp:Content>

