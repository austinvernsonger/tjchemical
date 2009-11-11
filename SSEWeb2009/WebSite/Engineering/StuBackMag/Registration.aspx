<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Registration.aspx.cs" Inherits="Engineering_StuBackMag_Registration" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <script type="text/javascript" language="javascript">
        function chkdropdownlist(source, arguments)
        {
            if(arguments.Value != 0)
            {
                arguments.IsValid = true;
            }
            else
            {
                arguments.IsValid = false;
            }
        }
    </script>
    <style type="text/css">
        .style1
        {
            height: 26px;
        }
        .style2
        {
            height: 36px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="margin:14px 0 0 50px">
    <div>
        注册：第一次登陆系统需要注册你的信息
        ，注册成功后请重新登录</div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    <hr style="width:600px; text-align:left" />
    <br />
    <div>
        <table width="600">
            <tr>
                <td width="100" height="31" align="right" valign="middle">
                    姓名：
                </td>
                <td width="500" align="left" valign="middle">
                    <asp:TextBox ID="tbName" runat="server" Width="200px" Enabled="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td height="31" align="right" valign="middle">
                    学号：
                </td>
                <td align="left" valign="middle">
                    <asp:TextBox ID="tbStuNo" runat="server" Width="200px" Enabled="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td height="31" align="right" valign="middle">
                    性别：
                </td>
                <td align="left" valign="middle">
                    <asp:RadioButton ID="rbMan" runat="server" Checked="True" GroupName="gender" 
                        Text="男" />
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:RadioButton ID="rbWoman" runat="server" GroupName="gender" Text="女" />
                &nbsp;
                </td>
            </tr>
            <tr>
                <td height="31" align="right" valign="middle">
                    <span style="color:Red">*</span>出生年月：
                </td>
                <td align="left" valign="middle">
                     <div style="float: left;">
                                    <asp:DropDownList ID="ddlYear" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    年
                                    <asp:DropDownList ID="ddlMonth" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlMonth_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    月
                                </div>
                                <div style="float: left;">
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="ddlDay" runat="server">
                                            </asp:DropDownList>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="ddlMonth" EventName="TextChanged"></asp:AsyncPostBackTrigger>
                                            <asp:AsyncPostBackTrigger ControlID="ddlYear" EventName="TextChanged"></asp:AsyncPostBackTrigger>
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </div>
                                日
                                <asp:Label ID="lblCalendarError" runat="server" ForeColor="Red" 
                         Text="日期选择有误" Visible="False" Font-Names="Verdana" Font-Size="10pt"></asp:Label>
                </td>
            </tr>
            <tr>
                <td height="31" align="right" valign="middle">
                    <span style="color:Red">*</span>民族：
                </td>
                <td align="left" valign="middle">
                    <asp:TextBox ID="tbNation" runat="server" Width="200px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                        ControlToValidate="tbNation" Display="Dynamic" ErrorMessage="不能为空" 
                        SetFocusOnError="True" Font-Names="Verdana" Font-Size="10pt"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td height="31" align="right" valign="middle">
                    <span style="color:Red">*</span>籍贯：
                </td>
                <td align="left" valign="middle">
                    <asp:TextBox ID="tbNativePro" runat="server" Width="200px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                        ControlToValidate="tbNativePro" Display="Dynamic" ErrorMessage="不能为空" 
                        SetFocusOnError="True" Font-Names="Verdana" Font-Size="10pt"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td height="31" align="right" valign="middle">
                    <span style="color:Red">*</span>政治面貌：
                </td>
                <td align="left" valign="middle">
                    <asp:DropDownList ID="ddlPolitic" runat="server" Width="100px">
                        <asp:ListItem Value="0">请选择</asp:ListItem>
                        <asp:ListItem>团员</asp:ListItem>
                        <asp:ListItem>党员</asp:ListItem>
                        <asp:ListItem>其他</asp:ListItem>
                    </asp:DropDownList>
                    <asp:CustomValidator ID="CustomValidator1" runat="server" 
                        ControlToValidate="ddlPolitic" Display="Dynamic" ErrorMessage="请选择政治面貌" 
                        ClientValidationFunction="chkdropdownlist" SetFocusOnError="True" 
                        ValidateEmptyText="True" Font-Names="Verdana" Font-Size="10pt"></asp:CustomValidator>
                </td>
            </tr>
            <tr>
                <td height="31" align="right" valign="middle">
                    <span style="color:Red">*</span>身份证号：
                </td>
                <td align="left" valign="middle">
                    <asp:TextBox ID="tbIDNum" runat="server" Width="200px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="tbIDNum" Display="Dynamic" ErrorMessage="不能为空" 
                        SetFocusOnError="True" Font-Names="Verdana" Font-Size="10pt"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                        ControlToValidate="tbIDNum" Display="Dynamic" ErrorMessage="身份证号不合法" 
                        Font-Names="Verdana" Font-Size="10pt" 
                        ValidationExpression="\d{17}[\d|X]|\d{15}"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td height="31" align="right" valign="middle">
                    <span style="color:Red">*</span>婚姻状况：
                </td>
                <td align="left" valign="middle">
                    <asp:DropDownList ID="ddlMarStatus" runat="server" Width="100px">
                        <asp:ListItem Value="0">请选择</asp:ListItem>
                        <asp:ListItem>未婚</asp:ListItem>
                        <asp:ListItem>已婚</asp:ListItem>
                    </asp:DropDownList>
                    <asp:CustomValidator ID="CustomValidator2" runat="server" ErrorMessage="请选择婚姻状况" 
                        ClientValidationFunction="chkdropdownlist" 
                        ControlToValidate="ddlMarStatus" Font-Names="Verdana" Font-Size="10pt"></asp:CustomValidator>
                </td>
            </tr>
        </table>
    </div>
    <br />
    <hr  style="width:600px; text-align:left"/>
    <br />
    <div>
        <table width="600">
            <tr>
                <td height="31" align="right" valign="middle" class="style1">
                    手机号码：
                </td>
                <td align="left" valign="middle">
                    <asp:TextBox ID="tbPhoneNum" runat="server" Width="200px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td height="31" align="right" valign="middle" class="style2">
                    固定电话：
                </td>
                <td align="left" valign="middle">
                    <asp:TextBox ID="tbFixedNum" runat="server" Width="200px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td height="31" align="right" valign="middle">
                    Email：
                </td>
                <td align="left" valign="middle">
                    <asp:TextBox ID="tbEmail" runat="server" Width="200px"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                        ControlToValidate="tbEmail" ErrorMessage="邮箱不合法" Font-Names="Verdana" 
                        Font-Size="10pt" 
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td height="31" align="right" valign="middle">
                    通信地址：
                </td>
                <td align="left" valign="middle">
                    <asp:TextBox ID="tbAddress" runat="server" Width="300px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td height="31" align="right" valign="middle">
                    邮编：
                </td>
                <td align="left" valign="middle">
                    <asp:TextBox ID="tbPostalCode" runat="server" Width="300px"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
                        ControlToValidate="tbPostalCode" Display="Dynamic" ErrorMessage="邮编不合法" 
                        Font-Names="Verdana" Font-Size="10pt" ValidationExpression="\d{6}"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td height="31" align="right" valign="middle">
                    家庭住址：
                </td>
                <td align="left" valign="middle">
                    <asp:TextBox ID="tbHomeAddress" runat="server" Width="300px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td height="31" align="right" valign="middle">
                    工作单位：
                </td>
                <td align="left" valign="middle">
                    <asp:TextBox ID="tbWorkPlace" runat="server" Width="300px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="100" height="31" align="right" valign="middle">
                    单位地址：
                </td>
                <td width="500" align="left" valign="middle">
                    <asp:TextBox ID="tbwPlaceAddress" runat="server" Width="300px"></asp:TextBox>
                </td>
            </tr>
        </table>
    </div>
    <br />
    <hr style="width:600px; text-align:left"/>
    <br />
    <div>
        <table width="600">
            <tr>
                <td width="130" height="38" align="right" valign="middle">
                    修改登录密码：
                </td>
                <td width="470" align="left" valign="middle">
                    <asp:TextBox ID="tbPassword" runat="server" Width="200px" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="tbPassword" Display="Dynamic" ErrorMessage="密码不能为空" 
                        Font-Names="Verdana" Font-Size="10pt"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td height="31" align="right" valign="middle">
                    再输一遍密码：
                </td>
                <td align="left" valign="middle">
                    <asp:TextBox ID="tbPasswordAgn" runat="server" Width="200px" 
                        TextMode="Password"></asp:TextBox>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" 
                        ControlToCompare="tbPassword" ControlToValidate="tbPasswordAgn" 
                        Display="Dynamic" ErrorMessage="两次输入密码不一致" Font-Names="Verdana" 
                        Font-Size="10pt"></asp:CompareValidator>
                </td>
            </tr>
        </table>
    </div>
    <br />
    <div style="width:600px; padding-left:120px">
        <asp:Button ID="btConfirm" runat="server" Text="完成注册" BackColor="#3333FF" 
            ForeColor="White" Height="31px" Width="100px" onclick="btConfirm_Click" />
    </div>
     </div>
    </form>
</body>
</html>
