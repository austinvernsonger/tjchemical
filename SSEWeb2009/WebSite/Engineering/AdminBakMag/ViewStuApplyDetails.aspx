<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewStuApplyDetails.aspx.cs" Inherits="Engineering_AdminBakMag_ViewStuApplyDetails" %>
<%@ OutputCache Duration="1" VaryByParam="None"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <base target="_self" />
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align:center; padding-top:4px">
        <div>
            <table width="500">
                <tr>
                    <td width="340" height="31" align="left" valign="middle">
                        学籍变动信息详细</td>
                    <td width="160" align="right" valign="middle">
                        <asp:LinkButton ID="LinkButton1" runat="server" OnClientClick="window.close();">关闭窗口</asp:LinkButton>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div>
            <asp:DetailsView ID="dvApplyInfo" runat="server" AutoGenerateRows="False" 
                BackColor="White" BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" 
                CellPadding="4" Height="50px" Width="500px">
                <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                <RowStyle BackColor="White" ForeColor="#003399" />
                <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                <Fields>
                    <asp:BoundField HeaderText="姓名" DataField="Name" >
                        <HeaderStyle Width="150px" Wrap="True" BorderColor="#666666" 
                            BorderStyle="Solid" BorderWidth="1px" />
                        <ItemStyle HorizontalAlign="Left" BorderColor="#666666" BorderStyle="Solid" 
                            BorderWidth="1px" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="学号" DataField="StudentID" >
                        <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                        <ItemStyle HorizontalAlign="Left" BorderColor="#666666" BorderStyle="Solid" 
                            BorderWidth="1px" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="性别">
                         <ItemTemplate>
                            <%#Convert.ToInt32(Eval("Gender"))==0?"男":"女" %>
                         </ItemTemplate>
                         <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                         <ItemStyle HorizontalAlign="Left" BorderColor="#666666" BorderStyle="Solid" 
                             BorderWidth="1px" />
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="年级" DataField="Grade" >
                        <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                        <ItemStyle HorizontalAlign="Left" BorderColor="#666666" BorderStyle="Solid" 
                            BorderWidth="1px" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="教学点" DataField="TeaSchoolName" >
                        <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                        <ItemStyle HorizontalAlign="Left" BorderColor="#666666" BorderStyle="Solid" 
                            BorderWidth="1px" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="申请类别" DataField="ApplyCategory" >
                        <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                        <ItemStyle HorizontalAlign="Left" BorderColor="#666666" BorderStyle="Solid" 
                            BorderWidth="1px" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="申请原因">
                        <ItemTemplate>
                            <asp:Label ID="lblReason" runat="server" Width="400" Height="100" Text='<%#Eval("ApplyReason") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                        <ItemStyle HorizontalAlign="Left" BorderColor="#666666" BorderStyle="Solid" 
                            BorderWidth="1px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="申请结果">
                        <ItemTemplate>
                            <%# GetApplyResult(Convert.ToInt32(Eval("ApplyResult")))%>
                        </ItemTemplate>
                        <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                        <ItemStyle HorizontalAlign="Left" BorderColor="#666666" BorderStyle="Solid" 
                            BorderWidth="1px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="申请时间">
                        <ItemTemplate>
                            <%# Convert.ToDateTime(Eval("ApplyTime")).ToString("yyyy-MM-dd")%>
                        </ItemTemplate>
                        <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                        <ItemStyle HorizontalAlign="Left" BorderColor="#666666" BorderStyle="Solid" 
                            BorderWidth="1px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="返校时间">
                        <ItemTemplate>
                            <%# GetBackTime(Eval("BackTime"))%>
                        </ItemTemplate>
                        <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                        <ItemStyle HorizontalAlign="Left" BorderColor="#666666" BorderStyle="Solid" 
                            BorderWidth="1px" />
                    </asp:TemplateField>
                </Fields>
                <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                <EditRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
            </asp:DetailsView> 
        </div>
        <br />
        <p style="text-align:center; height: 31px; width: 500px;">
            <asp:LinkButton ID="LinkButton2" runat="server" OnClientClick="window.close();">关闭窗口</asp:LinkButton>
        </p>
    </div>
    </form>
</body>
</html>
