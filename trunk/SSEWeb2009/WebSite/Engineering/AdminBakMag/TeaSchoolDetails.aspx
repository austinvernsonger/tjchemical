<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TeaSchoolDetails.aspx.cs" Inherits="Engineering_AdminBakMag_TeaSchoolDetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:FormView ID="FormView1" runat="server" DefaultMode="Edit" 
            ondatabound="FormView1_DataBound" onprerender="FormView1_PreRender">
            <EditItemTemplate>
                <table width="600">
                    <tr>
                        <td height="50" colspan="2" align="left" valign="middle">
                            <h2>
                                教学点详细信息
                            </h2>
                        </td>
                    </tr>
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
                           <span style="color:Red">*</span> 教学点编号：</td>
                        <td align="left" valign="middle">
                            <asp:TextBox ID="tbTSchoolNum" runat="server" Width="200px" 
                                Text='<%#Bind("TeaSchoolID") %>' ValidationGroup="edit"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ControlToValidate="tbTSchoolNum" Display="Dynamic" ErrorMessage="教学点编号不能为空" 
                                Font-Names="Verdana" Font-Size="10pt" ValidationGroup="edit"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td height="31" align="left" valign="middle">
                            <span style="color:Red">*</span> 教学点名称：</td>
                        <td align="left" valign="middle">
                            <asp:TextBox ID="tbTSchoolName" runat="server" Width="200px" 
                                Text='<%#Bind("TeaSchoolName") %>' ValidationGroup="edit"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                ControlToValidate="tbTSchoolName" Display="Dynamic" ErrorMessage="教学点名称不能为空" 
                                Font-Names="Verdana" Font-Size="10pt" ValidationGroup="edit"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td height="31" align="left" valign="middle">
                            <span style="color:Red">*</span> 密码：</td>
                        <td align="left" valign="middle">
                            <asp:TextBox ID="tbTSchoolPassword" runat="server" Width="200px" 
                                Text='<%#Bind("Password") %>' ValidationGroup="edit"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                ControlToValidate="tbTSchoolPassword" Display="Dynamic" ErrorMessage="密码不能为空" 
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
                                ForeColor="White" Height="31px" Width="90px" ValidationGroup="edit" 
                                onclick="btSave_Click" />
                        </td>
                        <td align="left" valign="middle">
                            <asp:Button ID="Button2" runat="server" Text="返回" BackColor="#3333FF" 
                                ForeColor="White" Height="31px" Width="90px" 
                                PostBackUrl="~/Engineering/AdminBakMag/TeachingSchoolManagement.aspx" />
                        </td>
                    </tr>
                </table>
            </EditItemTemplate>
        </asp:FormView>
    </div>
    <br />
    <div>
        <asp:Label ID="lblMessage" runat="server" Text="//教学点编号可形如 TS1000 这样的编号，最好采用字母和数字的组合" Visible ="false"></asp:Label>
    </div>
    </form>
</body>
</html>
