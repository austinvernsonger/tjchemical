 <%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/default_menu.master" AutoEventWireup="true" CodeFile="DefaultPage.aspx.cs" Inherits="Teaching_DefaultPage" %>

<%@ Register src="../../UserControl/MMTList.ascx" tagname="MMTList" tagprefix="uc1" %>
<%@ Register src="../../UserControl/Calendar.ascx" tagname="Calendar" tagprefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../CssClass/TeachingHomepage.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="phctnt_body" Runat="Server">
    <div id="middle" style="width:900px; margin-left:auto; margin-right:auto; height:395px;">
        <div id="notice" style="width:439px; float:left; height:395px; padding:0; border:0; margin:0;">
            <div id="notice_name" style="height:37px; background-image:url(../../Resources/Images/notice_name.jpg); padding:0; border:0; margin:0;"></div>
            <div id="notice_body" style="height:358px; background-image:url(../../Resources/Images/middle_body.jpg); padding:0; border:0; margin:0;">
                <uc1:MMTList ID="MMTLNews" runat="server" DepartmentId="2"  AllowPaging="True"  
                    EmptyString="没有新闻" PageSize="15" Mode="news" ShowTime="True" 
                    ShowURL="../Teaching/FrontEnd/ShowNews.aspx" />
                
            </div>
        </div>
        <div id="nspacep" style="width:22px; float:left; height:395px; padding:0; border:0; margin:0;"></div>
        <div id="post" style="width:439px; float:left; height:395px; padding:0; border:0; margin:0;">
            <div id="post_name" style="height:37px; background-image:url(../../Resources/Images/post_name.jpg); padding:0; border:0; margin:0;"></div>
            <div id="post_body" style="height:358px; background-image:url(../../Resources/Images/middle_body.jpg); padding:0; border:0; margin:0;">
                <uc1:MMTList ID="MMTLBulletin" runat="server" DepartmentId="2"  
                    AllowPaging="True" EmptyString="没有公告" PageSize="15" InternalOnly="True" 
                    Mode="notice" ShowURL="../Teaching/FrontEnd/ShowNews.aspx" />
            </div>
        </div>
    </div>
</asp:Content>

