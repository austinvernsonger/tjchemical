<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AllTutorsDetails.aspx.cs" Inherits="Engineering_StuBackMag_AllTutorsDetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="700">
            <tr>
                <td width="450" height="25" align="left" valign="bottom">
                    <span style=" font-size:25px">导师详细信息</span>
                </td>
                <td width="250" align="right" valign="bottom">
                    <asp:LinkButton ID="lnbBack" runat="server" 
                        PostBackUrl="~/Engineering/StuBackMag/ViewAllTutorsInfo.aspx">返回上一页</asp:LinkButton>
                </td>
            </tr>
        </table> 
    </div>
    <hr />
    <br />
    <div>
        <asp:DetailsView ID="dvTutorInfo" runat="server" Height="50px" Width="700px" 
            AutoGenerateRows="False" BorderColor="#666666" BorderStyle="Solid" 
            BorderWidth="1px" CellPadding="5" DataKeyNames="TeacherID" 
            ondatabound="dvTutorInfo_DataBound">
            <Fields>
                <asp:BoundField DataField="Name" HeaderText="姓名">
                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" 
                        Width="600px" />
                </asp:BoundField>
                <asp:BoundField DataField="Title" HeaderText="职称">
                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="联系方式">
                    <ItemTemplate>
                        <asp:Label ID="lblTelephone" runat="server"></asp:Label>
                        <br />
                        <asp:Label ID="lbEmail" runat="server"></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="研究方向">
                    <ItemTemplate>
                        <asp:Label ID="lbResAspect" runat="server"></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="研究课题">
                    <ItemTemplate>
                        <asp:Label ID="lbCourse" runat="server"></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="简介">
                    <ItemTemplate>
                        <asp:Label ID="lbThesis" runat="server"></asp:Label>
                        <br />
                        <asp:Label ID="lbResAward" runat="server"></asp:Label>
                        <br />
                        <asp:Label ID="lbCompetition" runat="server"></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="备注">
                    <ItemTemplate>
                        <asp:Label ID="lblRemark" runat="server"></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                </asp:TemplateField>
            </Fields>
        </asp:DetailsView>
    </div>
    </form>
</body>
</html>
