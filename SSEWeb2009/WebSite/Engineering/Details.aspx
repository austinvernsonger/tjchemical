<%@ Page Language="C#" MasterPageFile="~/Engineering/ArticleView.master" AutoEventWireup="true" CodeFile="Details.aspx.cs" Inherits="Engineering_Details" Title="无标题页" %>

<%@ Register src="../UserControl/ViewMMT.ascx" tagname="ViewMMT" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlace" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
        <uc1:ViewMMT ID="ViewMMT1" runat="server"  ShowClickCount="true" ShowLabel="false" />
    </div>
</asp:Content>

