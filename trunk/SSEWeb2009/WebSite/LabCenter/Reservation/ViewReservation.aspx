<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/LabCenter/MasterPages/HomeMaster.master" CodeFile="ViewReservation.aspx.cs" Inherits="实验预约_ViewOrder" %>

<%@ Register src="../NavUserControls/MyExperiment.ascx" tagname="MyExperiment" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<uc1:MyExperiment ID="MyExperiment1" runat="server" />
    <div id="InnerContainer">
    <h3>查看/取消预约</h3>
    <asp:Label ID="Label1" runat="server">当前预约信息：</asp:Label>        
        <asp:GridView
            id = "ReservationList"
             DataKeyNames="DateIndex"
            AutoGenerateColumns="False"
             AutoGenerateSelectButton="True"
             SelectedRowStyle-BackColor="yellow"
            runat = "server" CellPadding="4" ForeColor="#333333" GridLines="None">
            <RowStyle BackColor="#EFF3FB" />
            <Columns>
            <asp:BoundField DataField="Labname" HeaderText="实验名称" 
                    ItemStyle-HorizontalAlign="Center">
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
            <asp:BoundField DataField="Timespan" HeaderText="已预约的时间段" />
            </Columns>
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <EmptyDataTemplate>
            <p>当前没有预约实验.</p>
            </EmptyDataTemplate>

<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <AlternatingRowStyle BackColor="White" />
            </asp:GridView>
        <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/LabCenter/Reservation/LabReservation.aspx">转到预约页面</asp:LinkButton>
        <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click" Enabled="false">解除此预约</asp:LinkButton>
        <asp:Label ID="Label3" runat="server"></asp:Label>        
        </div>
</asp:Content>
