<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TA_examine.aspx.cs" Inherits="Education_TA_TA_examine" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <p>
        <asp:GridView ID="GridViewApplys" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" ForeColor="#333333" GridLines="None" Height="258px" 
           Width="542px"
            OnItemCommand ="OnButtonPush" >
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#EFF3FB" />
            <Columns>
                <asp:BoundField DataField="apply_num" HeaderText="申请编号" />
                <asp:BoundField DataField="id" HeaderText="申请学生" />
                <asp:BoundField DataField="course_id" HeaderText="申请课程" />
                <asp:ButtonField CommandName="detailes" Text="详细情况" />
                <asp:ButtonField CommandName="agree" Text="同意" />
                <asp:ButtonField CommandName="reject" Text="拒绝" />
            </Columns>
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
        <br />
    </p>
    <div style="height: 377px">
    
    </div>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    </form>
</body>
</html>
