<%@ Page Language="C#" MasterPageFile="~/Engineering/zs/Enrollment.master" AutoEventWireup="true" CodeFile="regulation.aspx.cs" Inherits="Engineering_zs_regulation" Title="无标题页" %>

<%@ Register src="../../UserControl/MMTList.ascx" tagname="MMTList" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>招生简章<br />Regulation</h1>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <img src="../Resources/images/banner_adm.jpg" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
    <h1>同济大学软件学院工程硕士招生简章</h1>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
    <uc1:MMTList ID="MMTList1" runat="server" DepartmentId="42" Mode="Passage" TitleMaxLength="50" 
    EmptyString="当前没有招生简章" PageSize="20" InternalOnly="true" ShowTime="true" 
    Target="_blank" ShowURL="../Engineering/Details.aspx"/>
</asp:Content>

