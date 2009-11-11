<%@ Page Title="" Language="C#" MasterPageFile="~/AlumnusRecord/MasterPage.master" AutoEventWireup="true" CodeFile="alumnusNews.aspx.cs" Inherits="alumnusNews" %>
<%@ Register Src="../UserControl/MMTList.ascx" TagName="MMTList" TagPrefix="ucl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
    <div id="banner_news"></div>
    
    <div id="content">
        <div id="content_top"></div>
        <div id="sub_content">
    
            <ucl:MMTList ID="MMTList1" runat="server" AllowPaging="True" DepartmentId="1" 
            Mode="news" PageSize="30" ShowClickCount="True" 
            ShowTime="True" InternalOnly="True" 
            ShowURL="../AlumnusRecord/showInfo.aspx" />
            <li><a href="alumnusRecordHome.aspx">返回</a></li>	
        </div>
        <div id="content_bottom"></div>
     </div>	
</asp:Content>

