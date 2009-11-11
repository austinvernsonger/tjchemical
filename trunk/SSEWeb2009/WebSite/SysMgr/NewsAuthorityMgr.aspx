<%@ Page Language="C#" MasterPageFile="~/MasterPages/ManageSite.master" AutoEventWireup="true" CodeFile="NewsAuthorityMgr.aspx.cs" Inherits="SysMgr_NewsAuthorityMgr" Title="软件学院网站管理系统 - [新闻权限管理]" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderDefault" Runat="Server">
<div style="font-size:12px; font-family:宋体; color:Black;">
        <a href="NewNewsAuthority.aspx" target="ContentFrm">新增新闻发布人</a>
        |
        <a href="MgrNewsAuthority.aspx" target="ContentFrm">管理新闻发布人</a>
        <br /> <br />
        <iframe name="ContentFrm" 
            style="padding: 5px 5px 5px 8px; border: 1px dashed #808080; font:12px|宋体"  height="100%" width="95%"
            marginheight="0" marginwidth="0"
            frameborder="0" 
            onload="this.height=this.contentWindow.document.body.scrollHeight" src="NewNewsAuthority.aspx"></iframe>
</div>
</asp:Content>

