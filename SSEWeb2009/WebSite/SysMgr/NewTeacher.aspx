<%@ Page Language="C#" MasterPageFile="~/MasterPages/blank.master" AutoEventWireup="true" CodeFile="NewTeacher.aspx.cs" Inherits="SysMgr_NewTeacher" Title="无标题页" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="phctnt_head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="phctnt_body" Runat="Server">
<div style="font-size:12px; font-family:宋体; color:Black;">
<table class="style1">
        <tr>
            <td class="style2">
                教师编号:</td>
            <td>
                <asp:TextBox ID="tbTeacherID" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
                密码:</td>
            <td>
                <asp:TextBox ID="tbPassword" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
                姓名:</td>
            <td>
                <asp:TextBox ID="tbName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
                性别:</td>
            <td>
                <asp:DropDownList ID="tbGender" runat="server">
                    <asp:ListItem Value="0">男</asp:ListItem>
                    <asp:ListItem Value="1">女</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style2">
             教师属性:
            </td>
            <td>
                <asp:DropDownList ID="tbTeacherAttribute" runat="server">
                    <asp:ListItem Value="0">本院教师</asp:ListItem>
                    <asp:ListItem Value="1">外聘教师</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <!----
        <tr>
            <td class="style2">
                出生年月:</td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" 
                    TargetControlID="TextBox1">
                </cc1:CalendarExtender>
                        </td>
        </tr>
        <tr>
            <td class="style2">
                地址:       <td>
                <asp:TextBox ID="tbAddress" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
                电话:</td>
            <td>
                <asp:TextBox ID="tbTelephone" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
                传真:</td>
            <td>
                <asp:TextBox ID="tbFax" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
                邮件:</td>
            <td>
                <asp:TextBox ID="tbEmail" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
                职称:</td>
            <td>
                <asp:TextBox ID="tbTitle" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
                职务:</td>
            <td>
                <asp:TextBox ID="tbPost" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
                备注:</td>
            <td>
                <asp:TextBox ID="tbMemo" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
                学历:</td>
            <td>
                <asp:TextBox ID="tbEducationDegree" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
                毕业院校:
            </td>
            <td>
                <asp:TextBox ID="tbDegreeIssuedBy" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
                研究方向:</td>
            <td>
                <asp:TextBox ID="tbResearchArea" runat="server"></asp:TextBox>
            </td>
        </tr>
        ----->
        <tr>
            <td>
                <asp:Button ID="AddInfo" Text="添加" runat="server" onclick="AddInfo_Click" />
            </td>
            <td>
                <asp:Button ID="Cancel" Text="取消" runat="server" onclick="Cancel_Click" />
            </td>
        </tr>
        <tr>
            <asp:TextBox ID="Warning" Visible=false ReadOnly=true runat="server" 
                BorderStyle="None"></asp:TextBox>
        </tr>
    </table>
</div>
</asp:Content>

