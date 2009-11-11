<%@ Page Language="C#" MasterPageFile="~/Teaching/MainFrame.master"  AutoEventWireup="true" CodeFile="OrdinaryTeacher.aspx.cs" Inherits="Teaching_BackEnd_OrdinaryTeacher" Title="Untitled Page" %>
<%--
<%@ Register assembly="System.Web.Extensions" namespace="System.Web.UI" tagprefix="asp" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
--%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title></title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlace" Runat="Server">
    <div>
    

      <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    

        【基本信息】
        <br/>姓名      
        <asp:Label ID="Name" runat="server"></asp:Label>
        <br/>性别      
        <asp:Label ID="Gender" runat="server"></asp:Label>
        <br/>出生年月
         
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
        </asp:UpdatePanel>
        <p>
        <br/>
        职称     <asp:TextBox ID="TitleName" runat="server"></asp:TextBox>
        <br />取得职称的时间     
         

                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                        <ContentTemplate>
                            <asp:Calendar ID="TitleTime" runat="server" BackColor="White" 
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
        <br/>职务      <asp:TextBox ID="Post" runat="server"></asp:TextBox>
        <br/>硕/博导      
            <asp:DropDownList ID="DropDownList1" runat="server">
                <asp:ListItem Value="0">无</asp:ListItem>
                <asp:ListItem Value="1">博导</asp:ListItem>
                <asp:ListItem Value="2">工程硕士导师</asp:ListItem>
                <asp:ListItem Value="3">工学硕士导师</asp:ListItem>
            </asp:DropDownList>
        <br />评上硕/博导的时间     

                    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                        <ContentTemplate>
                            <asp:Calendar ID="TutorTime" runat="server" BackColor="White" 
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

        <p>
        <br/>最后学历      <asp:TextBox ID="LastDegree" runat="server"></asp:TextBox>
        <br/>最后学历毕业院校     <asp:TextBox ID="LastCollege" runat="server"></asp:TextBox>
        <br/>研究方向     <asp:TextBox ID="ResearchAspect" runat="server"></asp:TextBox>
        <br/>地址     <asp:TextBox ID="Address" runat="server"></asp:TextBox>
        <br/>电话     <asp:TextBox ID="Telephone" runat="server"></asp:TextBox>
        <br/>传真     <asp:TextBox ID="Fax" runat="server"></asp:TextBox>
        <br/>邮件     <asp:TextBox ID="Email" runat="server"></asp:TextBox>
        </p>
     
        <p>
      
        【科研信息】
        <br/>论文发表情况</p>
        <p>
      
        &nbsp;<asp:TextBox ID="ThesisIssue" runat="server" Height="239px" 
                TextMode="MultiLine" Width="715px"></asp:TextBox>
        <br/>承担科研项目情况
        </p>
        <p>
      
        &nbsp;<asp:TextBox ID="ResearchDuty" runat="server" Height="270px" 
                TextMode="MultiLine" Width="710px"></asp:TextBox>
        <br/>科研成果获奖情况</p>
        <p>
      
        &nbsp;<asp:TextBox ID="ResearchAward" runat="server" Height="213px" TextMode="MultiLine" 
                Width="702px"></asp:TextBox>
        </p>
        
        <p>
        
        【教学信息】
        <br/>承担/参与教改项目情况</p>
        <p>
        
        &nbsp;<asp:TextBox ID="EducationReform" runat="server" Height="239px" 
                TextMode="MultiLine" Width="708px"></asp:TextBox>
        <br/>承担/参与精品课程情况</p>
        <p>
        
        &nbsp;<asp:TextBox ID="CompetitiveCourse" runat="server" Height="278px" 
                TextMode="MultiLine" Width="700px"></asp:TextBox>
        <br/>讲授的课程名     <asp:TextBox ID="CourseName" runat="server"></asp:TextBox>
        <br/>课程性质      
            <asp:DropDownList ID="CourseType" runat="server">
                <asp:ListItem Value="本科">本科</asp:ListItem>
                <asp:ListItem Value="单证硕士">单证硕士</asp:ListItem>
                <asp:ListItem Value="双证硕士">双证硕士</asp:ListItem>
                <asp:ListItem Value="博士">博士</asp:ListItem>
            </asp:DropDownList>
        <br/>课程属性      
            <asp:DropDownList ID="CourseProperty" runat="server">
                <asp:ListItem Value="中文">中文</asp:ListItem>
                <asp:ListItem Value="双语">双语</asp:ListItem>
                <asp:ListItem Value="纯英语">纯英语</asp:ListItem>
            </asp:DropDownList>
        <br/>教学获奖情况</p>
        <p>
        
        &nbsp;<asp:TextBox ID="EducationAward" runat="server" Height="263px" TextMode="MultiLine" 
                Width="700px"></asp:TextBox>
        </p>
        
        <p>
        
        【学生培养】
        <br/>指导学生参加竞赛情况</p>
        <p>
        
        &nbsp;<asp:TextBox ID="StudentCompetition" runat="server" Height="251px" 
                TextMode="MultiLine" Width="699px"></asp:TextBox>
        <br/>博士/硕士届数     <asp:TextBox ID="StudentTerm" runat="server"></asp:TextBox>
            届<br/>指导的博士/硕士在读生数     <asp:TextBox ID="StudentCurrent" runat="server"></asp:TextBox>
            人<br/>已毕业的 博士/硕士学生数     <asp:TextBox ID="GraduateCount" runat="server"></asp:TextBox>
            人</p>
        <p>
        
            &nbsp;</p>
        
        <p>
        
        【补充信息】
        <br/>备注</p>
        <p>
        
        &nbsp;<asp:TextBox ID="Memo" runat="server" Height="307px" TextMode="MultiLine" 
                Width="712px"></asp:TextBox>



        </p>
        <p>
        
            &nbsp;</p>
        <p>
        
            <asp:Button ID="Submit" runat="server" Text="保存" onclick="Submit_Click" />



        </p>



    
    </div>
</asp:Content>