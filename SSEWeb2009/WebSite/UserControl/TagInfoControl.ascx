<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TagInfoControl.ascx.cs" Inherits="UserControl_TagInfoControl" %>
<div style="padding: 3px; border: 1px solid #C1C1C1; width: 357px; margin-top: 4px; margin-right: 4px; margin-bottom: 4px;">
<asp:CheckBox ID="cbCheckItem" runat="server" BorderColor="#666666" 
    AutoPostBack="True" />
&nbsp;<asp:Label ID="lbTagNum" runat="server" Text="优先级："></asp:Label>
<asp:TextBox ID="tbTagNum" runat="server" Width="33px" BorderColor="#999999" 
    BorderStyle="Solid" BorderWidth="1px" Font-Names="Tahoma" Font-Size="Small" 
        MaxLength="3"></asp:TextBox>&nbsp;
<asp:Label ID="lbTagName" runat="server" Text="标签名称："></asp:Label>
<asp:TextBox ID="tbTagName" runat="server" BorderColor="#999999" 
    BorderStyle="Solid" BorderWidth="1px" Font-Names="Tahoma" Font-Size="Small" 
        MaxLength="15"></asp:TextBox>
</div>