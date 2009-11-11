<%@ Page Language="C#" MasterPageFile="~/MasterPages/News.master" AutoEventWireup="true" CodeFile="ActivityEdit.aspx.cs" Inherits="News_ActivityEdit" Title="无标题页" %>

<%@ Register src="../UserControl/EditMMT.ascx" tagname="EditMMT" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderDefault" Runat="Server">
    <div id="edit">
    <h3 class="title">活动编辑</h3>
    <uc1:EditMMT ID="EditMMT1" runat="server" NewPost="false" Mode="Activity" DepartmentId="0" EditHeight="800"/>
    </div>
</asp:Content>

