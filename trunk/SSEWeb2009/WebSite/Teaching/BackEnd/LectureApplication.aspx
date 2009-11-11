<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LectureApplication.aspx.cs" Inherits="Teaching_BackEnd_LectureApplication" %>

<%@ Register src="../../UserControl/Calendar.ascx" tagname="Calendar" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<link href="../../CssClass/TeachingBackEnd.css" rel="stylesheet" type="text/css" />
<head runat="server">
    <title></title>
</head>
<body>
<form runat=server>
           <asp:ScriptManager ID="ScriptManager1" runat="server">
           </asp:ScriptManager>
    <fieldset>
    <legend>同济大学软件学院论坛讲座申请表</legend>
    <dl>
    <dt><asp:Label ID="Label3" runat="server" Text="讲座主题" CssClass="label1"></asp:Label></dt>
    <dd><asp:TextBox ID="Subject" runat="server" Width="307px" CssClass="textbox"></asp:TextBox></dd>
     <dt><asp:Label ID="Label1" runat="server" Text="主讲人姓名：" CssClass="label1"></asp:Label></dt>
      <dd><asp:Label ID="Name" runat="server" CssClass="label"></asp:Label></dd>
     <dt><asp:Label ID="Label4" runat="server" Text="意向讲座时间：" CssClass="label1"></asp:Label></dt>
     <dd><asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <asp:Calendar ID="RequestTime" runat="server" BackColor="White" 
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
        </asp:UpdatePanel></dd>
    </dl>
    <dl>
    <dt><asp:Label ID="Label5" runat="server" Text="讲座内容介绍及要求：" CssClass="label1"></asp:Label></dt>
    <dd><asp:TextBox ID="Content" runat="server" Height="263px" Width="555px" TextMode="MultiLine" MaxLength="500"></asp:TextBox></dd>    
    </dl>
    <dl>
    <dt><asp:Label ID="Label6" runat="server" Text=" 讲座具体安排(讲座负责人填写)：" CssClass="label1" ></asp:Label></dt>     
    <dd><asp:TextBox ID="DetailPlan" runat="server" Height="284px" Width="555px" 
            TextMode="MultiLine"></asp:TextBox></dd>
    </dl>
   </fieldset>
       <asp:Button ID="Submit" runat="server" onclick="Submit_Click" Text="提交" />
    <asp:Button ID="Cancel" runat="server" Text="返回" 
        PostBackUrl="~/Teaching/BackEnd/LectureApplicationList.aspx" 
        onclick="Cancel_Click" />
 
    </form>
</body>
</html>
