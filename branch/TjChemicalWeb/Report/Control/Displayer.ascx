<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Displayer.ascx.cs" Inherits="Report_Control_Displayer" %>
<asp:Panel ID="Panel_Holder" runat="server" Width="550px">
    <asp:PlaceHolder ID="PlaceHolder_Report" runat="server"></asp:PlaceHolder>
</asp:Panel>
<br />
<asp:Label ID="Hidden_DescriptorFilePAth" runat="server" Visible="False"></asp:Label>
<asp:Label ID="Hidden_ResultFilePath" runat="server" Visible="False"></asp:Label>
<asp:Label ID="Hidden_KeyValue" runat="server" Visible="False"></asp:Label>
<br />
<br />
<asp:Button ID="BN_Submit" runat="server" onclick="Button2_Click" Text="提交" />





<asp:Label ID="Label_Message" runat="server"></asp:Label>





<asp:Timer ID="Timer1" runat="server" Enabled="False" EnableViewState="False" 
    Interval="1">
</asp:Timer>






