<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Calendar.ascx.cs" Inherits="UserControl_Calendar" %>
<div style="width: 100%;">
    <div style="float: left;">
        <asp:DropDownList ID="ddl_year" runat="server" 
            ontextchanged="ddl_year_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>年
        <asp:DropDownList ID="ddl_month" runat="server"
            ontextchanged="ddl_month_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>月
    </div>
    <div style="float: left;">
    <asp:UpdatePanel ID="uppnl_cal" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:DropDownList ID="ddl_day" runat="server" ></asp:DropDownList>日
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="ddl_month" EventName="TextChanged" />
            <asp:AsyncPostBackTrigger ControlID="ddl_year" EventName="TextChanged" />
        </Triggers>
    </asp:UpdatePanel>
    </div>
    <div id="hour_div" runat="server" style="float: left;"><asp:DropDownList ID="ddl_hour" runat="server" ></asp:DropDownList>时</div>
</div>