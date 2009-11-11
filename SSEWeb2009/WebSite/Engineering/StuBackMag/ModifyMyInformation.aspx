
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ModifyMyInformation.aspx.cs" Inherits="Engineering_StuBackMag_ModifyMyInformation" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>修改个人信息--工程硕士中心</title>
    <link rel="Stylesheet" type="text/css" href="../Resources/Css/CustomAJAXTabStyle.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div style="font-size: 25px">
        修改个人信息
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    </div>
    <hr />
    <br />
    <div>
        <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="4" Height="600px"
            Width="100%" CssClass="AjaxTabStrip">
            <cc1:TabPanel runat="server" HeaderText="基本信息" ID="TabPanel1">
                <HeaderTemplate>
                    基本信息
                
                
            </HeaderTemplate>
                
<ContentTemplate>
                    <table width="600" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td width="100" height="31" align="right" valign="middle">
                                姓名：
                            </td>
                            <td width="500" align="left" valign="middle">
                                <asp:TextBox ID="tbName" runat="server" Width="150px" Enabled="False"></asp:TextBox>

                                只有管理员有权限修改
                            </td>
                        </tr>
                        <tr>
                            <td height="31" align="right" valign="middle">
                                学号：
                            </td>
                            <td align="left" valign="middle">
                                <asp:TextBox ID="tbStuNum" runat="server" Width="150px" Enabled="False"></asp:TextBox>

                                只有管理员有权限修改
                            </td>
                        </tr>
                        <tr>
                            <td height="31" align="right" valign="middle">
                                性别：
                            </td>
                            <td align="left" valign="middle">
                                <asp:RadioButton ID="rbMan" runat="server" Checked="True" GroupName="gender" Text="男"></asp:RadioButton>

                                &#160;&#160;<asp:RadioButton ID="rbWoman" runat="server" GroupName="gender" Text="女"></asp:RadioButton>

                            </td>
                        </tr>
                        <tr>
                            <td height="31" align="right" valign="middle">
                                出生年月：
                            </td>
                            <td align="left" valign="middle">
                                <div style="float: left;">
                                    <asp:DropDownList ID="ddlYear" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged"
                                        OnPreRender="ddlYear_PreRender"></asp:DropDownList>

                                    年
                                    <asp:DropDownList ID="ddlMonth" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlMonth_SelectedIndexChanged"></asp:DropDownList>

                                    月
                                </div>
                                <div style="float: left;">
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional"><ContentTemplate>
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
                                <asp:Label ID="lblCalendarError" runat="server" ForeColor="Red" Text="*日期选择有误" Visible="False"></asp:Label>

                            </td>
                        </tr>
                        <tr>
                            <td height="31" align="right" valign="middle">
                                民族：
                            </td>
                            <td align="left" valign="middle">
                                <asp:TextBox ID="tbNation" runat="server" Width="150px"></asp:TextBox>

                            </td>
                        </tr>
                        <tr>
                            <td height="31" align="right" valign="middle">
                                籍贯：
                            </td>
                            <td align="left" valign="middle">
                                <asp:TextBox ID="tbProvince" runat="server" Width="150px"></asp:TextBox>

                            </td>
                        </tr>
                        <tr>
                            <td height="31" align="right" valign="middle">
                                政治面貌：
                            </td>
                            <td align="left" valign="middle">
                                <asp:DropDownList ID="ddlPolitic" runat="server" Width="80px"><asp:ListItem></asp:ListItem>
<asp:ListItem Value="1">党员</asp:ListItem>
<asp:ListItem Value="2">团员</asp:ListItem>
                                </asp:DropDownList>

                            </td>
                        </tr>
                        <tr>
                            <td height="31" align="right" valign="middle">
                                身份证号：
                            </td>
                            <td align="left" valign="middle">
                                <asp:TextBox ID="tbNum" runat="server" Width="150px"></asp:TextBox>

                            </td>
                        </tr>
                        <tr>
                            <td height="31" align="right" valign="middle">
                                婚姻状况：
                            </td>
                            <td align="left" valign="middle">
                                <asp:DropDownList ID="ddlMarStatus" runat="server" Width="80px"><asp:ListItem></asp:ListItem>
