<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PaperJudgeDetails.aspx.cs" Inherits="Engineering_AdminBakMag_PaperJudgeDetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <base target="_self" />
</head>
<body>
    <form id="form1" runat="server">
    <div style="margin:14px 0 0 16px">
        <div>
            <table width="500">
                <tr>
                    <td width="340" height="31" align="left" valign="middle">
                        论文评审结果详细
                    </td>
                    <td width="160" align="right" valign="middle">
                        <asp:LinkButton ID="LinkButton1" runat="server" OnClientClick="window.close();">关闭窗口</asp:LinkButton>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div>
            <asp:DetailsView ID="dvPaperJudgeDetails" runat="server" Height="50px" 
                Width="500px" AutoGenerateRows="False"
                CellPadding="5" ondatabound="dvPaperJudgeDetails_DataBound" 
                BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px">
                <Fields>
                    <asp:BoundField DataField="Name" HeaderText="姓名">
                        <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                        <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="StudentID" HeaderText="学号">
                        <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                        <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="BlindReviewNo" HeaderText="盲审号">
                        <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                        <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Grade" HeaderText="年级">
                        <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                        <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="TeaSchoolName" HeaderText="教学点">
                        <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                        <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="评审结果">
                        <ItemTemplate>
                            <asp:Label ID="lblJudgeResult" runat="server" Text=' <%#Convert.ToInt32(Eval("IsCriterion"))==1?"已达到标准":"尚未达到标准" %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                        <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="评审意见">
                        <ItemTemplate>
                            <asp:Label ID="lblJudgeSuggestion" runat="server" Text='<%#Eval("JudgeResult")%>'
                                Width="300px"></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                        <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="评审完成时间" DataField="JudgeTime" DataFormatString="{0:yyyy-MM-dd}">
                        <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                        <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="评审组长">
                        <ItemTemplate>
                            <asp:Label ID="lblTeacher1" runat="server" Text='<%#Eval("tName") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                        <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="评审成员一">
                        <ItemTemplate>
                            <asp:Label ID="lblTeacher2" runat="server"></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                        <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="评审成员二">
                        <ItemTemplate>
                            <asp:Label ID="lblTeacher3" runat="server"></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                        <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    </asp:TemplateField>
                </Fields>
            </asp:DetailsView>
        </div>
        <br />
        <p style="text-align: center; height: 31px; width: 500px;">
            <asp:LinkButton ID="LinkButton2" runat="server" OnClientClick="window.close();">关闭窗口</asp:LinkButton>
        </p>
    </div>
    </form>
</body>
</html>
