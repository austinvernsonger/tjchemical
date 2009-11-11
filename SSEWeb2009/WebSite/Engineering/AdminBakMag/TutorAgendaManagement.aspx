<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TutorAgendaManagement.aspx.cs" Inherits="Engineering_AdminBakMag_TutorAgendaManagement" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register src="../Control/sitmap.ascx" tagname="sitmap" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>管理导师选择日程--工程硕士中心</title>
    <link rel="Stylesheet" type="text/css" href="../Resources/Css/CustomAJAXTabStyle.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div style=" font-size:25px">
        管理导师选择日程
        <asp:ScriptManager ID="ScriptManager1" runat="server" 
            EnableScriptGlobalization="True" EnableScriptLocalization="True">
        </asp:ScriptManager>
    </div>
    <hr />
    <br />
    <div>
        <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0"
            Width="100%" CssClass="AjaxTabStrip" 
            OnActiveTabChanged="TabContainer1_ActiveTabChanged">
            <cc1:TabPanel runat="server" HeaderText=" 查看日程" ID="TabPanel1">
                <ContentTemplate>
                    <table width="600">
                        <tr>
                            <td align="left" height="31" valign="middle" width="80">
                                年级
                            </td>
                            <td align="left" valign="middle" width="140">
                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlViewGrade" runat="server" AutoPostBack="True" DataSourceID="ObjectDataSource3"
                                            DataTextField="Grade" DataValueField="Grade" OnSelectedIndexChanged="ddlViewGrade_SelectedIndexChanged"
                                            Width="120px">
                                            <asp:ListItem>--请选择年级--</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" SelectMethod="GetGrade"
                                            TypeName="Department.Engineering.StudentManage"></asp:ObjectDataSource>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td align="left" valign="middle" width="80">
                                教学点
                            </td>
                            <td align="left" valign="middle" width="140">
                                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlViewSchool" runat="server" DataSourceID="ObjectDataSource4"
                                            DataTextField="TeaSchoolName" DataValueField="TeaSchoolID" Width="120px">
                                            <asp:ListItem>--请选择教学点--</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:ObjectDataSource ID="ObjectDataSource4" runat="server" SelectMethod="GetTeaSchool"
                                            TypeName="Department.Engineering.TeachingSchool">
                                            <SelectParameters>
                                                <asp:ControlParameter ControlID="ddlViewGrade" Name="selValue" PropertyName="SelectedValue"
                                                    Type="String" />
                                            </SelectParameters>
                                        </asp:ObjectDataSource>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="ddlViewGrade" EventName="SelectedIndexChanged" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                            <td align="left" valign="middle" width="160">
                                <asp:Button ID="btQuery" runat="server" Text="查询" Height="31px" Width="90px" OnClick="btQuery_Click"
                                    BackColor="#3333FF" ForeColor="White" />
                            </td>
                        </tr>
                    </table>
                    <br />
                    <div>
                        <asp:GridView
                            ID="gvTutorTime" runat="server" Width="700px" AllowPaging="True" 
                            AutoGenerateColumns="False" CellPadding="4" OnRowDataBound="gvTutorTime_RowDataBound"
                            PageSize="20" ForeColor="#333333" GridLines="None" 
                            onrowcommand="gvTutorTime_RowCommand" onrowdeleting="gvTutorTime_RowDeleting">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:BoundField DataField="Grade" HeaderText="年级">
                                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                    <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="TeaSchoolName" HeaderText="教学点">
                                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                    <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="StartTime" DataFormatString="{0:yyyy-MM-dd}" 
                                    HeaderText="选导师开始时间">
                                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" 
                                        HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="EndTime" DataFormatString="{0:yyyy-MM-dd}" 
                                    HeaderText="选导师结束时间">
                                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" 
                                        HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="当前状态">
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%#GetCurrentStatus(Eval("StartTime").ToString() + "|" + Eval("EndTime").ToString()) %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                    <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="删除">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="lnbDelete" runat="server" ImageUrl="~/Engineering/Resources/images/icon-delete.gif" CommandName="cmdDelete" CommandArgument='<%#Eval("TeaMagID") %>' />
                                    </ItemTemplate>
                                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" 
                                        HorizontalAlign="Center" />
                                </asp:TemplateField>
                            </Columns>
                            <EditRowStyle BackColor="#2461BF" />
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Center" />
                            <RowStyle BackColor="#EFF3FB" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        </asp:GridView>
                    </div>
                    <br />
                    <div id="div_Remark" runat="server">
                        //选导师结束时间为学生选导师结束时间，再这之后的15天为导师选学生时间。<br />
                        //请谨慎使用删除操作，如果当前正处于选导师日程之内，删除相应的日程将会<br />
                        &nbsp; 导致该日程内学生所选导师的相关信息一并删除。
                    </div>
                </ContentTemplate>
            </cc1:TabPanel>
            <cc1:TabPanel ID="TabPanel2" runat="server" HeaderText="设置日程">
                <ContentTemplate>
                    <table width="600">
                        <tr>
                            <td width="120" height="31" align="left" valign="middle">
                                年级
                            </td>
                            <td width="180" align="left" valign="middle">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlGrade" runat="server" AutoPostBack="True" DataSourceID="ObjectDataSource1"
                                            DataTextField="Grade" DataValueField="Grade" OnSelectedIndexChanged="ddlGrade_SelectedIndexChanged"
                                            Width="120px">
                                            <asp:ListItem>--请选择年级--</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetGrade"
                                            TypeName="Department.Engineering.StudentManage"></asp:ObjectDataSource>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td width="120" align="left" valign="middle">
                                教学点
                            </td>
                            <td width="180" align="left" valign="middle">
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlSchool" runat="server" DataSourceID="ObjectDataSource2"
                                            DataTextField="TeaSchoolName" DataValueField="TeaSchoolID" Width="120px">
                                            <asp:ListItem>--请选择教学点--</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="GetTeaSchool"
                                            TypeName="Department.Engineering.TeachingSchool">
                                            <SelectParameters>
                                                <asp:ControlParameter ControlID="ddlGrade" Name="selValue" PropertyName="SelectedValue"
                                                    Type="String" />
                                            </SelectParameters>
                                        </asp:ObjectDataSource>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="ddlGrade" EventName="SelectedIndexChanged" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td height="31" align="left" valign="middle">
                                选导师开始时间
                            </td>
                            <td align="left" valign="middle">
                                <asp:TextBox ID="tbStartTime" runat="server" Width="115px"></asp:TextBox><asp:ImageButton
                                    ID="imgStartTime" runat="server" ImageUrl="~/Engineering/Resources/images/calendar.JPG" /><cc1:CalendarExtender
                                        ID="CalendarExtender1" runat="server" Format="yyyy-MM-dd" TargetControlID="tbStartTime"
                                        Enabled="True" PopupButtonID="imgStartTime">
                                    </cc1:CalendarExtender>
                            </td>
                            <td align="left" valign="middle">
                                选导师结束时间
                            </td>
                            <td align="left" valign="middle">
                                <asp:TextBox ID="tbEndTime" runat="server" Width="115px"></asp:TextBox><asp:ImageButton
                                    ID="imgEndTime" runat="server" ImageUrl="~/Engineering/Resources/images/calendar.JPG" /><cc1:CalendarExtender
                                        ID="CalendarExtender2" runat="server" Format="yyyy-MM-dd" TargetControlID="tbEndTime"
                                        Enabled="True" PopupButtonID="imgEndTime">
                                    </cc1:CalendarExtender>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <div>
                        <asp:Button ID="tbSubmit" runat="server" Height="31px" OnClick="tbSubmit_Click" Text="提交"
                            Width="90px" BackColor="#3333FF" ForeColor="White" /></div>
                    <br />
                    <div>
                        <asp:Label ID="lblResult" runat="server" ForeColor="Red"></asp:Label></div>
                    <div>
                    </div>
                </ContentTemplate>
            </cc1:TabPanel>
        </cc1:TabContainer>
    </div>
    </form>
</body>
</html>
