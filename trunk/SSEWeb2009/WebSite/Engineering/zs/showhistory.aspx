<%@ Page Language="C#" MasterPageFile="~/Engineering/zs/Enrollment.master" AutoEventWireup="true" CodeFile="showhistory.aspx.cs" Inherits="Engineering_zs_showhistory" Title="无标题页" %>

<%@ Register src="../../UserControl/ViewMMT.ascx" tagname="ViewMMT" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>成果展示<br />History</h1>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
     <img src="../Resources/images/banner_adm.jpg" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
    <h1>同济大学软件学院工程硕士历年所取得的成果</h1>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <uc1:ViewMMT ID="ViewMMT1" runat="server" MMTID="ENROLLMENT_HISTORY"  ShowClickCount="False" ShowLabel="False" ShowTitle="False"  />
</asp:Content>

