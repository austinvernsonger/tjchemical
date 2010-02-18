<%@ Page Language="C#" MasterPageFile="~/MasterPage/BackSys.master" AutoEventWireup="true" CodeFile="NoticeShow.aspx.cs" Inherits="Notice_NoticeShow" Title="Untitled Page" %>

<%@ Register src="~/UserControl/MMTList.ascx" tagname="MMTList" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<p>
    <uc1:MMTList ID="MMT_Notice" runat="server" DepartmentId="0" PageSize="5" TitleMaxLength="15"
                    ShowTime="True" ShowClickCount="False" Mode="News" EmptyString="Empty." AllowPaging="true"
                    ShowURL="~/NewsDetail.aspx" SpecifialNews="true" ReturnWords="50" />
 </p>
</asp:Content>

