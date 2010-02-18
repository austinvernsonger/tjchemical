<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SclPicInfoControl.ascx.cs" Inherits="UserControl_SclPicInfoControl" %>

<div id = "mainDiv" runat="server" style="margin: 5px; padding: 4px; border: 1px solid #C0C0C0; width: 148px; float: left; "> 
    <asp:LinkButton ID="lbOK" runat="server" onclick="lbOK_Click" Font-Size="Small" 
        ForeColor="#333333">获取图片</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:ImageButton ID="ibRemove" runat="server" 
        ImageUrl="~/Resources/Images/close.png" onclick="ibRemove_Click" 
        AlternateText="X" ToolTip="删除此图片" />
        
    <hr size="0" noshade="noshade" color="#C0C0C0" style="width: 100%;">
   
    <asp:Image ID="imgPrew" runat="server" />
   
    <div id="divFullView" runat="server" style="margin-top: 2px; width: 60px;"></div>
    <asp:Label ID="lbLink" runat="server" Text="Label" Font-Size="Small" 
        ForeColor="Red" Visible="False"></asp:Label>
        <asp:Label ID="lbHiddenInfo1" runat="server" Text="+" Visible="False"></asp:Label>
</div>
