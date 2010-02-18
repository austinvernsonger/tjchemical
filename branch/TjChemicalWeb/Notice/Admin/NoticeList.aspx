<%@ Page Language="C#" MasterPageFile="~/MasterPage/BackSys.master" AutoEventWireup="true" CodeFile="NoticeList.aspx.cs" Inherits="Notice_Admin_NoticeList" Title="Untitled Page" %>

<%@ Register src="~/UserControl/MMTList.ascx" tagname="MMTList" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:MMTList ID="mmtNoticeList" runat="server" 
		                    DepartmentId="3" ShowTime="True" ShowClickCount="false" 
		                    Mode="notice" EmptyString="No" 
		                    AllowPaging="false" ShowURL="~/Notice/Admin/EditNotice.aspx" 
		                     ItemCssClass="notice_content_stl1" isReport="true"/>
</asp:Content>

