<%@ Page Language="C#" MasterPageFile="~/LabCenter/MasterPages/HomeMaster.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="LabCenter_Repair_Order_Default" %>


<%@ Register src="../../NavUserControls/Repair.ascx" tagname="Repair" tagprefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <uc1:Repair ID="Repair1" runat="server" />

</asp:Content>