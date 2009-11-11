<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewOtherMemDetails.aspx.cs" Inherits="Engineering_TeacherBackMag_ViewOtherMemDetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
   <base target="_self" />
</head>
<body>
    <form id="form1" runat="server">
    <div style="margin: 5px 0 0 3px">
        <div>
            <table width="550">
                <tr>
                    <td width="400" height="31" align="left" valign="middle">
                        评审成员的评审结果详细
                    </td>
                    <td width="150" align="center" valign="middle">
                        <asp:LinkButton ID="LinkButton1" runat="server" OnClientClick="window.close();">关闭窗口</asp:LinkButton>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div>
            <asp:DetailsView ID="dvMemDetails" runat="server" Height="50px" Width="550px" AutoGenerateRows="False"
                BackColor="White" BorderColor="#3366CC" BorderStyle="Solid" BorderWidth="1px"
                CellPadding="5">
                <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                <RowStyle BackColor="White" ForeColor="#003399" />
                <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                <Fields>
                    <asp:BoundField HeaderText="盲审编号" DataField="BlindReviewNo" />
                    <asp:BoundField HeaderText="评审成员" DataField="Name" />
                    <asp:TemplateField HeaderText="评审结果">
                        <ItemTemplate>
                            <%# Convert.ToInt32(Eval("IsCriterion")) == 2 ?"不通过":"通过"%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="完成时间" DataField="JudgeTime" />
                    <asp:TemplateField HeaderText="学术评语">
                        <ItemTemplate>
                            <asp:TextBox ID="tbRemark" runat="server" Height="200px" ReadOnly="True" TextMode="MultiLine"
                                Width="450px" Text='<%# Eval("JudgeResult") %>'></asp:TextBox>
                        </ItemTemplate>
                        <ItemStyle Width="450px" />
                    </asp:TemplateField>
                </Fields>
                <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                <EditRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
            </asp:DetailsView>
        </div>
        <br />
        <p style="text-align: center; width: 550px;">
            <asp:LinkButton ID="LinkButton2" runat="server" OnClientClick="window.close();">关闭窗口</asp:LinkButton>
        </p>
    </div>
    </form>
</body>
</html>
