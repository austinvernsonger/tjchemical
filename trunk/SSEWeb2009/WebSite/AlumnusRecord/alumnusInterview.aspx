<%@ Page Title="" Language="C#" MasterPageFile="~/AlumnusRecord/MasterPage.master" AutoEventWireup="true" CodeFile="alumnusInterview.aspx.cs" Inherits="alumnusInterview" %>

<%@ Register src="../UserControl/MMTList.ascx" tagname="MMTList" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="banner_interview"></div>
    <div id="content">
        <div id="content_top"></div>
        <div id="sub_content"><uc1:MMTList ID="MMTList1" runat="server"  AllowPaging="True" DepartmentId="6" 
                Mode="news" NeedThumbnail="True" PageSize="10" ShowClickCount="True" 
                ShowTime="True" ShowURL="../AlumnusRecord/showInfo.aspx"/>
                
                <div style="text-align:right;float:right;padding-bottom:0px;">
                    <asp:HyperLink ID="HyperLink1" runat="server" Text="·µ»Ø" NavigateUrl="alumnusRecordHome.aspx">·µ»Ø</asp:HyperLink>
                </div>
        </div>
         <div id="content_bottom"></div>
     </div>	
   
</asp:Content>

