<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LectureApplicationLabel.aspx.cs" Inherits="Teaching_BackEnd_LectureApplicationLabel" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<link href="../../CssClass/TeachingBackEnd.css" rel="stylesheet" type="text/css" />
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        .form1
        {
            width: 350px;
            height: 288px;
        }
    </style>
</head>
<body>
    <form id="Form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
      <fieldset>
      <legend>讲座申请表</legend>
      <dl>
      <dt><asp:Label ID="Label2" runat="server" Text="讲座主题" CssClass="label1"></asp:Label></dt>
      <dd><asp:Label ID="Subject" runat="server" CssClass="label1"></asp:Label></dd>              
      <dt><asp:Label ID="Label3" runat="server" Text="主讲人姓名：" CssClass="label1"></asp:Label></dt>
      <dd><asp:Label ID="Name" runat="server" CssClass="label1"></asp:Label></dd>
      <dt><asp:Label ID="Label4" runat="server" Text="意向讲座时间：" CssClass="label1"></asp:Label></dt> 
      <dd><asp:Label ID="RequestTime" runat="server" CssClass="label1"></asp:Label></dd>        
      </dl>        
      <dl>
      <dt><asp:Label ID="Label5" runat="server" Text="讲座内容介绍及要求：" CssClass="label1"></asp:Label></dt>
      <dd><asp:TextBox ID="Content" runat="server" Height="303px" Width="555px" 
            TextMode="MultiLine" MaxLength="500"></asp:TextBox></dd>  
      </dl>
      <dl>
      <dt><asp:Label ID="Label6" runat="server" Text="讲座具体安排(讲座负责人填写)：" CssClass="label1"></asp:Label></dt>
      <dd><asp:TextBox ID="DetailPlan" runat="server" Height="291px" Width="555px" 
            TextMode="MultiLine"></asp:TextBox></dd>  
       </dl> 
       </fieldset>
       </form>
</body>
</html>