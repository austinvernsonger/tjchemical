<%@ Page Language="C#" MasterPageFile="~/MasterPages/blank.master" AutoEventWireup="true" CodeFile="MgrNewsAuthority.aspx.cs" Inherits="SysMgr_MgrNewsAuthority" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="phctnt_head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="phctnt_body" Runat="Server">
<div style="font-size:12px; font-family:宋体; color:Black;">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        onselectedindexchanged="GridView1_SelectedIndexChanged" 
        onrowcommand="GridView1_RowCommand" onrowdeleting="GridView1_RowDeleting">
        <Columns>
            <asp:TemplateField HeaderText="新闻账号">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("id") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="姓名">
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("name") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="删除" runat="server" CommandArgument='<%# Eval("id") %>'
                        CommandName="delete" onclick="删除_Click" oncommand="删除_Command">删除</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</div>
</asp:Content>
