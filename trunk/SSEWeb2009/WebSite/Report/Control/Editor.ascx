<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Editor.ascx.cs" Inherits="Report_Control_Editor" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Panel ID="Panel_StartEdit" runat="server">
    <asp:Button ID="BN_EditReport" runat="server" Text="编辑问卷" 
        onclick="BN_EditReport_Click" />
    <asp:Button ID="BN_CheckResult" runat="server" onclick="BN_CheckResult_Click" 
        Text="查看结果" />
</asp:Panel>
<asp:BulletedList ID="BulletedList_WarnningMessage" runat="server" 
    EnableViewState="False">
</asp:BulletedList>
<asp:Panel ID="Panel_Edit" runat="server" Visible="False">
    <asp:Button ID="BN_NewReport" runat="server" onclick="BN_NewReport_Click" 
    Text="新建" />
    <asp:Button ID="BN_LoadFile" runat="server" onclick="BN_LoadFile_Click" 
        Text="还原" />
    <asp:Button ID="BN_CancelEdit" runat="server" onclick="BN_CancelEdit_Click" 
        Text="取消编辑" />
    <br />
    <br />
    <asp:Panel ID="Panel_Report" runat="server">
        <asp:PlaceHolder ID="PlaceHolder_Report" runat="server"></asp:PlaceHolder>
    </asp:Panel>
</asp:Panel>
<p>
    <asp:Label ID="Hidden_HasOldResult" runat="server" Visible="False"></asp:Label>
</p>
<p>
<asp:Label ID="Hidden_DescriptorFilePath" runat="server" Visible="False"></asp:Label>
</p>
<p>
    <asp:Label ID="Hidden_ResultFilePath" runat="server" Visible="False"></asp:Label>
</p>
<p>
    <asp:Label ID="Label_ErrorMessage" runat="server" EnableViewState="False" 
        ForeColor="Red"></asp:Label>
</p>
<asp:Timer ID="Timer_Refresh" runat="server" Enabled="False" 
    EnableViewState="False" Interval="1">
</asp:Timer>
<cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" 
    ConfirmText="已有结果存在，继续并删除结果？" Enabled="False" TargetControlID="BN_EditReport">
</cc1:ConfirmButtonExtender>


