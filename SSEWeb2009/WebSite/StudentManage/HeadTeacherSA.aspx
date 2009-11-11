<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HeadTeacherSA.aspx.cs" Inherits="StudentManage_HeadTeacherSA"  MasterPageFile="~/StudentManage/MasterPage/HeadTeacher_NoNested.master"%>

<asp:Content ID="Content1" ContentPlaceHolderID="homeContent" runat="server">
 <link href="stylesheet.css" rel="stylesheet" type="text/css" />
    <p>
        选择年级和班级:
        <asp:DropDownList ID="DDL_Grade_Class" runat="server" 
            onselectedindexchanged="DDL_Grade_Class_SelectedIndexChanged" >
            <asp:ListItem  Value="-1">请选择</asp:ListItem>
        </asp:DropDownList>
        <asp:Button ID="Btn_Query" runat="server" Text="查询" onclick="Btn_Query_Click" />
        <br />
        查询结果：<br />
        <asp:GridView ID="GV_SA" runat="server" AutoGenerateColumns="false"  
            onrowcommand="GV_SA_RowCommand"  
            AllowPaging="true" PageSize="3"
            AllowSorting="true" onsorting="GV_SA_Sorting"  DataKeyNames="SAP"
            onpageindexchanging="GV_SA_PageIndexChanging">
            <Columns>
                <asp:BoundField HeaderText="姓名" DataField="Name" SortExpression="Name" />
                <asp:BoundField HeaderText="学号"  DataField="StudentID" SortExpression="StudentID"/>
                <asp:TemplateField HeaderText="评分状态" SortExpression="SAP">
                    <ItemTemplate>
                    <asp:Label ID="statusLbl" runat="server" Text='<%# GetStatus(Eval("SAP")) %>' /> 
                    </ItemTemplate>
                </asp:TemplateField>
              
                <asp:BoundField HeaderText="社会活动自评" DataField="SASE" 
                    FooterStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden"   />
                <asp:ButtonField HeaderText="操作" ShowHeader="True" Text="选择" CommandName="Select" />
            </Columns>
        </asp:GridView>
        <br />
        姓名&nbsp;&nbsp;&nbsp; 
        <asp:Label ID="Lbl_Name" runat="server" Text=""></asp:Label>
&nbsp;&nbsp;&nbsp; 学号&nbsp;&nbsp;&nbsp; 
        <asp:Label ID="Lbl_ID" runat="server" Text=""></asp:Label>
        <br />
        社会活动自评:
        <br />
        <asp:TextBox ID="Txt_SASE" runat="server" Height="150px" TextMode="MultiLine" 
            Width="350px" ReadOnly="true"></asp:TextBox>
        <br />
        评分<asp:DropDownList ID="DDLPoint" runat="server" 
            onselectedindexchanged="DDLPoint_SelectedIndexChanged">
            <asp:ListItem Value="-1">未评分</asp:ListItem>
            <asp:ListItem Value="1">1</asp:ListItem>
            <asp:ListItem Value="0.5">0.5</asp:ListItem>
            <asp:ListItem Value="0.33">0.33</asp:ListItem>
            <asp:ListItem Value="0">0</asp:ListItem>
        </asp:DropDownList>
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Btn_Save" runat="server" Text="保存" />
    </p>

</asp:Content>