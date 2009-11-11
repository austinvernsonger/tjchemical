<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ComputerDetail.aspx.cs" Inherits="RepairManagement_Unhandled_ComputerOrder" %>

<%@ Register Src="../UserControl/MailHtmlContent.ascx" TagName="MailHtmlContent"
    TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">

        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/LabCenter/Repair/Unhandled/ComputerList.aspx">返回</asp:HyperLink><br/>
        <div id="Message" visible="false" runat="server">
            <asp:Label ID="lblMsg" runat="server" ForeColor="Red" Font-Bold="True" 
                Height="31px"></asp:Label>
        </div>
        
        <div id="Content" runat="server">
        
        <asp:Label ID="lblCpNuminfo" runat="server" Text="机位编号:  "/>
        <asp:Label ID="lblCpNum" runat="server" Text="" Font-Bold="true"></asp:Label>
        
        <asp:GridView ID="GVUnhandledCpDetail" runat="server" CellPadding="4" 
            ForeColor="#333333" GridLines="None" 
                onrowdatabound="GVUnhandledCpDetail_RowDataBound"  >
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#EFF3FB" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <EmptyDataTemplate>
                <asp:Label runat="server" Font-Bold="True" Font-Size="12px" 
                    ForeColor="Red" Text="没有记录">
                </asp:Label>
            </EmptyDataTemplate>
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
       <br/>
            <uc1:MailHtmlContent ID="MailHtmlContent1" runat="server" OnGetEmailContent="GetEmailContent"/>
       <br/>
       <br/>
            <asp:Button ID="btnMakeSure" runat="server" Text="确定报修" OnClick="btnMakeSure_Click" />
            <asp:Button ID="btnCancel" runat="server" Text="取消报修" OnClick="btnCancel_Click" />
        </div>
     </form>
</body>
</html>