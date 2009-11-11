<%@ Page Title="" Language="C#" MasterPageFile="~/StudentAffair/Student/MasterPage.master" AutoEventWireup="true" CodeFile="PersonalInfo.aspx.cs" Inherits="StudentAffair_Student_PersonalInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:DetailsView ID="DetailsView1" runat="server" Width="100%">
        <EmptyDataTemplate>
            没有相关数据
        </EmptyDataTemplate>
    </asp:DetailsView>
</asp:Content>

