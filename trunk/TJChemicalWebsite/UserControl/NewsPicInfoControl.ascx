<%@ Control Language="C#" AutoEventWireup="true" CodeFile="NewsPicInfoControl.ascx.cs" Inherits="UserControl_NewsPicInfoControl" %>
<asp:Label ID="lbTitle" runat="server" Text="新闻描述:" Font-Size="X-Small" 
    ForeColor="#333333"></asp:Label>
<asp:TextBox ID="tbTitle" runat="server" BorderColor="Gray" BorderStyle="Solid" 
    BorderWidth="1px"></asp:TextBox>
<asp:Label ID="lbNewsID" runat="server" Text="新闻ID:" Font-Size="X-Small" 
    ForeColor="#333333"></asp:Label>
<asp:TextBox ID="tbNewsID" runat="server" BorderColor="Gray" 
    BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
<br />
<asp:Label ID="lbPic" runat="server" Text="图片:" Font-Size="X-Small" 
    ForeColor="#333333"></asp:Label> <br />
<asp:Image ID="img" runat="server" BorderColor="#999999" BorderWidth="1px" 
    ImageAlign="Middle" ImageUrl="~/Resources/Images/default.png" />