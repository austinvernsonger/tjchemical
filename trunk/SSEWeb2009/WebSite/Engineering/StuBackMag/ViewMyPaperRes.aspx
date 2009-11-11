<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewMyPaperRes.aspx.cs" Inherits="Engineering_StuBackMag_ViewMyPaperRes" %>

<%@ Register src="../Control/sitmap.ascx" tagname="sitmap" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div style=" font-size:25px">     
        查看评审结果
    </div>
    <hr />
    <br />
    <div>
        <asp:Label ID="Label2" runat="server" Text="你当前没有论文反馈信息:-)" ForeColor="#999999" 
            Visible="False"></asp:Label>
        <asp:Panel ID="Panel1" runat="server">
        <div>
            论文评审结果：<asp:Label ID="lblResult" runat="server" ForeColor="Red"></asp:Label>
        </div>
        <br />
        <div>
            评审的建议和意见：
        </div>
        <div>
            <asp:TextBox ID="tbRemark" runat="server" Height="200px" ReadOnly="True" TextMode="MultiLine"
                Width="500px"></asp:TextBox>
        </div>
        </asp:Panel>
    </div>
    </form>
</body>
</html>
