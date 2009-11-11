<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ExamArrageManagement.aspx.cs" Inherits="Engineering_AdminBakMag_ExamArrageManagement" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>设置考试安排--工程硕士中心</title>
    <link rel="Stylesheet" type="text/css" href="../Resources/Css/CustomAJAXTabStyle.css" />
    <script type ="text/javascript" language = "javascript">
    function OpenOvertimeDlog(ID,width,height) 
   {       
     var me; 
     // 把父页面窗口对象当作参数传递到对话框中，以便对话框操纵父页自动刷新。 
     me = "EditExamArrangementDetails.aspx?id="+ID+""; 
     // 显示对话框。
     window.showModalDialog(me,null,'dialogWidth='+width +'px;dialogHeight='+height+'px;help:no;status:no') ;
     window.location.href=window.location.href;   
    window.location.reload;   
   } 
  </script>
</head>
<body>
    <form id="form1" runat="server">
    <div   style=" font-size:25px"> 
        设置考试安排
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    </div>
    <hr />
    <br />
    <div>
        <table width="670">
            <tr>
                <td width="60" height="31" align="left" valign="middle">
                    <span style="font-size: 15px">年级：</span>
                </td>
                <td width="120" align="left" valign="middle">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="ddlGrade" runat="server" DataSourceID="ObjectDataSource1" DataTextField="Grade"
                                DataValueField="Grade" OnSelectedIndexChanged="ddlGrade_SelectedIndexChanged"
                                Width="120px" AutoPostBack="True">
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
                    <asp:DropDownList ID="ddlTerms" runat="server" DataSourceID="ObjectDataSource3" DataTextField="Key"
                        DataValueField="Value" Width="120px">
                    </asp:DropDownList>
                    <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" SelectMethod="GetTerms"
                        TypeName="Department.Engineering.TermsManage"></asp:ObjectDataSource>
                </td>
                <td width="118" align="center" valign="middle">
                    <asp:Button ID="btQuery" runat="server" Height="31px" OnClick="btQuery_Click" Text="确定"
                        Width="90px" BackColor="#3333FF" ForeColor="White"></asp:Button>
                </td>
            </tr>
        </table>
        <br />
        <div>
            <asp:GridView ID="gvViewArrange" runat="server" AutoGenerateColumns="False" 
                CellPadding="4" DataKeyNames="CourseID"
                OnRowDataBound="gvViewArrange_RowDataBound" Width="700px" 
                ForeColor="#333333" GridLines="None" AllowPaging="True" PageSize="25" 
                onpageindexchanging="gvViewArrange_PageIndexChanging">
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <RowStyle BackColor="#EFF3FB" />
                <Columns>
                    <asp:TemplateField HeaderText="学期">
                        <ItemTemplate>
                            <asp:Label ID="lblTerm" runat="server" Text='<%#GetCourseTime(Eval("CourseTime").ToString())%>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                        <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" 
                            HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="CourseName" HeaderText="课程名称">
                        <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                        <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Grade" HeaderText="年级" >
                        <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                        <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" 
                            HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="TeaSchoolName" HeaderText="教学点" >
                        <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                        <ItemStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" 
                            HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="考试时间">
                        <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                        <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="考试地点">
                        <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                        <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="监考老师">
                        <HeaderStyle BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                        <ItemStyle HorizontalAlign="Center" BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="操作">
                        <ItemTemplate>
                            <asp:LinkButton ID="lblArrange" runat="server">设置</asp:LinkButton>
                        </ItemTemplate>
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
        </div>
    </div>
    </form>
</body>
</html>
