<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StudentTrainingPlanMng.aspx.cs" Inherits="Teaching_Admin_StudentTrainingPlanMng" %>

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
        学生培养方案管理</p>
    <p>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <p>
                    学年：<asp:DropDownList ID="Term" runat="server" >
                    </asp:DropDownList>
                </p>
                <p>
                    类型：<asp:DropDownList ID="Type" runat="server">
                        <asp:ListItem>本科生</asp:ListItem>
                        <asp:ListItem>研究生</asp:ListItem>
                    </asp:DropDownList>
                </p>
                <div>
                    标题：<asp:TextBox ID="ArticleTitle" runat="server" Width="205px"></asp:TextBox>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </p>
    <div>
    
        <FCKeditorV2:FCKeditor ID="TrainingPlan" runat="server" Height="800px">
        </FCKeditorV2:FCKeditor>
        <br />
        <asp:Button ID="Submit" runat="server" Text="提交" onclick="Submit_Click" />
        <asp:Button ID="Cancel" runat="server" Text="取消" PostBackUrl="~/Teaching/Admin/AdminManagement.aspx?Type=5" />
    
    </div>
    </form>
</body>
</html>
