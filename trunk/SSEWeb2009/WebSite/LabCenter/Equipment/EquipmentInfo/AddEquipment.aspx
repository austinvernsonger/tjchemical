<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddEquipment.aspx.cs" Inherits="LabCenter_Equipment_EquipmentInfo_AddEquipment" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
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
                <asp:TableCell ID="TableCell6" runat="server">设备编号：</asp:TableCell>
                <asp:TableCell ID="TableCell25" runat="server">
                    <asp:TextBox ID="devId" runat="server" Width="284px"></asp:TextBox>
                    </asp:TableCell>
            </asp:TableRow>
                  <asp:TableRow ID="TableRow16" runat="server">               
                <asp:TableCell ID="TableCell28" runat="server">                    
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="devId" ErrorMessage="设备编号不能为空"></asp:RequiredFieldValidator>
                    </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="TableRow1" runat="server">
                <asp:TableCell ID="TableCell1" runat="server">设备名称：</asp:TableCell>
                <asp:TableCell ID="TableCell1x" runat="server">
                    <asp:TextBox ID="devName" runat="server" Width="284px"></asp:TextBox>
                    </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="TableRow4" runat="server">
                <asp:TableCell ID="TableCell7" runat="server">型号：</asp:TableCell>
                <asp:TableCell ID="TableCell7x" runat="server">
                    <asp:TextBox ID="devModel" runat="server" Width="284px"></asp:TextBox>
                    </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="TableRow5" runat="server">
                <asp:TableCell ID="TableCell9" runat="server">规格：</asp:TableCell>
                <asp:TableCell ID="TableCell9x" runat="server">
                    <asp:TextBox ID="devFormat" runat="server" Width="284px"></asp:TextBox>
                    </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="TableRow6" runat="server">
            
                <asp:TableCell ID="TableCell11" runat="server">数量：</asp:TableCell>
                <asp:TableCell ID="TableCell11x" runat="server">
                    <asp:TextBox ID="devAccount" runat="server" OnKeyPress="if(((event.keyCode>=48)&&(event.keyCode <=57))) {event.returnValue=true;} else{event.returnValue=false;}" Width="284px"></asp:TextBox>
                    </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="TableRow7" runat="server">
                <asp:TableCell ID="TableCell13" runat="server">单价：</asp:TableCell>
                <asp:TableCell ID="TableCell14" runat="server">
                    <asp:TextBox ID="devPrice" runat="server" OnKeyPress="if(((event.keyCode>=48)&&(event.keyCode <=57))) {event.returnValue=true;} else{event.returnValue=false;}" Width="284px"></asp:TextBox>
                    </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="TableRow8" runat="server">
                <asp:TableCell ID="TableCell15" runat="server">购置日期：</asp:TableCell>
                <asp:TableCell ID="TableCell16" runat="server">
                       <asp:Calendar ID="Calendar2" runat="server" BackColor="White" BorderColor="Black" BorderStyle="Solid" CellSpacing="1" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="194px" NextPrevFormat="ShortMonth" Width="275px">
            <SelectedDayStyle BackColor="#333399" ForeColor="White" />
            <TodayDayStyle BackColor="#999999" ForeColor="White" />
            <OtherMonthDayStyle ForeColor="#999999" />
            <DayStyle BackColor="#CCCCCC" />
            <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="White" />
            <DayHeaderStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" Height="8pt" />
            <TitleStyle BackColor="#333399" BorderStyle="Solid" Font-Bold="True" Font-Size="12pt"
                ForeColor="White" Height="12pt" />
        </asp:Calendar>
                    </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="TableRow9" runat="server">
                <asp:TableCell ID="TableCell17" runat="server">厂家：</asp:TableCell>
                <asp:TableCell ID="TableCell18" runat="server">
                    <asp:TextBox ID="devFactory" runat="server" Width="284px"></asp:TextBox>
                    </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="TableRow10" runat="server">
                <asp:TableCell ID="TableCell19" runat="server">现状：</asp:TableCell>
                <asp:TableCell ID="TableCell20" runat="server">
                    <asp:TextBox ID="devStatus" runat="server" Width="284px"></asp:TextBox>
                    </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="TableRow14" runat="server">
                <asp:TableCell ID="TableCell2" runat="server">存放地点：</asp:TableCell>
                <asp:TableCell ID="TableCell8" runat="server">
                    <asp:TextBox ID="devLocation" runat="server" Width="284px"></asp:TextBox>
                    </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="TableRow15" runat="server">
                <asp:TableCell ID="TableCell10" runat="server">存放地点1：</asp:TableCell>
                <asp:TableCell ID="TableCell12" runat="server">
                    <asp:TextBox ID="TextBox4" runat="server" Width="284px"></asp:TextBox>
                    </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="TableRow11" runat="server">
                <asp:TableCell ID="TableCell21" runat="server">使用人：</asp:TableCell>
                <asp:TableCell ID="TableCell22" runat="server">
                    <asp:TextBox ID="devUser" runat="server" Width="284px"></asp:TextBox>
                    </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="TableRow12" runat="server">
                <asp:TableCell ID="TableCell23" runat="server">监管人：</asp:TableCell>
                <asp:TableCell ID="TableCell24" runat="server">
                    <asp:TextBox ID="devAdmin" runat="server" Width="284px"></asp:TextBox>
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
                <asp:Button ID="Submit" runat="server" OnClick="btnNewEquipment_Click" Text="提交" />
                
                <asp:Button ID="Cancel" runat="server" OnClick="btnNewEquipment_Click" Text="取消" />
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
