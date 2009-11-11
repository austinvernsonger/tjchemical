<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddNewCourse.aspx.cs" Inherits="Engineering_AdminBakMag_AddNewCourse" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="700">
            <tr>
                <td width="450" height="25" align="left" valign="bottom">
                    <span style=" font-size:25px">
                        <asp:Label ID="lblTitle" runat="server" Text="添加新课程（单个添加）"></asp:Label></span>
                </td>
                <td width="250" align="right" valign="bottom">
                    <asp:HyperLink ID="HyperLink1" runat="server" 
                        ForeColor="#666666">&lt;&lt;返回上一页</asp:HyperLink>
                </td>
            </tr>
        </table>
    </div>
    <hr />
    <br />
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:FormView ID="FormView1" runat="server" DefaultMode="Insert" 
            onpageindexchanging="FormView1_PageIndexChanging">
            <EditItemTemplate>
                <table width="600">
                    <tr>
                        <td height="20" colspan="2" valign="top">
                        </td>
                    </tr>
                    <tr>
                        <td width="150" height="2">
                        </td>
                        <td width="450">
                        </td>
                    </tr>
                    <tr id="tr_name" runat="server">
                        <td height="31" align="left" valign="middle">
                            课程名称：</td>
                        <td align="left" valign="middle">
                            <asp:TextBox ID="tbCourseName" runat="server" Width="150px" 
                                ValidationGroup="insert"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ControlToValidate="tbCourseName" Display="Dynamic" ErrorMessage="请输入课程名称" 
                                Font-Names="Verdana" Font-Size="10pt" ValidationGroup="insert"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td height="31" align="left" valign="middle">
                             开课学期：</td>
                        <td align="left" valign="middle">
                            <asp:DropDownList ID="ddlTerm" runat="server" DataSourceID="ObjectDataSource1" 
                                DataTextField="Key" DataValueField="Value">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
                                SelectMethod="GetTerms" TypeName="Department.Engineering.TermsManage"></asp:ObjectDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td height="31" align="left" valign="middle">
                            所属年级：
                        </td>
                        <td align="left" valign="middle">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                <asp:DropDownList ID="ddlGrade" runat="server" AutoPostBack="True" 
                                        DataSourceID="ObjectDataSource2" DataTextField="Grade" 
                                        DataValueField="Grade" onselectedindexchanged="ddlGrade_SelectedIndexChanged">
                                    <asp:ListItem>--请选择年级--</asp:ListItem>
                                </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" 
                                        SelectMethod="GetGrade" TypeName="Department.Engineering.StudentManage"></asp:ObjectDataSource>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td height="31" align="left" valign="middle">
                            所属教学点：
                        </td>
                        <td align="left" valign="middle">
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                <asp:DropDownList ID="ddlSchool" runat="server" DataSourceID="ObjectDataSource3" 
                                        DataTextField="TeaSchoolName" DataValueField="TeaSchoolID" 
                                        onselectedindexchanged="ddlSchool_SelectedIndexChanged">
                                    <asp:ListItem>--请选择教学点--</asp:ListItem>
                                </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" 
                                        SelectMethod="GetTeaSchool" TypeName="Department.Engineering.TeachingSchool">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="ddlGrade" Name="selValue" 
                                                PropertyName="SelectedValue" Type="String" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddlGrade" 
                                        EventName="SelectedIndexChanged" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td height="31" align="left" valign="middle">
                            学分：
                        </td>
                        <td align="left" valign="middle">
                            <asp:TextBox ID="tbCredit" runat="server" Width="150px" 
                                ValidationGroup="insert"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                ControlToValidate="tbCredit" Display="Dynamic" ErrorMessage="请输入学分" 
                                Font-Names="Verdana" Font-Size="10pt" ValidationGroup="insert"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td height="31" align="left" valign="middle">
                             学时：</td>
                        <td align="left" valign="middle">
                            <asp:TextBox ID="tbCreditHour" runat="server" Width="150px" 
                                ValidationGroup="insert"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                ControlToValidate="tbCreditHour" ErrorMessage="请输入学时" Font-Names="Verdana" 
                                Font-Size="10pt" ValidationGroup="insert"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td height="31" align="left" valign="middle">
                             课程性质：</td>
                        <td align="left" valign="middle">
                            <asp:DropDownList ID="ddlPorperty" runat="server">
                                <asp:ListItem Value="0">--请选择--</asp:ListItem>
                                <asp:ListItem Value="1">学位课</asp:ListItem>
                                <asp:ListItem Value="2">非学位课</asp:ListItem>
                                <asp:ListItem Value="3">必修环节</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td height="31" align="left" valign="middle">
                             课程类别：</td>
                        <td align="left" valign="middle">
                            <asp:DropDownList ID="ddlCategory" runat="server">
                                <asp:ListItem Value="0">--请选择--</asp:ListItem>
                                <asp:ListItem Value="1">必修</asp:ListItem>
                                <asp:ListItem Value="2">选修</asp:ListItem>
                            </asp:DropDownList>   
                        </td>
                    </tr>
                    <tr>
                        <td height="31" align="left" valign="middle">
                             上课时间：</td>
                        <td align="left" valign="middle">
                            <asp:TextBox ID="tbClassPeriod" runat="server" Width="250px" Height="80px" 
                                TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="31" align="left" valign="middle">
                             上课地点：</td>
                        <td align="left" valign="middle">
                            <asp:TextBox ID="tbPlace" runat="server" Height="80px" TextMode="MultiLine" 
                                Width="250px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="31" align="left" valign="middle">
                             任课教师一：</td>
                        <td align="left" valign="middle">
                            <asp:DropDownList ID="ddlTeacher1" runat="server" 
                                DataSourceID="ObjectDataSource4" DataTextField="UserName" 
                                DataValueField="UserID">
                            </asp:DropDownList>      
                        </td>
                    </tr>
                    <tr>
                        <td height="31" align="left" valign="middle">
                             任课教师二：</td>
                        <td align="left" valign="middle">  
                            <asp:DropDownList ID="ddlTeacher2" runat="server" 
                                DataSourceID="ObjectDataSource4" DataTextField="UserName" 
                                DataValueField="UserID">
                            </asp:DropDownList>        
                            <asp:ObjectDataSource ID="ObjectDataSource4" runat="server" 
                                SelectMethod="GetTeacherFromUsers" 
                                TypeName="Department.Engineering.TeacherManage"></asp:ObjectDataSource>   
                        </td>
                    </tr>
                    <tr>
                        <td height="23" colspan="2" valign="top">
                        </td>
                    </tr>
                    <tr>
                        <td height="32" align="center" valign="middle">
                            <asp:Button ID="btSave" runat="server" Text="保存" BackColor="#3333FF" 
                                ForeColor="White" Height="31px" Width="90px" onclick="btSave_Click" 
                                ValidationGroup="insert" />
                        </td>
                        <td align="left" valign="middle">
                            <asp:Button ID="Button2" runat="server" Text="返回" BackColor="#3333FF" 
                                ForeColor="White" Height="31px" Width="90px" 
                                PostBackUrl="~/Engineering/AdminBakMag/CoursesManagement.aspx" />
                        </td>
                    </tr>
                </table>
            </EditItemTemplate>
        </asp:FormView>
    </div>
    </form>
</body>
</html>
