<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Account.aspx.cs" Inherits="Education_AccountManage_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <style type="text/css">
        .style1
        {
            width: 155px;
        }
        .style2
        {
            width: 201px;
        }
        .style3
        {
            width: 155px;
            height: 27px;
        }
        .style4
        {
            width: 201px;
            height: 27px;
        }
        .style5
        {}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height: 546px">
    
        <br />
        <asp:DetailsView ID="DetailsViewInfo" runat="server" HeaderText="学生基本信息" 
            Height="50px" onpageindexchanging="DetailsView1_PageIndexChanging" 
            Width="723px">
            <Fields>
                <asp:BoundField HeaderText="学号" />
                <asp:CheckBoxField HeaderText="是否登录" />
            </Fields>
        </asp:DetailsView>
        <br />
        <table style="width: 100%;">
        </table>
&nbsp;
    
    </div>
    </form>
</body>
</html>
