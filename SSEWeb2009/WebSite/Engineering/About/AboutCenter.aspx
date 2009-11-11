<%@ Page Language="C#" MasterPageFile="~/Engineering/About/About.master" AutoEventWireup="true" CodeFile="AboutCenter.aspx.cs" Inherits="Engineering_About_AboutCenter" Title="无标题页" %>

<%@ Register src="../../UserControl/ViewMMT.ascx" tagname="ViewMMT" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>关于硕士中心<br />About</h1>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <img src="../Resources/images/banner_intro.jpg"/>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
    <h1>同济大学软件学院硕士中心介绍</h1>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <uc1:ViewMMT ID="ViewMMT1" runat="server" MMTID="ABOUT_MSE"  ShowClickCount="False" ShowLabel="False" ShowTitle="False" />
</asp:Content>

