<%@ Page Language="C#" MasterPageFile="~/MasterPages/blank.master" AutoEventWireup="true" CodeFile="SetHistorySSE.aspx.cs" Inherits="StaticPagesControl_SetHistorySSE" Title="Admin Only" %>

<%@ Register src="../UserControl/EditMMT.ascx" tagname="EditMMT" tagprefix="uc1" %>

<asp:Content ID="ctnt_head" ContentPlaceHolderID="phctnt_head" Runat="Server">
</asp:Content>
<asp:Content ID="ctnt_body" ContentPlaceHolderID="phctnt_body" Runat="Server">
    <uc1:EditMMT ID="mmt_history" runat="server" OnSuccessGoTo="~/StaticPages/HistorySSE.aspx" 
        AllowAttachment="False" DepartmentId="-1" MMTID="STATIC_HISTORY_SSE"
        Mode="passage" NewPost="False" />
</asp:Content>

