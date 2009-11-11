<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TA_apply.aspx.cs" Inherits="Education_TA_TA_apply" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <style type="text/css">
        #form1
        {
            height: 763px;
        }
        .style1
        {
            width: 331px;
        }
        .style2
        {
            width: 972px;
        }
        .style3
        {
            width: 972px;
            height: 27px;
        }
        .style4
        {
            width: 331px;
            height: 27px;
        }
        .style9
        {
            width: 972px;
            height: 50px;
        }
        .style10
        {
            width: 331px;
            height: 50px;
        }
        .style11
        {
            width: 972px;
            height: 186px;
        }
        .style12
        {
            width: 331px;
            height: 186px;
        }
        .style13
        {
            width: 972px;
            height: 130px;
        }
        .style14
        {
            width: 331px;
            height: 130px;
        }
        .style15
        {
            width: 972px;
            height: 34px;
        }
        .style16
        {
            width: 331px;
            height: 34px;
        }
        .style17
        {
            width: 972px;
            height: 33px;
        }
        .style18
        {
            width: 331px;
            height: 33px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height: 837px">
    
        <table style="width: 45%; height: 601px; margin-right: 80px;">
            <tr>
                <td class="style2">
                    学号：</td>
                <td class="style1">
                    <asp:Label ID="LabelID" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    姓名：</td>
                <td class="style1">
                    <asp:Label ID="LabelName" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    选择课程：</td>
                <td class="style1">
                    <asp:DropDownList ID="DropDownListCourse" runat="server" AutoPostBack="True">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    选择老师：</td>
                <td class="style4">
                    <asp:DropDownList ID="DropDownListTeacher" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    是否选修过该课程：</td>
                <td class="style1">
                    <asp:CheckBox ID="CheckBoxCourse" runat="server" Text="是" 
                        oncheckedchanged="CheckBoxCourse_CheckedChanged" />
                </td>
            </tr>
            <tr>
                <td class="style2">
                    该课程成绩：</td>
                <td class="style1">
                    <asp:TextBox ID="TextBoxScore" runat="server" Enabled="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style17">
                    EMail：</td>
                <td class="style18">
                    <asp:TextBox ID="TextBoxEmail" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style15">
                    联系电话：</td>
                <td class="style16">
                    <asp:TextBox ID="TextBoxPhone" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style13">
                    自我评价：</td>
                <td class="style14">
                    <asp:TextBox ID="TextBoxIntroduce" runat="server" Height="83px" MaxLength="100" 
                        TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style11">
                    备注：</td>
                <td class="style12">
                    <asp:TextBox ID="TextBoxComment" runat="server" Height="98px" MaxLength="200" 
                        TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style9">
                    <asp:Button ID="Buttonapply" runat="server" Text="确认申请" 
                        onclick="Buttonapply_Click" />
                </td>
                <td class="style10">
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
