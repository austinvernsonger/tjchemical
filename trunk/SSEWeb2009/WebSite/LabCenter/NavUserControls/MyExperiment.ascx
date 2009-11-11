<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MyExperiment.ascx.cs" Inherits="LabCenter_Reservation_UserControl_MyExperiment" %>
<div>
<h2>我的实验</h2>
<div id="nav">
  <ul>
    <li><asp:HyperLink ID="LabResv" runat="server" NavigateUrl="~/LabCenter/Reservation/LabReservation.aspx" >实验预约</asp:HyperLink></li>
	<li><asp:HyperLink ID="LabResvLog" runat="server" NavigateUrl="~/LabCenter/Reservation/ReservationLogin_pre.aspx" >实验登记</asp:HyperLink></li>
    <li><asp:HyperLink ID="LabResvView" runat="server" NavigateUrl="~/LabCenter/Reservation/ViewReservation.aspx" >查看/取消预约</asp:HyperLink></li>
	<li><asp:HyperLink ID="LavReport" runat="server" NavigateUrl="~/LabCenter/Reservation/CheckReport.aspx" >实验报告</asp:HyperLink></li>
  </ul>
</div>
</div>