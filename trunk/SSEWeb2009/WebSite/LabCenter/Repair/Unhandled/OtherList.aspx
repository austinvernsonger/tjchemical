﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OtherList.aspx.cs" Inherits="RepairManagement_Unhandled_OtherOrderList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    
        <asp:Label ID="lblMsg" runat="server" Text="" ForeColor="Red"></asp:Label><br/>
        
        <asp:GridView ID="GVUnhandledOt" runat="server" 
            OnRowCommand="GVUnhandledOt_RowCommand" CellPadding="4" ForeColor="#333333" 
            GridLines="None" Width="500px" onrowdatabound="GVUnhandledOt_RowDataBound">
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#EFF3FB" />
            <Columns>
                <asp:TemplateField HeaderText="" ShowHeader="true">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Details"
                            Text="详细" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <EmptyDataTemplate>
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="12px" 
                    ForeColor="Red" Text="没有记录">
                </asp:Label>
            </EmptyDataTemplate>
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>

     </form>
</body>
</html>