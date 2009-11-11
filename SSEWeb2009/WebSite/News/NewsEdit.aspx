<%@ Page Language="C#" MasterPageFile="~/MasterPages/News.master" AutoEventWireup="true" CodeFile="NewsEdit.aspx.cs" Inherits="News_NewsEdit" Title="无标题页" %>

<%@ Register src="../UserControl/EditMMT.ascx" tagname="EditMMT" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderDefault" Runat="Server">
    <div id="edit">
    <h3 class="title">新闻编辑</h3>
    <uc1:EditMMT ID="EditMMT1" runat="server" NewPost="false" Mode="news" DepartmentId="0" EditHeight="800"/>
    </div>
</asp:Content>

