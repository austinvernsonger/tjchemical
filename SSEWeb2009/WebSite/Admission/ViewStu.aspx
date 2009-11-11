<%@ Page Title="" Language="C#" MasterPageFile="~/Admission/MasterPage.master" AutoEventWireup="true" CodeFile="ViewStu.aspx.cs" Inherits="RecruitmentNew_ViewStu" %>

<%@ Register Src="../UserControl/ViewMMT.ascx" TagName="ViewMMT" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="view">
        <uc1:ViewMMT ID="MmtContent" runat="server" />
    </div>
</asp:Content>

