<%@ Page Language="C#" AutoEventWireup="true" CodeFile="QueryCourseInfo.aspx.cs" Inherits="Teaching_Admin_QueryCourseInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <asp:gridview id="CourseGridView"
        emptydatatext="没有数据！" 
        allowpaging="True" 
        runat="server" AllowSorting="True" CellPadding="4" ForeColor="#333333" 
            GridLines="None"
            OnSorting="GridViewSortEventHandler" 
            onrowdatabound="CourseGridView_RowDataBound">
          <RowStyle BackColor="#EFF3FB" />
          <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
          <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
          <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
          <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
          <EditRowStyle BackColor="#2461BF" />
          <AlternatingRowStyle BackColor="White" />
      </asp:gridview>
    </div>
    </form>
</body>
</html>
