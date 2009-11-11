<%@ Page Language="C#" MasterPageFile="~/Teaching/MainFrame.master" AutoEventWireup="true"
    CodeFile="OrdinaryAdmin.aspx.cs" Inherits="Teaching_BackEnd_OrdinaryAdmin" Title="Untitled Page" %>

<%@ Register Assembly="System.Web.Extensions" Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title></title>
    <link href="../../CssClass/Teaching_OrdinaryAdmin.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            width: 72px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlace" runat="Server">
    <div id="ContentContainer">
        <%--<div id="TopRoundCorner">
            <cc1:RoundedCornersExtender ID="RoundedCornersExtender1" Color="#bdd9f7" Corners="Top"
                Radius="8" runat="server">
            </cc1:RoundedCornersExtender>
        </div>--%>
        <div id="Middle">
            <div id="Div1">
                <asp:ScriptManager ID="ScriptManager2" runat="server">
                </asp:ScriptManager>
                <table cellpadding="5px" cellspacing="5px" width="100%" style="color: Black; font-family: 黑体;
                    font-weight: bold; font-size: 18px; line-height: 25px">
                    <tr align="center">
                        <td style="padding-left: 20px">
                            普通管理人员信息
                        </td>
                    </tr>
                </table>
                <table cellpadding="0" cellspacing="0" width="100%" style="background-color: #003399;
                    color: White; font-weight: bold; line-height: 25px">
                    <tr>
                        <td style="padding-left: 20px">
                            >> 基本信息
                        </td>
                    </tr>
                </table>
                <table cellpadding="2px" cellspacing="2px" style="margin-left: auto; margin-right: auto">
                    <tr>
                        <td align="right" class="style1">
                            姓名
                        </td>
                        <td align="left">
                            <asp:Label ID="Name" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="style1">
                            性别
                        </td>
                        <td align="left">
                            <asp:Label ID="Gender" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr valign="top">
                        <td align="right" class="style1">
                            出生年月
                        </td>
                        <td align="left">
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                    <asp:Calendar ID="Birthday" runat="server" BackColor="White" BorderColor="#3366CC"
                                        BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana"
                                        Font-Size="8pt" ForeColor="#003399" Height="200px" Width="233px">
                                        <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                        <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                                        <WeekendDayStyle BackColor="#CCCCFF" />
                                        <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                                        <OtherMonthDayStyle ForeColor="#999999" />
                                        <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                                        <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
                                        <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True"
                                            Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
                                    </asp:Calendar>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="style1">
                            地址
                        </td>
                        <td align="left">
                            <asp:TextBox ID="Address" runat="server" BorderColor="#B4B9FE" BorderStyle="Solid"
                                BorderWidth="1px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="style1">
                            电话
                        </td>
                        <td align="left">
                            <asp:TextBox ID="Telephone" runat="server" BorderColor="#B4B9FE" BorderStyle="Solid"
                                BorderWidth="1px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="style1">
                            最后学历
                        </td>
                        <td align="left">
                            <asp:TextBox ID="LastDegree" runat="server" BorderColor="#B4B9FE" BorderStyle="Solid"
                                BorderWidth="1px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="style1">
                            最后学历毕业院校
                        </td>
                        <td align="left">
                            <asp:TextBox ID="LastCollege" runat="server" BorderColor="#B4B9FE" BorderStyle="Solid"
                                BorderWidth="1px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="style1">
                            工作部门
                        </td>
                        <td align="left">
                            <asp:TextBox ID="Department" runat="server" BorderColor="#B4B9FE" BorderStyle="Solid"
                                BorderWidth="1px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="style1">
                            专业
                        </td>
                        <td align="left">
                            <asp:TextBox ID="Major" runat="server" BorderColor="#B4B9FE" BorderStyle="Solid"
                                BorderWidth="1px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="style1">
                            传真
                        </td>
                        <td align="left">
                            <asp:TextBox ID="Fax" runat="server" BorderColor="#B4B9FE" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="style1">
                            邮件
                        </td>
                        <td align="left">
                            <asp:TextBox ID="Email" runat="server" BorderColor="#B4B9FE" BorderStyle="Solid"
                                BorderWidth="1px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="style1">
                            职称
                        </td>
                        <td align="left">
                            <asp:TextBox ID="TitleName" runat="server" BorderColor="#B4B9FE" BorderStyle="Solid"
                                BorderWidth="1px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="style1">
                            职务
                        </td>
                        <td align="left">
                            <asp:TextBox ID="Post" runat="server" BorderColor="#B4B9FE" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </div>
            <div id="Div2">
                <table cellpadding="0" cellspacing="0" width="100%" style="background-color: #003399;
                    color: White; font-weight: bold; line-height: 25px">
                    <tr>
                        <td style="padding-left: 20px">
                            >> 教学信息
                        </td>
                    </tr>
                </table>
                <table cellpadding="2px" cellspacing="2px" style="margin-left: auto; margin-right: auto">
                    <tr>
                        <td align="right">
                            教改论文发表情况
                        </td>
                        <td align="left">
                            <asp:TextBox ID="ReformThesis" runat="server" Height="322px" Width="450px" BorderColor="#B4B9FE"
                                BorderStyle="Solid" BorderWidth="1px" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            承担/参与教改项目情况
                        </td>
                        <td align="left">
                            <asp:TextBox ID="ReformDuty" runat="server" Height="276px" TextMode="MultiLine" Width="480px"
                                BorderColor="#B4B9FE" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            教学获奖情况
                        </td>
                        <td align="left">
                            <asp:TextBox ID="EducationAward" runat="server" Height="308px" Width="479px" BorderColor="#B4B9FE"
                                BorderStyle="Solid" BorderWidth="1px" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </div>
            <div id="Div3">
                <table cellpadding="0" cellspacing="0" width="100%" style="background-color: #003399;
                    color: White; font-weight: bold; line-height: 25px">
                    <tr>
                        <td style="padding-left: 20px">
                            >> 补充信息
                        </td>
                    </tr>
                </table>
                <table cellpadding="5px" cellspacing="5px" style="margin-left: auto; margin-right: auto">
                    <tr>
                        <td align="right" valign="top">
                            备注
                        </td>
                        <td align="left">
                            <asp:TextBox ID="Memo" Height="242px" Width="409px" runat="server" BorderColor="#B4B9FE"
                                BorderStyle="Solid" BorderWidth="1px" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <table width="100%">
                    <tr>
                        <td align="center">
                            <asp:Button ID="Submit" runat="server" BackColor="Blue" Width="60px" BorderWidth="0"
                                ForeColor="White" Text="保存" OnClick="Submit_Click" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <%--<div id="BottomRoundCorner">
            <cc1:RoundedCornersExtender ID="RoundedCornersExtender2" Color="#bdd9f7" Corners="Bottom"
                Radius="8" runat="server">
            </cc1:RoundedCornersExtender>
        </div>--%>
    </div>
</asp:Content>
