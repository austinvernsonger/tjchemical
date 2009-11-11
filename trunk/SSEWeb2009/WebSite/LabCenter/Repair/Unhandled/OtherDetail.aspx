<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OtherDetail.aspx.cs" Inherits="RepairManagement_Unhandled_OtherOrder" %>

<%@ Register Src="../UserControl/MailHtmlContent.ascx" TagName="MailHtmlContent"
    TagPrefix="uc1" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/LabCenter/Repair/Unhandled/OtherList.aspx">返回</asp:HyperLink><br />
    <br />
    
    <div  id="Message" visible="false" runat="server">
        <asp:Label ID="lblMsg" runat="server" Text="" ForeColor="Red" Font-Bold="true"></asp:Label>
    </div>
        
    <div id="Content" runat="server">

        <asp:Table ID="tbldetail" runat="server">
            <asp:TableRow ID="TableRow1" runat="server">
                <asp:TableCell ID="TableCell1" runat="server">
                    <asp:Label ID="lblRecordIDinfo" runat="server" Text="报修编号："></asp:Label>
                </asp:TableCell>
                <asp:TableCell ID="TableCell2" runat="server">
                    <asp:Label ID="lblRecordID" runat="server" Text="Label" Visible="false"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">
                    <asp:Label ID="lblDevNameinfo" runat="server" Text="设备名称："></asp:Label>
                </asp:TableCell>
                <asp:TableCell runat="server">
                    <asp:Label ID="lblDevName" runat="server" Text="Label"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">
                    <asp:Label ID="lblLocationinfo" runat="server" Text="位置："></asp:Label>
                </asp:TableCell>
                <asp:TableCell runat="server">
                    <asp:Label ID="lblLocation" runat="server" Text="Label"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">
                    <asp:Label ID="lblDescriptioninfo" runat="server" Text="情况描述："></asp:Label>
                </asp:TableCell>
                <asp:TableCell runat="server">
                    <asp:Label ID="lblDescription" runat="server" Text="Label"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">
                    <asp:Label ID="lblUpdateTimeinfo" runat="server" Text="报修时间："></asp:Label>
                </asp:TableCell>
                <asp:TableCell runat="server">
                    <asp:Label ID="lblUpdateTime" runat="server" Text="Label"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">
                    <asp:Label ID="lblReporterinfo" runat="server" Text="报修者："></asp:Label>
                </asp:TableCell>
                <asp:TableCell runat="server">
                    <asp:Label ID="lblReporter" runat="server" Text="Label"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <br/>
        <uc1:MailHtmlContent ID="MailHtmlContent1" runat="server" OnGetEmailContent="GetEmailContent"/>
        <br/>    
            <asp:Button ID="btnMakeSure" runat="server" Text="确定报修" OnClick="btnMakeSure_Click" />
            <asp:Button ID="btnCancel" runat="server" Text="取消报修" OnClick="btnCancel_Click" />
    </div>            
    </form>
</body>
</html>
