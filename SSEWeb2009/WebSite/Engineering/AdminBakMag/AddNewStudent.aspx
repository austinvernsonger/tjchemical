<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddNewStudent.aspx.cs" Inherits="Engineering_AdminBakMag_AddNewStudent" %>

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
                        <asp:Label ID="lblTitle" runat="server" Text="添加新生信息（单个添加）"></asp:Label></span>
                </td>
                <td width="250" align="right" valign="bottom">
                    <asp:HyperLink ID="HyperLink1" runat="server" 
                        NavigateUrl="~/Engineering/AdminBakMag/StudentsManagement.aspx" 
                        ForeColor="#666666">&lt;&lt;返回上一页</asp:HyperLink>
                </td>
            </tr>
        </table>
    </div>
    <hr />
    <br />
    <div>
        <asp:FormView ID="FormView1" runat="server" DefaultMode="Edit" 
            ondatabound="FormView1_DataBound" onprerender="FormView1_PreRender">
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
                            学号：</td>
                        <td align="left" valign="middle">
                            <asp:TextBox ID="tbStuID" runat="server" Width="150px" ValidationGroup="edit" Text='<%#Bind("StudentID") %>'></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ControlToValidate="tbStuID" Display="Dynamic" ErrorMessage="请输入学号" 
                                Font-Names="Verdana" Font-Size="10pt" ValidationGroup="edit"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td height="31" align="left" valign="middle">
                             姓名：</td>
                        <td align="left" valign="middle">
                            <asp:TextBox ID="tbName" runat="server" Width="150px" ValidationGroup="edit" Text='<%#Bind("sName") %>'></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                ControlToValidate="tbName" ErrorMessage="请输入姓名" Font-Names="Verdana" 
                                Font-Size="10pt" ValidationGroup="edit"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td height="31" align="left" valign="middle">
                            性别：
                        </td>
                        <td align="left" valign="middle">
                            <asp:RadioButton ID="rdMan" runat="server" Text="男" Checked='<%#Convert.ToInt32(Eval("sGender"))==0?true : false %>' 
                                GroupName="gender"/>
                            <asp:RadioButton ID="rdWoman" runat="server" Text="女" GroupName="gender" Checked='<%#Convert.ToInt32(Eval("sGender"))==1?true : false %>' />
                        </td>
                    </tr>
                    <tr>
                        <td height="31" align="left" valign="middle">
                            年级：
                        </td>
                        <td align="left" valign="middle">
                            <asp:DropDownList ID="ddlGrade" runat="server" Width="120px" 
                                DataSourceID="ObjectDataSource2" DataTextField="Key" DataValueField="Value">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" 
                                SelectMethod="GetGradeWithOtherForm" 
                                TypeName="Department.Engineering.StudentManage"></asp:ObjectDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td height="31" align="left" valign="middle">
                            教学点：
                        </td>
                        <td align="left" valign="middle">
                            <asp:DropDownList ID="ddlSchool" runat="server" Width="120px" 
                                DataSourceID="ObjectDataSource1" DataTextField="TeaSchoolName" 
                                DataValueField="TeaSchoolID">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
                                SelectMethod="GetTeaSchoolList" 
                                TypeName="Department.Engineering.TeachingSchool"></asp:ObjectDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td height="31" align="left" valign="middle">
                             学制：</td>
                        <td align="left" valign="middle">
                            <asp:TextBox ID="tbSchooling" runat="server" Width="150px" Text="2.5年"
                                ValidationGroup="edit"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                ControlToValidate="tbSchooling" Display="Dynamic" ErrorMessage="请输入学制" 
                                Font-Names="Verdana" Font-Size="10pt" ValidationGroup="edit"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td height="31" align="left" valign="middle">
                             学位类别：</td>
                        <td align="left" valign="middle">
                            <asp:DropDownList ID="ddlDegree" runat="server">
                                <asp:ListItem>--请选择--</asp:ListItem>
                                <asp:ListItem>单证硕士</asp:ListItem>
                                <asp:ListItem>双证硕士</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td height="31" align="left" valign="middle">
                             登陆密码：</td>
                        <td align="left" valign="middle">
                            <asp:TextBox ID="tbPassword" runat="server" Width="150px" 
                                ValidationGroup="edit" Text='<%#Bind("Password") %>'></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                ControlToValidate="tbPassword" Display="Dynamic" ErrorMessage="请输入学生登录密码" 
                                Font-Names="Verdana" Font-Size="10pt" ValidationGroup="edit"></asp:RequiredFieldValidator>
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
                                ValidationGroup="edit" />
                        </td>
                        <td align="left" valign="middle">
                            <asp:Button ID="Button2" runat="server" Text="返回" BackColor="#3333FF" 
                                ForeColor="White" Height="31px" Width="90px" 
                                PostBackUrl="~/Engineering/AdminBakMag/StudentsManagement.aspx" />
                        </td>
                    </tr>
                </table>
            </EditItemTemplate>
        </asp:FormView>
    </div>
    </form>
</body>
</html>
