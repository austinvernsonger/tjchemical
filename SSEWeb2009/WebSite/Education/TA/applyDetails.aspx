<%@ Page Language="C#" AutoEventWireup="true" CodeFile="applyDetails.aspx.cs" Inherits="Education_TA_applyDetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:DetailsView ID="DetailsViewApply" runat="server" AutoGenerateRows="False" 
            CellPadding="4" ForeColor="#333333" GridLines="None" HeaderText="助教申请详细情况" 
            Height="445px" Width="550px">
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <CommandRowStyle BackColor="#D1DDF1" Font-Bold="True" />
            <RowStyle BackColor="#EFF3FB" />
            <FieldHeaderStyle BackColor="#DEE8F5" Font-Bold="True" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <Fields>
                <asp:BoundField DataField="apply_num" HeaderText="申请编号" />
                <asp:BoundField DataField="id" HeaderText="申请人学号" />
                <asp:BoundField DataField="coures_name" HeaderText="申请课程" />
                <asp:BoundField DataField="teacher" HeaderText="任课教师" />
                <asp:CheckBoxField DataField="isstudied" HeaderText="是否选修过该课程" />
                <asp:BoundField DataField="score" HeaderText="课程成绩" />
                <asp:BoundField DataField="email" HeaderText="Emial" />
                <asp:BoundField DataField="phonenumber" HeaderText="联系电话" />
                <asp:BoundField DataField="self_apprise" HeaderText="自我评价" />
                <asp:BoundField DataField="comment" HeaderText="备注" />
            </Fields>
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <AlternatingRowStyle BackColor="White" />
        </asp:DetailsView>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <asp:Button ID="ButtonAgree" runat="server" onclick="ButtonAgree_Click" 
            Text="同意" />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="ButtonReject" runat="server" onclick="ButtonReject_Click" 
            Text="拒绝" />
&nbsp;&nbsp;
        <asp:HyperLink ID="HyperLinkback" runat="server">返回</asp:HyperLink>
        <br />
&nbsp;&nbsp;&nbsp;
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
