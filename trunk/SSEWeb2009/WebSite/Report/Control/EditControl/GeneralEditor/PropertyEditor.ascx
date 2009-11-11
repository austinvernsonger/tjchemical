<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PropertyEditor.ascx.cs" Inherits="Report_Control_EditControl_GeneralEditor_PropertyEditor" %>
<asp:Panel ID="Panel_PropertyHolder" runat="server">
    <asp:Button ID="Button_Open" runat="server" onclick="Button_Open_Click" 
        Text="高级属性" />
    <asp:Panel ID="Panel1" runat="server" Visible="False">
        <asp:CheckBox ID="CB_IsKey" runat="server" Text="设为主键" 
            oncheckedchanged="CB_IsKey_CheckedChanged" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:CheckBox ID="CB_MustNotEmpty" runat="server" Text="不允许为空" 
            oncheckedchanged="CB_MustNotEmpty_CheckedChanged" />
        <br />
        <asp:Label ID="Label_MaxSize" runat="server" Text="最大字数(0表示无限制)"></asp:Label>
        <asp:TextBox ID="TB_MaxSize" runat="server" 
            ontextchanged="TB_MaxSize_TextChanged"></asp:TextBox>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
            ControlToValidate="TB_MaxSize" Display="Dynamic" ErrorMessage="请填入有效数字" 
            ValidationExpression="^[Z0-9]+$"></asp:RegularExpressionValidator>
        <br />
        <asp:Label ID="Label1" runat="server" Text="可编辑"></asp:Label>
        <asp:DropDownList ID="DropDownList_ResultEditMode" runat="server" 
            ontextchanged="DropDownList_ResultEditMode_TextChanged">
            <asp:ListItem>前后台</asp:ListItem>
            <asp:ListItem>前台</asp:ListItem>
            <asp:ListItem>后台</asp:ListItem>
        </asp:DropDownList>
        &nbsp;
        <br />
        <asp:Label ID="Label2" runat="server" Text="结果是否显示该列"></asp:Label>
        &nbsp;<asp:DropDownList ID="DropDownList_ResultViewMode" runat="server" 
            ontextchanged="DropDownList_ResultViewMode_TextChanged">
            <asp:ListItem>显示</asp:ListItem>
            <asp:ListItem>隐藏</asp:ListItem>
        </asp:DropDownList>
        <asp:Button ID="BN_Confirm" runat="server" onclick="BN_Confirm_Click" 
            Text="确定" Enabled="False" Visible="False" />
        <asp:Timer ID="Timer_Refresh" runat="server" Enabled="False" 
            EnableViewState="False" Interval="1" ontick="Timer_Refresh_Tick">
        </asp:Timer>
    </asp:Panel>
</asp:Panel>

