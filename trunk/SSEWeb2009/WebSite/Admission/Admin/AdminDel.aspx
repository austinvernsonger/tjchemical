<%@ Page Title="" Language="C#" MasterPageFile="~/Admission/Admin/MasterPage.master"
    AutoEventWireup="true" CodeFile="AdminDel.aspx.cs" Inherits="RecruitmentNew_Admin_AdminDel" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="position: relative; float: none">
    <asp:Panel ID="Panel1" runat="server" DefaultButton="BtCommit" Font-Italic="True"
        Font-Bold="True">
        <asp:Label ID="Label1" runat="server" Text="��������Ҫɾ���Ĺ���ԱID�����Ż�ѧ�ţ�"></asp:Label>
        <br />
        <asp:TextBox ID="TbAmdinId" runat="server" Width="228px"></asp:TextBox>
        <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" ServiceMethod="GetCompletionList"
            UseContextKey="True" TargetControlID="TbAdminId">
        </cc1:AutoCompleteExtender>
        <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" TargetControlID="TbAmdinId"
            WatermarkText="����ԱID" WatermarkCssClass="watermarked">
        </cc1:TextBoxWatermarkExtender>

        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
            ControlToValidate="TbAmdinId" Display="Static">������ID</asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
         Display="Static" ControlToValidate="TbAmdinId">��ʽ����</asp:RegularExpressionValidator>
        <br />
        <br />
        <asp:Button ID="BtCommit" runat="server" Text="�ύ" />
        <br />
    </asp:Panel>
    </div>
</asp:Content>
