<%@ Page Title="" Language="C#"  MasterPageFile="~/MasterPages/default_menu.master" AutoEventWireup="true"
    CodeFile="TeachingCommittee.aspx.cs" Inherits="Teaching_Committee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../../CssClass/TeachingFront.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="phctnt_body" runat="Server">
    <div style="width: 902px; margin-left: auto; margin-right: auto; background-image: url(../../Resources/Images/mid_body_up.jpg);
        border: 0; padding: 0;">
    </div>
    <div style="width: 902px; margin-left: auto; margin-right: auto; background-image: url(../../Resources/Images/mid_body_mid.jpg);
        border: 0; padding: 0;">
        <div style="width: 422px; margin-left: auto; margin-right: auto; border: 0; padding: 0;">
            <% =ShowContent() %>
        </div>
    </div>
    <div style="width: 902px; margin-left: auto; margin-right: auto; background-image: url(../../Resources/Images/mid_body_down.jpg);
        border: 0; padding: 0;">
    </div>
</asp:Content>
