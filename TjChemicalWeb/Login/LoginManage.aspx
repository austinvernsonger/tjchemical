<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LoginManage.aspx.cs" Inherits="Login_LoginManage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>帐号管理</title>
    <style type="text/css">
        .style1
        {
        	font-weight:normal;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" 
        AssociatedUpdatePanelID="Up1">
        <ProgressTemplate>
            查询查询中
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel  runat="server" ID="Up1">
    <Triggers>
     <asp:AsyncPostBackTrigger ControlID="grvLoginInformation" EventName="PageIndexChanging" />
     <asp:AsyncPostBackTrigger ControlID="grvLoginInformation" EventName="RowDeleting" />
     <asp:AsyncPostBackTrigger ControlID="grvLoginInformation" EventName="RowUpdating" />
     <asp:AsyncPostBackTrigger ControlID="grvLoginInformation" EventName="RowEditing" />
    </Triggers>
    <ContentTemplate>
    <div style="font-size:14px; font-family:宋体; color:Black;">
        <asp:GridView ID="grvLoginInformation" runat="server" 
            AutoGenerateColumns="False" DataKeyNames="AccountID" 
            onrowcancelingedit="grvLoginInformation_RowCancelingEdit"  
            onrowediting="grvLoginInformation_RowEditing" 
                onrowupdating="grvLoginInformation_RowUpdating" Font-Size="13px">
            <Columns>
                <asp:CommandField ShowEditButton="True" />
                <asp:TemplateField HeaderText="选择删除" HeaderStyle-CssClass="style1">
                    <ItemTemplate>
                        <asp:CheckBox ID="cbDelete" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="帐号" HeaderStyle-CssClass="style1">
                    <ItemTemplate>
                        <asp:Label ID="lbAccountID" runat="server" Text='<%# Eval("AccountID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="密码" HeaderStyle-CssClass="style1">
                    <ItemTemplate>
                        <asp:Label ID="lbPassword" runat="server" Text='<%# Eval("Password") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate> 
                        <asp:TextBox ID="tbPassword" runat="server"  Width="60px"  Text='<%# Eval("Password") %>'></asp:TextBox>
                    </EditItemTemplate> 
                </asp:TemplateField>
                <asp:TemplateField HeaderText="账号状态" HeaderStyle-CssClass="style1">
                    <EditItemTemplate>
                        <asp:DropDownList ID="ddlAccountState" runat="server" SelectedValue='<%# Eval("AccountState") %>' >
                            <asp:ListItem Value="0">正常</asp:ListItem>
                            <asp:ListItem Value="1">冻结</asp:ListItem>
                        </asp:DropDownList>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:DropDownList ID="ddlAccountState1" runat="server" SelectedValue='<%# Eval("AccountState") %>' Enabled=false>
                            <asp:ListItem Value="0">正常</asp:ListItem>
                            <asp:ListItem Value="1">冻结</asp:ListItem>
                        </asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="E-Mail地址" HeaderStyle-CssClass="style1">
                    <ItemTemplate>
                        <asp:Label ID="lbSafetyEmail" runat="server" Text='<%# Eval("SafetyEmail") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate> 
                        <asp:TextBox ID="tbSafetyEmail" runat="server" Width="85%" Text='<%# Eval("SafetyEmail") %>'></asp:TextBox>
                    </EditItemTemplate> 
                </asp:TemplateField>
                <asp:TemplateField HeaderText="E-mail认证" HeaderStyle-CssClass="style1">
                    <ItemTemplate>
                        <asp:CheckBox ID="cbEmailValidation1" runat="server" Checked='<%# Eval("EmailValidation") %>' Enabled=false/>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:CheckBox ID="cbEmailValidation" runat="server" Checked='<%# Eval("EmailValidation") %>'/>
                    </EditItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:LinkButton ID="lbSelectAll" runat="server" onclick="lbSelectAll_Click" 
            ForeColor="Black" Font-Size="12px">全选</asp:LinkButton>
        <asp:LinkButton ID="lbChancelAll" runat="server" onclick="lbChancelAll_Click"  ForeColor="Black"  Font-Size="12px">取消</asp:LinkButton>
        <br /><br />
        <asp:Button ID="btnDelete" runat="server" Text="删除" onclick="btnDelete_Click" />
            </ContentTemplate>
    </asp:UpdatePanel>
    </div>
    </form>
    </body>
</html>
