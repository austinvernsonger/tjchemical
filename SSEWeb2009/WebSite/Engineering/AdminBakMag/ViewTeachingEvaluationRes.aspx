<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewTeachingEvaluationRes.aspx.cs" Inherits="Engineering_AdminBakMag_ViewTeachingEvaluationRes" %>

<%@ Register src="../Control/sitmap.ascx" tagname="sitmap" tagprefix="uc1" %>

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
        <table width="600">
            <tr>
                <td width="438" height="31" align="left" valign="middle">
                    测评结果详细信息
                </td>
                <td width="162" align="right" valign="middle">
                    <asp:LinkButton ID="LinkButton1" runat="server" OnClientClick="window.close()">关闭窗口</asp:LinkButton>
                </td>
            </tr>
        </table>
    </div>
    <div> 
        <br />
        <asp:Label ID="lblText" runat="server" Text="到目前为止还没有学生对这门课程进行测评" 
            Visible="False"></asp:Label>
        <asp:Panel ID="Panel1" runat="server">
        <div>
            <table width="600" border="1" cellpadding="0" cellspacing="0">
                <tr>
                    <td width="300" height="31" align="center" valign="middle">
                        <asp:Label ID="lblCourseName" runat="server"></asp:Label>
                    </td>
                    <td width="300" align="center" valign="middle">
                        <asp:Label ID="lblTeacher" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div>
            到目前为止，总共有 
            <asp:Label ID="lblSum" runat="server" Text="0" Font-Bold="True" 
                Font-Size="Large" ForeColor="Red"></asp:Label> &nbsp;位同学对这门课进行了测评
        </div>
        <div>
            <asp:GridView ID="gvResult" runat="server" Width="600px" 
                AutoGenerateColumns="False" BorderColor="#666666" 
                BorderStyle="Solid" BorderWidth="1px" CellPadding="3" 
                onprerender="gvResult_PreRender">
                <Columns>
                    <asp:BoundField DataField="Item" HeaderText="评估项目" >
                        <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                        <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" 
                            BorderWidth="1px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="No" HeaderText="序号" >
                        <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                        <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" 
                            BorderWidth="1px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="element" HeaderText="项目要素" >
                        <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                        <ItemStyle HorizontalAlign="Left" BorderColor="#666666" BorderStyle="Solid" 
                            BorderWidth="1px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="excellent" HeaderText="优" >
                        <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                        <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" 
                            BorderWidth="1px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="good" HeaderText="良" >
                        <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                        <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" 
                            BorderWidth="1px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="quality" HeaderText="合格" >
                        <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                        <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" 
                            BorderWidth="1px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="bad" HeaderText="不合格" >
                        <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                        <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" 
                            BorderWidth="1px" />
                    </asp:BoundField>
                </Columns>
            </asp:GridView>       
        </div>
        <br />
        <div>
            相关评论：
        </div>  
        <br />
        <div>
            <asp:GridView ID="gvSuggestion" runat="server" Width="600px" 
                AutoGenerateColumns="False" BackColor="White" 
                BorderStyle="None" CellPadding="2" ShowHeader="False" AllowPaging="True" 
                GridLines="None" PageSize="5" 
                onpageindexchanging="gvSuggestion_PageIndexChanging">
                <FooterStyle BackColor="White" ForeColor="#000066" />
                <RowStyle ForeColor="#000066" />
                <Columns>
                    <asp:BoundField DataField="ID">
                        <ItemStyle HorizontalAlign="Left" Width="30px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Item">
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                </Columns>
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
            </asp:GridView>
        </div>
        </asp:Panel>
    </div>
    <p style="width:600px; text-align:center">
        <asp:LinkButton ID="LinkButton2" runat="server" OnClientClick="window.close()">关闭窗口</asp:LinkButton>
    </p>
    </div>
    </form>
</body>
</html>
