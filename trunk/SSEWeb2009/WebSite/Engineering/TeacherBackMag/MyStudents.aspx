<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MyStudents.aspx.cs" Inherits="Engineering_TeacherBackMag_MyStudents" %>

<%@ Register src="../Control/sitmap.ascx" tagname="sitmap" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div  style="font-size: 25px">           
            我的学生
        </div>
        <hr />
        <br />
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <table width="600" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td width="120" height="31" align="left" valign="middle">
                        按年级查询：
                    </td>
                    <td width="170" align="left" valign="middle">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlGrade" runat="server" Width="120px" 
                                    AutoPostBack="True" DataSourceID="ObjectDataSource1" DataTextField="Grade" 
                                    DataValueField="Grade" 
                                    onselectedindexchanged="ddlGrade_SelectedIndexChanged">
                                    <asp:ListItem>--请选择年级--</asp:ListItem>
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetGrade" TypeName="Department.Engineering.StudentManage">
                                </asp:ObjectDataSource>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td width="120" height="31" align="left" valign="middle">
                        按教学点查询：
                    </td>
                    <td width="190" align="left" valign="middle">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlSchool" runat="server" Width="120px" 
                                    DataSourceID="ObjectDataSource2" DataTextField="TeaSchoolName" 
                                    DataValueField="TeaSchoolID">
                                    <asp:ListItem>--请选择教学点--</asp:ListItem>
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" 
                                    SelectMethod="GetTeaSchool" TypeName="Department.Engineering.TeachingSchool">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="ddlGrade" Name="selValue" 
                                            PropertyName="SelectedValue" Type="String" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="ddlGrade" 
                                    EventName="SelectedIndexChanged" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td height="31" align="left" valign="middle">
                        按姓名查询：
                    </td>
                    <td align="left" valign="middle">
                        <asp:TextBox ID="tbName" runat="server" Width="115px"></asp:TextBox>
                    </td>
                    <td align="left" valign="middle">
                        <asp:Button ID="btQuery" runat="server" Text="查询" Height="31px" Width="90px" 
                            onclick="btQuery_Click" BackColor="#3333FF" ForeColor="White" />
                    </td>
                    <td align="left" valign="middle">  
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div>
            <asp:GridView ID="gvMyStudents" runat="server" AutoGenerateColumns="False" 
                onrowdatabound="gvMyStudents_RowDataBound" DataKeyNames="StudentID" 
                BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" 
                CellPadding="4" Width="700px" AllowPaging="True" 
                onrowcommand="gvMyStudents_RowCommand">
                <Columns>
                    <asp:BoundField DataField="StudentID" HeaderText="学号" >
                        <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                        <ItemStyle HorizontalAlign="Center" BorderColor="#999999" BorderStyle="Solid" 
                            BorderWidth="1px" />
                    </asp:BoundField>
                    <asp:HyperLinkField DataTextField="Name" HeaderText="姓名" >
                        <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                        <ItemStyle HorizontalAlign="Center" BorderColor="#999999" BorderStyle="Solid" 
                            BorderWidth="1px" />
                    </asp:HyperLinkField>
                    <asp:TemplateField HeaderText="性别">
                        <ItemTemplate>
                            <asp:Label ID="lblGender" runat="server" Text='<%# Convert.ToBoolean(Eval("Gender"))?"女":"男"%>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                        <ItemStyle HorizontalAlign="Center" BorderColor="#999999" BorderStyle="Solid" 
                            BorderWidth="1px" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="Grade" HeaderText="年级" >
                        <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                        <ItemStyle HorizontalAlign="Center" BorderColor="#999999" BorderStyle="Solid" 
                            BorderWidth="1px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="TeaSchoolName" HeaderText="教学点" >
                        <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                        <ItemStyle HorizontalAlign="Center" BorderColor="#999999" BorderStyle="Solid" 
                            BorderWidth="1px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Degree" HeaderText="学位类别" >
                        <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                        <ItemStyle HorizontalAlign="Center" BorderColor="#999999" BorderStyle="Solid" 
                            BorderWidth="1px" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="开题报告">
                        <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                        <ItemStyle HorizontalAlign="Center" BorderColor="#999999" BorderStyle="Solid" 
                            BorderWidth="1px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="校导信息">
                        <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                        <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" 
                            HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="中期考核表">
                        <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                        <ItemStyle HorizontalAlign="Center" BorderColor="#999999" BorderStyle="Solid" 
                            BorderWidth="1px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="论文初稿">
                        <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                        <ItemStyle HorizontalAlign="Center" BorderColor="#999999" BorderStyle="Solid" 
                            BorderWidth="1px" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
    </form>
</body>
</html>
