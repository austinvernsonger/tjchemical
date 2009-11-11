<%@ Page Language="C#" MasterPageFile="~/Engineering/educationplan/EducationPlan.master" AutoEventWireup="true" CodeFile="programme.aspx.cs" Inherits="Engineering_educationplan_programme" Title="无标题页" %>

<%@ Register src="../../UserControl/ViewMMT.ascx" tagname="ViewMMT" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>培养计划<br />Plan</h1>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <img src="../Resources/images/banner_edu.jpg" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
    <h1>同济大学软件学院工程硕士培养方案</h1>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <uc1:ViewMMT ID="ViewMMT1" runat="server" MMTID="EDUCATION_PLAN"  ShowClickCount="False" ShowLabel="False" ShowTitle="False"  />
</asp:Content>

