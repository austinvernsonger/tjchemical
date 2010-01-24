<%@ Page Language="C#" MasterPageFile="~/MasterPage/BackSys.master" AutoEventWireup="true" CodeFile="StraitStudentInfoLogin.aspx.cs" Inherits="StraitStudentInfo_StraitStudentInfoLogin" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<p>
    学号：
    <asp:TextBox ID="txtStudentID" runat="server"></asp:TextBox>
</p>
<p>
    姓名：
    <asp:TextBox ID="txtStudentName" runat="server"></asp:TextBox>
</p>
<p>
    入学前户口：
    <asp:DropDownList ID="DropDownListRegisteredResidenceBeforeSchool" runat="server">
        <asp:ListItem Value="0">农村</asp:ListItem>
        <asp:ListItem Value="1">城镇</asp:ListItem>
    </asp:DropDownList>
</p>
<p>
    家庭人数：
    <asp:TextBox ID="txtFamilyMemberNum" runat="server"></asp:TextBox>
</p>
<p>
    家庭人均月收入：
    <asp:TextBox ID="txtFamilySalary" runat="server"></asp:TextBox>
</p>
<p>
    是否是城市低保：
    <asp:DropDownList ID="DropDownListDiBao" runat="server">
        <asp:ListItem Value="0">否</asp:ListItem>
        <asp:ListItem Value="1">是</asp:ListItem>
    </asp:DropDownList>
</p>
<p>
    孤残：
    <asp:DropDownList ID="DropDownListGuCan" runat="server">
        <asp:ListItem Value="0">否</asp:ListItem>
        <asp:ListItem Value="1">是</asp:ListItem>
    </asp:DropDownList>
</p>
<p>
    单亲：
    <asp:DropDownList ID="DropDownListSingleParent" runat="server">
        <asp:ListItem Value="0">否</asp:ListItem>
        <asp:ListItem Value="1">是</asp:ListItem>
    </asp:DropDownList>
</p>
<p>
    烈士子女：
    <asp:DropDownList ID="DropDownListMartyrChild" runat="server">
        <asp:ListItem Value="0">否</asp:ListItem>
        <asp:ListItem Value="1">是</asp:ListItem>
    </asp:DropDownList>
</p>
<p>
    递交困难生登记表：
     <asp:DropDownList ID="DropDownListApply" runat="server">
        <asp:ListItem Value="0">否</asp:ListItem>
        <asp:ListItem Value="1">是</asp:ListItem>
    </asp:DropDownList>
</p>
<p>
    需要说明的事项（家庭遭受自然灾害、突发意外事件、重病、大病或其他特殊情况）：
     <asp:DropDownList ID="DropDownListExplainThings" runat="server">
        <asp:ListItem Value="0">否</asp:ListItem>
        <asp:ListItem Value="1">是</asp:ListItem>
    </asp:DropDownList>
</p>
<p>
    学院认定困难生情况：
    <asp:DropDownList ID="DropDownListStraitDegree" runat="server">
        <asp:ListItem Value="0">特困</asp:ListItem>
        <asp:ListItem Value="1">普困</asp:ListItem>
        <asp:ListItem Value="2">一般</asp:ListItem>
        <asp:ListItem Value="3">良好</asp:ListItem>
    </asp:DropDownList>
</p>
</asp:Content>

