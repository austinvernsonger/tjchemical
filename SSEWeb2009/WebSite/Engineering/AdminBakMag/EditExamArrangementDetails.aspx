<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditExamArrangementDetails.aspx.cs" Inherits="Engineering_AdminBakMag_EditExamArrangementDetails" %>
<%@ OutputCache Duration="1" VaryByParam="None"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <base target="_self" />
</head>
<body>
    <form id="form1" runat="server">
    <div  style="margin:12px 0 0 14px">
    <div>
        <table width="550">
            <tr>
                <td width="450" height="25" align="left" valign="bottom">
                    <span style="font-size:25px">考试安排详细</span>
                </td>
                <td width="100" align="right" valign="bottom">
                    <asp:LinkButton ID="lbBack1" runat="server" OnClientClick="window.close();">关闭</asp:LinkButton>
                </td>
            </tr>
        </table>
    </div>
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:FormView ID="fvTestArrange" runat="server" DefaultMode="Edit" 
            ondatabound="fvTestArrange_DataBound">
            <EditItemTemplate>
                <table width="550">
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
                    <tr>
                        <td height="31" align="left" valign="middle">
                            课程名称：</td>
                        <td align="left" valign="middle">
                            <asp:TextBox ID="tbName" runat="server" Width="200px" 
                                Text='<%#Eval("CourseName") %>'  ReadOnly="true"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="31" align="left" valign="middle">
                             学期：</td>
                        <td align="left" valign="middle">
                            <asp:TextBox ID="tbStuID" runat="server" Width="200px" 
                                Text='<%#Eval("CourseTime") %>' ReadOnly="true"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="31" align="left" valign="middle">
                            年级：
                        </td>
                        <td align="left" valign="middle">
                            <asp:TextBox ID="tbGrade" runat="server" Width="200px" 
                            Text='<%#Eval("Grade") %>' ReadOnly="true"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="31" align="left" valign="middle">
                            教学点：
                        </td>
                        <td align="left" valign="middle">
                            <asp:TextBox ID="tbSchool" runat="server" Width="200px"
                            Text='<%#Eval("TeaSchoolName") %>' ReadOnly="true"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="31" align="left" valign="middle">
                             任课教师：</td>
                        <td align="left" valign="middle">
                            <asp:TextBox ID="tbTerm" runat="server" Width="200px" 
                                Text='<%#Eval("Name") %>' ReadOnly="true"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="31" align="left" valign="middle">
                             考试时间：</td>
                        <td align="left" valign="middle">
                             <div style="float: left;">
                                    <asp:DropDownList ID="ddlYear" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged"
                                        OnPreRender="ddlYear_PreRender">
                                    </asp:DropDownList>
                                    年
                                    <asp:DropDownList ID="ddlMonth" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlMonth_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    月
                                </div>
                                <div style="float: left;">
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="ddlDay" runat="server">
                                            </asp:DropDownList>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="ddlMonth" EventName="TextChanged"></asp:AsyncPostBackTrigger>
                                            <asp:AsyncPostBackTrigger ControlID="ddlYear" EventName="TextChanged"></asp:AsyncPostBackTrigger>
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </div>
                                日
                                <asp:DropDownList ID="ddlStartHour" runat="server" 
                            DataSourceID="XmlDataSource1" DataTextField="name" DataValueField="id">
                        </asp:DropDownList>
                        --
                        <asp:DropDownList ID="ddlEndHour" runat="server" 
                            DataSourceID="XmlDataSource1" DataTextField="name" DataValueField="id">
                        </asp:DropDownList>
                        <asp:XmlDataSource ID="XmlDataSource1" runat="server" 
                            DataFile="~/Engineering/Resources/Xml/Time.xml" XPath="/Time/Hour">
                        </asp:XmlDataSource>    
                        </td>
                    </tr>
                    <tr>
                        <td height="31" align="left" valign="middle">
                             考试地点：</td>
                        <td align="left" valign="middle">
                            <asp:TextBox ID="tbPlace" runat="server" Width="300px" Height="100px"
                             TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="31" align="left" valign="middle">
                             监考老师一：</td>
                        <td align="left" valign="middle">
                            <asp:DropDownList ID="ddlTeacher1" runat="server" Width="120px" 
                                DataSourceID="ObjectDataSource1" DataTextField="Name" DataValueField="TeacherID">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td height="31" align="left" valign="middle">
                             监考老师二：</td>
                         <td align="left" valign="middle">
                             <asp:DropDownList ID="ddlTeacher2" runat="server" Width="120px" 
                                DataSourceID="ObjectDataSource1" DataTextField="Name" DataValueField="TeacherID">
                            </asp:DropDownList>
                         </td> 
                    </tr>
                    <tr>
                        <td height="23" colspan="2" valign="top">
                        </td>
                    </tr>
                    <tr>
                        <td height="32" align="center" valign="middle">
                            <asp:Button ID="btSave" runat="server" Text="保存" BackColor="#3333FF" 
                                ForeColor="White" Height="31px" Width="90px" onclick="btSave_Click" />
                        </td>
                        <td align="left" valign="middle">
                            <asp:Button ID="Button2" runat="server" Text="返回" BackColor="#3333FF" 
                                ForeColor="White" Height="31px" Width="90px"  OnClientClick="window.close();" />
                        </td>
                    </tr>
                </table> 
            </EditItemTemplate>
        </asp:FormView>
        <asp:Label ID="lblMessage" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
            SelectMethod="GetAllTeacherInfoList" 
            TypeName="Department.Engineering.TeacherManage" 
            OldValuesParameterFormatString="original_{0}"></asp:ObjectDataSource>
    </div>
    </div>
    </form>
</body>
</html>
