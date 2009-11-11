<%@ Page Language="C#" MasterPageFile="~/MasterPages/ManageSite.master" AutoEventWireup="true" CodeFile="AccountMgr.aspx.cs" Inherits="SysMgr_AccountMgr" Title="软件学院网站管理系统 - [帐号管理]" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="ContentPlaceHolderDefault" Runat="Server">
    <h3 class="h3style">
        帐号管理</h3>
    <hr size="0" noshade="noshade" color="#999999"/>
    <div class="divstyle">
        <a href="../Login/LoginManage.aspx"target="ContentFrm">管理账户信息</a>
        |
        <a href="../Login/NewAccount.aspx" target="ContentFrm">新增账户信息</a>
        <br /> <br />
        <iframe name="ContentFrm" 
            style="padding: 5px 5px 5px 8px; border: 1px dashed #808080; font:12px|宋体"  height="100%" width="95%"
            marginheight="0" marginwidth="0"
            frameborder="0"
            onload="this.height=this.contentWindow.document.body.scrollHeight" src="../Login/LoginManage.aspx"></iframe>
    </div>
</asp:Content>

