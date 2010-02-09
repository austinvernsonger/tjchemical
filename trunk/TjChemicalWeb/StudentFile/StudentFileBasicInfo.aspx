<%@ Page Language="C#" MasterPageFile="~/MasterPage/BackSys.master" AutoEventWireup="true" CodeFile="StudentFileBasicInfo.aspx.cs" Inherits="StudentFile_StudentFileBasicInfo" Title="Untitled Page" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<p>
    <asp:Label ID="lbErrorMessage" runat="server" Visible="false"></asp:Label>
</p>
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
            <asp:DropDownList ID="DropDownListMemberInfo" runat="server">
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
            <asp:DropDownList ID="DropDownListPartyMemberInfo" runat="server">
                <asp:ListItem Value="0">无</asp:ListItem>
                <asp:ListItem Value="1">有</asp:ListItem>
            </asp:DropDownList>
        </td>
        <td>
            建档时间：
        </td>
        <td>
            <asp:TextBox ID="txtFileCreateTime" runat="server" ReadOnly ="true"></asp:TextBox>
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
            <asp:TextBox ID="txtGradutaionTime" runat="server" ReadOnly="true"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender3" runat="server"
                    TargetControlID="txtGradutaionTime" Format="yyyy/MM/dd">
                </cc1:CalendarExtender>
        </td>
        <td>
            档案寄出时间:
        </td>
        <td>
            <asp:TextBox ID="txtFileSendTime" runat="server" ReadOnly="true"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender4" runat="server"
                    TargetControlID="txtFileSendTime" Format="yyyy/MM/dd">
                </cc1:CalendarExtender>
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
            <asp:TextBox ID="txtStoreFileStartTime" runat="server" ReadOnly="true"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender2" runat="server"
                    TargetControlID="txtStoreFileStartTime" Format="yyyy/MM/dd">
                </cc1:CalendarExtender>
        </td>
    </tr>
</table>
<p>
    <asp:Button ID="bt_SaveArchives" runat="server" Text="保存基本资料" 
        onclick="bt_SaveArchives_Click" />
</p>
<p>
    <asp:GridView ID="GridViewFile" runat="server" AutoGenerateColumns="false" 
    AutoGenerateDeleteButton="true" DataKeyNames="ContentTitle" 
        onrowdeleting="OnRowDeleting">
    <Columns>
        <asp:TemplateField HeaderText = "标题">
            <ItemTemplate>
                <asp:Label ID="lbContentTitle" runat="server" Text='<%# Eval("ContentTitle")%>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText = "内容">
            <ItemTemplate>
                <asp:TextBox ID="txtContent" runat="server" Text='<%# Eval("Content")%>' ReadOnly="true" 
                TextMode="MultiLine"></asp:TextBox>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText = "备注">
            <ItemTemplate>
                <asp:TextBox ID="txtRemark" runat="server" Text='<%# Eval("Remark")%>' ReadOnly="true" 
                TextMode="MultiLine"></asp:TextBox>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
    </asp:GridView>
</p>
<p>
    标题：
    <asp:TextBox ID="txtContentTitle" runat="server"></asp:TextBox>
</p>
<p>
    内容：
</p>
<p>
    <asp:TextBox ID="txtFileContent" runat="server" TextMode="MultiLine" MaxLength="500"></asp:TextBox>
</p>
<p>
    备注：
</p>
<p>
    <asp:TextBox ID="txtFileRemark" runat="server" TextMode="MultiLine" MaxLength="200"></asp:TextBox>
</p>
<p>
    <asp:Button ID="btFileSave" runat="server" Text="保存" 
        onclick="btFileSave_Click" />
</p>
<p>
    档案添加记录：
</p>
<p>
    <asp:GridView ID="GridViewArchivesNew" runat="server" 
        AutoGenerateColumns="false" AutoGenerateDeleteButton="true"
     DataKeyNames="ID" onrowdeleting="ArchivesNewOnRowDeleting">
     <Columns>
        <asp:TemplateField HeaderText = "序号" Visible="false">
            <ItemTemplate>
                <asp:Label ID="lbId" runat="server" Text='<%# Eval("ID")%>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText = "添加时间">
            <ItemTemplate>
                <asp:Label ID="lbAddTime" runat="server" Text='<%# Eval("AddTime")%>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText = "添加内容">
            <ItemTemplate>
                <asp:TextBox ID="txtNewContent" runat="server" Text='<%# Eval("Content")%>' ReadOnly="true" TextMode="MultiLine"></asp:TextBox>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="添加人">
            <ItemTemplate>
                <asp:Label ID="lbAddPeople" runat="server" Text='<%# Eval("AddPeople")%>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="备注">
            <ItemTemplate>
                <asp:TextBox ID="txtNewRemark" runat="server" Text='<%# Eval("Remark")%>' ReadOnly="true" TextMode="MultiLine"></asp:TextBox>
            </ItemTemplate>
        </asp:TemplateField>
     </Columns>
     </asp:GridView>
</p>
<p>
    添加时间：
    <asp:TextBox ID="txtAddTime" runat="server" ReadOnly="true"></asp:TextBox>
        <cc1:CalendarExtender ID="CalendarExtender5" runat="server"
                    TargetControlID="txtAddTime" Format="yyyy/MM/dd">
                </cc1:CalendarExtender>
</p>
<p>
    添加内容：
</p>
<p>
    <asp:TextBox ID="txtArchivesNewContent" runat="server" TextMode="MultiLine" MaxLength="500"></asp:TextBox>
</p>
<p>
    添加人：
</p>
<p>
    <asp:TextBox ID="txtAddPeople" runat="server"></asp:TextBox>
</p>
<p>
    备注：
</p>
<p>
    <asp:TextBox ID="txtArchivesNewRemark" runat="server" TextMode="MultiLine" MaxLength="200"></asp:TextBox>
</p>
<p>
    <asp:Button ID="bt_AddArchivesNew" runat="server" Text="添加" 
        onclick="bt_AddArchivesNew_Click" />
</p>
<p>
    <asp:Button ID="bt_Back" runat="server" Text="返回" onclick="bt_Back_Click" />
</p>
</asp:Content>

