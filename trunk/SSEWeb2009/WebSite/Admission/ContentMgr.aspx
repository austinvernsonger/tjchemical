<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ContentMgr.aspx.cs" Inherits="ContentMgr" %>
<%@ Register Src="../UserControl/EditMMT.ascx" TagName="EditMMT" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        #top {
            width: 955px;
            margin: 0 auto;
            background-image: url("./img/logo.jpg");
            height: 150px;
        }
        #top_left {
            float: left;
        }
        #top_right {
            float: right;
            width: 150px;
            padding-top: 3px;
        }
        #top_right a {
            color: #ff00ff;
            margin-left: 40px;
        }
        #top_right a:hover {
            text-decoration: underline;
        }
        #body {
            width: 955px;
            margin-left: auto;
            margin-right: auto;
        }
        #view {
            width: 955px;
            margin: 0 auto;
        }
        #bottom {
            width: 955px;
            margin: 0 auto;
            background-image: url("./img/bottom.jpg");
            color: Lime;
        }
    </style>
</head>
<body>
    <form id="form2" runat="server">
    <div id="top">
        <div id="top_left">
        </div>
        <div id="top_right">
            <a href="#">主站</a> <a href="#">首页</a>
        </div>
    </div>
    <div id="view">
        <table id="table2">
            <tr>
                <td align="right">
                    请选择您面向的招生群体
                </td>
                <td>
                    <asp:DropDownList ID="DDGroup" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                        <asp:ListItem Value="HghStu_" Selected="True">高考生</asp:ListItem>
                        <asp:ListItem Value="EngMaster_">工程硕士</asp:ListItem>
                        <asp:ListItem Value="IndMaster_">工学硕士</asp:ListItem>
                        <asp:ListItem Value="ProDegree_">专业学位</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td align="right">
                    请选择发布的文件种类
                </td>
                <td>
                    <asp:DropDownList ID="DDKind" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
                        <asp:ListItem Value="Question">招生问答</asp:ListItem>
                        <asp:ListItem Value="Policy">招生政策</asp:ListItem>
                        <asp:ListItem Value="Booklet" Selected="True">招生简章</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
        <div>
            <uc1:EditMMT id="RcrEdit" runat="server" departmentid="8" mode="passage" onsuccessgoto="Default.aspx"
                newpost="False" />
        </div>
    </div>
    <div id="bottom" align="center">
        同济大学软件学院 2009 &copy
    </div>
    </form>
</body>
</html>
