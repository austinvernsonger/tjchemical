<%@ Page Language="C#" MasterPageFile="~/LabCenter/MasterPages/HomeMaster.master" AutoEventWireup="true" CodeFile="Other.aspx.cs" Inherits="LabCenter_Repair_Order_Other" %>

<%@ Register src="../../NavUserControls/Repair.ascx" tagname="Repair" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<uc1:Repair ID="Repair2" runat="server" />
<div id="InnerContainer">
      <h3>其他设备报修</h3>      
        <asp:Table ID="Table1" runat="server" >
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">设备名称：</asp:TableCell>
                <asp:TableCell runat="server">
                    <asp:TextBox ID="tbDevName" runat="server" Width="100px"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="TableRow1" runat="server">
                <asp:TableCell runat="server">位置：</asp:TableCell>
                <asp:TableCell runat="server">
                    <asp:TextBox ID="tbLocation" runat="server" Width="100px"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="TableRow2" runat="server">
                <asp:TableCell runat="server">情况描述：</asp:TableCell>
                <asp:TableCell runat="server">
                    <asp:TextBox ID="tbDiscription" runat="server" TextMode="MultiLine" Height="120px" 
            Width="350px"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="TableRow4" runat="server">
                <asp:TableCell ID="TableCell2" runat="server"></asp:TableCell>
                <asp:TableCell ID="TableCell1" runat="server">
                    <asp:Label ID="lblRetmsg" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="TableRow3" runat="server">
                <asp:TableCell runat="server"></asp:TableCell>
                <asp:TableCell runat="server">
                    <asp:Button ID="btnNewOtherOrder" OnClick="btnNewOtherOrder_Click" runat="server" Text="提交" /></asp:TableCell>
            </asp:TableRow>
        </asp:Table>    
</div>
</asp:Content>
