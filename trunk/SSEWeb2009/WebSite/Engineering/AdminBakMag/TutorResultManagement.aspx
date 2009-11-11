<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TutorResultManagement.aspx.cs" Inherits="Engineering_AdminBakMag_TutorResultManage" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register src="../Control/sitmap.ascx" tagname="sitmap" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>管理导师分配信息--工程硕士中心</title>
    <link rel="Stylesheet" type="text/css" href="../Resources/Css/CustomAJAXTabStyle.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div  style=" font-size:25px">
        管理导师分配信息
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    </div>
    <hr />
    <br />
    <div>
        <cc1:TabContainer ID="TabContainer1" runat="server" Width="100%" ActiveTabIndex="0"
            CssClass="AjaxTabStrip">
            <cc1:TabPanel runat="server" HeaderText="处理选择结果" ID="TabPanel1">
                <ContentTemplate>
                    <div>
                        <asp:Label ID="lblDisposeRes" runat="server" ForeColor="#999999"></asp:Label></div>
                    <div>
                        <asp:GridView ID="gvChoosingResult" runat="server" AutoGenerateColumns="False" Width="700px"
                            CellPadding="4" AllowPaging="True" PageSize="20" ForeColor="#333333" 
                            GridLines="None">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:BoundField DataField="Grade" HeaderText="年级">
                                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="TeaSchoolName" HeaderText="教学点">
                                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="状态">
                                    <ItemTemplate>
                                        <asp:Label ID="lblStatus" runat="server" Text="导师双向选择已完成"></asp:Label></ItemTemplate>
                                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="完成时间">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTime" runat="server" Text='<%# Convert.ToDateTime(Eval("completeTime")).ToString("yyyy-MM-dd") %>'></asp:Label></ItemTemplate>
                                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="操作">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "~/Engineering/AdminBakMag/TutorChooseingDetails.aspx?grade="+Eval("Grade")+"&&schoolid="+Eval("TeaSchoolID") %>'
                                            ForeColor="Red">处理选择结果</asp:HyperLink></ItemTemplate>
                                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" />
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
                </ContentTemplate>
            </cc1:TabPanel>
            <cc1:TabPanel ID="TabPanel2" runat="server" HeaderText="最终分配结果">
                <ContentTemplate>
                    <table width="600">
                        <tr>
                            <td align="left" height="31" valign="middle" width="80">
                                年级
                            </td>
                            <td align="left" valign="middle" width="140">
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
                            <td align="left" valign="middle" width="80">
                                教学点
                            </td>
                            <td align="left" valign="middle" width="140">
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
                                        <asp:AsyncPostBackTrigger ControlID="ddlGrade" EventName="SelectedIndexChanged">
                                        </asp:AsyncPostBackTrigger>
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                            <td align="left" valign="middle" width="160">
                                <asp:Button ID="btQuery" runat="server" Height="31px" OnClick="btQuery_Click" Text="查询"
                                    Width="90px" BackColor="#3333FF" ForeColor="White"></asp:Button>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <div>
                        <asp:Label ID="lblResutl" runat="server" ForeColor="Red" Visible="False"></asp:Label></div>
                    <div>
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="gvStuInfo" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                    Width="700px" AllowPaging="True" PageSize="15" OnRowEditing="gvStuInfo_RowEditing"
                                    DataKeyNames="StudentID" OnRowCancelingEdit="gvStuInfo_RowCancelingEdit" OnRowUpdating="gvStuInfo_RowUpdating"
                                    ForeColor="#333333" GridLines="None">
                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <RowStyle BackColor="#EFF3FB" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="姓名">
                                            <ItemTemplate>
                                                <asp:Label ID="lblName" runat="server" Text='<%#Eval("sName") %>'></asp:Label></ItemTemplate>
                                            <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                            <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="学号">
                                            <ItemTemplate>
                                                <asp:Label ID="lblStuNo" runat="server" Text='<%#Eval("StudentID") %>'></asp:Label></ItemTemplate>
                                            <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                            <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="性别">
                                            <ItemTemplate>
                                                <asp:Label ID="lblGender" runat="server" Text='<%#Convert.ToInt32(Eval("sGender"))==0?"男":"女"%>'></asp:Label></ItemTemplate>
                                            <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                            <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="年级">
                                            <ItemTemplate>
                                                <asp:Label ID="lblGrade" runat="server" Text='<%#Eval("Grade") %>'></asp:Label></ItemTemplate>
                                            <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                            <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="教学点">
                                            <ItemTemplate>
                                                <asp:Label ID="lblschool" runat="server" Text='<%#Eval("TeaSchoolName") %>'></asp:Label></ItemTemplate>
                                            <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                            <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="他的导师">
                                            <EditItemTemplate>
                                                <asp:DropDownList ID="ddlTutor" runat="server" Width="80px" DataSourceID="ObjectDataSource3"
                                                    DataTextField="UserName" DataValueField="UserID">
                                                </asp:DropDownList>
                                                <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" SelectMethod="GetAllTutorInfo"
                                                    TypeName="Department.Engineering.TeacherManage"></asp:ObjectDataSource>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblTutor" runat="server" Text='<%#Eval("tName") %>'></asp:Label></ItemTemplate>
                                            <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                            <ItemStyle HorizontalAlign="Center" Width="90px" BorderColor="#666666" BorderStyle="Solid"
                                                BorderWidth="1px" />
                                        </asp:TemplateField>
                                        <asp:CommandField EditText="更换导师" ShowEditButton="True" UpdateText="保存">
                                            <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                            <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                        </asp:CommandField>
                                    </Columns>
                                    <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Center" />
                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <EditRowStyle BackColor="#2461BF" />
                                    <AlternatingRowStyle BackColor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </ContentTemplate>
            </cc1:TabPanel>
        </cc1:TabContainer>
    </div>
    </form>
</body>
</html>
