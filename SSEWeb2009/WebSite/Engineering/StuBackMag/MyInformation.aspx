<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MyInformation.aspx.cs" Inherits="Engineering_StuBackMag_MyInformation" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>我的详细信息--工程硕士中心</title>
</head>
<body>
    <form id="form1" runat="server">
    <div  style=" font-size:25px">
        我的详细信息
    </div>
    <hr />
    <br />
    <div>
        <table border="1" style="border-color: #999999; margin: left; width: 650px; border-collapse: collapse;">
            <tr>
                <td height="31" colspan="4" align="left" valign="middle">
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="账号信息"></asp:Label>
                </td>
            </tr>
            <tr>
                <td width="99" height="31" align="right" valign="middle">
                    姓名：
                </td>
                <td colspan="2" align="center" valign="middle">
                    <asp:Label ID="lblName" runat="server"></asp:Label>
                </td>
                <td width="204" rowspan="5" align="center" valign="middle">
                    <asp:Image ID="Image1" runat="server" ImageAlign="Middle" Width="120px" />
                </td>
            </tr>
            <tr>
                <td height="31" align="right" valign="middle">
                    学号：
                </td>
                <td colspan="2" align="center" valign="middle">
                    <asp:Label ID="lblStuNum" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td height="31" align="right" valign="middle">
                    性别：
                </td>
                <td colspan="2" align="center" valign="middle">
                    <asp:Label ID="lblGender" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td height="31" align="right" valign="middle">
                    出生年月：
                </td>
                <td colspan="2" align="center" valign="middle">
                    <asp:Label ID="lblBirthday" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td height="31" align="right" valign="middle">
                    身份证号：
                </td>
                <td colspan="2" align="center" valign="middle">
                    <asp:Label ID="lblIDNum" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td height="31" colspan="4" align="left" valign="middle">
                    <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="基本信息"></asp:Label>
                </td>
            </tr>
            <tr>
                <td height="40" align="right" valign="middle">
                    民族：
                </td>
                <td width="161" align="center" valign="middle">
                    <asp:Label ID="lblNation" runat="server"></asp:Label>
                </td>
                <td width="121" align="right" valign="middle">
                    领域名称：
                </td>
                <td align="center" valign="middle">
                    <asp:Label ID="lblMajor" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td height="31" align="right" valign="middle">
                    籍贯：
                </td>
                <td align="center" valign="middle">
                    <asp:Label ID="lblNativePro" runat="server"></asp:Label>
                </td>
                <td align="right" valign="middle">
                    学制：
                </td>
                <td align="center" valign="middle">
                    <asp:Label ID="lblSchooling" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td height="40" align="right" valign="middle">
                    政治面貌：
                </td>
                <td valign="middle" align="center">
                    <asp:Label ID="lblPolitics" runat="server"></asp:Label>
                </td>
                <td align="right" valign="middle">
                    婚姻状况：
                </td>
                <td align="center" valign="middle">
                    <asp:Label ID="lblMarStatus" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td height="40" align="right" valign="middle">
                    所属学院：
                </td>
                <td align="center" valign="middle">
                    <asp:Label ID="lblSchool" runat="server" Text="软件学院"></asp:Label>
                </td>
                <td align="right" valign="middle">
                    所属年级：
                </td>
                <td align="center" valign="middle">
                    <asp:Label ID="lblGrade" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td height="40" align="right" valign="middle">
                    学位类别：
                </td>
                <td align="center" valign="middle">
                    <asp:Label ID="lblDegree" runat="server"></asp:Label>
                </td>
                <td align="right" valign="middle">
                    毕业时间：
                </td>
                <td align="center" valign="middle">
                     <asp:Label ID="lblGraduate" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td height="31" colspan="4" align="left" valign="middle">
                    <asp:Label ID="Label3" runat="server" Font-Bold="True" Text="联系方式"></asp:Label>
                </td>
            </tr>
            <tr>
                <td height="31" align="right" valign="middle">
                    手机号码：
                </td>
                <td colspan="3" align="left" valign="middle">
                    <asp:Label ID="lblMobile" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td height="31" align="right" valign="middle">
                    固定电话：
                </td>
                <td colspan="3" align="left" valign="middle">
                    <asp:Label ID="lblFixedPhone" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td height="31" align="right" valign="middle">
                    通信地址：
                </td>
                <td colspan="3" align="left" valign="middle">
                    <asp:Label ID="lblAddress" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td height="31" align="right" valign="middle">
                    邮政编码：
                </td>
                <td colspan="3" align="left" valign="middle">
                    <asp:Label ID="lblPostalCode" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td height="31" align="right" valign="middle">
                    家庭住址：
                </td>
                <td colspan="3" align="left" valign="middle">
                    <asp:Label ID="lblHomeAddress" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td height="31" align="right" valign="middle">
                    工作单位：
                </td>
                <td colspan="3" align="left" valign="middle">
                    <asp:Label ID="lblCompany" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td height="31" align="right" valign="middle">
                    单位地址：
                </td>
                <td colspan="3" align="left" valign="middle">
                    <asp:Label ID="lblCompanyAdd" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
