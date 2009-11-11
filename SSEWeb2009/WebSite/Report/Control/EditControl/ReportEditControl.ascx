<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ReportEditControl.ascx.cs" Inherits="Report_Control_EditControl_ReportEditControl" %>
<%@ Register src="GeneralEditor/GeneralEditor.ascx" tagname="GeneralEditor" tagprefix="uc1" %>

<asp:Panel ID="Panel1" runat="server" BackColor="#3399FF">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:Panel>
<asp:Panel ID="Panel_Holder" runat="server" CssClass="ReportHolderPanel">
        <uc1:GeneralEditor ID="GeneralEditor1" runat="server" />

        <div class="EditItemLabel">问卷</div>
        <div class="EditItemControl">
            <asp:TextBox ID="TB_ReportName" runat="server" AutoPostBack="True" 
                ontextchanged="TB_ReportName_TextChanged" Width="150px"></asp:TextBox>
        </div>
        <div class="EditItemLabel">新建项类型</div>
        <div class="EditItemControl">
            <asp:DropDownList ID="DropDownList_ItemType" runat="server" Width="150px">
            <asp:ListItem>文本项</asp:ListItem>
            <asp:ListItem>子问卷</asp:ListItem>
            <asp:ListItem>单选项</asp:ListItem>
            <asp:ListItem>富文本项</asp:ListItem>
            <asp:ListItem>学号</asp:ListItem>
            <asp:ListItem>审核</asp:ListItem>
            </asp:DropDownList>
            <asp:Button ID="BN_AddItem" runat="server" onclick="BN_AddItem_Click" 
            Text="添加" />
        </div>


        <asp:BulletedList ID="BulletedList_ErrorMessage" runat="server" 
            EnableViewState="False" Font-Bold="True" Font-Size="X-Small" ForeColor="Red">
        </asp:BulletedList>
        <asp:Panel ID="Panel_SubItem" runat="server" CssClass="ReportSubItemHolderPanel">
                <asp:PlaceHolder ID="PlaceHolder_SubItem" runat="server" 
                EnableViewState="False"></asp:PlaceHolder>
        </asp:Panel>
</asp:Panel>

<asp:Timer ID="Timer_Refresh" runat="server" Enabled="False" 
    EnableViewState="False" Interval="1">
</asp:Timer>
        
