<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/LabCenter/MasterPages/HomeMaster.master"  CodeFile="DeviceApplyTable.aspx.cs" Inherits="LabCenter_Equipment_DeviceApply_DeviceApplyTable" %>


<%@ Register src="../../NavUserControls/Equipment.ascx" tagname="Equipment" tagprefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script type="text/javascript">
    function HideSuccess(){
    document.getElementById("Information").style.display="none";
    }
    </script>    
        <uc1:Equipment ID="Equipment1" runat="server" />
  <div id="InnerContainer">
  <h3>设备借用申请表</h3>
        <asp:Table ID="Table1" runat="server">
            <asp:TableRow ID="TableRow1" runat="server">
                <asp:TableCell ID="TableCell1" runat="server">设备名称：</asp:TableCell>
                <asp:TableCell ID="TableCell2" runat="server">
                       <asp:DropDownList ID="DeviceDrop" runat="server" Width="150px" BackColor="#EBFAF9" onfocus="HideSuccess()">
                    </asp:DropDownList >
                    </asp:TableCell>
            </asp:TableRow>
            

            <asp:TableRow ID="TableRow2" runat="server">
                <asp:TableCell ID="TableCell3" runat="server">备注：</asp:TableCell>
                <asp:TableCell ID="TableCell4" runat="server">
                    <asp:TextBox ID="tbDescription" runat="server" TextMode="MultiLine" Height="97px" 
            Width="284px" onfocus="HideSuccess()"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="TableRow3" runat="server">
   
            <asp:TableCell ID="TableCell5" runat="server">  </asp:TableCell>
                <asp:TableCell ID="TableCell27" runat="server">
               </asp:TableCell>
                    
            </asp:TableRow>
            <asp:TableRow ID="TableRow4" runat="server">
            <asp:TableCell ID="TableCell28" runat="server">
            <asp:Button runat="server" Text="提交" OnClick="btnDeviceApply_Click" />
            </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    <br />
    <asp:Label ID="Information" runat="server" Text="Label"></asp:Label>
    <br />
        <asp:Button ID="Button1" runat="server" Text="查看借用记录" onclick="Button1_Click" />
  </div> 
</asp:Content>    