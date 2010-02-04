<%@ Page Language="C#" MasterPageFile="~/MasterPage/BackSys.master" AutoEventWireup="true" CodeFile="StudentFileBasicInfo.aspx.cs" Inherits="StudentFile_StudentFileBasicInfo" Title="Untitled Page" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table>
    <tr>
        <td>
            学号：
        </td>
        <td>
            <asp:Label ID="lbStudentID" runat="server"></asp:Label>
        </td>
        <td>
            姓名：
        </td>
        <td>
            <asp:Label ID="lbName" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            籍贯:
        </td>
        <td>
            <asp:Label ID="lbNativeProvince" runat="server"></asp:Label>
        </td>
        <td>
            生源地：
        </td>
        <td>
            <asp:Label ID="lbStudentSource" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            政治面貌：
        </td>
        <td>
            <asp:DropDownList ID="DropDownListPoliticalStatus" runat="server">
                <asp:ListItem Value="0">群众</asp:ListItem>
                <asp:ListItem Value="1">团员</asp:ListItem>
                <asp:ListItem Value="2">预备党员</asp:ListItem>
                <asp:ListItem Value="3">党员</asp:ListItem>
                <asp:ListItem Value="4">民主党派</asp:ListItem>
            </asp:DropDownList>
        </td>
        <td>
            团员材料有无：
        </td>
        <td>
            <asp:DropDownList ID="MemberInfo" runat="server">
                <asp:ListItem Value="0">无</asp:ListItem>
                <asp:ListItem Value="1">有</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td>
            党员资料有无：
        </td>
        <td>
            <asp:DropDownList ID="PartyMemberInfo" runat="server">
                <asp:ListItem Value="0">无</asp:ListItem>
                <asp:ListItem Value="1">有</asp:ListItem>
            </asp:DropDownList>
        </td>
        <td>
            建档时间：
        </td>
        <td>
            <asp:TextBox ID="txtFileCreateTime" runat="server"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender1" runat="server"
                    TargetControlID="txtFileCreateTime" Format="yyyy/MM/dd">
                </cc1:CalendarExtender>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
        </td>
    </tr>
    <tr>
        <td>
            档案来源：
        </td>
        <td>
            <asp:TextBox ID="txtFileSource" runat="server"></asp:TextBox>
        </td>
        <td>
            档案来源方式：
        </td>
        <td>
            <asp:TextBox ID="txtFileSourceType" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            毕业时间：
        </td>
        <td>
            <asp:TextBox ID="txtGradutaionTime" runat="server"></asp:TextBox>
        </td>
        <td>
            档案寄出时间:
        </td>
        <td>
            <asp:TextBox ID="txtFileSendTime" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            档案寄至单位名称：
        </td>
        <td>
            <asp:TextBox ID="txtFileSendCompany" runat="server"></asp:TextBox>
        </td>
        <td>
            档案寄至单位地址：
        </td>
        <td>
            <asp:TextBox ID="txtFileSendCompanyAddress" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            档案寄至单位邮编：
        </td>
        <td>
            <asp:TextBox ID="txtFileSendCompanyPost" runat="server"></asp:TextBox>
        </td>
        <td>
            档案寄至单位联系人：
        </td>
        <td>
            <asp:TextBox ID="txtFileSendCompanyContact" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            档案寄至单位电话：
        </td>
        <td>
            <asp:TextBox ID="txtFileSendCompanyPhone" runat="server"></asp:TextBox>
        </td>
        <td>
            档案寄至单位方式：
        </td>
        <td>
            <asp:TextBox ID="txtFileSendCompanyType" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            是否办理保留档案：
        </td>
        <td>
            <asp:DropDownList ID="DropDownListStoreFile" runat="server">
                <asp:ListItem Value="0">否</asp:ListItem>
                <asp:ListItem Value="1">是</asp:ListItem>
            </asp:DropDownList>
        </td>
        <td>
            办理保留档案的起始日期：
        </td>
        <td>
            <asp:TextBox ID="txtStoreFileStartTime" runat="server"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender2" runat="server"
                    TargetControlID="txtStoreFileStartTime" Format="yyyy/MM/dd">
                </cc1:CalendarExtender>
        </td>
    </tr>
</table>

</asp:Content>

