<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LinkInfoControl.ascx.cs" Inherits="UserControl_LinkInfoControl" %>


<asp:Label ID="LabelName" runat="server" Text="链接名称:"></asp:Label>
<asp:TextBox ID="tbLnkName" runat="server" BorderColor="#999999" 
    BorderStyle="Solid" BorderWidth="1px" Font-Names="Tahoma" 
    Font-Size="Small"></asp:TextBox>&nbsp;
<asp:Label ID="LabelAddr" runat="server" Text="链接地址:"></asp:Label>
<asp:TextBox ID="tbLnkAddr" runat="server" BorderColor="#999999" 
    BorderStyle="Solid" BorderWidth="1px" Font-Names="Tahoma" Width="176px" 
    Font-Size="Small"></asp:TextBox>
    <asp:Label ID="lbNotify" runat="server" Text="输入不能为空" ForeColor="Red" 
    Visible="False"></asp:Label>
    <br/><br />
