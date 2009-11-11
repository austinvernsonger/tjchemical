<%@ Page Language="C#" MasterPageFile="../MasterPages/HomeMaster.master" AutoEventWireup="true" CodeFile="Show.aspx.cs" Inherits="LabCenter_Notice_Show" %>

<%@ Register Src="~/UserControl/ViewMMT.ascx" TagName="ViewMMT" TagPrefix="ucl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <!--
    <asp:LinkButton ID="lbtnEdit" runat="server" PostBackUrl="~/LabCenter/Notice/Back/Edit.aspx">修改</asp:LinkButton><br/>
    -->   
    <ucl:ViewMMT ID="view" runat="server"  />
     
</asp:Content>
