<%@ Page Language="C#" MasterPageFile="~/StudentManage/MasterPage/Administrator_NoNested.master" AutoEventWireup="true" CodeFile="AdministratorContestVerify.aspx.cs" Inherits="StudentManage_AdministratorContestVerif" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="homeContent" Runat="Server">
    <asp:DropDownList ID="DDLGradeClass" runat="server" 
        onselectedindexchanged="DDLGradeClass_SelectedIndexChanged">
        <asp:ListItem Value="-1">请选择</asp:ListItem>
        <asp:ListItem Value="2008,1">2008级1班</asp:ListItem>
        <asp:ListItem Value="2008,2">2008级2班</asp:ListItem>
        <asp:ListItem Value="2009,1">2009级1班</asp:ListItem>
        <asp:ListItem Value="2009,2">2009级2班</asp:ListItem>
    </asp:DropDownList>
    <asp:Button ID="BtnSel" runat="server"  Text="确定" />
    <br />
    <asp:GridView ID="GVContestVerify" runat="server" AutoGenerateColumns="False" 
        AllowPaging="True" AllowSorting="True"  PageSize="10"
        onrowcommand="GVContestVerify_RowCommand" 
        onpageindexchanging="GVContestVerify_PageIndexChanging" 
        onsorting="GVContestVerify_Sorting"> 
        <Columns>
            <asp:BoundField DataField="StudentID" HeaderText="学号" SortExpression="StudentID" />
            <asp:BoundField DataField="Name" HeaderText="姓名" SortExpression="Name" />
            <asp:TemplateField HeaderText="审核状态"  >
            <ItemTemplate>
                <asp:Label ID="Label1" runat="server" Text='<%# GetStatus(Eval("CTW")) %>'></asp:Label>
            </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="CTW" HeaderText="总学分" SortExpression="CTW" />
            <asp:BoundField DataField="CTP" HeaderText="总绩点"  SortExpression="CTP"/>
            <asp:ButtonField ButtonType="Button" CommandName="Verify" HeaderText="操作" 
                ShowHeader="True" Text="审核" />
            <asp:BoundField DataField="CPA" HeaderText="平均绩点" SortExpression="CPA" />
        </Columns>
    </asp:GridView>
    <br />
    <asp:Button ID="btnMaxTotalPoint" runat="server" Text="计算总学分最大值" 
        onclick="btnMaxTotalPoint_Click" />
    <asp:Label ID="lblMaxTotalPoint" runat="server" BorderStyle="Inset" Width="50"></asp:Label>
    <br />
    <asp:Button ID="BtnPointAve" runat="server" Text="计算平均绩点" 
        onclick="BtnPointAve_Click" />
    <br />
    <br />
    <br />
    
    学生：<asp:Label ID="lblName" runat="server" Text="Label"></asp:Label>
&nbsp;&nbsp;&nbsp; 学号：<asp:Label ID="lblStudentID" runat="server" Text="Label"></asp:Label>
    <asp:HiddenField ID="DDLVerifyHF" runat="server" />
    <asp:HiddenField ID="gradeHF" runat="server" />
    <asp:HiddenField ID="classHF" runat="server" />
     <asp:HiddenField ID="maxWeightHF" runat="server" />
    <br />
    <asp:GridView ID="GVStudentContest" runat="server" AutoGenerateColumns="False" 
        onrowdatabound="GVStudentContest_RowDataBound" DataKeyNames="ID"  
        AllowPaging="true" AllowSorting="true" PageSize="5"
        onrowcommand="GVStudentContest_RowCommand" 
        onsorting="GVStudentContest_Sorting" >
        <Columns>
            <asp:BoundField DataField="ID" 
                HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden" 
                FooterStyle-CssClass="hidden" >
            </asp:BoundField>
        
            <asp:BoundField DataField="Name" HeaderText="名称"  SortExpression="Name"/>
            <asp:TemplateField HeaderText="类别" SortExpression="Weight">
             <ItemTemplate>
                 <asp:Label ID="lblWeightName" runat="server" Text='<%# GetWeightName(Eval("Weight")) %>'></asp:Label>
             </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Weight" HeaderText="学分" SortExpression="Weight" />
            <asp:TemplateField HeaderText="等级" SortExpression="Rank">
            <ItemTemplate>
                <asp:Label ID="lblPointName" runat="server" Text='<%# GetPointName(Eval("Rank")) %>'></asp:Label>
            </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Point" HeaderText="绩点" SortExpression="Point" />
            <asp:TemplateField HeaderText="操作">
            <ItemTemplate>
                <asp:DropDownList ID="DDLVerify" runat="server" OnSelectedIndexChanged="DDLVerify_OnSelectedIndexChanged" >
                    <asp:ListItem Text="未审核" Value="NULL"></asp:ListItem>
                    <asp:ListItem Text="通过" Value="True"></asp:ListItem>
                    <asp:ListItem Text="未通过" Value="False" ></asp:ListItem>
                </asp:DropDownList>
            </ItemTemplate>
            </asp:TemplateField>
            <asp:ButtonField ButtonType="Button" CommandName="Verify" Text="更新" />
        </Columns>
    </asp:GridView>
    
    <br />
    <asp:Button ID="btnSave" runat="server" Text="保存" onclick="btnSave_Click1" />
    
</asp:Content>

