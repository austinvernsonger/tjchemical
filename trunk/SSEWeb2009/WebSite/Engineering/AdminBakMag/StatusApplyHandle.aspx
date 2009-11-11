<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StatusApplyHandle.aspx.cs" Inherits="Engineering_AdminBakMag_StatusApplyHandle" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>受理学籍信息--工程硕士中心</title>
</head>
<body> 
    <form id="form1" runat="server">
    <div>
        <table width="700">
            <tr>
                <td width="450" height="25" align="left" valign="bottom">
                    <span style=" font-size:25px">待处理学籍变动申请详情</span>
                </td>
                <td width="250" align="right" valign="bottom">
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Engineering/AdminBakMag/ApplyInfoManagement.aspx" ForeColor="#666666">&lt;&lt;返回上一页</asp:HyperLink>
                </td>
            </tr>
        </table>
    </div>
    <hr/>
    <br />
    <div>
        <asp:DetailsView ID="dvappInfo" runat="server" Height="50px" Width="600px" 
            AutoGenerateRows="False" CellPadding="4" BackColor="White" 
            BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" 
            onitemupdating="dvappInfo_ItemUpdating" 
            onmodechanging="dvappInfo_ModeChanging" DataKeyNames="StuStatusID" 
            GridLines="Horizontal">
            <FooterStyle BackColor="White" ForeColor="#333333" />
            <RowStyle BackColor="White" ForeColor="#333333" />
            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
            <Fields>
                <asp:TemplateField HeaderText="学号">
                    <ItemTemplate>
                        <%# Eval("StuID")%>
                    </ItemTemplate>
                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="姓名">
                    <ItemTemplate>
                        <%# Eval("Name")%>
                    </ItemTemplate>
                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="年级">
                    <ItemTemplate>
                        <%# Eval("Grade") %>
                    </ItemTemplate>
                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="所属教学点">
                    <ItemTemplate>
                        <%# Eval("TeaSchoolName")%>
                    </ItemTemplate>
                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="学位类型">
                    <ItemTemplate>
                        <%# Eval("Degree")%>
                    </ItemTemplate>
                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="导师">
                    <ItemTemplate>
                        <%# Eval("tName")%>
                    </ItemTemplate>
                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="学籍变更类别">
                    <ItemTemplate>
                        <%# Eval("ApplyCategory")%>
                    </ItemTemplate>
                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="学籍变更原因">
                    <ItemTemplate>
                        <asp:Label ID="lblApplyReason" runat="server" Text='<%# Eval("ApplyReason") %>' Width="400" Height="100"></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="申请时间">
                    <ItemTemplate>
                        <%# Convert.ToDateTime(Eval("ApplyTime")).ToString("yyyy年MM月dd日")%>
                    </ItemTemplate>
                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="审批结果">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# GetApplyResult(Convert.ToInt32(Eval("ApplyResult"))) %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:DropDownList ID="ddlResult" runat="server" Width="80px">
                            <asp:ListItem Value="1">批准</asp:ListItem>
                            <asp:ListItem Value="2">不批准</asp:ListItem>
                        </asp:DropDownList>
                    </EditItemTemplate>
                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" />
                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="审批建议">
                    <ItemTemplate>
                        <asp:Label ID="lbSuggestion" runat="server" Text='<%# Eval("ApplyRemark") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="tbSuggestion" runat="server" Height="100px" 
                            TextMode="MultiLine" Width="400px" Text='<%# Eval("ApplyRemark") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                </asp:TemplateField>
                <asp:CommandField EditText="进行审批" ShowEditButton="True" UpdateText="保存" 
                    ButtonType="Button" >
                    <ControlStyle BackColor="#3333FF" ForeColor="White" Height="31px" 
                        Width="90px" />
                    <FooterStyle BorderStyle="None" />
                    <ItemStyle HorizontalAlign="Center" Height="50px" />
                </asp:CommandField>
            </Fields>
            <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
        </asp:DetailsView> 
    </div>
    <br />
    <div>
        <asp:Label ID="lbResult" runat="server" ForeColor="Red"></asp:Label>
    </div>
    </form>
</body>
</html>
