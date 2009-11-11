<%@ Page Language="C#" MasterPageFile="~/Engineering/degree/Degree.master" AutoEventWireup="true" CodeFile="application.aspx.cs" Inherits="Engineering_degree_application" Title="无标题页" %>

<%@ Register src="../../UserControl/ViewMMT.ascx" tagname="ViewMMT" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>申请答辩流程<br />Application</h1>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <img src="../Resources/images/banner_Degree.jpg" />  
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
    <h1>同济大学工程硕士申请答辩流程</h1>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">    
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <uc1:ViewMMT ID="ViewMMT1" runat="server" MMTID="DEGREE_APPLICATION"  ShowClickCount="False" ShowLabel="False" ShowTitle="False"/>
</asp:Content>

