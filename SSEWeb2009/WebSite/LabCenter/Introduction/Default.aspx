<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/LabCenter/MasterPages/HomeMaster.master" CodeFile="Default.aspx.cs" Inherits="LabCenter_Introduction_Default" %>
<%@ Register Src="~/UserControl/ViewMMT.ascx" TagName="ViewMMT" TagPrefix="ucl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <!--<ucl:ViewMMT ID="mmt_about" runat="server" MMTID="STATIC_ABOUT_SSE" ShowClickCount="False" ShowLabel="False" ShowTitle="False" />-->
    <ucl:ViewMMT ID="view" runat="server"  MMTID="LABCENTER_INTRODUCTION" ShowClickCount="False" ShowLabel="False" ShowTitle="False" />
</asp:Content>
