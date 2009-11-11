<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CurrentStu.aspx.cs" Inherits="实验预约_CurrentStu" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<style type="text/css">
        .current td,.current th
        {
            padding:5px;
        }
    </style>
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <br />
    <asp:ScriptManager ID="sm1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="up1" runat="server">
    <ContentTemplate>
    <asp:GridView ID="grdcurrent"
     runat="server"
      CssClass="current"
      AllowPaging="true"
      PageSize="5"
      DataSourceID="srccurrent"></asp:GridView>
    </ContentTemplate>
    </asp:UpdatePanel>
    <asp:ObjectDataSource ID="srccurrent"
     runat="server" SelectMethod="GetCurrentStudent" TypeName="LabCenter.Reservation.CurrentStudentUIPaging">
     </asp:ObjectDataSource>
     <br /><hr />
     <asp:Button ID="btnbacktohomepage" Text="返回主页" runat="server" PostBackUrl="~/LabCenter/BackDefault.aspx" />
     <asp:Label ID="lblresult" runat="server"></asp:Label>
    </div>
    </form>
</body>
</html>
