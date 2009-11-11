<%@ Page Language="C#" MasterPageFile="~/MasterPages/blank.master" AutoEventWireup="true" CodeFile="NewStudent.aspx.cs" Inherits="SysMgr_NewStudent" Title="无标题页" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="phctnt_head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="phctnt_body" Runat="Server">
仅某些关键字段有效
    <p>
        姓名<asp:TextBox ID="txtName" runat="server"></asp:TextBox>
    </p>
    <p>
        学号<asp:TextBox ID="txtStudentID" runat="server"></asp:TextBox>
    </p>
                <p>
                    密码<asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
    </p>
    <p>
        性别<asp:DropDownList ID="dropGender" runat="server">
            <asp:ListItem Value="0">女</asp:ListItem>
            <asp:ListItem Value="1">男</asp:ListItem>
        </asp:DropDownList>
    </p>
    <p>
        专业<asp:TextBox ID="txtMajor" runat="server"></asp:TextBox>
    </p>
                <p>
                    学制<asp:DropDownList ID="dropLOS" runat="server">
                        <asp:ListItem>2.5年</asp:ListItem>
                        <asp:ListItem>3年</asp:ListItem>
                        <asp:ListItem Selected="True">4年</asp:ListItem>
                    </asp:DropDownList>
    </p>
    <p>
        学位(学士/单证工程硕士/双证工程硕士/工学硕士)<asp:TextBox ID="txtDegree" runat="server">学士</asp:TextBox>
    </p>
    <asp:Button ID="btnOK" runat="server" Text="确定" onclick="btnOK_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnClear" runat="server" Text="重置" onclick="btnClear_Click" />
            <asp:TextBox ID="Warning" Visible=false ReadOnly=true runat="server" 
                BorderStyle="None"></asp:TextBox>
</asp:Content>
