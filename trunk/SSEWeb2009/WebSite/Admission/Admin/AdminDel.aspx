<%@ Page Title="" Language="C#" MasterPageFile="~/Admission/Admin/MasterPage.master"
    AutoEventWireup="true" CodeFile="AdminDel.aspx.cs" Inherits="RecruitmentNew_Admin_AdminDel" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="position: relative; float: none">
    <asp:Panel ID="Panel1" runat="server" DefaultButton="BtCommit" Font-Italic="True"
        Font-Bold="True">
        <asp:Label ID="Label1" runat="server" Text="请输入你要删除的管理员ID（工号或学号）"></asp:Label>
        <br />
        <asp:TextBox ID="TbAmdinId" runat="server" Width="228px"></asp:TextBox>
        <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" ServiceMethod="GetCompletionList"
            UseContextKey="True" TargetControlID="TbAdminId">
        </cc1:AutoCompleteExtender>
        <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" TargetControlID="TbAmdinId"
            WatermarkText="管理员ID" WatermarkCssClass="watermarked">
        </cc1:TextBoxWatermarkExtender>

        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
            ControlToValidate="TbAmdinId" Display="Static">请输入ID</asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
         Display="Static" ControlToValidate="TbAmdinId">格式错误</asp:RegularExpressionValidator>
        <br />
        <br />
        <asp:Button ID="BtCommit" runat="server" Text="提交" />
        <br />
    </asp:Panel>
    </div>
</asp:Content>
