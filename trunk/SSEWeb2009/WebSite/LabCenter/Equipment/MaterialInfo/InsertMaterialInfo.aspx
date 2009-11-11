<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InsertMaterialInfo.aspx.cs" Inherits="LabCenter_Equipment_MaterialInfo_InsertMaterialInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="添加新设备" runat="server" Text="" Visible="false" ForeColor="Red" Font-Bold="true"></asp:Label>
        <asp:Table ID="Table1" runat="server">
            <asp:TableRow ID="TableRow13" runat="server">
                <asp:TableCell ID="TableCell6" runat="server">耗材名称：</asp:TableCell>
                <asp:TableCell ID="TableCell25" runat="server">
                    <asp:TextBox ID="devName" runat="server" Width="284px"></asp:TextBox>
                    </asp:TableCell>
            </asp:TableRow>
                  <asp:TableRow ID="TableRow16" runat="server">               
                <asp:TableCell ID="TableCell28" runat="server">                    
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="devName" ErrorMessage="耗材信息不能为空"></asp:RequiredFieldValidator>
                    </asp:TableCell>
            </asp:TableRow>
   
          
            <asp:TableRow ID="TableRow6" runat="server">
            
                <asp:TableCell ID="TableCell11" runat="server">数量：</asp:TableCell>
                <asp:TableCell ID="TableCell11x" runat="server">
                    <asp:TextBox ID="devAccount" runat="server" OnKeyPress="if(((event.keyCode>=48)&&(event.keyCode <=57))) {event.returnValue=true;} else{event.returnValue=false;}" Width="284px"></asp:TextBox>
                    </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="TableRow7" runat="server">
                <asp:TableCell ID="TableCell13" runat="server">单位：</asp:TableCell>
                <asp:TableCell ID="TableCell14" runat="server">
                    <asp:TextBox ID="devUnit" runat="server" Width="284px"></asp:TextBox>
                    </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="TableRow8" runat="server">
                <asp:TableCell ID="TableCell15" runat="server">开放领用：</asp:TableCell>
                <asp:TableCell ID="TableCell16" runat="server">
                    <asp:CheckBox ID="CheckBox1" runat="server" />
                    </asp:TableCell>
            </asp:TableRow>
            
            <asp:TableRow ID="TableRow2" runat="server">
                <asp:TableCell ID="TableCell3" runat="server">备注：</asp:TableCell>
                <asp:TableCell ID="TableCell4" runat="server">
                    <asp:TextBox ID="devRemark" runat="server" TextMode="MultiLine" Height="97px" 
            Width="284px"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="TableRow3" runat="server">
   
   <asp:TableCell ID="TableCell5" runat="server">  </asp:TableCell>
                <asp:TableCell ID="TableCell27" runat="server">
                <asp:Button ID="Submit" runat="server" OnClick="btnNewMaterial_Click" Text="提交" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        &nbsp;<br />
        <br />
        &nbsp;
    </div>
    </form>
</body>
</html>
