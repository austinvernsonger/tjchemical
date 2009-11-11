<%@ Page Language="C#" MasterPageFile="~/MasterPages/News.master" AutoEventWireup="true" CodeFile="NoticeEdit.aspx.cs" Inherits="News_NoticeEdit" Title="无标题页" %>

<%@ Register src="../UserControl/EditMMT.ascx" tagname="EditMMT" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderDefault" Runat="Server">
<div id="edit">
    <h3  class="title">通知编辑</h3>
    <uc1:EditMMT ID="EditMMT1" runat="server" NewPost="false" Mode="notice" DepartmentId="0" EditHeight="800"/>
    </div>
</asp:Content>

