<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RolesPrivilege.aspx.cs" Inherits="Engineering_AdminBakMag_RolesPrivilege" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>角色管理--工程硕士中心</title>
</head>
<body>
    <form id="form1" runat="server">
    <div  style=" font-size:25px">
        角色权限详细信息
    </div>
     <hr />
     <br />
     <div runat="server" id="div_updateRole" visible="false">
        当前角色：<asp:Label ID="lblRole" runat="server" Font-Bold="True" Font-Size="Large" 
             ForeColor="Red"></asp:Label>
     </div>
     <br />
    <div runat="server" id="div_adm" visible="false">
        <table width="700" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td height="39" colspan="4" valign="middle" align="left">
                        <span style=" font-weight:bold">管理员相关权限：</span></td>
                </tr>
                <tr>
                    <td width="175" height="31" align="left" valign="middle">
                        <asp:CheckBox ID="CheckBox_A1" runat="server" />
                        <asp:Label ID="Label_A1" runat="server" Text="消息信息管理"></asp:Label>
                    </td>
                    <td width="175" align="left" valign="middle">
                        <asp:CheckBox ID="CheckBox_A2" runat="server" />
                        <asp:Label ID="Label_A2" runat="server" Text="教学点管理"></asp:Label>
                    </td>
                    <td width="175" align="left" valign="middle">
                        <asp:CheckBox ID="CheckBox_A3" runat="server" />
                        <asp:Label ID="Label_A3" runat="server" Text="学生信息管理"></asp:Label>
                    </td>
                    <td width="175" align="left" valign="middle">
                        <asp:CheckBox ID="CheckBox_A4" runat="server" />
                        <asp:Label ID="Label_A4" runat="server" Text="学费信息管理"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td height="31" align="left" valign="middle">
                        <asp:CheckBox ID="CheckBox_A5" runat="server" />
                        <asp:Label ID="Label_A5" runat="server" Text="学籍信息管理"></asp:Label>
                    </td>
                    <td align="left" valign="middle">
                        <asp:CheckBox ID="CheckBox_A6" runat="server" />
                        <asp:Label ID="Label_A6" runat="server" Text="课程信息管理"></asp:Label>
                    </td>
                    <td align="left" valign="middle">
                        <asp:CheckBox ID="CheckBox_A7" runat="server" />
                        <asp:Label ID="Label_A7" runat="server" Text="选课信息管理"></asp:Label>
                    </td>
                    <td align="left" valign="middle">
                        <asp:CheckBox ID="CheckBox_A8" runat="server" />
                        <asp:Label ID="Label_A8" runat="server" Text="考试安排管理"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td height="31" align="left" valign="middle">
                        <asp:CheckBox ID="CheckBox_A9" runat="server" />
                        <asp:Label ID="Label_A9" runat="server" Text="课程成绩管理"></asp:Label>
                    </td>
                    <td align="left" valign="middle">
                        <asp:CheckBox ID="CheckBox_A10" runat="server" />
                        <asp:Label ID="Label_A10" runat="server" Text="教学评测管理"></asp:Label>
                    </td>
                    <td align="left" valign="middle">
                        <asp:CheckBox ID="CheckBox_A11" runat="server" />
                        <asp:Label ID="Label_A11" runat="server" Text="选导师日程管理"></asp:Label>
                    </td>
                    <td align="left" valign="middle">
                        <asp:CheckBox ID="CheckBox_A12" runat="server" />
                        <asp:Label ID="Label_A12" runat="server" Text="导师分配管理"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td height="31" align="left" valign="middle">
                        <asp:CheckBox ID="CheckBox_A13" runat="server" />
                        <asp:Label ID="Label_A13" runat="server" Text="分配预审论文"></asp:Label>
                    </td>
                    <td align="left" valign="middle">
                        <asp:CheckBox ID="CheckBox_A14" runat="server" />
                        <asp:Label ID="Label_A14" runat="server" Text="查看论文评审结果"></asp:Label>
                    </td>
                    <td align="left" valign="middle">
                        <asp:CheckBox ID="CheckBox_A15" runat="server" />
                        <asp:Label ID="Label_A15" runat="server" Text="发布硕士通知"></asp:Label>
                    </td>
                    <td align="left" valign="middle">
                        <asp:CheckBox ID="CheckBox_A16" runat="server" />
                        <asp:Label ID="Label_A16" runat="server" Text="发布硕士新闻"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td height="31" align="left" valign="middle">
                        <asp:CheckBox ID="CheckBox_A17" runat="server" />
                        <asp:Label ID="Label_A17" runat="server" Text="发布中心介绍"></asp:Label>
                    </td>
                    <td align="left" valign="middle">
                        <asp:CheckBox ID="CheckBox_A18" runat="server" />
                        <asp:Label ID="Label_A18" runat="server" Text="发布招生简章"></asp:Label>
                    </td>
                    <td align="left" valign="middle">
                        <asp:CheckBox ID="CheckBox_A19" runat="server" />
                        <asp:Label ID="Label_A19" runat="server" Text="发布招生流程"></asp:Label>
                    </td>
                    <td align="left" valign="middle">
                        <asp:CheckBox ID="CheckBox_A20" runat="server" />
                        <asp:Label ID="Label_A20" runat="server" Text="发布常见问题"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td height="31" align="left" valign="middle">
                        <asp:CheckBox ID="CheckBox_A21" runat="server" />
                        <asp:Label ID="Label_A21" runat="server" Text="历年成果展示"></asp:Label>
                    </td>
                    <td align="left" valign="middle">
                        <asp:CheckBox ID="CheckBox_A22" runat="server" />
                        <asp:Label ID="Label_A22" runat="server" Text="发布培养计划"></asp:Label>
                    </td>
                    <td align="left" valign="middle">
                        <asp:CheckBox ID="CheckBox_A23" runat="server" />
                        <asp:Label ID="Label_A23" runat="server" Text="发布教学培养流程"></asp:Label>
                    </td>
                    <td align="left" valign="middle">
                        <asp:CheckBox ID="CheckBox_A24" runat="server" />
                        <asp:Label ID="Label_A24" runat="server" Text="发布答辩申请流程"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td height="31" align="left" valign="middle">
                        <asp:CheckBox ID="CheckBox_A25" runat="server" />
                        <asp:Label ID="Label_A25" runat="server" Text="发布答辩材料要求"></asp:Label>
                    </td>
                </tr>
            </table>
    </div>
    <div id="div_teacher" runat="server" visible="false">
        <table width="700" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td height="39" colspan="4" valign="middle" align="left">
                    <asp:Label ID="lblTeacher" runat="server" Font-Bold="True"></asp:Label>
                 </td>
            </tr>
            <tr>
                <td width="175" height="31" align="left" valign="middle">
                    <asp:CheckBox ID="CheckBox_B1" runat="server" />
                    <asp:Label ID="Label_B1" runat="server" Text="管理所带学生"></asp:Label>
                </td>
                <td width="175" align="left" valign="middle">
                    <asp:CheckBox ID="CheckBox_B2" runat="server" />
                    <asp:Label ID="Label_B2" runat="server" Text="学生意向选择"></asp:Label>
                </td>
                <td width="175" align="left" valign="middle">
                    <asp:CheckBox ID="CheckBox_B3" runat="server" />
                    <asp:Label ID="Label_B3" runat="server" Text="查询课程信息"></asp:Label>
                </td>
                <td width="175" align="left" valign="middle">
                    <asp:CheckBox ID="CheckBox_B4" runat="server" />
                    <asp:Label ID="Label_B4" runat="server" Text="查询考试安排"></asp:Label>
                </td>
            </tr>
            <tr>
                <td height="31" align="left" valign="middle">
                    <asp:CheckBox ID="CheckBox_B5" runat="server" />
                    <asp:Label ID="Label_B5" runat="server" Text="学生论文互动"></asp:Label>
                </td>
                <td align="left" valign="middle">
                    <asp:CheckBox ID="CheckBox_B6" runat="server" />
                    <asp:Label ID="Label_B6" runat="server" Text="受理答辩申请"></asp:Label>
                </td>
                <td align="left" valign="middle">
                    <asp:CheckBox ID="CheckBox_B7" runat="server" />
                    <asp:Label ID="Label_B7" runat="server" Text="查看评审结果"></asp:Label>
                </td>
                <td align="left" valign="middle">
                    <asp:CheckBox ID="CheckBox_B8" runat="server" />
                    <asp:Label ID="Label_B8" runat="server" Text="评审预审论文"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <div id="div_student" runat="server" visible="false">
        <table width="700" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td height="39" colspan="4" valign="middle" align="left">
                    <span style="font-weight:bold">学生相关权限：相关权限：相关权限：</span>
                    </td>
            </tr>
            <tr>
                <td width="175" height="31" align="left" valign="middle">
                    <asp:CheckBox ID="CheckBox_C1" runat="server"/>
                    <asp:Label ID="Label_C1" runat="server" Text="注册个人信息"></asp:Label>
                </td>
                <td width="175" align="left" valign="middle">
                    <asp:CheckBox ID="CheckBox_C2" runat="server"  />
                    <asp:Label ID="Label_C2" runat="server" Text="查看个人信息"></asp:Label>
                </td>
                <td width="175" align="left" valign="middle">
                    <asp:CheckBox ID="CheckBox_C3" runat="server"  />
                    <asp:Label ID="Label_C3" runat="server" Text="更新个人信息"></asp:Label>
                </td>
                <td width="175" align="left" valign="middle">
                    <asp:CheckBox ID="CheckBox_C4" runat="server" />
                    <asp:Label ID="Label_C4" runat="server" Text="查看学费信息"></asp:Label>
                </td>
            </tr>
            <tr>
                <td height="31" align="left" valign="middle">
                    <asp:CheckBox ID="CheckBox_C5" runat="server"/>
                    <asp:Label ID="Label_C5" runat="server" Text="申请学籍变动"></asp:Label>
                </td>
                <td align="left" valign="middle">
                    <asp:CheckBox ID="CheckBox_C6" runat="server"/>
                    <asp:Label ID="Label_C6" runat="server" Text="查看所有导师"></asp:Label>
                </td>
                <td align="left" valign="middle">
                    <asp:CheckBox ID="CheckBox_C7" runat="server" />
                    <asp:Label ID="Label_C7" runat="server" Text="查看我的导师"></asp:Label>
                </td>
                <td align="left" valign="middle">
                    <asp:CheckBox ID="CheckBox_C8" runat="server" />
                    <asp:Label ID="Label_C8" runat="server" Text="查看开课课程"></asp:Label>
                </td>
            </tr>
            <tr>
                <td height="31" align="left" valign="middle">
                    <asp:CheckBox ID="CheckBox_C9" runat="server" />
                    <asp:Label ID="Label_C9" runat="server" Text="网上选课"></asp:Label>
                </td>
                <td align="left" valign="middle">
                    <asp:CheckBox ID="CheckBox_C10" runat="server"/>
                    <asp:Label ID="Label_C10" runat="server" Text="查看我的课表"></asp:Label>
                </td>
                <td align="left" valign="middle">
                    <asp:CheckBox ID="CheckBox_C11" runat="server"/>
                    <asp:Label ID="Label_C11" runat="server" Text="查看考试安排"></asp:Label>
                &nbsp;</td>
                <td align="left" valign="middle">
                    <asp:CheckBox ID="CheckBox_C12" runat="server" />
                    <asp:Label ID="Label_C12" runat="server" Text="查看成绩信息"></asp:Label>
                </td>
            </tr>
            <tr>
                <td height="31" align="left" valign="middle">
                    <asp:CheckBox ID="CheckBox_C13" runat="server"/>
                    <asp:Label ID="Label_C13" runat="server" Text="教学评估"></asp:Label>
                </td>
                <td align="left" valign="middle">
                    <asp:CheckBox ID="CheckBox_C14" runat="server" />
                    <asp:Label ID="Label_14" runat="server" Text="网上选导师"></asp:Label>
                </td>
                <td align="left" valign="middle">
                    <asp:CheckBox ID="CheckBox_C15" runat="server" />
                    <asp:Label ID="Label_C15" runat="server" Text="提交开题报告"></asp:Label>
                </td>
                <td align="left" valign="middle">
                    <asp:CheckBox ID="CheckBox_C16" runat="server"/>
                    <asp:Label ID="Label_C16" runat="server" Text="提交中期考核表"></asp:Label>
                </td>
            </tr>
            <tr>
                <td height="31" align="left" valign="middle">
                    <asp:CheckBox ID="CheckBox_C17" runat="server"/>
                    <asp:Label ID="Label_C17" runat="server" Text="提交论文初稿"></asp:Label>
                </td>
                <td align="left" valign="middle">
                    <asp:CheckBox ID="CheckBox_C18" runat="server"  />
                    <asp:Label ID="Label_C18" runat="server" Text="申请论文答辩"></asp:Label>
                </td>
                <td align="left" valign="middle">
                    <asp:CheckBox ID="CheckBox_C19" runat="server"/>
                    <asp:Label ID="Label_C19" runat="server" Text="查看审核结果"></asp:Label>
                </td>
                <td align="left" valign="middle">
                    
                    <asp:CheckBox ID="CheckBox_C20" runat="server" />
                    <asp:Label ID="Label1" runat="server" Text="提交校外导师信息"></asp:Label>
                    
                </td>
            </tr>
        </table>
    </div>
    <br />
    <div>
            <asp:Button ID="btModify" runat="server" Text="修改权限" BackColor="#3333FF" 
                ForeColor="White" Height="31px" onclick="btModify_Click" />
            &nbsp;&nbsp;
            <asp:Button ID="btSave" runat="server" BackColor="#3333FF" ForeColor="White" 
                Height="31px" onclick="btSave_Click" Text="保存修改" />
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="btBack" runat="server" BackColor="#3333FF" ForeColor="White" 
                Height="31px" PostBackUrl="~/Engineering/AdminBakMag/RoleManagement.aspx" 
                Text="返回" Width="60px" />
        </div>
    </form>
</body>
</html>
