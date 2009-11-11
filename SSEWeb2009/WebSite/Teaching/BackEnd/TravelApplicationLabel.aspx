<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TravelApplicationLabel.aspx.cs" Inherits="Teaching_BackEnd_TravelApplicationLabel" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<link href="../../CssClass/TeachingBackEnd.css" rel="stylesheet" type="text/css" />
<head id="Head1" runat="server">
    <title></title>
</head>
<body>

    <form runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    <fieldset>
    <legend>出差申请表</legend>
    <dl>
    <dt><asp:Label ID="Label1" runat="server" Text="申请人姓名"></asp:Label></dt>
    <dd><asp:Label ID="RequestPerson" runat="server"></asp:Label></dd>
    
    <dt><asp:Label ID="Label2" runat="server" Text="同行人姓名"></asp:Label></dt>
    <dd><asp:Label ID="PersonTogether" runat="server"></asp:Label></dd>
    
    <dt><asp:Label ID="Label3" runat="server" Text="出差地点"></asp:Label></dt>
    <dd><asp:Label ID="TravelPlace" runat="server"></asp:Label></dd>
    
    <dt><asp:Label ID="Label4" runat="server" Text="出差单位"></asp:Label></dt>
    <dd><asp:Label ID="TravelCompany" runat="server"></asp:Label></dd>
    
    <dt><asp:Label ID="Label5" runat="server" Text="预计出差开始日期"></asp:Label></dt>
    <dd><<asp:Label ID="PreStartDate" runat="server"></asp:Label></dd>
    
    <dt><asp:Label ID="Label6" runat="server" Text="预计出差结束日期"></asp:Label></dt>
    <dd><asp:Label ID="PreEndDate" runat="server"></asp:Label></dd>
    
    <dt><asp:Label ID="Label7" runat="server" Text="经费预算"></asp:Label></dt>
    <dd><<asp:Label ID="FundsBudget" runat="server"></asp:Label>元</dd>
    </dl>
    <dl>
    
    <dt><asp:Label ID="Label8" runat="server" Text="出差任务"></asp:Label></dt>
    <dd><asp:TextBox ID="TravelTask" runat="server" Height="191px" MaxLength="200" 
            TextMode="MultiLine" Width="555px" ReadOnly="True"></asp:TextBox></dd>
    </dl>
    
    <dl>
    <dt><asp:Label ID="Label9" runat="server" Text="其它事项"></asp:Label></dt>
    <dd><asp:TextBox ID="Other" runat="server" Height="237px" MaxLength="200" 
            TextMode="MultiLine" Width="555px" ReadOnly="True"></asp:TextBox></dd>
       
    </dl>
    </fieldset>
    </form>
</body>
</html>
