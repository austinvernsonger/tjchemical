<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TravelApplication.aspx.cs" Inherits="Teaching_BackEnd_TravelApplication" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<link href="../../CssClass/TeachingBackEnd.css" rel="stylesheet" type="text/css" />
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <p>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        出差申请表</p>
    <p>&nbsp;</p>
    <p>申请人姓名   
    <asp:Label ID="RequestPerson" runat="server"></asp:Label>
    </p>
<p>同行人姓名  <asp:TextBox ID="PersonTogether" runat="server" MaxLength="20"></asp:TextBox> </p>
<p>出差地点  <asp:TextBox ID="TravelPlace" runat="server" MaxLength="100" Width="277px"></asp:TextBox> </p>
<p>出差单位  <asp:TextBox ID="TravelCompany" runat="server" MaxLength="100" 
        Width="272px"></asp:TextBox> </p>
<p>预计出差开始日期<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <asp:Calendar ID="PreStartDate" runat="server" BackColor="White" 
            BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" 
            DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" 
            ForeColor="#003399" Height="200px" Width="220px">
            <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
            <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
            <WeekendDayStyle BackColor="#CCCCFF" />
            <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
            <OtherMonthDayStyle ForeColor="#999999" />
            <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
            <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
            <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" 
                Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
        </asp:Calendar>
    </ContentTemplate>
    </asp:UpdatePanel>
&nbsp;</p>
<p>预计出差结束日期  </p>
    <p>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <asp:Calendar ID="PreEndDate" runat="server" BackColor="White" 
                    BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" 
                    DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" 
                    ForeColor="#003399" Height="200px" Width="220px">
                    <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                    <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                    <WeekendDayStyle BackColor="#CCCCFF" />
                    <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                    <OtherMonthDayStyle ForeColor="#999999" />
                    <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                    <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
                    <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" 
                        Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
                </asp:Calendar>
            </ContentTemplate>
        </asp:UpdatePanel>
    </p>
<p>经费预算  <asp:TextBox ID="FundsBudget" runat="server"></asp:TextBox> 元</p>
<p>出差任务</p>
    <p>&nbsp;<asp:TextBox ID="TravelTask" runat="server" Height="228px" MaxLength="200" 
            TextMode="MultiLine" Width="644px"></asp:TextBox> </p>
<p>其它事项</p>
    <p>&nbsp;<asp:TextBox ID="Other" runat="server" Height="199px" MaxLength="200" 
            TextMode="MultiLine" Width="658px"></asp:TextBox> </p>
    <p>&nbsp;</p>
    <p>
        <asp:Button ID="bnSubmit" runat="server" onclick="bnSubmit_Click" Text="提交" 
            Width="70px" />
        <asp:Button ID="bnCancel" runat="server" onclick="bnCancel_Click" Text="返回" 
            Width="62px" />
    </p>
    </div>
    </form>
</body>
</html>
