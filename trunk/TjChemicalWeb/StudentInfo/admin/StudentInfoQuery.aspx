﻿<%@ Page Language="C#" MasterPageFile="~/MasterPage/BackSys.master" AutoEventWireup="true" CodeFile="StudentInfoQuery.aspx.cs" Inherits="StudentInfo_StudentInfoQuery" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<p>

    <asp:Table ID="Table1" runat="server">
       <asp:TableRow ID="TableRow1" runat="server">
         <asp:TableCell ID="TableCell1" runat="server">
         学号:
         <asp:TextBox ID="txtStudentID" runat="server"></asp:TextBox>
         </asp:TableCell>
         <asp:TableCell ID="TableCell2" runat="server">
         姓名：
         <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
         </asp:TableCell>
         <asp:TableCell ID="TableCell3" runat="server">
         民族：
         <asp:TextBox ID="txtNation" runat="server"></asp:TextBox>
         </asp:TableCell>
       </asp:TableRow>
        <asp:TableRow ID="TableRow2" runat="server">
         <asp:TableCell ID="TableCell4" runat="server">
         系所：
         <asp:DropDownList ID="DropDownListDepartment" runat="server">
            <asp:ListItem Value="-1" Text=" "></asp:ListItem>
         </asp:DropDownList>
         </asp:TableCell>
         <asp:TableCell ID="TableCell5" runat="server">
         现在专业:
         <asp:TextBox ID="txtField" runat="server"></asp:TextBox>
         </asp:TableCell>
         <asp:TableCell ID="TableCell6" runat="server">
         入学年份:
         <asp:TextBox ID="txtEntranceYear" runat="server"></asp:TextBox>
         </asp:TableCell>
       </asp:TableRow>
        <asp:TableRow ID="TableRow3" runat="server">
         <asp:TableCell ID="TableCell7" runat="server">
         学生类别：
         <asp:DropDownList ID="DropDownListStudentType" runat="server">
            <asp:ListItem Value="-1" Text=" "></asp:ListItem>
            <asp:ListItem Value="0">本科生</asp:ListItem>
            <asp:ListItem Value="1">研究生</asp:ListItem>
            <asp:ListItem Value="2">博士生</asp:ListItem>
         </asp:DropDownList>
         </asp:TableCell>
         <asp:TableCell ID="TableCell8" runat="server">
         毕业身份：
         <asp:DropDownList ID="DropDownListGraduationType" runat="server">
            <asp:ListItem Value="-1" Text=" "></asp:ListItem>
            <asp:ListItem Value="0">本科生</asp:ListItem>
            <asp:ListItem Value="1">研究生</asp:ListItem>
            <asp:ListItem Value="2">博士生</asp:ListItem>
         </asp:DropDownList>
         </asp:TableCell>
         <asp:TableCell ID="TableCell9" runat="server">
            目前所在单位：
            <asp:DropDownList ID="DropDownListWorkUnit" runat="server">
                <asp:ListItem Value="-1" Text=" "></asp:ListItem>
            </asp:DropDownList>
         </asp:TableCell>
       </asp:TableRow>             
    </asp:Table>
    <asp:Button ID="btQuery" Text="查询" runat="server" onclick="btQuery_Click" />
</p>
<p>
    <asp:GridView ID="GridViewStudentInfo" runat="server" DataKeyNames="StudentID" 
        AllowPaging="true" AllowSorting="true" 
        onpageindexchanging="OnPageIndexChanging" PageSize="20" 
        onrowdatabound="OnRowDataBound" AutoGenerateColumns="false" 
        AutoGenerateDeleteButton="true" onrowdeleting="OnRowDeleting" 
        AutoGenerateEditButton="true" onrowediting="OnRowEditing">
        <Columns>
            <asp:TemplateField HeaderText="学号">
                <ItemTemplate>
                    <asp:Label ID="lbStudentID" runat="server" Text='<%# Eval("StudentID") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="姓名">
                <ItemTemplate>
                    <asp:Label ID="lbName" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="民族">
                <ItemTemplate>
                    <asp:Label ID="lbNation" runat="server" Text='<%# Eval("Nation") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="系所">
                <ItemTemplate>
                    <asp:Label ID="lbDepartment" runat="server" Text='<%# Eval("DepartmentName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="目前所在单位">
                <ItemTemplate>
                    <asp:Label ID="lbWorkUnitName" runat="server" Text='<%# Eval("WorkUnitName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="现在专业">
                <ItemTemplate>
                    <asp:Label ID="lbField" runat="server" Text='<%# Eval("Major") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="入学年份">
                <ItemTemplate>
                    <asp:Label ID="lbEntranceYear" runat="server" Text='<%# Eval("EntryYear") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="学生类别">
                <ItemTemplate>
                    <asp:DropDownList ID="DropDownListStudentType" runat="server" SelectedValue='<%# Eval("TypeOfStudent") %>'>
                        <asp:ListItem Value="0">本科生</asp:ListItem>
                        <asp:ListItem Value="1">研究生</asp:ListItem>
                        <asp:ListItem Value="2">博士生</asp:ListItem>
                    </asp:DropDownList>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="毕业身份">
                <ItemTemplate>
                    <asp:DropDownList ID="DropDownListGraduationType" runat="server" SelectedValue='<%# Eval("GraduationType") %>'>
                        <asp:ListItem Value="0">本科生</asp:ListItem>
                        <asp:ListItem Value="1">研究生</asp:ListItem>
                        <asp:ListItem Value="2">博士生</asp:ListItem>
                    </asp:DropDownList>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="审核状态">
                <ItemTemplate>
                    <asp:DropDownList ID="DropDownListValidity" runat="server" SelectedValue='<%# Eval("Validity") %>'>
                        <asp:ListItem Value="0">未审核</asp:ListItem>
                        <asp:ListItem Value="1">未通过</asp:ListItem>
                        <asp:ListItem Value="2">通过</asp:ListItem>
                    </asp:DropDownList>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</p>
</asp:Content>
