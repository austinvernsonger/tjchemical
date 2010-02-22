<%@ Page Language="C#" MasterPageFile="~/MasterPage/BackSys.master" AutoEventWireup="true" CodeFile="StraitStudentInfoLogin.aspx.cs" Inherits="StraitStudentInfo_StraitStudentInfoLogin" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table>
    <tr>
        <td>
            学号：
        </td>
        <td>
            <asp:Label ID = "lbStudentID" runat="server"></asp:Label>
        </td>
        <td>
            姓名：
        </td>
        <td>
            <asp:Label ID = "lbName" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            入学前户口：
        </td>
        <td>
            <asp:DropDownList ID="DropDownListRegisteredResidenceBeforeSchool" runat="server">
                <asp:ListItem Value="0">农村</asp:ListItem>
                <asp:ListItem Value="1">城镇</asp:ListItem>
            </asp:DropDownList>
        </td>
        <td>
            家庭人数：
        </td>
        <td>
            <asp:TextBox ID="txtFamilyMemberNum" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
             家庭人均月收入：
        </td>
        <td>
            <asp:TextBox ID="txtFamilySalary" runat="server"></asp:TextBox>
        </td>
        <td>
            是否是城市低保：
        </td>
        <td>
            <asp:DropDownList ID="DropDownListDiBao" runat="server">
                <asp:ListItem Value="0">否</asp:ListItem>
                <asp:ListItem Value="1">是</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td>
            孤残：
        </td>
        <td>
            <asp:DropDownList ID="DropDownListGuCan" runat="server">
                <asp:ListItem Value="0">否</asp:ListItem>
                <asp:ListItem Value="1">是</asp:ListItem>
            </asp:DropDownList>
        </td>
        <td>
            单亲：
        </td>
        <td>
            <asp:DropDownList ID="DropDownListSingleParent" runat="server">
                <asp:ListItem Value="0">否</asp:ListItem>
                <asp:ListItem Value="1">是</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td>
             烈士子女：
        </td>
        <td>
            <asp:DropDownList ID="DropDownListMartyrChild" runat="server">
                <asp:ListItem Value="0">否</asp:ListItem>
                <asp:ListItem Value="1">是</asp:ListItem>
            </asp:DropDownList>
        </td>
        <td>
            递交困难生登记表：
        </td>
        <td>
            <asp:DropDownList ID="DropDownListApply" runat="server">
                <asp:ListItem Value="0">否</asp:ListItem>
                <asp:ListItem Value="1">是</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
         <td>
            需要说明的事项<br />
           （家庭遭受自然灾害、<br />
             突发意外事件、重病、<br />
             大病或其他特殊情况）：
         </td>
         <td colspan="3">
        <asp:TextBox ID="txtExplainThings" runat="server" TextMode="MultiLine" 
         MaxLength="500" Height="100px" Width="500px"></asp:TextBox>
         </td>
    </tr>
    <tr>
        <td>
            学院认定困难生情况：
        </td>
        <td>
            <asp:DropDownList ID="DropDownListStraitDegree" runat="server">
                <asp:ListItem Value="0">特困</asp:ListItem>
                <asp:ListItem Value="1">普困</asp:ListItem>
                <asp:ListItem Value="2">一般</asp:ListItem>
                <asp:ListItem Value="3">良好</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
</table>
<p>
    <asp:Button ID="btCommit" runat="server" Text="保存" onclick="btCommit_Click" />
</p>
</asp:Content>

