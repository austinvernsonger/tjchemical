<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StudentChoosingCourseDetails.aspx.cs" Inherits="Engineering_AdminBakMag_StudentChoosingCourseDetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <base target="_self" />
</head>
<body>
    <form id="form1" runat="server">
    <div style="margin:14px 0 0 12px">
        <asp:Label ID="lblCourseName" runat="server" ForeColor="#999999"></asp:Label>
        <br />
        <br />
        <asp:GridView ID="gvStudentInfo" runat="server" Width="500px" 
            AutoGenerateColumns="False" CellPadding="4" BorderColor="#666666" 
            BorderStyle="Solid" BorderWidth="1px">
            <Columns>
                <asp:BoundField DataField="Name" HeaderText="姓名">
                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" 
                        HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="StudentID" HeaderText="学号">
                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" 
                        HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="性别">
                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" 
                        HorizontalAlign="Center" />
                      <ItemTemplate>
                        <%#Convert.ToInt32(Eval("Gender"))==0?"男":"女"%>
                      </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Degree" HeaderText="学位类别">
                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" 
                        HorizontalAlign="Center" />
                </asp:BoundField>
            </Columns>
        </asp:GridView>
    </div>
    <br />
    <p style="width:500px; text-align:center">
        <asp:LinkButton ID="LinkButton1" runat="server" OnClientClick="window.close();">关闭窗口</asp:LinkButton>
    </p>
    </form>
</body>
</html>
