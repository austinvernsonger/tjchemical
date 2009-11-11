<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MessageCenter.aspx.cs" Inherits="Engineering_AdminBakMag_MessageCenter" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="font-size: 25px">
        消息中心
    </div>
    <hr />
    <br />
    <div>
        <table width="600">
            <tr>
                <td width="300" height="31" align="left" valign="middle">
                    <asp:Label ID="Label1" runat="server" Text="学籍变动申请："></asp:Label>
                    <asp:LinkButton ID="lnbApply" runat="server" ForeColor="#999999" PostBackUrl="~/Engineering/AdminBakMag/ApplyInfoManagement.aspx"></asp:LinkButton>
                </td>
                <td width="300" align="left" valign="middle">
                    <asp:Label ID="Label2" runat="server" Text="课程选择信息："></asp:Label>
                    <asp:LinkButton ID="lnbCourse" runat="server" ForeColor="#999999" PostBackUrl="~/Engineering/AdminBakMag/CourseViewManagement.aspx"></asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td width="300" height="31" align="left" valign="middle">
                    <asp:Label ID="Label3" runat="server" Text="导师分配信息："></asp:Label>
                    <asp:LinkButton ID="lnbTutor" runat="server" ForeColor="#999999" PostBackUrl="~/Engineering/AdminBakMag/TutorResultManagement.aspx"></asp:LinkButton>
                </td>
                <td width="300" align="left" valign="middle">
                    <asp:Label ID="Label4" runat="server" Text="论文分配信息："></asp:Label>
                    <asp:LinkButton ID="lnbThesis" runat="server" ForeColor="#999999" PostBackUrl="~/Engineering/AdminBakMag/AssignPaperForStus.aspx"></asp:LinkButton>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
