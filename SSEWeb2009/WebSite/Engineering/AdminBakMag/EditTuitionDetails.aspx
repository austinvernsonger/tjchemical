<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditTuitionDetails.aspx.cs" Inherits="Engineering_AdminBakMag_EditTuitionDetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

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
                    <span style=" font-size:25px">学费详细信息</span>
                </td>
                <td width="250" align="right" valign="bottom">
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Engineering/AdminBakMag/TutionInfoManage.aspx" ForeColor="#666666">&lt;&lt;返回上一页</asp:HyperLink>
                </td>
            </tr>
        </table>
        <asp:ScriptManager ID="ScriptManager1" runat="server" 
            EnableScriptGlobalization="True" EnableScriptLocalization="True">
        </asp:ScriptManager>
    </div>
    <hr />
    <div>
        <asp:FormView ID="FormView1" runat="server" DefaultMode="Edit" 
            onpageindexchanging="FormView1_PageIndexChanging" 
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
                            <span style="color:Red">*</span>姓名：</td>
                        <td align="left" valign="middle">
                            <asp:TextBox ID="tbName" runat="server" Width="200px" 
                                Text='<%#Bind("Name") %>' ></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="31" align="left" valign="middle">
                             <span style="color:Red">*</span>学号：</td>
                        <td align="left" valign="middle">
                            <asp:TextBox ID="tbStuID" runat="server" Width="200px" 
                                Text='<%#Bind("StudentID") %>' ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                ControlToValidate="tbStuID" ErrorMessage="学号不能为空" Font-Names="Verdana" 
                                Font-Size="10pt" ValidationGroup="edit"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr id="tr_grade" runat = "server">
                        <td height="31" align="left" valign="middle">
                            <span style="color:Red">*</span>年级：
                        </td>
                        <td align="left" valign="middle">
                            <asp:TextBox ID="tbGrade" runat="server" Width="200px" Enabled="false" Text='<%#Bind("Grade") %>'></asp:TextBox>
                        </td>
                    </tr>
                    <tr id="tr_school" runat="server">
                        <td height="31" align="left" valign="middle">
                            <span style="color:Red">*</span>教学点：
                        </td>
                        <td align="left" valign="middle">
                            <asp:TextBox ID="tbSchool" runat="server" Width="200px" Enabled="false" Text='<%#Bind("TeaSchoolName") %>'></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="31" align="left" valign="middle">
                             <span style="color:Red">*</span>缴费学期：</td>
                        <td align="left" valign="middle">
                            <asp:DropDownList ID="ddlTerm" runat="server" DataSourceID="ObjectDataSource3" 
                                DataTextField="Key" DataValueField="Value" Width="120px">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" 
                                SelectMethod="GetTerms" TypeName="Department.Engineering.TermsManage"></asp:ObjectDataSource>
                            <asp:TextBox ID="tbTerm" runat="server" Width="200px" Enabled="false" Text='<%#Bind("PaymentTerm") %>'></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="31" align="left" valign="middle">
                             <span style="color:Red">*</span>缴费时间：</td>
                        <td align="left" valign="middle">
                            <asp:TextBox ID="tbTime" runat="server" Width="200px" 
                            Text='<%#Bind("PaymentTime") %>'></asp:TextBox>
                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy-MM-dd" TargetControlID="tbTime">
                            </cc1:CalendarExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                ControlToValidate="tbTime" Display="Dynamic" ErrorMessage="缴费时间不能为空" 
                                Font-Names="Verdana" Font-Size="10pt" ValidationGroup="edit"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td height="31" align="left" valign="middle">
                             <span style="color:Red">*</span>需缴学费：</td>
                        <td align="left" valign="middle">
                            <asp:TextBox ID="tbMustPay" runat="server" Width="200px" 
                            Text='<%#Bind("MustMoney") %>' ValidationGroup="edit"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ControlToValidate="tbMustPay" Display="Dynamic" ErrorMessage="需缴学费不能为空" 
                                Font-Names="Verdana" Font-Size="10pt" ValidationGroup="edit"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td height="31" align="left" valign="middle">
                             <span style="color:Red">*</span>已缴学费：</td>
                        <td align="left" valign="middle">
                            <asp:TextBox ID="tbactualMoney" runat="server" Width="200px" 
                            Text='<%#Bind("ActualMoney") %>' ValidationGroup="edit"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                ControlToValidate="tbactualMoney" Display="Dynamic" 
                                ErrorMessage="已缴学费不能空，可以用 0 表示 " Font-Names="Verdana" Font-Size="10pt" 
                                ValidationGroup="edit"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td height="31" align="left" valign="middle">
                             备注：</td>
                         <td align="left" valign="middle">
                             <asp:TextBox ID="tbRemark" runat="server" Width="294px" 
                             Text='<%#Bind("Remark") %>' Height="100px" TextMode="MultiLine"></asp:TextBox>
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
                                PostBackUrl="~/Engineering/AdminBakMag/TutionInfoManage.aspx" />
                        </td>
                    </tr>
                </table>
            </EditItemTemplate>
        </asp:FormView>
    </div>
    </form>
</body>
</html>
