<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/ManageSite.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="SysMgr_Default" %>

<%@ Register src="../UserControl/TagListControl.ascx" tagname="TagListControl" tagprefix="uc" %>


<asp:Content ID="ContentHead" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="ContentMain" ContentPlaceHolderID="ContentPlaceHolderDefault" Runat="Server">

  <div id="info">
    <p> Hey, I'm the 'info' div! </p>
    <p> I look like this: </p>
  </div>
</asp:Content>

