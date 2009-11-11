<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ViewMMT.ascx.cs" Inherits="UserControl_ViewMMT" %>
<%@ Register src="TagListControl.ascx" tagname="taglist" tagprefix="ucl" %>
<%@ Register src="../Report/Control/Displayer.ascx" tagname="Displayer" tagprefix="uc1" %>

<div id="div_title" runat="server" align="center">
    <asp:Label ID="lb_title" runat="server" Text=""></asp:Label>
</div>

<div id="div_clickCount" runat="server" align="center" 
    style="font-family: Arial; font-size: 10px; color: #808080">
    [<asp:Label ID="lb_clickCount" runat="server" Text=""></asp:Label>]</div>

<div id="div_tag" runat="server" align="center"
    style="font-family: Arial, Helvetica, sans-serif; font-size: 11px; color: #666666; text-decoration: none" 
    visible="False">
    <asp:PlaceHolder ID="phd_tags" runat="server"></asp:PlaceHolder>
</div>

<div id="div_time" runat="server" visible="False">
    开始时间：<asp:Label ID="lb_startTime" runat="server" Text=""></asp:Label><br />
    结束时间：<asp:Label ID="lb_endTime" runat="server" Text=""></asp:Label>
</div>

<div id="div_location" runat="server" visible="False">
    活动地点：<asp:Label ID="lb_location" runat="server" Text=""></asp:Label>
</div>

<div id="div_content" runat="server" visible="False" style="font-size:14px; color:Black">
</div>

<div id="div_registration" runat="server" visible="False">
    <asp:PlaceHolder ID="phd_registration" runat="server"></asp:PlaceHolder>
</div>

<div id="div_attachment" runat="server" 
    style="text-decoration: none; font-size: 12px; color: #000000" 
    visible="False">
    <asp:Label ID="lb_tag" runat="server" Text="附件下载：<br />" Font-Bold="True" 
        Font-Size="14px"></asp:Label>
    <asp:PlaceHolder ID="phd_attachment" runat="server"></asp:PlaceHolder>
</div>

<asp:UpdatePanel ID="label_pnl" runat="server">
    <ContentTemplate>
        <uc1:Displayer ID="ReportDisplayer" runat="server" />
    </ContentTemplate>
</asp:UpdatePanel>

