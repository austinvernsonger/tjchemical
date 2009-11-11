<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TimeTableDisplay.ascx.cs" Inherits="LabCenter_Reservation_UserControl_TimeTableDisplay" %>
<%@ Register Assembly="System.Web.Extensions" Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Src="TimeSpanEdit.ascx" TagName="TimeSpanEdit" TagPrefix="uc1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<link rel="stylesheet" type="text/css" href="TabContainer.css" />
<div style="width: 100%;">
    <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" CssClass="ajax__tab_xp-theme" ActiveTabIndex="0">
        <ajaxToolkit:TabPanel ID="TabPanel1" runat="server" HeaderText="星期一" Width="10%">
            <ContentTemplate>
                <span><asp:Button ID="MonAdd" runat="server" Text="+" OnClick="MonAdd_Click" Enabled="<%# EditOff %>" />
                    <asp:Button ID="MonDel" runat="server" Text="-" OnClick="MonDel_Click" />
                </span>
                <asp:UpdatePanel ID="MonPanel" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:PlaceHolder ID="MonPlace" runat="server" />
                        
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="MonAdd" />
                        <asp:AsyncPostBackTrigger ControlID="MonDel" />
                    </Triggers>
                </asp:UpdatePanel>
            </ContentTemplate>
        </ajaxToolkit:TabPanel>
        <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="星期二" Width="10%">
            <ContentTemplate>
                <span><asp:Button ID="TueAdd" runat="server" Text="+" OnClick="TueAdd_Click" />
                    <asp:Button ID="TueDel" runat="server" Text="-" OnClick="TueDel_Click" />
                </span>
                <asp:UpdatePanel ID="TuePanel" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:PlaceHolder ID="TuePlace" runat="server" />
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="TueAdd" />
                        <asp:AsyncPostBackTrigger ControlID="TueDel" />
                    </Triggers>
                </asp:UpdatePanel>
            </ContentTemplate>
        </ajaxToolkit:TabPanel>
        <ajaxToolkit:TabPanel ID="TabPanel3" runat="server" HeaderText="星期三" Width="10%">
            <ContentTemplate>
                <span><asp:Button ID="WedAdd" runat="server" Text="+" OnClick="WedAdd_Click" />
                    <asp:Button ID="WedDel" runat="server" Text="-" OnClick="WedDel_Click" />
                </span>
                <asp:UpdatePanel ID="WedPanel" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:PlaceHolder ID="WedPlace" runat="server" />
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="WedAdd" />
                        <asp:AsyncPostBackTrigger ControlID="WedDel" />
                    </Triggers>
                </asp:UpdatePanel>
            </ContentTemplate>
        </ajaxToolkit:TabPanel>
        <ajaxToolkit:TabPanel ID="TabPanel4" runat="server" HeaderText="星期四" Width="10%">
            <ContentTemplate>
                <span><asp:Button ID="ThuAdd" runat="server" Text="+" OnClick="ThuAdd_Click" />
                    <asp:Button ID="ThuDel" runat="server" Text="-" OnClick="ThuDel_Click" />
                </span>
                <asp:UpdatePanel ID="ThuPanel" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:PlaceHolder ID="ThuPlace" runat="server" />
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ThuAdd" />
                        <asp:AsyncPostBackTrigger ControlID="ThuDel" />
                    </Triggers>
                </asp:UpdatePanel>
            </ContentTemplate>
        </ajaxToolkit:TabPanel>
        <ajaxToolkit:TabPanel ID="TabPanel5" runat="server" HeaderText="星期五" Width="10%">
            <ContentTemplate>
                <span><asp:Button ID="FriAdd" runat="server" Text="+" OnClick="FriAdd_Click" />
                    <asp:Button ID="FriDel" runat="server" Text="-" OnClick="FriDel_Click" />
                </span>
                <asp:UpdatePanel ID="FriPanel" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:PlaceHolder ID="FriPlace" runat="server" />
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="FriAdd" />
                        <asp:AsyncPostBackTrigger ControlID="FriDel" />
                    </Triggers>
                </asp:UpdatePanel>
            </ContentTemplate>
        </ajaxToolkit:TabPanel>
        <ajaxToolkit:TabPanel ID="TabPanel6" runat="server" HeaderText="星期六" Width="10%">
            <ContentTemplate>
                <span><asp:Button ID="SatAdd" runat="server" Text="+" OnClick="SatAdd_Click" />
                    <asp:Button ID="SatDel" runat="server" Text="-" OnClick="SatDel_Click" />
                </span>
                <asp:UpdatePanel ID="SatPanel" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:PlaceHolder ID="SatPlace" runat="server" />
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="SatAdd" />
                        <asp:AsyncPostBackTrigger ControlID="SatDel" />
                    </Triggers>
                </asp:UpdatePanel>
            </ContentTemplate>
        </ajaxToolkit:TabPanel>
    </ajaxToolkit:TabContainer>
    
   <asp:Timer ID="Timer_Refresh" runat="server" Enabled="False" 
                            EnableViewState="False" Interval="1">
                        </asp:Timer>
</div>