<asp:ListItem Value="1">已婚</asp:ListItem>
<asp:ListItem Value="2">未婚</asp:ListItem>
                                </asp:DropDownList>

                            </td>
                        </tr>
                    </table>
                    <br />
                    <br />
                    <p style="text-align: center; width: 252px;">
                        <asp:Button ID="btSaveInfo" runat="server" Text="保存修改" BackColor="#3333FF" ForeColor="White"
                            Height="31px" Width="90px" OnClick="btSaveInfo_Click"></asp:Button>

                    </p>
                    <div>
                    </div>
                
                
            </ContentTemplate>
            
</cc1:TabPanel>
            <cc1:TabPanel runat="server" HeaderText="上传头像" ID="TabPanel2">
                <HeaderTemplate>
                    上传头像
                
                
            </HeaderTemplate>
                
<ContentTemplate>
                    <table width="600" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td width="280" height="31" align="left" valign="middle">
                                当前头像<hr />
                            </td>
                            <td width="14">
                                &#160;&#160;
                            </td>
                            <td width="306" align="left" valign="middle">
                                更换头像<hr />
                            </td>
                        </tr>
                        <tr>
                            <td align="left" height="202" valign="top">
                                <asp:Image ID="imgStudent" runat="server" BorderColor="#999999" BorderStyle="Ridge"
                                    BorderWidth="1px" ImageAlign="Middle" Width="150px" />
                            </td>
                            <td>
                                &nbsp;&nbsp;
                            </td>
                            <td valign="top">
                                <div>
                                    请选择新的照片文件，文件大小小于2MB
                                </div>
                                <div>
                                    <asp:FileUpload ID="FileUpload1" runat="server" Width="283px" />
                                </div>
                                <br />
                                <div>
                                    <asp:Button ID="btUploadImage" runat="server" OnClick="btUploadImage_Click" Text="提交"
                                        Width="50px" />
                                </div>
                                <br />
                                <div>
                                </div>
                            </td>
                        </tr>
                    </table>
                
                
            </ContentTemplate>
            
</cc1:TabPanel>
            <cc1:TabPanel ID="TabPanel3" runat="server" HeaderText="联系方式">
                <HeaderTemplate>
                    联系方式
                
                
            </HeaderTemplate>
                
<ContentTemplate>
                    <table width="600" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td width="100" height="31" align="right" valign="middle">
                                手机号码：
                            </td>
                            <td width="500" align="left" valign="middle">
                                <asp:TextBox ID="tbMobile" runat="server" Width="150px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td height="31" align="right" valign="middle">
                                固定电话：
                            </td>
                            <td align="left" valign="middle">
                                <asp:TextBox ID="tbFixPhone" runat="server" Width="150px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td height="31" align="right" valign="middle">
                                Email：
                            </td>
                            <td align="left" valign="middle">
                                <asp:TextBox ID="tbEmail" runat="server" Width="150px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td height="31" align="right" valign="middle">
                                通信地址：
                            </td>
                            <td align="left" valign="middle">
                                <asp:TextBox ID="tbAddress" runat="server" Width="300px" Style="margin-bottom: 0px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td height="31" align="right" valign="middle">
                                邮编：
                            </td>
                            <td align="left" valign="middle">
                                <asp:TextBox ID="tbPostalcode" runat="server" Width="300px"></asp:TextBox>
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
                                <asp:TextBox ID="tbCompany" runat="server" Width="300px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td height="31" align="right" valign="middle">
                                工作地址：
                            </td>
                            <td align="left" valign="middle">
                                <asp:TextBox ID="tbCompanyAddress" runat="server" Width="300px"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <br />
                    <p style="text-align: center; width: 362px;">
                        <asp:Button ID="btSaveContact" runat="server" Text="保存修改" Height="31px" Width="90px"
                            BackColor="#3333FF" ForeColor="White" OnClick="btSaveContact_Click" />&nbsp;&nbsp;
                    </p>
                    <br />
                    <div>
                    </div>
                
                
            </ContentTemplate>
            
</cc1:TabPanel>
            <cc1:TabPanel ID="TabPanel4" runat="server" HeaderText="个人信息">
                <HeaderTemplate>
                    个人信息
                
                
            </HeaderTemplate>
                
