<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ApplyInfoManagement.aspx.cs"
    Inherits="Engineering_AdminBakMag_ApplyInfoManagement" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="../Control/sitmap.ascx" TagName="sitmap" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>受理学籍信息--工程硕士中心</title>
    <link rel="Stylesheet" type="text/css" href="../Resources/Css/CustomAJAXTabStyle.css" />

    <script type="text/javascript" language="javascript">
    function OpenOvertimeDlog(ID,width,height) 
   {       
     var me; 
     // 把父页面窗口对象当作参数传递到对话框中，以便对话框操纵父页自动刷新。 
     me = "ViewStuApplyDetails.aspx?applyID="+ID+""; 
     // 显示对话框。
     window.showModalDialog(me,null,'dialogWidth='+width +'px;dialogHeight='+height+'px;help:no;status:no') 
   } 
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div style="font-size: 25px">
        受理学籍信息
    </div>
    <hr />
    <br />
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <cc1:TabContainer ID="TabContainer1" runat="server" Width="100%" ActiveTabIndex="1"
            CssClass="AjaxTabStrip">
            <cc1:TabPanel runat="server" HeaderText="受理学籍申请" ID="TabPanel1">
                <HeaderTemplate>
                    受理学籍申请
                </HeaderTemplate>
                <ContentTemplate>
                    <asp:Label ID="lbRestult" runat="server" ForeColor="#999999"></asp:Label><asp:GridView
                        ID="gvAppInfomation" runat="server" Width="700px" AutoGenerateColumns="False"
                        CellPadding="4" AllowPaging="True" PageSize="25" ForeColor="#333333" 
                        GridLines="None">
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField HeaderText="学号" DataField="StuID">
                                <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="姓名" DataField="Name">
                                <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="年级" DataField="Grade">
                                <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="教学点" DataField="TeaSchoolName">
                                <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="学籍变更类型" DataField="ApplyCategory">
                                <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ApplyTime" DataFormatString="{0:yyyy-MM-dd}" HeaderText="申请时间">
                                <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:HyperLinkField DataNavigateUrlFields="StuStatusID" Text="进行受理" DataNavigateUrlFormatString="StatusApplyHandle.aspx?id={0}">
                                <ControlStyle ForeColor="Red" />
                                <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px"
                                    ForeColor="Red" />
                            </asp:HyperLinkField>
                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    </asp:GridView>
                </ContentTemplate>
            </cc1:TabPanel>
            <cc1:TabPanel runat="server" HeaderText="查询变动历史" ID="TabPanel2">
                <ContentTemplate>
                    <table width="650">
                        <tr>
                            <td width="85" height="31" align="left" valign="middle">
                                <span style="font-size: 15px">学籍状态：</span>
                            </td>
                            <td width="115" align="left" valign="middle">
                                <asp:DropDownList ID="ddlSchoolStatus" runat="server" Width="120px">
                                    <asp:ListItem>------请选择------</asp:ListItem>
                                    <asp:ListItem>退学</asp:ListItem>
                                    <asp:ListItem>休学</asp:ListItem>
                                    <asp:ListItem>其他</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td width="85" align="left" valign="middle">
                                <span style="font-size: 15px">活动状态：</span>
                            </td>
                            <td width="115" align="left" valign="middle">
                                <asp:DropDownList ID="ddlActivity" runat="server" Width="120px" OnSelectedIndexChanged="ddlActivity_SelectedIndexChanged">
                                    <asp:ListItem>------请选择------</asp:ListItem>
                                    <asp:ListItem>当前活动</asp:ListItem>
                                    <asp:ListItem>历史记录</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td width="250" align="center" valign="middle">
                                <asp:Button ID="btQuery" runat="server" Height="31px" OnClick="btQuery_Click" Text="查询"
                                    Width="60px" BackColor="#3333FF" ForeColor="White" />
                            </td>
                        </tr>
                    </table>
                    <br />
                    <div id="div_ApplyRecord" runat="server" visible="False">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="gvApplyRecord" runat="server" Width="700px" AutoGenerateColumns="False"
                                    CellPadding="4" OnRowDataBound="gvApplyRecord_RowDataBound" DataKeyNames="StuStatusID"
                                    AllowPaging="True" PageSize="20" OnRowCommand="gvApplyRecord_RowCommand" OnRowEditing="gvApplyRecord_RowEditing"
                                    ForeColor="#333333" GridLines="None" 
                                    OnSelectedIndexChanged="gvApplyRecord_SelectedIndexChanged">
                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <RowStyle BackColor="#EFF3FB" />
                                    <Columns>
                                        <asp:BoundField DataField="StuID" HeaderText="学号">
                                            <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                            <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Name" HeaderText="姓名">
                                            <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                            <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="ApplyTime" HeaderText="申请时间" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}">
                                            <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                            <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="ApplyCategory" HeaderText="申请类别">
                                            <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                            <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="记录状态">
                                            <ItemTemplate>
                                                <%#GetStatus(Convert.ToInt32(Eval("Activiy")),Convert.ToInt32(Eval("ApplyResult")))%>
                                            </ItemTemplate>
                                            <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                            <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="查看详细">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lbViewDetails" runat="server">查看</asp:LinkButton></ItemTemplate>
                                            <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                            <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="操作">
                                            <ItemTemplate>
                                                <asp:Button ID="btBackSchool" runat="server" Text="返校" Visible="False" CommandName="backschool"
                                                    CommandArgument='<%#Eval("StuStatusID") %>' /></ItemTemplate>
                                            <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                            <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Center" />
                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <EditRowStyle BackColor="#2461BF" />
                                    <AlternatingRowStyle BackColor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <br />
                        //学生返校后，请点击操作栏中的返校进行确认
                    </div>
                </ContentTemplate>
            </cc1:TabPanel>
        </cc1:TabContainer>
    </div>
    </form>
</body>
</html>
