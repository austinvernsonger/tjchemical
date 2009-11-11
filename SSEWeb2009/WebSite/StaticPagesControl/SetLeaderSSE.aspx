<%@ Page Language="C#" MasterPageFile="~/MasterPages/blank.master" AutoEventWireup="true" CodeFile="SetLeaderSSE.aspx.cs" Inherits="StaticPagesControl_SetLeaderSSE" Title="Untitled Page" %>
<%@ Register src="../UserControl/EditMMT.ascx" tagname="EditMMT" tagprefix="uc1" %>
<asp:Content ID="ctnt_head" ContentPlaceHolderID="phctnt_head" Runat="Server">
</asp:Content>
<asp:Content ID="ctnt_body" ContentPlaceHolderID="phctnt_body" Runat="Server">
    <uc1:EditMMT ID="mmt_leader" runat="server" OnSuccessGoTo="~/StaticPages/LeaderSSE.aspx" 
        AllowAttachment="False" DepartmentId="-1" MMTID="STATIC_LEADER_SSE"
        Mode="passage" NewPost="False" />
</asp:Content>

