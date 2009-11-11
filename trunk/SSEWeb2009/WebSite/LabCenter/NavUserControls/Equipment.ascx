<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Equipment.ascx.cs" Inherits="LabCenter_NavUserControls_Equipment" %>
<div>
<h2>设备管理</h2>
<div id="nav">
  <ul>
    <li><asp:HyperLink ID="LabDevice" runat="server" NavigateUrl="~/LabCenter/Equipment/DeviceApply/DeviceApplyTable.aspx">设备借用</asp:HyperLink></li>
	<li><asp:HyperLink ID="LabMaterial" runat="server" NavigateUrl="~/LabCenter/Equipment/MaterialApply/MaterialApply.aspx">耗材领用</asp:HyperLink></li>
  </ul>
</div>
</div>