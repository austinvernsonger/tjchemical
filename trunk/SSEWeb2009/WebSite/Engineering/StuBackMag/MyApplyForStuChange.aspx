<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MyApplyForStuChange.aspx.cs" Inherits="Engineering_StuBackMag_MyApplyForStuChange" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register src="../Control/sitmap.ascx" tagname="sitmap" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>申请学籍变动--工程硕士中心</title>
</head>
<body>
    <form id="form1" runat="server">
    <div style=" font-size:25px">     
        申请学籍变动
    </div>
    <hr />
    <br />
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager> 
        <asp:Panel ID="Panel0" runat="server" Visible="False">
            申请学籍变动说明：<br /><br />
            1. 首先需填写必要的申请类别和申请理由。<br />
            2. 提交申请后等待管理员处理该申请。<br />
            3. 如果教务员批准了你的申请，请下载相应的表格填写完整并提交研究生院。<br />
            4. 当你返校后，请及时到教务员处注册。<br /><br />
            <asp:Button ID="btMyApply" runat="server" Text="我要申请学籍变动" BackColor="#3333FF" 
                ForeColor="White" Height="31px" onclick="btMyApply_Click" />
        </asp:Panel>
        <asp:Panel ID="Panel1" runat="server" Width="600px" Visible="False">
            <table width="524">
                <tr>
                    <td align="left" height="31" valign="middle" width="112">
                        申请类别：
                    </td>
                    <td align="left" valign="middle" width="150">
                        <asp:DropDownList ID="dplApplyCategory" runat="server" Width="120px">
                            <asp:ListItem>------请选择------</asp:ListItem>
                            <asp:ListItem>休学</asp:ListItem>
                            <asp:ListItem>退学</asp:ListItem>
                            <asp:ListItem>其他</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td align="left" valign="middle" width="112">
                        &nbsp;</td>
                    <td align="left" valign="middle" width="150">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="left" colspan="4" height="31" valign="middle">
                        申请理由(请简短描述你的申请理由)
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="4" height="210" valign="middle">
                        <asp:TextBox ID="tbApplyReason" runat="server" Height="210px" TextMode="MultiLine"
                            Width="99%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" height="31" valign="middle" align="left">
                        <asp:Button ID="btnCommit" runat="server" Height="31px" Text="提交" Width="90px" 
                            OnClick="btnCommit_Click" BackColor="#3333FF" ForeColor="White" />
                    </td>
                </tr>
            </table>
            <br />
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Visible="False"></asp:Label>
        </asp:Panel>
    </div>
    <div>
        <asp:Panel ID="Panel2" runat="server" Width="600px" Visible="False">
            <div>
                申请正在处理，请耐心等候......
            </div>
            <br />
              如有疑问请与工程硕士中心联系。
        <asp:LinkButton ID="LinkButton2" runat="server">给教务员发信</asp:LinkButton>
        </asp:Panel>
    </div>
    <div>
        <asp:Panel ID="Panel3" runat="server" Width="600px" Visible="False">
            <div>
                <table width="524">
                    <tr>
                        <td align="left" height="31" valign="middle" width="112">
                            申请结果：
                        </td>
                        <td align="left" valign="middle" width="412">
                            <asp:Label ID="lbAppRes" runat="server" ForeColor="#FF3300" Font-Bold="True">批准</asp:Label>
                            (部分功能将不可用)</td>
                    </tr>
                    <tr>
                        <td align="left" colspan="2" height="31" valign="middle">
                            请<asp:LinkButton ID="LinkButton1" runat="server">点击这里</asp:LinkButton>
                            下载表格，填写完整并交研究生院
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="2" height="31" valign="middle">
                            意见和建议
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2" height="210" valign="middle">
                            <asp:TextBox ID="tbApplyRemark" runat="server" Height="210px" ReadOnly="True" TextMode="MultiLine"
                                Width="99%"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <br />
                //备注：返校后，请及时到教务员处注册
            </div>
        </asp:Panel>
    </div>
    <div>
        <asp:Panel ID="Panel4" runat="server" Width="600px" Visible="False">
             <table width="524">
                <tr>
                    <td align="left" height="31" valign="middle" width="112">
                        申请类别：
                    </td>
                    <td align="left" valign="middle" width="412">
                        <asp:Label ID="lblCategory" runat="server" ></asp:Label>
                    </td>    
                </tr>
                <tr>
                    <td align="left" height="31" valign="middle" width="112">
                        申请时间：
                    </td>
                    <td align="left" valign="middle" width="412">
                        <asp:Label ID="lblApplyTime" runat="server"  ></asp:Label>
                    </td>    
                </tr>
                <tr>
                    <td align="left" height="31" valign="middle" width="112">
                        申请结果：
                    </td>
                    <td align="left" valign="middle" width="412">
                        <asp:Label ID="lblFailRes" runat="server" ForeColor="Red" Font-Bold="True">不批准</asp:Label>
                    </td>    
                </tr>
                <tr>
                    <td align="left" colspan="2" height="31" valign="middle">
                        原因：
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="2" height="210" valign="middle">  
                        <asp:TextBox ID="tbFailReason" runat="server" Width="510px"  Height="200px"
                            TextMode="MultiLine" ReadOnly="True"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <br />
            <div>
                <asp:Button ID="btApplyAgain" runat="server" Text="重新申请" Height="31px" 
                    Width="90px" onclick="btApplyAgain_Click" BackColor="#3333FF" 
                    ForeColor="White" />
            </div>
        </asp:Panel>
    </div>
    </form>
</body>
</html>
