<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SetTestArrangement.aspx.cs" Inherits="Engineering_AdminBakMag_SetTestArrangement" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <base target="_self" />
</head>
<body>
    <form id="form1" runat="server">
    <div style="margin:12px 0 0 14px">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server" 
            EnableScriptGlobalization="True" EnableScriptLocalization="True">
        </asp:ScriptManager>
        <table width="500">
            <tr>
                <td width="340" height="31" align="left" valign="middle">
                    设置考试安排
                </td>
                <td width="160" align="right" valign="middle">
                    <asp:LinkButton ID="LinkButton1" runat="server" OnClientClick="window.close();">关闭窗口</asp:LinkButton>
                </td>
            </tr>
        </table>
    </div>
    <br />
    <div>
        <asp:DetailsView ID="dvTestArrange" runat="server" Height="50px" Width="500px" 
            AutoGenerateRows="False" BackColor="White" BorderColor="#CCCCCC" 
            BorderStyle="Solid" BorderWidth="1px" CellPadding="3" 
            ondatabound="dvTestArrange_DataBound" 
            onmodechanging="dvTestArrange_ModeChanging" 
            onitemupdating="dvTestArrange_ItemUpdating">
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <RowStyle ForeColor="#000066" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <Fields>
                <asp:TemplateField HeaderText="课程名称">
                    <ItemStyle Width="380px" />
                    <ItemTemplate>
                        <asp:Label ID="lblCourseName" runat="server" Text='<%#Eval("CourseName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="学期">
                    <ItemTemplate>
                        <asp:Label ID="lblTerm" runat="server" Text='<%#Eval("CourseTime") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="年级">
                    <ItemTemplate>
                        <asp:Label ID="lblGrade" runat="server" Text='<%#Eval("Grade") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="教学点">
                    <ItemTemplate>
                        <asp:Label ID="lblTeaSchoolName" runat="server" Text='<%#Eval("TeaSchoolName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="任课教师">
                    <ItemTemplate>
                        <asp:Label ID="lblName" runat="server" Text='<%#Eval("Name") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="考试时间">
                    <EditItemTemplate>    
                        日期：<asp:TextBox ID="tbCalendar" runat="server" Width="90px"></asp:TextBox>
                        &nbsp; 小时：<asp:DropDownList ID="ddlStartHour" runat="server" 
                            DataSourceID="XmlDataSource1" DataTextField="name" DataValueField="id">
                        </asp:DropDownList>
                        &nbsp;--
                        <asp:DropDownList ID="ddlEndHour" runat="server" 
                            DataSourceID="XmlDataSource1" DataTextField="name" DataValueField="id">
                        </asp:DropDownList>
                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy-MM-dd" 
                            TargetControlID="tbCalendar">
                        </cc1:CalendarExtender>
                        <asp:XmlDataSource ID="XmlDataSource1" runat="server" 
                            DataFile="~/Engineering/Resources/Xml/Time.xml" XPath="/Time/Hour">
                        </asp:XmlDataSource>        
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="考试地点">
                    <EditItemTemplate>
                        <asp:TextBox ID="tbPlace" runat="server" Height="50px" TextMode="MultiLine" 
                            Width="200px"></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="监考教师一">
                    <EditItemTemplate>
                        <asp:DropDownList ID="ddlTeacher1" runat="server" Width="120px" 
                            DataSourceID="ObjectDataSource1" DataTextField="Name" 
                            DataValueField="TeacherID">
                        </asp:DropDownList>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="监考教师二">
                    <EditItemTemplate>
                        <asp:DropDownList ID="ddlTeacher2" runat="server" Width="120px" 
                            DataSourceID="ObjectDataSource1" DataTextField="Name" 
                            DataValueField="TeacherID">
                        </asp:DropDownList>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:CommandField EditText="进行设置" ShowEditButton="True" UpdateText="保存">
                    <ItemStyle ForeColor="Red" HorizontalAlign="Center" />
                </asp:CommandField>
            </Fields>
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
        </asp:DetailsView>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
            SelectMethod="GetAllTeacherInfo" 
            TypeName="Department.Engineering.TeacherManage"></asp:ObjectDataSource>
    </div>
     <div>
        <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Visible="False"></asp:Label>
    </div>
    <br />
    <p style="text-align:center; width: 500px;"> 
        <asp:LinkButton ID="LinkButton2" runat="server" OnClientClick="window.close();">关闭窗口</asp:LinkButton>
    </p>
    </div>
    </form>
</body>
</html>
