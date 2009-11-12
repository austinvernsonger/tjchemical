﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Computer.aspx.cs" Inherits="RepairManagement_Record_ComputerRepair" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    
        <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </cc1:ToolkitScriptManager>
        <cc1:CalendarExtender ID="cld1" runat="server" TargetControlID="tbBeginTime" Format="yyyy-MM-dd">
        </cc1:CalendarExtender>
        <cc1:CalendarExtender ID="cld2" runat="server" TargetControlID="tbEndTime" Format="yyyy-MM-dd">
        </cc1:CalendarExtender>
        <asp:Table ID="Table1" runat="server" >
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">开始时间</asp:TableCell>
                <asp:TableCell runat="server">
                    <asp:TextBox ID="tbBeginTime" runat="server" BackColor="#EBFAF9"></asp:TextBox></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">结束时间</asp:TableCell>
                <asp:TableCell runat="server">
                    <asp:TextBox ID="tbEndTime" runat="server" BackColor="#EBFAF9"></asp:TextBox></asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <br />
        <asp:Button ID="btnQuery" runat="server" Text="查询" OnClick="btnQuery_Click" Width="67px" />
        
        <asp:GridView ID="GVCpRecords" runat="server" AllowPaging="True" PageSize="10" 
            DataSourceID="obj_date" OnRowDataBound="GVCpRecords_RowDataBound" 
            BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" 
            CellPadding="4" AllowSorting="true" Width="100%">
            <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
            <RowStyle BackColor="White" ForeColor="#003399" />
            <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
            <EmptyDataTemplate>
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="宋体" ForeColor="Red"
                    Text="没有数据"></asp:Label>
            </EmptyDataTemplate>
            <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
            <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
        </asp:GridView>
        
        <asp:ObjectDataSource ID="obj_date" runat="server" SelectMethod="GetRecords" 
            TypeName="LabCenter.Repair.ComputerManager">
            <SelectParameters>
                <asp:ControlParameter ControlID="tbBeginTime" Name="begintime"
                    PropertyName="text" Type="DateTime" />
                <asp:ControlParameter ControlID="tbEndTime" Name="endtime"
                    PropertyName="text" Type="DateTime" />
            </SelectParameters>
        </asp:ObjectDataSource>
        
    </form>
</body>
</html>