<ContentTemplate>
                    <table width="600" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td width="100" height="31" align="right" valign="middle">
                                我的导师：
                            </td>
                            <td width="500" align="left" valign="middle">
                                <asp:TextBox ID="tbTutorName" runat="server" Width="150px" Enabled="False"></asp:TextBox>只有管理员有权限修改
                            </td>
                        </tr>
                        <tr>
                            <td height="31" align="right" valign="middle">
                                毕业时间：
                            </td>
                            <td align="left" valign="middle">
                                <asp:TextBox ID="tbLeaveTime" runat="server" Width="150px" Enabled="False"></asp:TextBox>只有管理员有权限修改
                            </td>
                        </tr>
                        <tr>
                            <td height="31" align="right" valign="middle">
                                学制：
                            </td>
                            <td align="left" valign="middle">
                                <asp:TextBox ID="tbSchooling" runat="server" Width="150px" Enabled="False"></asp:TextBox>只有管理员有权限修改
                            </td>
                        </tr>
                        <tr>
                            <td height="31" align="right" valign="middle">
                                学院名称：
                            </td>
                            <td align="left" valign="middle">
                                <asp:TextBox ID="tbSchoolName" runat="server" Enabled="False" ReadOnly="True" Width="150px">软件学院</asp:TextBox>只有管理员有权限修改
                            </td>
                        </tr>
                        <tr>
                            <td height="31" align="right" valign="middle">
                                学位类别：
                            </td>
                            <td align="left" valign="middle">
                                <asp:TextBox ID="tbDegree" runat="server" Width="150px" Enabled="False"></asp:TextBox>只有管理员有权限修改
                            </td>
                        </tr>
                        <tr>
                            <td height="31" align="right" valign="middle">
                                年级：
                            </td>
                            <td align="left" valign="middle">
                                <asp:TextBox ID="tbGrade" runat="server" Width="150px" Enabled="False"></asp:TextBox>只有管理员有权限修改
                            </td>
                        </tr>
                    </table>
                    <br />
                    <br />
                    <div>
                        &#160;&#160;
                    </div>
                
                
            </ContentTemplate>
            
</cc1:TabPanel>
            <cc1:TabPanel ID="TabPanel5" runat="server" HeaderText="修改密码">
                <ContentTemplate>
                    <table width="600">
                        <tr>
                            <td width="100" height="31" align="right" valign="middle">
                                旧密码：
                            </td>
                            <td width="500" align="left" valign="middle">
                                <asp:TextBox ID="tbOldPassword" runat="server" Width="150px" ValidationGroup="changepassword"
                                    TextMode="Password"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                                        runat="server" ControlToValidate="tbOldPassword" ErrorMessage="*密码不能为空" ValidationGroup="changepassword"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td height="31" align="right" valign="middle">
                                新密码：
                            </td>
                            <td align="left" valign="middle">
                                <asp:TextBox ID="tbNewPassword" runat="server" Width="150px" TextMode="Password"
                                    ValidationGroup="changepassword"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                                        runat="server" ControlToValidate="tbNewPassword" ErrorMessage="*密码不能为空" ValidationGroup="changepassword"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td height="31" align="right" valign="middle">
                                重输新密码：
                            </td>
                            <td align="left" valign="middle">
                                <asp:TextBox ID="tbPasswordAgain" runat="server" Width="150px" TextMode="Password"
                                    ValidationGroup="changepassword"></asp:TextBox>&#160;<asp:CompareValidator ID="CompareValidator1"
                                        runat="server" ControlToCompare="tbNewPassword" ControlToValidate="tbPasswordAgain"
                                        ErrorMessage="*两次输入密码不匹配" ValidationGroup="changepassword"></asp:CompareValidator>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <br />
                    <p style="text-align: center; width: 252px;">
                        <asp:Button ID="btSavePassword" runat="server" Text="保存修改" BackColor="#3333FF" ForeColor="White"
                            Height="31px" Width="90px" OnClick="btSavePassword_Click" ValidationGroup="changepassword">
                        </asp:Button></p>
                    <br />
                    <div>
                    </div>
                
                
            </ContentTemplate>
            
</cc1:TabPanel>
        </cc1:TabContainer>
    </div>
    </form>
</body>
</html>
