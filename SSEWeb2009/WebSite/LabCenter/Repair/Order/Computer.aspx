<%@ Page Language="C#" MasterPageFile="~/LabCenter/MasterPages/HomeMaster.master" AutoEventWireup="true" CodeFile="Computer.aspx.cs" Inherits="LabCenter_Repair_Order_Computer" %>

<%@ Register src="../../NavUserControls/Repair.ascx" tagname="Repair" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:Repair ID="Repair1" runat="server" />
    <div id="InnerContainer">
    <h3>机房电脑报修</h3>     
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Table ID="Table1" runat="server">
                    <asp:TableRow runat="server">
                        <asp:TableCell runat="server">机位编号：</asp:TableCell>
                        <asp:TableCell runat="server" Font-Bold="False">
                <asp:DropDownList ID="ddlCpNum_Room" AutoPostBack="true" Width="53px" 
                runat="server" OnSelectedIndexChanged="ddlCpNum_Room_OnSelectedIndexChanged" >
                </asp:DropDownList>室 
                <asp:DropDownList ID="ddlCpNum_Num" Width="53px" runat="server">
                </asp:DropDownList>号
            
</asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow VerticalAlign="Top" runat="server">
                        <asp:TableCell runat="server">情况描述：</asp:TableCell>
                        <asp:TableCell runat="server">
                <asp:CheckBoxList ID="cblDescriptions"  runat="server" 
                RepeatDirection="Vertical" Font-Overline="False" RepeatLayout="Table">
                </asp:CheckBoxList>                

<asp:TextBox ID="tbDescription" runat="server" TextMode="MultiLine" Height="120px" 
                Width="400px"></asp:TextBox>
            

</asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow ID="TableRow2" runat="server">
                        <asp:TableCell ID="TableCell2" runat="server"></asp:TableCell>
                        <asp:TableCell ID="TableCell1" runat="server"><asp:Label 
                ID="lblRetmsg" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
</asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow ID="TableRow1" runat="server">
                        <asp:TableCell runat="server"></asp:TableCell>
                        <asp:TableCell runat="server"><asp:Button 
                ID="btnNewCpOrder" OnClick="btnNewCpOrder_Click" runat="server" Text="提交"  />
</asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
