<%@ Page Language="C#" MasterPageFile="~/Education/MasterPages/HomeMaster.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Education_Default" Title="Untitled Page" %>

<%@ Register src="UserControl/DefaultMenu.ascx" tagname="DefaultMenu" tagprefix="uc1" %>

<%-- Add content controls here --%><asp:Content ID="Content1" runat="server" 
    contentplaceholderid="ContentPlaceHolder1">
    <div id = "div1" align = "center">
    this is the content!
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Button" />
    </div> 
</asp:Content>

