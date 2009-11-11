<%@ Page Language="C#" MasterPageFile="~/StudentManage/MasterPage/Administrator_NoNested.master" AutoEventWireup="true" CodeFile="AdiministratorContestVerifyStu.aspx.cs" Inherits="StudentManage_AdiministratorContestVerifyStu" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="homeContent" Runat="Server">

    <p>
        学生：<asp:Label ID="lblName" runat="server" Text="Label"></asp:Label>
&nbsp;&nbsp;&nbsp; 学号：<asp:Label ID="lblStudentID" runat="server" Text="Label"></asp:Label>
        <br />
        <asp:GridView ID="GVContest" runat="server">
        </asp:GridView>
        <br />
        <asp:Button ID="btnReturn" runat="server" Text="返回学生列表" 
            onclick="btnReturn_Click" />
    </p>

</asp:Content>

