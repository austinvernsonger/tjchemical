<%@ Page Language="C#" MasterPageFile="~/MasterPages/News.master" AutoEventWireup="true" CodeFile="NewsPost.aspx.cs" Inherits="News_NewsPost" Title="新闻发布" %>

<%@ Register src="../UserControl/EditMMT.ascx" tagname="EditMMT" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderDefault" Runat="Server">
    <h3 class="title">新闻发布</h3>
    <div id="edit">
    <uc1:EditMMT ID="EditMMT1" runat="server" NewPost="true" Mode="news" DepartmentId="0" EditHeight="800"/>
    </div>
</asp:Content>

