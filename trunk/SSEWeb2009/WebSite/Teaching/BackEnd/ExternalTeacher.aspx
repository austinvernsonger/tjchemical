<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ExternalTeacher.aspx.cs" Inherits="Teaching_BackEnd_ExternalTeacher" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<link href="../../CssClass/TeachingBackEnd.css" rel="stylesheet" type="text/css" />
<head runat="server">
    <title></title>
    <style type="text/css">
        .left3
        {
            height: 348px;
            width: 531px;
        }
    </style>
</head>
<body>
               <asp:ScriptManager ID="ScriptManager1" runat="server">
               </asp:ScriptManager>
        <form>
         <fieldset>
        <legend>【基本信息】</legend>
        <dl>
        <dt>      <asp:Label ID="Label1" runat="server" Text="姓名"></asp:Label></dt>  

        <dd>    <asp:TextBox ID="Name" runat="server" CssClass="textbox"></asp:TextBox></dd>
        
        <dt><asp:Label ID="Label2" runat="server" Text="性别" CssClass="label"></asp:Label></dt>
        <dd><asp:TextBox ID="Gender" runat="server" CssClass="textbox"></asp:TextBox></dd>     
        <dt><asp:Label ID="Label3" runat="server" Text="出生年月" CssClass="label"></asp:Label></dt> 
        <dd>
                                      <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                   <ContentTemplate>
                       <asp:Calendar ID="Birthday" runat="server" BackColor="White" 
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
        <dt><asp:Label ID="Label4" runat="server" Text="职称" CssClass="label"></asp:Label></dt>
        <dd><asp:TextBox ID="TitleName" runat="server" CssClass="textbox"></asp:TextBox></dd>
        <dt><asp:Label ID="Label5" runat="server" Text="职务" CssClass="label"></asp:Label></dt>
        <dd><asp:TextBox ID="Post" runat="server" CssClass="textbox"></asp:TextBox></dd>
        <dt><asp:Label ID="Label6" runat="server" Text="工作单位" CssClass="label"></asp:Label></dt>
        <dd><asp:TextBox ID="WorkPlace" runat="server" CssClass="textbox"></asp:TextBox></dd>
        <dt><asp:Label ID="Label7" runat="server" Text="硕/博导" CssClass="label"></asp:Label></dt>
        <dd>
               <asp:DropDownList ID="TutorType" runat="server" CssClass="textbox" Width="104px">
                   <asp:ListItem>博导</asp:ListItem>
                   <asp:ListItem>工程硕士导师</asp:ListItem>
                   <asp:ListItem>工学硕士导师</asp:ListItem>
               </asp:DropDownList></dd>
        <dt><asp:Label ID="Label8" runat="server" Text="评上硕/博导的时间" CssClass="label"></asp:Label></dt>
        <dd><asp:TextBox ID="TutorTime" runat="server" CssClass="textbox"></asp:TextBox></dd>
        <dt><asp:Label ID="Label9" runat="server" Text="最后学历" CssClass="label"></asp:Label></dt>
        <dd><asp:TextBox ID="LastDegree" runat="server" CssClass="textbox"></asp:TextBox></dd>
        <dt><asp:Label ID="Label10" runat="server" Text="最后学历毕业院校" CssClass="label"></asp:Label></dt>
        <dd><asp:TextBox ID="LastCollege" runat="server" CssClass="textbox"></asp:TextBox></dd>

        <dt><asp:Label ID="Label11" runat="server" Text="研究方向" CssClass="label"></asp:Label></dt>
        <dd><asp:TextBox ID="ResearchAspect" runat="server" CssClass="textbox"></asp:TextBox></dd>
        <dt><asp:Label ID="Label12" runat="server" Text="地址" CssClass="label"></asp:Label></dt>
        <dd><asp:TextBox ID="Address" runat="server" CssClass="textbox"></asp:TextBox></dd>
        <dt><asp:Label ID="Label13" runat="server" Text="电话" CssClass="label"></asp:Label></dt>
        <dd><asp:TextBox ID="Telephone" runat="server" CssClass="textbox"></asp:TextBox></dd>
        <dt><asp:Label ID="Label14" runat="server" Text="传真" CssClass="label"></asp:Label></dt>
        <dd><asp:TextBox ID="Fax" runat="server" CssClass="textbox"></asp:TextBox></dd>
        <dt><asp:Label ID="Label15" runat="server" Text="邮件" CssClass="label"></asp:Label></dt>
        <dd><asp:TextBox ID="Email" runat="server" CssClass="textbox"></asp:TextBox></dd>  
        </dl>
        </fieldset>
         <fieldset>
        <legend>【科研信息】</legend>
        <dl>
        <dt><asp:Label ID="Label16" runat="server" Text="论文发表情况" CssClass="label"></asp:Label></dt>
        <dd><asp:TextBox ID="ThesisIssue" runat="server" CssClass="textbox"></asp:TextBox></dd>
        <dt><asp:Label ID="Label17" runat="server" Text="承担科研项目情况" CssClass="label"></asp:Label></dt>
        <dd><asp:TextBox ID="ResearchDuty" runat="server" CssClass="textbox"></asp:TextBox></dd>
        <dt><asp:Label ID="Label18" runat="server" Text="研究成果获奖情况" CssClass="label"></asp:Label></dt>
        <dd><asp:TextBox ID="ResearchAward" runat="server" CssClass="textbox"></asp:TextBox></dd>
        </dl>
        
        
        </fieldset>

        

        <fieldset>
        <legend>【教学信息】</legend>
        <dl>
        <dt><asp:Label ID="Label19" runat="server" Text="讲授的课程名" CssClass="label"></asp:Label></dt>
        <dd>
         <asp:TextBox ID="CourseName" runat="server" CssClass="textbox"></asp:TextBox></dd>
        <dt><asp:Label ID="Label20" runat="server" Text="课程性质" CssClass="label"></asp:Label></dt>
        <dd>
            <asp:DropDownList ID="CourseType" runat="server" CssClass="textbox" 
                Height="16px" Width="104px">
                <asp:ListItem>本科</asp:ListItem>
                <asp:ListItem>单证硕士</asp:ListItem>
                <asp:ListItem>双证硕士</asp:ListItem>
                <asp:ListItem>博士</asp:ListItem>
            </asp:DropDownList>
        </dd>
        <dt><asp:Label ID="Label21" runat="server" Text="课程属性" CssClass="label"></asp:Label></dt>
        <dd><div class="div_texbox">
                    <asp:DropDownList ID="CourseProperty" runat="server" CssClass="textbox" Width="104px">
                <asp:ListItem>中文</asp:ListItem>
                <asp:ListItem>双语</asp:ListItem>
                <asp:ListItem>纯英文</asp:ListItem>
            </asp:DropDownList></dd>
        </dl>
        </fieldset>

         <fieldset>
        <legend>【补充信息】</legend>
        <dl>
        <dt><asp:Label ID="Label22" runat="server" Text="备注" CssClass="label"></asp:Label></dt>
        <dd><asp:TextBox ID="Memo" runat="server" Height="213px" TextMode="MultiLine" 
                Width="450px"></asp:TextBox></dd>
        </dl>
        </fieldset>

        <asp:Button ID="Submit" runat="server" onclick="Submit_Click" Text="保存" CssClass="buttons"/>
           </form>
</body>
</html>
