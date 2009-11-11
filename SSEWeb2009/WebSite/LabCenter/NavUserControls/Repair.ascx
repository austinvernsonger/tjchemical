<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Repair.ascx.cs" Inherits="LabCenter_NavUserControls_Repair" %>
<div>
<h2>设备报修</h2>
<div id="nav">
  <ul>
    <li><asp:HyperLink ID="LabRepairComputer" runat="server" NavigateUrl="~/LabCenter/Repair/Order/Computer.aspx">机房电脑报修</asp:HyperLink></li>
	<li><asp:HyperLink ID="LabRepairOther" runat="server" NavigateUrl="~/LabCenter/Repair/Order/Other.aspx">其他设备报修</asp:HyperLink></li>
  </ul>
</div>
</div>