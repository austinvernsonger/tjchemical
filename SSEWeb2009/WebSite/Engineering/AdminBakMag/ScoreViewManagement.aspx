<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ScoreViewManagement.aspx.cs" Inherits="Engineering_AdminBakMag_ScoreViewManagement" %>

<%@ Register src="../Control/sitmap.ascx" tagname="sitmap" tagprefix="uc1" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>学生成绩管理--工程硕士中心</title>
    <link rel="Stylesheet" type="text/css" href="../Resources/Css/CustomAJAXTabStyle.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div  style=" font-size:25px">
        学生成绩管理
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    </div>
    <hr />
    <br />
    <div>
        <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Width="100%"
            CssClass="AjaxTabStrip">
            <cc1:TabPanel runat="server" HeaderText="查询学科成绩" ID="TabPanel1">
                <ContentTemplate>
                    <div>
                        <table width="670">
                            <tr>
                                <td width="60" height="31" align="left" valign="middle">
                                    <span style="font-size: 15px">年级：</span>
                                </td>
                                <td width="120" align="left" valign="middle">
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
                                <td width="80" align="left" valign="middle">
                                    <span style="font-size: 15px">教学点：</span>
                                </td>
                                <td width="120" align="left" valign="middle">
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
                                <td width="52" align="left" valign="middle">
                                    <span style="font-size: 15px">学期：</span>
                                </td>
                                <td width="120" align="left" valign="middle">
                                    <asp:DropDownList ID="ddlTerm" runat="server" DataSourceID="ObjectDataSource3" DataTextField="Key"
                                        DataValueField="Value" Width="120px">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" 
                                        SelectMethod="GetTermsWithStartYear" 
                                        TypeName="Department.Engineering.TermsManage"></asp:ObjectDataSource>
                                </td>
                                <td width="118" align="center" valign="middle">
                                    <asp:Button ID="btQuery" runat="server" Height="31px" Text="查询" Width="90px" OnClick="btQuery_Click"
                                        BackColor="#3333FF" ForeColor="White" />
                                </td>
                            </tr>
                        </table>
                    </div>
                    <br />
                    <div>
                        <asp:GridView ID="gvCourseScore" runat="server" AutoGenerateColumns="False" CellPadding="4"
                            Width="700px" DataKeyNames="CourseID" OnRowDataBound="gvCourseScore_RowDataBound"
                            AllowPaging="True" ForeColor="#333333" GridLines="None" PageSize="25">
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:TemplateField HeaderText="开课学期">
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%#GetCourseTime(Eval("CourseTime").ToString())%>'></asp:Label></ItemTemplate>
                                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                    <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="CourseName" HeaderText="课程名称">
                                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                    <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Grade" HeaderText="年级">
                                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="TeaSchoolName" HeaderText="教学点">
                                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="任课教师">
                                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                    <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="StudentNumber" HeaderText="选课人数">
                                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                    <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="操作">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="hlOperate" runat="server" Text="查看成绩" NavigateUrl='<%#"~/Engineering/AdminBakMag/CourseScoreDetails.aspx?id="+Eval("CourseID") %>'></asp:HyperLink></ItemTemplate>
                                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="状态">
                                    <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                    <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" />
                                </asp:TemplateField>
                            </Columns>
                            <EditRowStyle BackColor="#2461BF" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Center" />
                            <RowStyle BackColor="#EFF3FB" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        </asp:GridView>
                    </div>
                </ContentTemplate>
            </cc1:TabPanel>
            <cc1:TabPanel ID="TabPanel2" runat="server" HeaderText="查询学生成绩">
                <ContentTemplate>
                    <div>
                        学号：<asp:TextBox ID="tbStuID" runat="server" ValidationGroup="query"></asp:TextBox>&#160;&nbsp;<asp:Button
                            ID="btStuIDQuery" runat="server" Height="31px" Text="查询" Width="90px" OnClick="btStuIDQuery_Click"
                            ValidationGroup="query" BackColor="#3333FF" ForeColor="White" /><asp:RequiredFieldValidator
                                ID="RequiredFieldValidator1" runat="server" ErrorMessage="请输入学号" ControlToValidate="tbStuID"
                                Font-Names="Verdana" Font-Size="10pt" ValidationGroup="query"></asp:RequiredFieldValidator></div>
                    <br />
                    <div>
                        <asp:Label ID="lblRes" runat="server" ForeColor="Red" Visible="False">该生暂时没有成绩！</asp:Label><asp:Panel
                            ID="Panel1" runat="server" Visible="False">
                            <asp:Label ID="lblName" runat="server"></asp:Label><asp:Label ID="lblGrade" runat="server"></asp:Label><asp:GridView
                                ID="gvStuScore" runat="server" Width="700px" AutoGenerateColumns="False" CellPadding="4"
                                OnRowDataBound="gvStuScore_RowDataBound" ForeColor="#333333" GridLines="None"
                                DataKeyNames="CourseID">
                                <FooterStyle BackColor="#507CD1" ForeColor="White" BorderStyle="None" HorizontalAlign="Center"
                                    Font-Bold="True" />
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:BoundField DataField="CourseName" HeaderText="开课名称">
                                        <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                        <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="考试时间">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCourseTime" runat="server" Text='<%#Eval("ExamTime") %>' ForeColor="Red"></asp:Label></ItemTemplate>
                                        <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                        <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="课程类别">
                                        <ItemTemplate>
                                            <asp:Label ID="lblProperty" runat="server" Text='<%#sProperty[Convert.ToInt32(Eval("Property"))] %>'></asp:Label></ItemTemplate>
                                        <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                        <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="课程性质">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCategory" runat="server" Text='<%#sCategory[Convert.ToInt32(Eval("Category"))] %>'></asp:Label></ItemTemplate>
                                        <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                        <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Credit" HeaderText="学分">
                                        <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                        <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="成绩">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRes" runat="server" Text='<%#Eval("CourResult")%>'></asp:Label><asp:TextBox
                                                ID="tbRes" runat="server" Width="100px" Visible="false" Text='<%#Eval("CourResult")%>'></asp:TextBox></ItemTemplate>
                                        <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                                        <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center"
                                            Width="110px" />
                                    </asp:TemplateField>
                                </Columns>
                                <EditRowStyle BackColor="#2461BF" />
                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#EFF3FB" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            </asp:GridView>
                            <br />
                            <div>
                                <asp:Button ID="btPrint" runat="server" Text="打印成绩" Width="90px" Height="31px" OnClick="btPrint_Click" />&#160;&nbsp;<asp:Button
                                    ID="btModify" runat="server" Height="31px" Text="修改成绩" OnClick="btModify_Click" />&#160;&nbsp;<asp:Button
                                        ID="btSave" runat="server" Text="保存成绩" Height="31px" OnClick="btSave_Click" /></div>
                        </asp:Panel>
                    </div>
                </ContentTemplate>
            </cc1:TabPanel>
        </cc1:TabContainer>
    </div>
    </form>
</body>
</html>
