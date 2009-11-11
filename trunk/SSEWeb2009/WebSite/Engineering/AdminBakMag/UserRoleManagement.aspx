<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserRoleManagement.aspx.cs" Inherits="Engineering_AdminBakMag_UserRoleManagement" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div  style=" font-size:25px">
          用户角色管理
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    </div>
    <hr />
    <br />
    <div>
        <table width="700">
            <tr>
                <td width="160" align="left" valign="middle">
                    非工硕用户：<br />
                    <asp:ListBox ID="lbSchoolTeachers" runat="server" Width="150px" Height="300px"></asp:ListBox>
                </td>
                <td width="100" align="center" valign="middle">
                    <asp:Button ID="btAddTeacher" runat="server" Text=">>添加>>" 
                        onclick="btAddTeacher_Click"  /><br /><br />
                    <asp:Button ID="btDeleteTeacher" runat="server" Text="<<删除<<" 
                        onclick="btDeleteTeacher_Click" />
                </td>
                <td width="160" align="left" valign="middle">
                    工硕用户：<br />
                    <asp:ListBox ID="lbAllTeachers" runat="server" Width="150px" Height="300px"></asp:ListBox>
                </td>
                <td width="100" align="center" valign="middle">
                    <asp:Button ID="btAdd" runat="server" Text=">>添加>>" onclick="btAdd_Click" /><br /><br />
                    <asp:Button ID="btDelete" runat="server" Text="<<删除<<" 
                        onclick="btDelete_Click" />
                </td>
                <td width="180" align="left" valign="middle"> 
                        <asp:DropDownList ID="ddlUsers" runat="server" Width="100px" 
                        AutoPostBack="True" onselectedindexchanged="ddlUsers_SelectedIndexChanged">
                    </asp:DropDownList><br />
                    <asp:ListBox ID="lbUsers" runat="server" Width="150px" Height="300px"></asp:ListBox>
                </td>
            </tr>
        </table>
        <br />
        <br />
        操作说明：<br />
        1.这里所说的工硕用户和非工硕用户仅仅是指属于工硕中心的教师（学生除外）<br />
        2.请先将工硕用户从非工硕用户的列表中选进工硕用户的列表<br />
        3.每个不能只能有一个超级管理员<br />
        4.某个用户不能即是超级管理员，又是管理员（超级管理员已经包含了所有管理员权限）<br />
        5.某个用户不能既是导师，又是教师（用户只能属于其中的一个角色）<br />
        6.如果某个用户已经具有教师这个角色，想要让该用户具有导师角色，请先删除该用户所具有的教师角色
     </div>
    </form>
</body>
</html>
