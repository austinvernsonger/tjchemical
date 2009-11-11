<%@ Page Language="C#" MasterPageFile="~/MasterPages/News.master" AutoEventWireup="true" CodeFile="NoticePost.aspx.cs" Inherits="News_NoticePost" Title="无标题页" %>

<%@ Register src="../UserControl/EditMMT.ascx" tagname="EditMMT" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderDefault" Runat="Server">
<div id="edit">
    <h3  class="title">通知发布</h3>
    <uc1:EditMMT ID="EditMMT1" runat="server" NewPost="true" Mode="notice" DepartmentId="0" EditHeight="800"/>
    </div>
</asp:Content>
