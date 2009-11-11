<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StudentInfoDetails.aspx.cs" Inherits="Engineering_AdminBakMag_StudentInfoDetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>学生详细信息--工程硕士中心</title>
    <link rel="Stylesheet" type="text/css" href="../Resources/Css/CustomAJAXTabStyle.css" />
    <base target="_self" />
</head>
<body>
    <form id="form1" runat="server">
    <div style="margin:12px 0 0 14px">
    <div>
        学生详细信息
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    </div>
    <hr />
    <br />
    <div>
        <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" 
            Width="100%" CssClass="AjaxTabStrip">
            <cc1:TabPanel runat="server" HeaderText="基本信息" ID="TabPanel1">
                <ContentTemplate>
                    <table border="1" style="border-color: Black; margin: left; width: 600px; border-collapse: collapse;" cellpadding="0" cellspacing="0">
                        <tr>
                            <td width="100" height="31" align="right" valign="middle">
                                学号：
                            </td>
                            <td width="300" align="left" valign="middle">
                                <asp:Label ID="lblStuNo" runat="server"></asp:Label>
                            </td>
                            <td width="200" rowspan="6" align="center" valign="middle">
                                <asp:Image ID="imgPicture" runat="server" Width="150px" />
                            </td>
                        </tr>
                        <tr>
                            <td height="31" align="right" valign="middle">
                                姓名：
                            </td>
                            <td align="left" valign="middle">
                                <asp:Label ID="lblName" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td height="31" align="right" valign="middle">
                                性别：
                            </td>
                            <td align="left" valign="middle">
                                <asp:Label ID="lblGender" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td height="31" align="right" valign="middle">
                                出生年月：
                            </td>
                            <td align="left" valign="middle">
                                <asp:Label ID="lblBirthday" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td height="31" align="right" valign="middle">
                                民族：
                            </td>
                            <td align="left" valign="middle">
                                <asp:Label ID="lblNation" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td height="31" align="right" valign="middle">
                                籍贯：
                            </td>
                            <td align="left" valign="middle">
                                <asp:Label ID="lblProvince" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td height="31" align="right" valign="middle">
                                政治面貌：
                            </td>
                            <td colspan="2" align="left" valign="middle">
                                <asp:Label ID="lblPolitics" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td height="31" align="right" valign="middle">
                                身份证号：
                            </td>
                            <td colspan="2" align="left" valign="middle">
                                <asp:Label ID="lblStuIDNum" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td height="31" align="right" valign="middle">
                                婚姻状况：
                            </td>
                            <td colspan="2" align="left" valign="middle">
                                <asp:Label ID="lblMarStatus" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td height="31" align="right" valign="middle">
                                他的导师：
                            </td>
                            <td colspan="2" align="left" valign="middle">
                                <asp:Label ID="lblTutor" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td height="31" align="right" valign="middle">
                                年级：
                            </td>
                            <td colspan="2" align="left" valign="middle">
                                <asp:Label ID="lblGrade" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td height="31" align="right" valign="middle">
                                教学点：
                            </td>
                            <td colspan="2" align="left" valign="middle">
                                <asp:Label ID="lblSchool" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td height="31" align="right" valign="middle">
                                学位类别：
                            </td>
                            <td colspan="2" align="left" valign="middle">
                                <asp:Label ID="lblDegree" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td height="31" align="right" valign="middle">
                                毕业时间：
                            </td>
                            <td colspan="2" align="left" valign="middle">
                                <asp:Label ID="lblLeavingTime" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <p style="width: 600px; text-align: center">
                        <asp:LinkButton ID="LinkButton1" runat="server" OnClientClick="window.close()">关闭窗口</asp:LinkButton></p>
                </ContentTemplate>
            </cc1:TabPanel>
            <cc1:TabPanel ID="TabPanel2" runat="server" HeaderText="联系方式">
                <ContentTemplate>
                    <table border="1" style="border-color: #999999; margin: left; width: 600px; border-collapse: collapse;">
                        <tr>
                            <td width="100" height="31" align="right" valign="middle">
                                手机号码：
                            </td>
                            <td width="500" align="left" valign="middle">
                                <asp:Label ID="lblMobile" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td height="31" align="right" valign="middle">
                                固定电话：
                            </td>
                            <td align="left" valign="middle">
                                <asp:Label ID="lblFixPhone" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td height="31" align="right" valign="middle">
                                Email：
                            </td>
                            <td align="left" valign="middle">
                                <asp:Label ID="lblEmail" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td height="31" align="right" valign="middle">
                                通信地址：
                            </td>
                            <td align="left" valign="middle">
                                <asp:Label ID="lblAddress" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td height="31" align="right" valign="middle">
                                邮编：
                            </td>
                            <td align="left" valign="middle">
                                <asp:Label ID="lblPostalCode" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td height="31" align="right" valign="middle">
                                家庭住址：
                            </td>
                            <td align="left" valign="middle">
                                <asp:Label ID="lblHomeAddress" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td height="31" align="right" valign="middle">
                                工作单位：
                            </td>
                            <td align="left" valign="middle">
                                <asp:Label ID="lblCompany" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td height="31" align="right" valign="middle">
                                单位地址：
                            </td>
                            <td align="left" valign="middle">
                                <asp:Label ID="lblCompanyAddress" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <p style="width: 600px; text-align: center">
                        <asp:LinkButton ID="LinkButton2" runat="server" OnClientClick="window.close()">关闭窗口</asp:LinkButton></p>
                </ContentTemplate>
            </cc1:TabPanel>
            <cc1:TabPanel ID="TabPanel3" runat="server" HeaderText="缴费信息">
                <ContentTemplate>
                    <asp:Label ID="lblMessage" runat="server" ForeColor="#999999">该学生当前还没有缴费信息:-(</asp:Label><asp:GridView
                        ID="gvTuitionInfo" runat="server" Width="600px" AutoGenerateColumns="False" BorderColor="#666666"
                        BorderStyle="Solid" BorderWidth="1px" CellPadding="4">
                        <Columns>
                            <asp:TemplateField HeaderText="学期">
                                <ItemTemplate>
                                    <asp:Label ID="lblTerm" runat="server" Text='<%#GetCourseTime(Eval("PaymentTerm").ToString())%>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="MustMoney" HeaderText="应缴学费">
                                <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ActualMoney" HeaderText="实缴学费">
                                <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="PaymentTime" DataFormatString="{0:yyyy-MM-dd}" HeaderText="缴费时间">
                                <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Remark" HeaderText="备注">
                                <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
                    <br />
                    <p style="width: 600px; text-align: center">
                        <asp:LinkButton ID="LinkButton3" runat="server" OnClientClick="window.close()">关闭窗口</asp:LinkButton></p>
                </ContentTemplate>
            </cc1:TabPanel>
            <cc1:TabPanel ID="TabPanel4" runat="server" HeaderText="成绩信息">
                <ContentTemplate>
                    <asp:Label ID="lblScoreMsg" runat="server" Text="该学生当前还没有成绩信息:-(" ForeColor="#999999"
                        Visible="False"></asp:Label>
                    <div id="div_score" runat="server">
                        <asp:GridView ID="gvScoreInfo" runat="server" AutoGenerateColumns="False" BorderColor="#666666"
                            BorderStyle="Solid" BorderWidth="1px" CellPadding="4" Width="600px" 
                            ondatabound="gvScoreInfo_DataBound">
                            <Columns>
                                <asp:BoundField DataField="CourseName" HeaderText="课程名称">
                                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="课程性质">
                                    <ItemTemplate>
                                        <asp:Label ID="lblProperty" runat="server" Text='<%#sProperty[Convert.ToInt32(Eval("Property"))]%>'></asp:Label></ItemTemplate>
                                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="课程类别">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCategory" runat="server" Text='<%#sCategory[Convert.ToInt32(Eval("Category"))]%>'></asp:Label></ItemTemplate>
                                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="ExamTime" HeaderText="考试时间">
                                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CreditHour" HeaderText="学时">
                                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Credit" HeaderText="学分">
                                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CourResult" HeaderText="考试成绩">
                                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" />
                                </asp:BoundField>
                            </Columns>
                        </asp:GridView>
                        <p>
                            <asp:Label ID="lblDegreeCredit" runat="server"></asp:Label>
                            &nbsp;&nbsp;&nbsp;
                            <asp:Label ID="lblNonDegreeCredit" runat="server"></asp:Label>
                            &nbsp;&nbsp;&nbsp;
                            <asp:Label ID="lblTotalCredit" runat="server"></asp:Label>
                        </p>
                    </div>
                </ContentTemplate>
            </cc1:TabPanel>
            <cc1:TabPanel ID="TabPanel5" runat="server" HeaderText="论文信息">
                <ContentTemplate>
                    <table width="600" border="1" style="border-color: Black" cellpadding="0" cellspacing="0">
                        <tr>
                            <td height="40" colspan="2" align="center" valign="middle">
                                答 辩 申 请
                            </td>
                        </tr>
                        <tr>
                            <td width="140" height="40" align="center" valign="middle">
                                开题报告
                            </td>
                            <td width="460" align="center" valign="middle">
                                <asp:Label ID="lblOpenSpeach" runat="server" Text="尚未提交" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td height="40" align="center" valign="middle">
                                校外导师信息
                            </td>
                            <td align="center" valign="middle">
                                <asp:Label ID="lblOutTeacher" runat="server" Text="尚未提交" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td height="40" align="center" valign="middle">
                                中期考核表
                            </td>
                            <td align="center" valign="middle">
                                <asp:Label ID="lblMidForm" runat="server" Text="尚未提交" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td height="40" align="center" valign="middle">
                                论文初稿
                            </td>
                            <td align="center" valign="middle">
                                <asp:Label ID="lblPaper" runat="server" Text="尚未提交" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </cc1:TabPanel>
        </cc1:TabContainer>
    </div>
    </div>
    </form>
</body>
</html>
