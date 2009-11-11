<%@ Page Language="C#" MasterPageFile="../MasterPages/HomeMaster.master" AutoEventWireup="true" CodeFile="List.aspx.cs" Inherits="LabCenter_Notice_List" %>

<%@ Register src="~/UserControl/MMTList.ascx" tagname="MMTList" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    
    <uc1:MMTList ID="MMTList1" runat="server" AllowPaging="true" DepartmentId="3" 
            Management="false" Mode="Notice" PageSize="20" ShowClickCount="True" 
            ShowTime="True" InternalOnly="false"
            ShowURL="~/LabCenter/Notice/Show.aspx"  />
    
</asp:Content>
