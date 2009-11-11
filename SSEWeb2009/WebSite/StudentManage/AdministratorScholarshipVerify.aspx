<%@ Page Language="C#" MasterPageFile="~/StudentManage/MasterPage/Administrator_NoNested.master" AutoEventWireup="true" CodeFile="AdministratorScholarshipVerify.aspx.cs" Inherits="StudentManage_AdministratorScholarshipVerify" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="homeContent" Runat="Server">
    <asp:HiddenField ID="gradeHF" runat="server" />
    <asp:HiddenField ID="classHF" runat="server" />
    <p>
        年级班级：
        <asp:DropDownList ID="DDLGradeClass" runat="server"  OnSelectedIndexChanged="DDLGradeClass_SelectedIndexChanged">
             <asp:ListItem Value="-1">请选择</asp:ListItem>
             <asp:ListItem Value="2008,1">2008级1班</asp:ListItem>
             <asp:ListItem Value="2008,2">2008级2班</asp:ListItem>
             <asp:ListItem Value="2009,1">2009级1班</asp:ListItem>
             <asp:ListItem Value="2009,2">2009级2班</asp:ListItem>
             </asp:DropDownList>
    <asp:Button ID="BtnSel" runat="server" Text="确定" />
             
        <br />
        <asp:GridView ID="GVScholar" runat="server" 
          AllowPaging="true" AllowSorting="true" AutoGenerateColumns="false"
          OnPageIndexChanging="GVScholar_OnPageIndexChanging" 
          OnSorting="GVScholar_OnSorting" >
            <Columns>
                <asp:BoundField DataField="Name" HeaderText="姓名" SortExpression="Name" />
                <asp:BoundField DataField="StudentID" HeaderText="学号"  SortExpression="StudentID" />
                <asp:BoundField DataField="GPA" HeaderText="学习绩点" SortExpression="GPA" />
                <asp:BoundField DataField="SAP" HeaderText="社会活动绩点" SortExpression="SAP" />
                <asp:BoundField DataField="CPA" HeaderText="课外科技平均绩点" SortExpression="CPA" />
                <asp:BoundField DataField="TotalPoint" HeaderText="总绩点"  SortExpression="TotalPoint" />
            </Columns>
        </asp:GridView>
        <br />
        <asp:Button ID="btnTPCalcu" runat="server" Text="计算总绩点" 
            onclick="btnTPCalcu_Click" />
    </p>

</asp:Content>

