<%@ Page Title="" Language="C#" MasterPageFile="~/Admission/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="AdminAdd.aspx.cs" Inherits="RecruitmentNew_Admin_AdminAdd" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="position:relative; float:right">
    <asp:Label ID="Label1" runat="server" Text="请输入您要指定的管理员 编号（工号或学号）" ForeColor="Lime"></asp:Label>
    <br />
    
    <asp:TextBox ID="TxtAdminID" runat="server" Height="20px" Width="187px"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtAdminID">请输入工号或学号</asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
        ControlToValidate="TxtAdminID" ValidationExpression="[0-9]{6}">请输入正确的格式--6位工号</asp:RegularExpressionValidator>
    <br />
    <br />
    <asp:Label ID="Label2" runat="server" Text="请选择他所具有的管理权限" ForeColor="Lime"></asp:Label>
    <br />
    <div id="chckbxStyle">
        <asp:CheckBoxList ID="CheckBoxList1" runat="server" Height="78px" Width="137px">
            <asp:ListItem>高考生</asp:ListItem>
            <asp:ListItem>工学硕士</asp:ListItem>
            <asp:ListItem>工程硕士</asp:ListItem>
            <asp:ListItem>专业学位</asp:ListItem>
        </asp:CheckBoxList>
        <asp:Button ID="BtCommit" runat="server" Text="提交" />
        <br />
    </div>
    </div>
</asp:Content>

