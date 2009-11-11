<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewAllTutorsInfo.aspx.cs" Inherits="Engineering_StuBackMag_ViewAllTutorsInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div  style="font-size: 25px">
        查看可选导师信息
    </div>
    <hr />
    <br />
    <div>
        <asp:GridView ID="gvTutorsInfo" runat="server" AutoGenerateColumns="False" DataKeyNames="TeacherID"
            BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" CellPadding="4" Width="700px">
            <Columns>
                <asp:HyperLinkField DataNavigateUrlFields="TeacherID" DataNavigateUrlFormatString="AllTutorsDetails.aspx?id={0}"
                    DataTextField="Name" HeaderText="姓名">
                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" ForeColor="Blue"
                        HorizontalAlign="Center" />
                </asp:HyperLinkField>
                <asp:TemplateField HeaderText="性别">
                    <ItemTemplate>
                        <asp:Label ID="lblGender" runat="server" Text='<%#Convert.ToInt32(Eval("Gender"))==0?"男":"女" %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:BoundField DataField="Title" HeaderText="职称">
                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="ResearchAspect" HeaderText="研究方向">
                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" />
                </asp:BoundField>
            </Columns>
        </asp:GridView>
    </div>
    </form>
</body>
</html>
