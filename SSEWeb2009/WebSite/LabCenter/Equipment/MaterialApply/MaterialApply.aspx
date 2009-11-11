<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/LabCenter/MasterPages/HomeMaster.master" CodeFile="MaterialApply.aspx.cs" Inherits="LabCenter_Equipment_MaterialApply_MaterialApply" %>

<%@ Register src="../../NavUserControls/Equipment.ascx" tagname="Equipment" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<uc1:Equipment ID="Equipment1" runat="server" />
<div id="InnerContainer">
  
        <h3>
            耗材领用申请表</h3>
        <asp:Table ID="Table1" runat="server">
            <asp:TableRow ID="TableRow1" runat="server">
                <asp:TableCell ID="TableCell1" runat="server">选择耗材：</asp:TableCell>
                <asp:TableCell ID="TableCell2" runat="server">
                    <asp:DropDownList ID="MaterialDrop" runat="server" Width="150px">
                    </asp:DropDownList >
                    </asp:TableCell>
            </asp:TableRow>           

            <asp:TableRow ID="TableRow2" runat="server">
                <asp:TableCell ID="TableCell3" runat="server">数量：</asp:TableCell>
                <asp:TableCell ID="TableCell4" runat="server">
                    <asp:TextBox ID="tbCount" runat="server" OnKeyPress="if(((event.keyCode>=48)&&(event.keyCode <=57))) {event.returnValue=true;} else{event.returnValue=false;}" Width="50px"></asp:TextBox>
                     <asp:RangeValidator ID="RangeValidator1" ControlToValidate="tbCount" Type="integer" 
                  MinimumValue="0"
                  MaximumValue="100" 
                  runat="server" ErrorMessage=" 请填写正确的数值"></asp:RangeValidator>
                   
                </asp:TableCell>
            
                 
            
            </asp:TableRow>
                        <asp:TableRow ID="TableRow5" runat="server">
                <asp:TableCell ID="TableCell6" runat="server">备注：</asp:TableCell>
                <asp:TableCell ID="TableCell7" runat="server">
                    <asp:TextBox ID="devRemark" runat="server" TextMode="MultiLine" MaxLength="10" Height="97px"
            Width="284px"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1"  ControlToValidate="devRemark" ValidationExpression="([\u4e00-\u9fa5]|[^\u4e00-\u9fa5]){0,500}" runat="server" ErrorMessage="请勿输入超过500个字！"></asp:RegularExpressionValidator>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="TableRow3" runat="server">
   
   <asp:TableCell ID="TableCell5" runat="server">  </asp:TableCell>
                <asp:TableCell ID="TableCell27" runat="server">
               </asp:TableCell>                    
            </asp:TableRow>
            <asp:TableRow ID="TableRow4" runat="server">
            <asp:TableCell ID="TableCell28" runat="server">
            <asp:Button ID="Submit" runat="server" Text="提交" OnClick="btnSubmit_Click"  />
            </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    <br />
     <asp:Label ID="Information" runat="server" Text="Label" Visible="False"></asp:Label>
    <br />
     <asp:Button ID="RecordBtn" runat="server" Text="查看领用记录" OnClick="RecordBtn_Click" />
</div>

</asp:Content>
