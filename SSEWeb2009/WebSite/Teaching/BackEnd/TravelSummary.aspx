<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TravelSummary.aspx.cs" Inherits="Teaching_BackEnd_TravelSummary" %>

<%@ Register assembly="FredCK.FCKeditorV2" namespace="FredCK.FCKeditorV2" tagprefix="FCKeditorV2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        出差总结<br />
        <FCKeditorV2:FCKeditor ID="Summary" runat="server" Height="600px">
        </FCKeditorV2:FCKeditor>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                出差资料提交(可选)<br />
                <asp:Label ID="Label" runat="server" 
    Text="\\10.60.40.2\Public_files\教师培训\培训资料\"></asp:Label>

                <asp:TextBox ID="ResourcePath" runat="server"></asp:TextBox>
                &nbsp;
                <asp:Label ID="Indicator" runat="server"></asp:Label>
            </ContentTemplate>
        </asp:UpdatePanel>
        <br />
        <br />
        <br />
        <asp:Button ID="Submit" runat="server" onclick="Submit_Click" Text="提交" />
        <asp:Button ID="Cancel" runat="server" Text="取消" 
            PostBackUrl="~/Teaching/BackEnd/TravelApplicationList.aspx" />
        <br />
    
    </div>
    </form>
</body>
</html>
