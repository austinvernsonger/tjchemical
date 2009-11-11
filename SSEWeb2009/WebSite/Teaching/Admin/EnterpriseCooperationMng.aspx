<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EnterpriseCooperationMng.aspx.cs" Inherits="Teaching_Admin_EnterpriseCooperationMng" %>

<%@ Register assembly="FredCK.FCKeditorV2" namespace="FredCK.FCKeditorV2" tagprefix="FCKeditorV2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <p>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        企业合作</p>
    <p>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <p>
                    类型：<asp:DropDownList ID="Type" runat="server">
                        <asp:ListItem>合作单位及合作过程</asp:ListItem>
                        <asp:ListItem>合作俱乐部情况</asp:ListItem>
                        <asp:ListItem>联合实验室情况</asp:ListItem>
                        <asp:ListItem>合作活动/讲座/课程</asp:ListItem>
                    </asp:DropDownList>
                </p>
                <div>
                    合作企业：<asp:TextBox ID="ArticleTitle" runat="server"></asp:TextBox>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </p>
    <div>
    
        <FCKeditorV2:FCKeditor ID="EnterpriseCoorperation" runat="server" 
            Height="800px">
        </FCKeditorV2:FCKeditor>
        <br />
        <asp:Button ID="Submit" runat="server" Text="提交" onclick="Submit_Click" />
        <asp:Button ID="Cancel" runat="server" Text="取消" 
            PostBackUrl="~/Teaching/Admin/AdminManagement.aspx?Type=6" />
    
    </div>
    </form>
</body>
</html>
