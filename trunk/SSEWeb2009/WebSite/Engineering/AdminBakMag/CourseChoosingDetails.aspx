<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CourseChoosingDetails.aspx.cs" Inherits="Engineering_AdminBakMag_CourseChoosingDetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <base target="_self" />
</head>
<body>
    <form id="form1" runat="server">
    <div style="margin:12px 0 0 14px">
    <div>
        <table width="500" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td width="348" height="31" align="left" valign="middle">
                选课学生详细信息</td>
            <td width="152" align="center" valign="middle">
                <asp:LinkButton ID="lbClose" runat="server" OnClientClick="window.close();">关闭窗口</asp:LinkButton>
            </td>
        </tr>
    </table>
    </div>
    <br />
    <div>
       <table width="500" border="1" cellpadding="0" cellspacing="0">
        <tr>
            <td height="31" colspan="2" align="left" valign="middle">
                <asp:Label ID="lblTerm" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td width="250" height="31" align="left" valign="middle">
                <asp:Label ID="lblGrade" runat="server"></asp:Label>
            </td>
            <td width="250" align="left" valign="middle">
                <asp:Label ID="lblSchool" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
    </div>
    <br />
    <div>
        <asp:Label ID="lblRes" runat="server" Text="到目前为止，该门课程还没有学生选修！" Visible="False"></asp:Label>
        <asp:GridView ID="gvStuInfo" runat="server" Width="500px" 
            AutoGenerateColumns="False" CellPadding="4" ShowFooter="True" 
            BorderStyle="Solid" BorderColor="#666666" BorderWidth="1px" 
            onrowdatabound="gvStuInfo_RowDataBound">
            <Columns>
                <asp:BoundField DataField="StudentID" HeaderText="学号">
                    <FooterStyle BorderStyle="None" />
                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" 
                        BorderWidth="1px" />
                </asp:BoundField>
                <asp:BoundField DataField="Name" HeaderText="姓名">
                    <FooterStyle BorderStyle="None" />
                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" 
                        BorderWidth="1px" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="性别">
                    <ItemTemplate>
                        <asp:Label ID="lblDegree" runat="server" Text='<%#Convert.ToInt32(Eval("Gender"))==0?"男":"女" %>'></asp:Label>
                    </ItemTemplate>
                    <FooterStyle BorderStyle="None" />
                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" 
                        HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:BoundField DataField="Degree" HeaderText="学位类别">
                    <FooterStyle BorderStyle="None" HorizontalAlign="Center" />
                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" 
                        BorderWidth="1px" />
                </asp:BoundField>
            </Columns>
        </asp:GridView>
    </div>
    <br />
    <div>
        <table width="500">
        <tr>
            <td height="31" colspan="2" align="center" valign="middle">
                <asp:LinkButton ID="lbCloseWin" runat="server" OnClientClick="window.close();">关闭窗口</asp:LinkButton>
            </td>
        </tr>
    </table>
    </div>
    </div>
    </form>
</body>
</html>
