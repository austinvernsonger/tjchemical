<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditCourseDetails.aspx.cs" Inherits="Engineering_AdminBakMag_EditCourseDetails" %>
<%@ OutputCache Duration="1" VaryByParam="None"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <base target="_self" />
</head>
<body>
    <form id="form1" runat="server">
    <div  style="text-align:center; padding-top:8px">
    <div>
        <table width="500">
            <tr>
                <td width="340" height="31" align="left" valign="middle">
                    课程信息详细
                </td>
                <td width="160" align="right" valign="middle">
                    <asp:LinkButton ID="LinkButton1" runat="server" OnClientClick="window.close();">关闭窗口</asp:LinkButton>
                </td>
            </tr>
        </table>
    </div>
    <br />
    <div>
        <asp:DetailsView ID="dvCourseDetails" runat="server" AutoGenerateRows="False" 
            Height="50px" Width="500px" BackColor="White" BorderColor="#CCCCCC" 
            BorderStyle="Solid" BorderWidth="1px" CellPadding="3" 
            ondatabound="dvCourseDetails_DataBound" 
            onitemcreated="dvCourseDetails_ItemCreated" 
            onmodechanging="dvCourseDetails_ModeChanging" 
            onitemupdating="dvCourseDetails_ItemUpdating" DataKeyNames="CourseID">
            <FooterStyle BackColor="White" ForeColor="#000066"/>
            <RowStyle ForeColor="#000066" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <Fields>
                <asp:TemplateField HeaderText="课程名称：">
                    <ItemStyle Width="350px" HorizontalAlign="Left" />
                    <ItemTemplate>
                        <%#Eval("CourseName") %>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:Label ID="lblCourseName" runat="server" Text='<%#Eval("CourseName") %>'></asp:Label>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="开课学期：">
                    <ItemTemplate>
                        <%#Eval("CourseTime")%>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="所属年级：">
                    <ItemTemplate>
                        <%#Eval("Grade") %>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="所属教学点：">
                    <ItemTemplate>
                        <%#Eval("TeaSchoolName") %>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="学分：">
                    <ItemTemplate>
                        <%#Eval("Credit") %>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="tbCredit" runat="server" Text='<%#Eval("Credit") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="学时：">
                    <ItemTemplate>
                        <%#Eval("CreditHour")%>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="tbCreditHour" runat="server" Text='<%#Eval("CreditHour")%>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="课程性质：">
                    <ItemTemplate>
                        <%#sProperty[Convert.ToInt32(Eval("Property"))] %>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:DropDownList ID="ddlProperty" runat="server">
                            <asp:ListItem Value="0">学位课</asp:ListItem>
                            <asp:ListItem Value="1">非学位课</asp:ListItem>
                            <asp:ListItem Value="2">必修环节</asp:ListItem>
                            <asp:ListItem Value="3">其他</asp:ListItem>
                        </asp:DropDownList>
                    </EditItemTemplate>
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="课程类别：">
                    <ItemTemplate>  
                        <%#sCategory[Convert.ToInt32(Eval("Category"))] %>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:DropDownList ID="ddlCategory" runat="server">
                            <asp:ListItem Value="0">必修</asp:ListItem>
                            <asp:ListItem Value="1">选修</asp:ListItem>
                            <asp:ListItem Value="2">其他</asp:ListItem>
                        </asp:DropDownList>
                    </EditItemTemplate>
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="上课时间：">
                    <ItemTemplate>
                        <%#Eval("ClassPeriod")%>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="tbClassPeriod" runat="server" Text=' <%#Eval("ClassPeriod")%>' 
                            Height="50px" TextMode="MultiLine"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="上课地点：">
                    <ItemTemplate>
                        <%#Eval("Place")%>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="tbPlace" runat="server" Text='<%#Eval("Place")%>' 
                            Height="50px" TextMode="MultiLine"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="任课教师一：">
                    <EditItemTemplate>
                        <asp:DropDownList ID="ddlTeacher1" runat="server" 
                            DataSourceID="ObjectDataSource1" DataTextField="UserName" 
                            DataValueField="UserID">
                        </asp:DropDownList>
                    </EditItemTemplate>
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="任课教师二：">
                    <EditItemTemplate>
                        <asp:DropDownList ID="ddlTeacher2" runat="server" 
                            DataSourceID="ObjectDataSource1" DataTextField="UserName" 
                            DataValueField="UserID">
                        </asp:DropDownList>
                    </EditItemTemplate>
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:CommandField EditText="修改" ShowEditButton="True" ButtonType="Button">
                    <ControlStyle BackColor="#3333FF" ForeColor="White" Height="31px" 
                        Width="90px" />
                    <ItemStyle ForeColor="Red" HorizontalAlign="Center" Height="50px" />
                </asp:CommandField>
            </Fields>
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
        </asp:DetailsView>
    </div>
    <div>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
            SelectMethod="GetTeacherFromUsers" 
            TypeName="Department.Engineering.TeacherManage" 
            OldValuesParameterFormatString="original_{0}"></asp:ObjectDataSource>
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
