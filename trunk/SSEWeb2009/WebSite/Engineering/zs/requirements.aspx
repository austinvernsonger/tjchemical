<%@ Page Language="C#" MasterPageFile="~/Engineering/zs/Enrollment.master" AutoEventWireup="true" CodeFile="requirements.aspx.cs" Inherits="Engineering_zs_requirements" Title="无标题页" %>

<%@ Register src="../../UserControl/MMTList.ascx" tagname="MMTList" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>招生简章</h1>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
     <img src="../Resources/images/banner_adm.jpg" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
     <h1>同济大学软件学院工程硕士自主招生简章</h1>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
    
    <uc1:MMTList ID="MMTList1" runat="server" />
    
</asp:Content>

