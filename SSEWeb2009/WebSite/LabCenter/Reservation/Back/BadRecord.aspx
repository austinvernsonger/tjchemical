<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BadRecord.aspx.cs" Inherits="LabCenter_Reservation_Back_BadRecord" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="GV_BadRecords" AllowPaging="True" PageSize="10" 
            AllowSorting="true" runat="server" DataSourceID="obj_ds" Width="100%" 
            onrowdatabound="GV_BadRecords_RowDataBound" RowStyle-VerticalAlign="Top">
            <HeaderStyle HorizontalAlign="Left" Wrap="false" />
        </asp:GridView>
        <asp:ObjectDataSource ID="obj_ds" runat="server" SelectMethod="GetBadRecords" 
            TypeName="LabCenter.Reservation.BadRecordMgr"></asp:ObjectDataSource>
    </div>
    </form>
</body>
</html>
