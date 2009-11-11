<%@ Page Title="" Language="C#" MasterPageFile="~/StudentAffair/MasterPage.master" AutoEventWireup="true" CodeFile="MentalHealth.aspx.cs" Inherits="StudentAffair_MentalHealth" %>
<%@ Register Src="../UserControl/MMTList.ascx" TagName="MMTList" TagPrefix="ucl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2>心理健康指导</h2>
    
    <ucl:MMTList ID="MMTList1" runat="server" AllowPaging="True" DepartmentId="2" 
            Mode="news" PageSize="30" ShowClickCount="True" 
            ShowTime="True" InternalOnly="True" 
            ShowURL="../StudentAffair/Show.aspx" />
</asp:Content>

