<%@ Page Title="" Language="C#" MasterPageFile="~/AlumnusRecord/Admin/MasterPageBack.master" AutoEventWireup="true" CodeFile="AddInterview.aspx.cs" Inherits="AlumnusRecord_Admin_AddInterview" %>
<%@ Register Src="../../UserControl/EditMMT.ascx" TagName="EditMMT" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="varContent" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <uc1:editmmt ID="EditMMT1" runat="server" DepartmentId="6" Mode="news" NewPost="True"
        OnSuccessGoTo="addInfo.aspx" AllowAttachment="True" />
  
</asp:Content>

